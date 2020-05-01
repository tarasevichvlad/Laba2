using System;
using Xamarin.Forms;

namespace App3.Contracts
{
	public class BrowserPage : ContentPage
	{
		private readonly WebView _webView;
		private readonly Entry _urlEntry;

		public BrowserPage(Uri url)
		{
			_urlEntry = new Entry
			{
				Text = url.OriginalString,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			var button = new Button { Text = "Go" };
			button.Clicked += button_Clicked;

			var stack = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				Children = { button, _urlEntry}
			};

			_webView = new WebView
			{
				Source = new UrlWebViewSource { Url = url.OriginalString },
				// или так
				// Source = "http://blog.xamarin.com/",
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			var cancel = new Button { Text = "Cancel" };
			cancel.Clicked += (sender, args) =>
			{
				Navigation.PopModalAsync();
			};

			Content = new StackLayout { Children = { stack, _webView, cancel }};
		}

		void button_Clicked(object sender, EventArgs e)
		{
			_webView.Source = new UrlWebViewSource
			{
				Url=_urlEntry.Text
			};
			// или так
			// webView.Source = urlEntry.Text;
		}
	}
}