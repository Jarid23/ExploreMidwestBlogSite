using ExploreMidwest.Data;
using ExploreMidwest.Data.BlogRepositories;
using ExploreMidwest.Model;
using ExploreMidwest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreMidwest.Web.Controllers
{
    [Authorize(Roles ="Manager")]
    public class ManagerController : Controller
    {
        IBlogRepo repo = BlogRepoFactory.Create();
        ExploreMidwestDBContext context = new ExploreMidwestDBContext();
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddBlog()
        {
            return View(new Blog());
        }

        [HttpPost]
        public ActionResult AddBlog(Blog blog)
        {
            if (ModelState.IsValid)
            {
                repo.AddBlog(blog);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(blog);
            }
        }

        public ActionResult SavedBlogs()
        {
            var model = new List<Blog>();

            model = repo.GetSavedFromAuthor(User.Identity.Name);

            return View(model);
        }

        public ActionResult EditBlog(int id)
        {
            var model = new BlogVM();
            model.Blog = repo.GetBlogById(id);

            model.SetCategories(context.Category.ToList());

            return View(model);
        }

        [HttpPost]
        public ActionResult EditBlog(BlogVM model)
        {
            return View(model);
        }

        public ActionResult DeleteBlog(int id)
        {
            repo.DeleteBlog(id);

            return RedirectToAction("SavedBlogs");
        }
    }
}