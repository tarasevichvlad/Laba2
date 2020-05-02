using System.Linq;
using App3.Contracts;
using Xamarin.Forms;

namespace App3
{
	public partial class MainPage : ContentPage
	{
		public MainPage(NewsService newsService)
		{
			Title = "News";
			var listView = CreateListView(newsService);

			var refresh = new Button { Text = "Refresh" };
			refresh.Clicked += (sender, args) =>
			{
				var updateListView = CreateListView(newsService);
				var updateLayout = new StackLayout
				{
					Children = { updateListView, refresh }
				};

				Update(updateLayout);
			}; 

			var layout = new StackLayout
			{
				Children = { listView, refresh }
			};

			void Update(View layoutUpdate)
			{
				Content = layoutUpdate;
			}

			Update(layout);

			Appearing += (sender, args) =>
			{
				base.OnAppearing();

				var updateListView = CreateListView(newsService);
				var updateLayout = new StackLayout
				{
					Children = { updateListView, refresh }
				};

				Update(updateLayout);
			};
		}

		private View CreateListView(NewsService newsService)
		{
			var news = newsService.GetNews(("q", " "));

			if (news.Status == "ok" && news.Articles.Any())
			{
				var listView = new ListView
				{
					SeparatorVisibility = SeparatorVisibility.Default,
					SeparatorColor = Color.Black,
					HasUnevenRows = true,
					ItemsSource = news.Articles,
					ItemTemplate = new DataTemplate(() =>
					{
						var imageUrl = new UriImageSource();
						imageUrl.SetBinding(UriImageSource.UriProperty, "UrlToImage");

						var title = new Label
						{
							FontSize = 23,
							FontAttributes = FontAttributes.Bold
						};
						title.SetBinding(Label.TextProperty, "Title");

						var description = new Label();
						description.SetBinding(Label.TextProperty, "Description");

						var date = new Label();
						date.HorizontalTextAlignment = TextAlignment.End;
						date.SetBinding(Label.TextProperty, "PublishedAt");

						var image = new Image
						{
							Source = imageUrl
						};

						//var rrr = new 
						return new ViewCell
						{
							View = new StackLayout
							{
								Children = {title, image, description, date}
							}
						};
					})
				};

				listView.ItemSelected += (sender, args) =>
				{
					var url = ((sender as ListView)?.SelectedItem as News).Url;
					Navigation.PushModalAsync(new BrowserPage(url));
				};

				return listView;
			}

			return new Label
			{
				Text = "No content",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
		}
	}
}