using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews.Models
{
    /// <summary>
    /// the DTO( Data transfer Objetct) for the details model
    /// </summary>
    public class Details
    {
        public string by { get; set; }
        public int descendants { get; set; }
        public string id { get; set; }
        public int score { get; set; }
        public long time { get; set; }
        public string title { get; set; }      
        public string type { get; set; }
        public string url { get; set; }



    }
}
