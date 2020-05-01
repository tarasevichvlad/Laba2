using Xamarin.Forms;

namespace App3.Contracts
{
	public class CategoryPage : ContentPage
	{
		private readonly NewsService _newsService;

		public CategoryPage(NewsService newsService)
		{
			Title = "Categories";
			_newsService = newsService;

			var stack = new StackLayout
			{
				Children =
				{
					CreateCategory("business"),
					CreateCategory("entertainment"),
					CreateCategory("general"),
					CreateCategory("health"),
					CreateCategory("science"),
					CreateCategory("sports"),
					CreateCategory("technology")
				}
			};

			Content = stack;
		}

		private StackLayout CreateCategory(string nameCategory)
		{
			var label1 = new Label { Text = nameCategory };
			var swich = new Switch();

			swich.Toggled += (sender, args) => 
			{
				Update(sender as Switch, nameCategory);
			};

			return new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				Children = { swich, label1 }
			};

			void Update(Switch @switch, string name)
			{
				if (@switch.IsToggled)
				{
					var result = _newsService.AddCategories(name);

					if (!result)
					{
						@switch.IsToggled = false;
						DisplayAlert("Warning", "Doesnt select over 3 categories", "Ok");
					}
				}
				else
				{
					_newsService.RemoveCategories(name);
				}
			}
		}
	}
}