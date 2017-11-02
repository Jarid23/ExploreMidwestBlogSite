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
            var toReturn = context.Blog.Include("Category").Include("Tags").OrderBy(b => b.BlogId).Skip(number * set).Take(number).ToList();
            return toReturn;
        }

        public List<Blog> GetBlogsByCategory(string category)
        {
            return context.Blog.Include("Category").Include("Tags").Where(c => c.Category.CategoryType == category).ToList();
        }


        public List<Blog> GetBlogsByDate(string date)
        {
            return context.Blog.Include("Category").Include("Tags").Where(d => d.Date.ToShortDateString() == date).ToList();
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
            blog.Category = context.Category.SingleOrDefault(c => c.CategoryId == blog.Category.CategoryId);
            context.Blog.Add(blog);
            context.SaveChanges();
        }


        public List<Blog> GetBlogsByTag(string tag)
        {
            //return context.Tags.Where(t => t.Tags.)
            return context.Blog.Include("Category").Include("Tags").Where(d => d.Tags.Where(t => t.TagName == tag).Count() >= 1).ToList();
        }

        public List<Blog> GetBlogsByTitle(string title)
        {
            return context.Blog.Include("Category").Include("Tags").Where(t => t.Title == title).ToList();
        }

        public Blog GetBlogById(int BlogId)
        {
            return context.Blog.Include("Category").Include("Tags").Where(d => d.BlogId == BlogId).FirstOrDefault();
        }

        public List<Blog> GetUnpublishedBlogs()
        {
            return context.Blog.Include("Category").Include("Tags").Where(d => d.IsFinished == false).ToList();
        }

        public List<Blog> GetSavedFromAuthor(string author)
        {
            return context.Blog.Include("Category").Include("Tags").Where(d => d.Author == author).Where(b => b.IsFinished == false).ToList();
        }
    }
}
