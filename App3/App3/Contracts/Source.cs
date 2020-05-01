using System;

namespace App3.Contracts
{
	public class Source
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Uri Url { get; set; }
		public string Category { get; set; }
		public string Language { get; set; }
		public string Country { get; set; }
	}
}