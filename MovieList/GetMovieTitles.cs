using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MovieList
{
    public class SearchResults
    {
        public IEnumerable<SearchResult> Search { get; set; }
        public int totalResults { get; set; }
        public string Response { get; set; }
    }

    public class SearchResult
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }

    class GetMovieTitles
    {
        const string ApiKey = "529ca5c7";
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            const string searchString = "Harry Potter";
            RunAsync(searchString).GetAwaiter().GetResult();
        }

        static async Task<SearchResults> GetSearchResultsAsync(string searchTerm, int page = 1)
        {
            SearchResults results = null;
            HttpResponseMessage response = await client.GetAsync(
                string.Format(@"?apikey={0}&s={1}&page={2}", ApiKey, searchTerm, page));
            if (response.IsSuccessStatusCode)
            {
                results = await response.Content.ReadAsAsync<SearchResults>();
            }
            return results;
        }

        static async Task RunAsync(string searchString)
        {
            client.BaseAddress = new Uri("http://www.omdbapi.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var searchResults = new List<string>();

            try
            {
                var results = await GetSearchResultsAsync(searchString, 1);
                var totalResults = results.totalResults;

                searchResults.AddRange(results.Search.Select(x => x.Title));

                var totalPages = (totalResults / 10) + 1;
                for (int i = 2; i <= totalPages; i++)
                {
                    results = await GetSearchResultsAsync(searchString, i);
                    searchResults.AddRange(results.Search.Select(x => x.Title));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (var s in searchResults)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Result count: " + searchResults.Count);
            Console.ReadLine();
        }
    }
}