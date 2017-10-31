﻿using ExploreMidwest.Data.BlogRepositories;
using ExploreMidwest.Data.PageRepositories;
using ExploreMidwest.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreMidwest.Web.Controllers
{
   // [Authorize(Roles = "admin")]
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

        [HttpGet]
        public ActionResult AddManager()
        {
            return View(new Manager());
        }


        [HttpPost]
        public ActionResult AddManager(Manager manager)
        {
            if (ModelState.IsValid)
            {
                ExploreMidwest.Data.ExploreMidwestDBContext context = new Data.ExploreMidwestDBContext();

                var userMgr = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
                var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                if (!userMgr.Users.Any(u => u.UserName == manager.Name))
                {
                    var user = new IdentityUser()
                    {
                        UserName = manager.Name
                    };
                    userMgr.Create(user, manager.Password);
                }
                var findmanager = userMgr.FindByName(manager.Name);
                // create the user with the manager class
                if (!userMgr.IsInRole(findmanager.Id, "Manager"))
                {
                    userMgr.AddToRole(findmanager.Id, "Manager");
                }
                return RedirectToAction("Index", "Home");

            }
            return View(manager);
        }
    }
}


