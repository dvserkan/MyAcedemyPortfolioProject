using MyAcedemyPortfolioProject.Models.Entity;
using MyAcedemyPortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAcedemyPortfolioProject.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
        GenericRepository <TblSkills> repo = new GenericRepository<TblSkills> ();

        public ActionResult Index()
        {
            var degerler = repo.list();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SkillsAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SkillsAdd(TblSkills p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SkillsRemove(int id)
        {
            var degerler = repo.Find(x => x.SkillID == id);
            repo.Delete(degerler);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SkillsGet(int id)
        {
            var degerler = repo.Find(x => x.SkillID == id);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult SkillsGet(TblSkills p)
        {
            var skill = repo.Find(x => x.SkillID == p.SkillID);
            skill.SkillName = p.SkillName;
            skill.Value = p.Value;
            repo.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}