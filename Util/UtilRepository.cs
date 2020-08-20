using HackerNews.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Threading;

namespace HackerNews.Util
{
    public class UtilRepository
    {
        private HttpClient _client;
        private IConfiguration configuration;

        /// <summary>
        /// This should be a Repository and stuff that will be consume by application, in this case the rest layer. (In a real world, this must be huge!)
        /// </summary>
        /// <param name="config"></param>
        /// <param name="cli"></param>
         public UtilRepository(IConfiguration config ,HttpClient cli)
        {
            configuration = config;
            _client = cli;
        }

        /// <summary>
        /// This method gets all data from a specific API for a later use.
        /// </summary>
        /// <returns></returns>
        public async Task<int[]> GetBestStories()
        {
            var response = await _client.GetAsync(configuration["RemoteApi"] + "/beststories.json");
            var content = await response.Content.ReadAsStringAsync();
            var bestStories = JsonConvert.DeserializeObject<int[]>(content);

            return bestStories;
        }

        /// <summary>
        /// This method is responsable to call a details from a single ID received.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Details> GetDetails(int id)
        {
            var Response = await _client.GetAsync(configuration["RemoteApi"] + $"/item/{id}.json");
            var content = await Response.Content.ReadAsStringAsync();
            var story = JsonConvert.DeserializeObject<Details>(content);

            return story;
        }


    }
}
