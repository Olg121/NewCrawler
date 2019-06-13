using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace NewsCrawler
{
    class Entity
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Note))]
        public string Url { get; set; }
        [ForeignKey(typeof(Name))]
        public string FullName { get; set; }
    }
}
