using ExploreMidwest.Data.BlogRepositories;
using ExploreMidwest.Data.PageRepositories;
using ExploreMidwest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreMidwest.Web.Controllers
{
<<<<<<< HEAD
   // [Authorize(Roles = "admin")]
=======
    //[Authorize(Roles = "admin")]
>>>>>>> 3901d4a2bf4a788ac7277ecc185300075b8eb847
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

        [HttpGet]
        public ActionResult AddPage()
        {
            return View(new Page());
        }

        [HttpPost]
        public ActionResult AddPage(Page page)
        {
            var repo = PageRepoFactory.Create();
            if (ModelState.IsValid)
            {
                repo.AddPage(page);
                return RedirectToAction("Blog");
            }
            else
            {
                return View(page);
            }
        }

        [HttpGet]
        public ActionResult EditPage(int pageId)
        {
            var repo = PageRepoFactory.Create();
            var page = repo.GetPage(pageId);

            return View(page);
        }
    }
}


