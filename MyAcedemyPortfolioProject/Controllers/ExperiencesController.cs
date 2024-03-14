using MyAcedemyPortfolioProject.Models.Entity;
using MyAcedemyPortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAcedemyPortfolioProject.Controllers
{
    public class ExperiencesController : Controller
    {
        // GET: About
        GenericRepository<TblExperiences> repo = new GenericRepository<TblExperiences>();
        public ActionResult Index()
        {
            var degerler = repo.list();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult ExperiencesAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ExperiencesAdd(TblExperiences p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult ExperiencesRemove(int id)
        {
            var degerler = repo.Find(x => x.ExperienceID == id);
            repo.Delete(degerler);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ExperiencesGet(int id)
        {
            var degerler = repo.Find(x => x.ExperienceID == id);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult ExperiencesGet(TblExperiences p)
        {
            var experiences = repo.Find(x => x.ExperienceID == p.ExperienceID);
            experiences.StartYear = p.StartYear;
            experiences.EndYear = p.EndYear;
            experiences.Title = p.Title;
            experiences.Description = p.Description;
            experiences.CompanyName = p.CompanyName;
            experiences.Location = p.Location;
            repo.TUpdate(experiences);
            return RedirectToAction("Index");
        }
    }
}