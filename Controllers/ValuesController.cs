using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackerNews.BLL;
using HackerNews.Models;
using HackerNews.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

namespace HackerNews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IConfiguration configuration;
        public ValuesController(IConfiguration config)
        {
            configuration = config;
        }
        // GET api/values
        [HttpGet]
        public async Task<List<Story>> Index()
        {
            try
            {   //Calling the "Bussines" Layer            
                bll b = new bll(configuration, new System.Net.Http.HttpClient());
                return  await b.ReturnStorylist(); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
