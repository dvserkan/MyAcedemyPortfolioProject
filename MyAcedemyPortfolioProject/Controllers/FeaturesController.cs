using MyAcedemyPortfolioProject.Models.Entity;
using MyAcedemyPortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAcedemyPortfolioProject.Controllers
{
    public class FeaturesController : Controller
    {
        GenericRepository<TblFeatures> repo = new GenericRepository<TblFeatures>();
        // GET: Features
        public ActionResult Index()
        {
           var degerler = repo.list();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult FeaturesAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FeaturesAdd(TblFeatures p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult FeaturesGet(int id)
        {
            var degerler = repo.Find(x => x.FeatureID == id);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult FeaturesGet(TblFeatures p)
        {
            var degerler = repo.Find(x => x.FeatureID == p.FeatureID);
            degerler.NameSurname = p.NameSurname;
            degerler.Title = p.Title;
            degerler.ImageUrl = p.ImageUrl;
            repo.TUpdate(degerler);
            return RedirectToAction("Index");
        }
        public ActionResult FeaturesRemove(int id)
        {
            var degerler3 = repo.Find(x => x.FeatureID == id);
            repo.Delete(degerler3);
            return RedirectToAction("Index");
        }
    }
}