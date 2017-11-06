using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExploreMidwest.Model;
using System.Data.Entity.Migrations;
using System.Text.RegularExpressions;
using System.Data.Entity;

namespace ExploreMidwest.Data.BlogRepositories
{
    public class EFBlogRepo : IBlogRepo
    {
        ExploreMidwestDBContext context = new ExploreMidwestDBContext();

        public List<Blog> GetNumberOfBlogs(int number, int set)
        {
            var toReturn = context.Blog.Include("Category").OrderByDescending(b => b.Date).Where(b => b.IsFinished).Skip(number * set).Take(number).ToList();
            return toReturn;
        }

        public List<Blog> GetBlogsByCategory(string category)
        {
            return context.Blog.Include("Category").Where(c => c.Category.CategoryType == category).ToList();
        }


        public List<Blog> GetBlogsByDate(string date)
        {
            DateTime day = DateTime.Parse(date);
            return context.Blog.Include("Category").Where(d => DbFunctions.TruncateTime(d.Date) == day.Date).ToList();
        }

        public void DeleteBlog(int blogId)
        {
            Blog blog = context.Blog.Find(blogId);
            context.Blog.Remove(blog);
            context.SaveChanges();
           
        }

        public void EditBlog(Blog blog)
        {
            var regex = new Regex(@"(?<=#)\w+");
            var matches = regex.Matches(blog.Body);

            foreach (Match m in matches)
            {
                if (context.Tags.Where(t => t.TagName == m.Value).Count() == 0)
                {
                    context.Tags.Add(new Tags { TagName = m.Value });
                    context.SaveChanges();
                }
                blog.Tags.Add(context.Tags.SingleOrDefault(t => t.TagName == m.Value));



            }
            var change = context.Blog.FirstOrDefault(b => b.BlogId == blog.BlogId);
            context.Blog.AddOrUpdate(blog);
            change.Category = context.Category.FirstOrDefault(c => c.CategoryId == blog.Category.CategoryId);
            change.Tags = blog.Tags;
            context.SaveChanges();

            //context.Entry(blog).State = System.Data.Entity.EntityState.Modified;
            //context.SaveChanges();
        }

        public void AddBlog(Blog blog)
        {
            var regex = new Regex(@"(?<=#)\w+");
            var matches = regex.Matches(blog.Body);

            foreach (Match m in matches)
            {
                if (context.Tags.Where(t => t.TagName == m.Value).Count() == 0)
                { 
                    context.Tags.Add(new Tags { TagName=m.Value});
                    context.SaveChanges();
                }
                blog.Tags.Add(context.Tags.SingleOrDefault(t => t.TagName == m.Value));
            }
                blog.Category = context.Category.SingleOrDefault(c => c.CategoryId == blog.Category.CategoryId);
            context.Blog.Add(blog);
            context.SaveChanges();
        }


        public List<Blog> GetBlogsByTag(string tag)
        {
            //return context.Tags.Where(t => t.Tags.)
            return context.Blog.Include("Category").Where(d => d.Tags.Where(t => t.TagName == tag).Count() >= 1).ToList();
        }

        public List<Blog> GetBlogsByTitle(string title)
        {
            return context.Blog.Include("Category").Where(t => t.Title == title).ToList();
        }

        public Blog GetBlogById(int BlogId)
        {
            return context.Blog.Include("Category").Where(d => d.BlogId == BlogId).FirstOrDefault();
        }

        public List<Blog> GetUnpublishedBlogs()
        {
            return context.Blog.Include("Category").Where(d => d.IsFinished == false).ToList();
        }

        public List<Blog> GetSavedFromAuthor(string author)
        {
            return context.Blog.Include("Category").Where(d => d.Author == author).Where(b => b.IsFinished == false).ToList();
        }
    }
}
