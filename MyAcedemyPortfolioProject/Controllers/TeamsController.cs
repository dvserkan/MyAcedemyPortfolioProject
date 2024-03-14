using MyAcedemyPortfolioProject.Models.Entity;
using MyAcedemyPortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAcedemyPortfolioProject.Controllers
{
    public class TeamsController : Controller
    {
        // GET: Teams
        // GET: About
        GenericRepository<TblTeams> repo = new GenericRepository<TblTeams>();
        public ActionResult Index()
        {
            var degerler = repo.list();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult TeamsAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TeamsAdd(TblTeams p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult TeamsRemove(int id)
        {
            var degerler = repo.Find(x => x.TeamID == id);
            repo.Delete(degerler);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult TeamsGet(int id)
        {
            var degerler = repo.Find(x => x.TeamID == id);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult TeamsGet(TblTeams p)
        {
            var teams = repo.Find(x => x.TeamID == p.TeamID);
            teams.ImageUrl = p.ImageUrl;
            teams.NameSurname = p.NameSurname;
            teams.Title = p.Title;
            teams.Description = p.Description;
            teams.TwitterUrl = p.TwitterUrl;
            teams.FacebookUrl = p.FacebookUrl;
            teams.LinkedinUrl = p.LinkedinUrl;
            teams.InstagramUrl = p.InstagramUrl;
            repo.TUpdate(teams);
            return RedirectToAction("Index");
        }
    }
}