using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace NewsCrawler
{
    class Name
    {
        [PrimaryKey]
        public string FullName { get; set; }
    }
}
