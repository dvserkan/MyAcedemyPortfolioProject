using MyAcedemyPortfolioProject.Models.Entity;
using MyAcedemyPortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAcedemyPortfolioProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TblLogin> repo = new GenericRepository<TblLogin>();
        public ActionResult Index()
        {
            var degerler = repo.list();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAdd(TblLogin p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult AdminRemove(int id)
        {
            var degerler = repo.Find(x => x.ID == id);
            repo.Delete(degerler);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminGet(int id)
        {
            var degerler = repo.Find(x => x.ID == id);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult AdminGet(TblLogin p)
        {
            var admin = repo.Find(x => x.ID == p.ID);
            admin.Username = p.Username;
            admin.Password = p.Password;
            repo.TUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}