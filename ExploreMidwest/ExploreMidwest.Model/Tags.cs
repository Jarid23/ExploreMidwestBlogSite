using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreMidwest.Model
{
    public class Tags
    {
        public int TagsId { get; set; }
        public string TagName { get; set; }
        public virtual ICollection<Blog> Blog { get; set;}

        public Tags()
        {
            Blog = new HashSet<Blog>();
        }
    }
}
