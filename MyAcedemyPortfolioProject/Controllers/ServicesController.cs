using MyAcedemyPortfolioProject.Models.Entity;
using MyAcedemyPortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAcedemyPortfolioProject.Controllers
{
    public class ServicesController : Controller
    {
        // GET: About
        GenericRepository<TblServices> repo = new GenericRepository<TblServices>();
        public ActionResult Index()
        {
            var degerler = repo.list();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult ServicesAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ServicesAdd(TblServices p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult ServicesRemove(int id)
        {
            var degerler = repo.Find(x => x.ServicesID == id);
            repo.Delete(degerler);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ServicesGet(int id)
        {
            var degerler = repo.Find(x => x.ServicesID == id);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult ServicesGet(TblServices p)
        {
            var services = repo.Find(x => x.ServicesID == p.ServicesID);
            services.Icon = p.Icon;
            services.Title = p.Title;
            services.Description = p.Description;
            repo.TUpdate(services);
            return RedirectToAction("Index");
        }
    }
}