using ExploreMidwest.Web.Models;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreMidwest.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginViewModel();

            return View(model);
        }
    }
}


    //[HttpPost]
    //[AllowAnonymous]
    //[ValidateAntiForgeryToken]
    //public ActionResult Login(LoginViewModel model, string returnUrl)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return View(model);
    //    }

    //    var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
    //    var authManager = HttpContext.GetOwinContext().Authentication;

    //    // attempt to load the user with this password
    //    AppUser user = userManager.Find(model.UserName, model.Password);

    //    // user will be null if the password or user name is bad
    //    if (user == null)
    //    {
    //        ModelState.AddModelError("", "Invalid username or password");

    //        return View(model);
    //    }
    //    else
    //    {
    //        // successful login, set up their cookies and send them on their way
    //        var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
    //        authManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);

    //        if (!string.IsNullOrEmpty(returnUrl))
    //            return Redirect(returnUrl);
    //        else
    //            return RedirectToAction("Index");
    //    }
    //}

