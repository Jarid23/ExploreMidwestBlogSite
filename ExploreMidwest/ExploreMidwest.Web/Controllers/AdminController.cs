using ExploreMidwest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreMidwest.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Blogs()
        {
            var model = BlogRepository.GetAll();
            return View(model.ToList());
        }

        [HttpPost]
        public ActionResult AddBlog(Blog blog)
        {
            if (ModelState.IsValid)
            {
                BlogRepository.Add(blog.BlogId);
                return RedirectToAction("Blog");
            }
            else
            {
                return View(new Blog());
            }
        }
    }
}