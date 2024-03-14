using MyAcedemyPortfolioProject.Models.Entity;
using MyAcedemyPortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAcedemyPortfolioProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        GenericRepository<TblAbouts> repo = new GenericRepository<TblAbouts>();
        public ActionResult Index()
        {
            var degerler = repo.list();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AboutAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AboutAdd(TblAbouts p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult AboutRemove(int id)
        {
            var degerler = repo.Find(x => x.AboutID == id);
            repo.Delete(degerler);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AboutGet(int id)
        {
            var degerler = repo.Find(x => x.AboutID == id);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult AboutGet(TblAbouts p)
        {
            var about = repo.Find(x => x.AboutID == p.AboutID);
            about.ImageURL = p.ImageURL;
            about.Title = p.Title;
            about.Description = p.Description;
            repo.TUpdate(about);
            return RedirectToAction("Index");
        }
    }
}