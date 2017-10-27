using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExploreMidwest.Model;
using System.Data.Entity.Migrations;

namespace ExploreMidwest.Data.BlogRepositories
{
    public class EFBlogRepo : IBlogRepo
    {
        ExploreMidwestDBContext context = new ExploreMidwestDBContext();

        public List<Blog> GetNumberOfBlogs(int number, int set)

        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogsByCategory(string category)
        {
            return context.Blog.Where(c => c.Category.CategoryType == category).ToList();
        }


        public List<Blog> GetBlogsByDate(string date)
        {
            return context.Blog.Where(d => d.Date.ToShortDateString() == date).ToList();
        }

        public void DeleteBlog(int blogId)
        {
            Blog blog = context.Blog.Find(blogId);
            context.Blog.Remove(blog);
            context.SaveChanges();
           
        }

        public void EditBlog(Blog blog)
        {
           
            context.Blog.AddOrUpdate(blog);
            context.SaveChanges();

            //context.Entry(blog).State = System.Data.Entity.EntityState.Modified;
            //context.SaveChanges();
        }

        public void AddBlog(Blog blog)
        {
            context.Blog.Add(blog);
            context.SaveChanges();
        }


        public List<Blog> GetBlogsByTag(string tag)
        {
            //return context.Tags.Where(t => t.Tags.)
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogsByTitle(string title)
        {
            return context.Blog.Where(t => t.Title == title).ToList();
        }

    }
}
