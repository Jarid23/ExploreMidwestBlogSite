using ExploreMidwest.Data;
using ExploreMidwest.Data.BlogRepositories;
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
    [Authorize(Roles ="Manager, admin")]
    public class ManagerController : Controller
    {
        IBlogRepo repo = BlogRepoFactory.Create();
        ExploreMidwestDBContext context = new ExploreMidwestDBContext();
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View(new ChangePasswordVM());
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordVM password)
        {
            if (password.newPassword == password.newPasswordConfirm)
            {
                var userMgr = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));

                userMgr.ChangePassword(User.Identity.GetUserId(), password.oldPassword, password.newPassword);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("newPassword", "Passwords must be the same");
            }
            return View(password);
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult AddBlog()
        {
            BlogVM model = new BlogVM()
            {
                Category = new Category(),
                Tags = new List<Tags>(),
                Author = User.Identity.Name,
                Date = DateTime.Today
            };

            var context = new ExploreMidwestDBContext();

            model.SetCategories(context.Category.ToList());

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddBlog(BlogVM b)
        {
            var repo = BlogRepoFactory.Create();
            var context = new ExploreMidwestDBContext();
            if (ModelState.IsValid)
            {
<<<<<<< HEAD

=======
                Blog blog = new Blog
                {
                    BlogId = b.BlogId,
                    Body = b.Body,
                    IsDeleted = b.IsDeleted,
                    IsFinished = b.IsFinished,
                    Tags = new List<Tags>(),
                    Title = b.Title,
                    Author = User.Identity.Name,
                    Date = DateTime.Today
                };
                if (b.Category.CategoryId == 0)
                {
                    Category c = new Category
                    {
                        CategoryType = b.NewCategory
                    };
                    context.Category.Add(c);
                    context.SaveChanges();
                    blog.Category = context.Category.FirstOrDefault(g => g.CategoryType == c.CategoryType);
                }
                else
                {
                    blog.Category = context.Category.FirstOrDefault(c => c.CategoryId == b.Category.CategoryId);
                }
                repo.AddBlog(blog);
>>>>>>> f32a70f18fe122f3bf8feb9724163fde9ee9081c
                return RedirectToAction("Index", "Home");
            }
            else
            {
                b.SetCategories(context.Category.ToList());
                return View(b);
            }
        }

        [ValidateInput(false)]
        public ActionResult SavedBlogs()
        {
            var model = new List<Blog>();

            model = repo.GetSavedFromAuthor(User.Identity.Name);

            return View(model);
        }

        [ValidateInput(false)]
        public ActionResult EditBlog(int id)
        {
            Blog b = repo.GetBlogById(id);

            var model = new BlogVM()
            {
                Author = b.Author,
                Body = b.Body,
                BlogId = b.BlogId,
                Category =  b.Category,
                Date = b.Date,
                IsDeleted = b.IsDeleted,
                IsFinished = b.IsFinished,
                Tags = b.Tags,
                Title = b.Title
            };

            model.SetCategories(context.Category.ToList());

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditBlog(BlogVM b)
        {
            if (ModelState.IsValid)
            {
                Blog blog = new Blog
                {
                    BlogId = b.BlogId,
                    Body = b.Body,
                    IsDeleted = b.IsDeleted,
                    IsFinished = b.IsFinished,
                    Tags = new List<Tags>(),
                    Title = b.Title,
                    Author = User.Identity.Name,
                    Date = DateTime.Today
                };
                if (b.Category.CategoryId == 0)
                {
                    Category c = new Category
                    {
                        CategoryType = b.NewCategory
                    };
                    context.Category.Add(c);
                    context.SaveChanges();
                    blog.Category = context.Category.FirstOrDefault(g => g.CategoryType == c.CategoryType);
                }
                else
                {
                    blog.Category = context.Category.FirstOrDefault(c => c.CategoryId == b.Category.CategoryId);
                }
                repo.EditBlog(blog);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                b.SetCategories(context.Category.ToList());
                return View(b);
            }
        }

        public ActionResult DeleteBlog(int id)
        {
            repo.DeleteBlog(id);

            return RedirectToAction("SavedBlogs");
        }
    }
}