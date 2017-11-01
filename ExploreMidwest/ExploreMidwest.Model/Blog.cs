using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreMidwest.Model
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Category Category { get; set; }
        public List<Tags> Tags { get; set; }
        public string Body { get; set; }
        public bool IsFinished { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}
