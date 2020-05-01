using App3.Contracts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace App3
{
	public partial class App : Application
	{
		public App()
		{
			var newsService = new NewsService(new NewsClient());
			var tabpage = new TabbedPage();
			tabpage.Children.Add(new CategoryPage(newsService));
			tabpage.Children.Add(new MainPage(newsService));

			MainPage = tabpage;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}