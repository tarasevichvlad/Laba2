using System;

namespace App3.Contracts
{
	public class News
	{
		public Source Source { get; set; }
		public string Author { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public Uri Url { get; set; }
		public Uri UrlToImage { get; set; }
		public DateTime PublishedAt { get; set; }
		public string Content { get; set; }
	}
}