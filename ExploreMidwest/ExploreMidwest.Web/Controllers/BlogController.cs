using ExploreMidwest.Data.BlogRepositories;
using ExploreMidwest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExploreMidwest.Web.Controllers
{
    public class BlogController : ApiController
    {
        IBlogRepo repo = BlogRepoFactory.Create();
        [Route("blogs/{number}/{set}")]
        public List<Blog> Get(int number, int set)
        {
            return repo.GetNumberOfBlogs(number, set);
        }

        [Route("blog/{id}")]
        public Blog GetById(int id)
        {
            return new Blog();
        }

        [Route("blog/{property}/{parameter}")]
        public List<Blog> GetByType(string property, string parameter)
        {
            var toReturn = new List<Blog>();

            switch (parameter)
            {
                case "category":
                    repo.GetBlogsByCategory(parameter);
                    break;
                case "tags":
                    repo.GetBlogsByTag(parameter);
                    break;
                case "date":
                    repo.GetBlogsByDate(parameter);
                    break;
                case "title":
                    repo.GetBlogsByTitle(parameter);
                    break;
            }

            return toReturn;
        }
    }
}
