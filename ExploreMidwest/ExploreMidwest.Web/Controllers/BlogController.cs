﻿using ExploreMidwest.Data;
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
            List<Blog> toReturn = repo.GetNumberOfBlogs(number, set);
            foreach (var item in toReturn)
                foreach (var tag in item.Tags)
                    tag.Blog = null;
            return toReturn;
        }

        [Route("blog/{id}")]
        public Blog GetById(int id)
        {
            var toReturn = repo.GetBlogById(id);
            foreach (var tag in toReturn.Tags)
            {
                tag.Blog = null;
                tag.TagName = "#" + tag.TagName;
            }
            return toReturn;
        }

        [Route("blog/{property}/{parameter}")]
        public List<Blog> GetByType(string property, string parameter)
        {
            var toReturn = new List<Blog>();

            switch (property)
            {
                case "category":
                    toReturn = repo.GetBlogsByCategory(parameter);
                    break;
                case "tags":
                    toReturn = repo.GetBlogsByTag(parameter);
                    break;
                case "date":
                    toReturn = repo.GetBlogsByDate(parameter);
                    break;
                case "title":
                    toReturn = repo.GetBlogsByTitle(parameter);
                    break;
            }

            foreach (var item in toReturn)
                foreach (var tag in item.Tags)
                    tag.Blog = null;

            return toReturn;
        }
    }
}
