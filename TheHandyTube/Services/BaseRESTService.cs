using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TheHandyTube.Services
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseRESTService
    {

        protected BaseRESTService()
        {

        }

        protected HttpClient GetConfiguredHttpClient()
        {
            var client = new HttpClient();

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
