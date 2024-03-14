using MyAcedemyPortfolioProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyAcedemyPortfolioProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
       
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
      public ActionResult Index(TblLogin p)
        {
            MyAcedemyPortfolioProjectEntities db = new MyAcedemyPortfolioProjectEntities();
            var bilgi = db.TblLogin.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);

            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.Username, false);
                Session["Username"]= bilgi.Username.ToString();
                return RedirectToAction("Index" , "Features");
            }
            else
            {
                ModelState.AddModelError("","Hatalı Şifre Girişi Yaptınız");
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}