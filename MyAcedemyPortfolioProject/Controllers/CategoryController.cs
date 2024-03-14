using MyAcedemyPortfolioProject.Models.Entity;
using MyAcedemyPortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAcedemyPortfolioProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin
        GenericRepository<TblCategories> repo = new GenericRepository<TblCategories>();
        public ActionResult Index()
        {
            var degerler = repo.list();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(TblCategories p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult CategoryRemove(int id)
        {
            var degerler = repo.Find(x => x.CategoryID == id);
            repo.Delete(degerler);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CategoryGet(int id)
        {
            var degerler = repo.Find(x => x.CategoryID == id);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult CategoryGet(TblCategories p)
        {
            var category = repo.Find(x => x.CategoryID == p.CategoryID);
            category.CategoryName = p.CategoryName;
            repo.TUpdate(category);
            return RedirectToAction("Index");
        }
    }
}