using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TheHandyTube.Models;

namespace TheHandyTube.Services
{
    public class YouTubeSearchServie : BaseRESTService, ISearchService<VideoItems>
    {
        public List<YouTubeSearchResult> youTubeSearchResults;

        private const String API_KEY = "AIzaSyBaSxZW-0oqjAOHXaVCPEh3Nk1ATuYb72M";

        private const String API_ENDPOINT_GET_SEARCH_LIVE_VIDEOS = @"https://www.googleapis.com/youtube/v3/search?";

        public YouTubeSearchServie()
        {
            youTubeSearchResults = new List<YouTubeSearchResult>()
            {

            };
        }
        
        public async Task<IEnumerable<VideoItems>> GetSearchResultAsync(string searchString, bool forceRefresh)

        {
            List<VideoItems> results = null;

            using (var client = GetConfiguredHttpClient())
            {
                HttpResponseMessage response = null; //Declaring an http response message

                try
                {
                    String searchAPI = API_ENDPOINT_GET_SEARCH_LIVE_VIDEOS+ "part=snippet" + "&key=" + API_KEY + "&q=" + searchString + "&type=video&eventType=live&maxResults=50";
                        
                    response = await client.GetAsync(searchAPI);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception", e.StackTrace);
                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    JArray jReferences = (JArray)JObject.Parse(content)["items"];

                    results = jReferences.ToObject<List<VideoItems>>();

                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception();
                }
                else if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception();
                }
                else
                {
                    throw new Exception();
                }
            }

            return results;
        }
    }
}
