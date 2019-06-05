using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace NewsCrawler
{
    class Note
    {
        [PrimaryKey]
        [AutoIncrement]
        int IdNote { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public string Url { get; set; }
        public string Html { get; set; }
    }
}
