using ExploreMidwest.Data.BlogRepositories;
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
      //  IBlogRepo repo = 
        [Route("blogs/{number}")]
        public IEnumerable<string> Get(int number)
        {
            throw new NotImplementedException();
        }

        [Route("blog/{id}")]
        public string GetById(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
