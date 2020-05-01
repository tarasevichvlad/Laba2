using System.Collections.Generic;

namespace App3.Contracts
{
	public class NewsService
	{
		private readonly NewsClient _newsClient;

		public NewsService(NewsClient newsClient)
		{
			_newsClient = newsClient;
		}

		public NewsResponse GetNews(params (string, string)[] parameters)
		{
			return _newsClient.GetNews(parameters);
		}

		//public SourceResponse GetSources()
		//{
		//	return _newsClient.GetSources();
		//}

		public bool AddCategories(string category)
		{
			var result = _newsClient.AddCategories(category);

			if (result)
			{
				_newsClient.AddSources(category);
			}

			return result;
		}

		public void RemoveCategories(string category)
		{
			_newsClient.RemoveCategories(category);
			_newsClient.RemoveSources(category);
		}
	}
}