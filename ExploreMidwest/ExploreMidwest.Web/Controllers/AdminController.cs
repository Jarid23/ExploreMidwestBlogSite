using ExploreMidwest.Data.BlogRepositories;
using ExploreMidwest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreMidwest.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddBlog()
        {
            return View(new Blog());
        }

        [HttpGet]
        public ActionResult EditBlog(int BlogId)
        {
            var repo = BlogRepoFactory.Create();
            var blog = repo.GetBlogById(BlogId);
            repo.EditBlog(blog);
            return View(blog);
        }

        [HttpGet]
        public ActionResult DeleteBlog()
        {
            var repo = BlogRepoFactory.Create();
            
            return View(new Blog());
        }

        [HttpPost]
        public ActionResult AddBlog(Blog blog)
        {
            var repo = BlogRepoFactory.Create();
            {
                if (ModelState.IsValid)
                {
                    repo.AddBlog(blog);
                    return RedirectToAction("Blog");
                }
                else
                {
                    return View(blog);
                }
            }
        }


        [HttpPost]
        public ActionResult EditBlog(Blog blog)
        {
            var repo = BlogRepoFactory.Create();

            if (ModelState.IsValid)
            {
                repo.EditBlog(blog);
                return RedirectToAction("Blog");
            }
            else
            {
                return View(blog);
            }
        }


        [HttpPost]
        public ActionResult DeleteBlog(Blog blog)
        {
            var repo = BlogRepoFactory.Create();

            if (ModelState.IsValid)
            {
                repo.DeleteBlog(blog.BlogId);
                return RedirectToAction("Blog");
            }
            else
            {
                return View(blog);
            }
        }

    }
}


