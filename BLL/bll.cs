using HackerNews.Models;
using HackerNews.Util;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerNews.BLL
{
    public class bll
    {
        private HttpClient _client;
        private IConfiguration _configuration;

        /// <summary>
        /// This will be a Bussines logic or BLL (well....its a short and fast demo...its a freeware budie!)
        /// </summary>
        /// <param name="config"></param>
        /// <param name="client"></param>
         public bll(IConfiguration config,HttpClient client)
        {
            _client = client;
            _configuration = config;
        }

        /// <summary>
        /// Return the bussines logic, calling  the rest methods and transfer the details to story DTO layer. 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Story>> ReturnStorylist()
        {
			try
			{
                
                int NumberPage = Convert.ToInt32(_configuration["NumberPerPage"]);
                UtilRepository u = new UtilRepository(_configuration, new System.Net.Http.HttpClient());
                var bs = await u.GetBestStories();

                List<Story> lstStory = new List<Story>();
                for (int i = 0; i < NumberPage; i++)
                {
                    Story s = new Story();
                    var x = await u.GetDetails(bs[i]);

                    s.title = x.title;
                    s.url = x.url;
                    s.postedby = x.by;
                    s.time = DateTimeOffset.FromUnixTimeSeconds(x.time).DateTime;
                    s.score = x.score;
                    s.commentCount = x.descendants;

                    lstStory.Add(s);
                }

                return lstStory.OrderByDescending(o => o.score).ToList();
            }
			catch (Exception)
			{
				throw;
			}
        }

    }
}
