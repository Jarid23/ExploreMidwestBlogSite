using ExploreMidwest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreMidwest.Data.BlogRepositories
{
    public interface IBlogRepo
    {
        List<Blog> GetNumberOfBlogs(int number);
    }
}
