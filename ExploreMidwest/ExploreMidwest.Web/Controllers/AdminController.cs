using ExploreMidwest.Data;
using ExploreMidwest.Data.BlogRepositories;
using ExploreMidwest.Data.PageRepositories;
using ExploreMidwest.Model;
using ExploreMidwest.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
        public ActionResult PendingPosts()
        {
            var repo = BlogRepoFactory.Create();

            var model = repo.GetUnpublishedBlogs();

            return View(model);
        }

        [HttpGet]
        public ActionResult SavedPages()
        {
            var repo = PageRepoFactory.Create();

            var model = repo.GetUnfinshedPages();

            return View(model);
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult AddBlog()
        {
            BlogVM model = new BlogVM();

            var context = new ExploreMidwestDBContext();

            model.SetCategories(context.Category.ToList());

            return View(model);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddBlog(Blog blog)
        {
            var repo = BlogRepoFactory.Create();
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
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult EditBlog(int id)
        {
            var repo = BlogRepoFactory.Create();
            var blog = repo.GetBlogById(id);
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
        [ValidateInput(false)]
        public ActionResult AddPage()
        {
            return View(new Page());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPage(Page page)
        {
            var repo = PageRepoFactory.Create();
            if (ModelState.IsValid)
            {
                if (page.IsInNavigation)
                {
                    page.IsFinished = true;
                }
                repo.AddPage(page);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(page);
            }
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult EditPage(int id)
        {
            var repo = PageRepoFactory.Create();
            var page = repo.GetPage(id);

            return View(page);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditPage(Page page)
        {
            var repo = PageRepoFactory.Create();
            if (ModelState.IsValid)
            {
                if (page.IsInNavigation)
                {
                    page.IsFinished = true;
                }
                repo.AddPage(page);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(page);
            }
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


        [HttpGet]
        public ActionResult DeleteManager()
        {
            return View(new DeleteManager());
        }

        [HttpPost]
        public ActionResult DeleteManager(DeleteManager manager)
        {
            if (ModelState.IsValid)
            {
                ExploreMidwest.Data.ExploreMidwestDBContext context = new Data.ExploreMidwestDBContext();

                var userMgr = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
                var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

               
                var findmanager = userMgr.FindByName(manager.Name);
                // create the user with the manager class
                if (findmanager != null)
                {
                    userMgr.Delete(findmanager);
                }
                else
                {
                    return View(manager);
                }
                return RedirectToAction("Index", "Home");

                
            }
            return View(manager);
        }
    }
}


