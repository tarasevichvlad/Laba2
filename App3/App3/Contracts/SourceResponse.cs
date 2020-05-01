using System.Collections.Generic;

namespace App3.Contracts
{
	public class SourceResponse
	{
		public string Status { get; set; }
		public IEnumerable<Source> Sources { get; set; }
	}
}