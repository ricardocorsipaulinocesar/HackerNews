using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews.Models
{
    /// <summary>
    /// the DTO (data transfer object) for the main Story model
    /// </summary>
    public class Story
    {        
        public string title { get; set; }
        public string url { get; set; }
        public string postedby { get; set; }
        public DateTime time { get; set; }
        public int score { get; set; }        
        public int commentCount { get; set; }
    }
}
