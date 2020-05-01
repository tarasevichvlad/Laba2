using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace App3.Contracts
{
	public class NewsClient
	{
		private readonly RestClient _httpClient;
		private const string ApiKey = "4c562121416f415e86be374b49c632c4";
		private IList<Uri> _sources = new List<Uri>();
		private IList<string> _categories = new List<string>();

		public NewsClient()
		{
			_httpClient = new RestClient();
		}

		public NewsResponse GetNews(params (string, string)[] parameters)
		{
			var request = CreateRequest("everything");

			foreach (var (apiKey, value) in parameters)
			{
				request.AddQueryParameter(apiKey, value);
			}

			return _httpClient.Get<NewsResponse>(request).Data;
		}

		public SourceResponse GetSources(string category)
		{
			var request = CreateRequest("sources");
			request.AddQueryParameter("category", category);

			return _httpClient.Get<SourceResponse>(request).Data;
		}

		public void AddSources(string category)
		{
			var sourcesResponse = GetSources(category);

			foreach (var sourcesResponseSource in sourcesResponse.Sources)
			{
				_sources.Add(sourcesResponseSource.Url);
			}
		}

		public void RemoveSources(string category)
		{
			var sourcesResponse = GetSources(category);

			foreach (var sourcesResponseSource in sourcesResponse.Sources)
			{
				var index = _sources.IndexOf(sourcesResponseSource.Url);
				if (index >= 0)
				{
					_sources.RemoveAt(index);
				}
			}
		}

		public bool AddCategories(string category)
		{
			if (_categories.Count >= 3) return false;

			_categories.Add(category);

			return true;
		}

		public void RemoveCategories(string category)
		{
			_categories.Remove(category);
		}

		private RestRequest CreateRequest(string partUrl)
		{
			_httpClient.BaseUrl = new Uri($"http://newsapi.org/v2/{partUrl}");

			var request= new RestRequest();

			request.AddQueryParameter("apiKey", ApiKey);

			if (_sources.Any())
			{
				request.AddQueryParameter("domains", string.Join(",", _sources.Select(x => x.Host.Replace("www.", "")).ToList()));
			}

			return request;
		}
	}
}