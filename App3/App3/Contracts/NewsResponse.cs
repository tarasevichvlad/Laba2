using System.Collections.Generic;

namespace App3.Contracts
{
	public class NewsResponse
	{
		public string Status { get; set; }
		public int TotalResult { get; set; }
		public IEnumerable<News> Articles { get; set; }
	}
}