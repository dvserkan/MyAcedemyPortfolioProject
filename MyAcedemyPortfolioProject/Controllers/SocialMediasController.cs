using MyAcedemyPortfolioProject.Models.Entity;
using MyAcedemyPortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAcedemyPortfolioProject.Controllers
{
    public class SocialMediasController : Controller
    {
        // GET: About
        GenericRepository<TblSocialMedias> repo = new GenericRepository<TblSocialMedias>();
        public ActionResult Index()
        {
            var degerler = repo.list();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SocialsAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SocialsAdd(TblSocialMedias p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SocialsRemove(int id)
        {
            var degerler = repo.Find(x => x.SocialMediaID == id);
            repo.Delete(degerler);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SocialsGet(int id)
        {
            var degerler = repo.Find(x => x.SocialMediaID == id);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult SocialsGet(TblSocialMedias p)
        {
            var social = repo.Find(x => x.SocialMediaID == p.SocialMediaID);
            social.SocialMediaName = p.SocialMediaName;
            social.Url = p.Url;
            social.Icon = p.Icon;
            repo.TUpdate(social);
            return RedirectToAction("Index");
        }
    }
}