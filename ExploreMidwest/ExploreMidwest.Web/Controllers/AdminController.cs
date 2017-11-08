using ExploreMidwest.Data;
using ExploreMidwest.Data.BlogRepositories;
using ExploreMidwest.Data.PageRepositories;
using ExploreMidwest.Model;
using ExploreMidwest.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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

        public ActionResult PublishBlog(int id)
        {
            var repo = BlogRepoFactory.Create();

            Blog blog = repo.GetBlogById(id);

            blog.IsFinished = true;

            repo.EditBlog(blog);

            return RedirectToAction("PendingPosts");
        }

        [HttpGet]
        public ActionResult SavedPages()
        {
            var repo = PageRepoFactory.Create();

            var model = repo.GetAllPages();

            return View(model);
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
                repo.EditPage(page);
                return RedirectToAction("SavedPages");
            }
            else
            {
                return View(page);
            }
        }

        [HttpGet]
        public ActionResult DeletePage(int id)
        {
            var repo = PageRepoFactory.Create();

            repo.RemovePage(id);

            return RedirectToAction("SavedPages");
        }

        public ActionResult ResetPassword()
        {
            var context = new ExploreMidwestDBContext();

            var userMgr = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));

            return RedirectToAction("Login", "Home");
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
            if (!string.IsNullOrEmpty(manager.Name))
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
            else
            {
                ModelState.AddModelError("Name", "Please Enter A Name");
            }
            return View(manager);
        }
    }
}




