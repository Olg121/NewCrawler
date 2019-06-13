using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace NewsCrawler
{
    public class Note
    {
        public string Title { get; set; }
        public string Article { get; set; }
        [PrimaryKey]
        public string Url { get; set; }
        public string Html { get; set; }
    }
}
