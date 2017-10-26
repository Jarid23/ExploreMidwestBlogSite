using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExploreMidwest.Model;

namespace ExploreMidwest.Data.BlogRepositories
{
    public class MockBlogRepo : IBlogRepo
    {
        private static List<Blog> _blogs = new List<Blog>
        {
            new Blog
            {
                BlogId = 1,
                Title = "River Rafting",
                Body = "What a great time it is rafting down the rapids in Minnesota. Going so fast makes it hard to keep a smile off my face",
                Category = new Category
                {
                    CategoryId = 1,
                    CategoryType = "Minnesota"
                },
                Tags = new List<Tags>
                {
                    new Tags
                    {
                        TagsId = 1,
                        TagName = "#Funtime"
                    },
                    new Tags
                    {
                        TagsId = 2,
                        TagName = "#Rivers"
                    },
                    new Tags
                    {
                        TagsId = 3,
                        TagName = "#Rafting"
                    }
                },
                IsFinished = true,
                IsDeleted = false,
                Date = DateTime.Parse("10/21/2017"),
            },
            new Blog
            {
                BlogId = 2,
                Title = "Corn Maze",
                Body = "What a wonderful maze I found ",
                Category = new Category
                {
                    CategoryId = 2,
                    CategoryType = "Iowa"
                },
                Tags = new List<Tags>
                {
                    new Tags
                    {
                        TagsId = 4,
                        TagName = "#Coolplaces"
                    },
                    new Tags
                    {
                        TagsId = 5,
                        TagName = "#Outdoors"
                    },
                    new Tags
                    {
                        TagsId = 1,
                        TagName = "#Funtime"
                    }
                },
                IsFinished = true,
                IsDeleted = false,
                Date = DateTime.Parse("8/19/2017"),
            },
            new Blog
            {
                BlogId = 3,
                Title = "Football Game",
                Body = "I went out to a cornhuskers game last night and it was a great time. The place was so packed and so loud everytime they scored thinking about it makes we want to go back right now!",
                Category = new Category
                {
                    CategoryId = 3,
                    CategoryType = "Nebraska"
                },
                Tags = new List<Tags>
                {
                    new Tags
                    {
                        TagsId = 1,
                        TagName = "#Goteam"
                    },
                    new Tags
                    {
                        TagsId = 2,
                        TagName = "#Bigcity"
                    }
                },
                IsFinished = true,
                IsDeleted = false,
                Date = DateTime.Parse("10/15/2017"),
            },
            new Blog
            {
                BlogId = 4,
                Title = "City Life",
                Body = "Living in Minneapolis always has its challenges. It can be fun to ",
                Category = new Category
                {
                    CategoryId = 1,
                    CategoryType = "Minnesota"
                },
                Tags = new List<Tags>(),
                IsFinished = false,
                IsDeleted = false,
                Date = DateTime.Parse("10/26/2017"),
            }
        };

        public void AddBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void DeleteBlog(int blogId)
        {
            throw new NotImplementedException();
        }

        public void EditBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogsByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogsByDate(string date)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogsByTag(string tag)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogsByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetNumberOfBlogs(int number, int set)
        {
            throw new NotImplementedException();
        }
    }
}
