using ExploreMidwest.Data.BlogRepositories;
using ExploreMidwest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreMidwest.Web.Controllers
{
    public class ManagerController : Controller
    {
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
            var repo = BlogRepoFactory.Create();
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
    }
}