using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyAcedemyPortfolioProject.Models.Entity;
using MyAcedemyPortfolioProject.Repositories;
namespace MyAcedemyPortfolioProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        
        // GET: Default
        MyAcedemyPortfolioProjectEntities db = new MyAcedemyPortfolioProjectEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Features()
        {
            var degerler = db.TblFeatures.ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Experiences()
        {
            var degerler1 = db.TblExperiences.ToList();
            var sırala = (from TblExperiences x in degerler1 orderby x.StartYear descending select x).ToList();
            return PartialView(sırala);
        }
        public PartialViewResult Services()
        {
            var degerler2 = db.TblServices.ToList();
            return PartialView(degerler2);
        }
        public PartialViewResult Contacts()
        {
            var degerler3 = db.TblContacts.ToList();
            return PartialView(degerler3);
        }
        public PartialViewResult SocialMedias()
        {
            var degerler4 = db.TblSocialMedias.ToList();
            return PartialView(degerler4);
        }
        public PartialViewResult Teams()
        {
            var degerler5 = db.TblTeams.ToList();
            return PartialView(degerler5);
        }
        public PartialViewResult TestiMonials()
        {
            var degerler5 = db.TblTestimonials.Where(x => x.Status == true).ToList();
            return PartialView(degerler5);
        }
        public PartialViewResult Skills()
        {
            var degerler6 = db.TblSkills.ToList();
            return PartialView(degerler6);
        }
        public PartialViewResult Project()
        {
            var degerler7 = db.TblProjects.ToList();
            return PartialView(degerler7);
        }
        public PartialViewResult Category()
        {
            var degerler8 = db.TblCategories.ToList();
            return PartialView(degerler8);
        }
        [HttpGet]
        public PartialViewResult Message()
        {
            var degerler9 = db.TblMessages.ToList();
            return PartialView(degerler9);
        }
        [HttpPost]
        public PartialViewResult Message(TblMessages p) 
        {
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblMessages.Add(p);
            db.SaveChanges();
            return PartialView();
        }
    }
}