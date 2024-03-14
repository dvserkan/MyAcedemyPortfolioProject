using MyAcedemyPortfolioProject.Models.Entity;
using MyAcedemyPortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAcedemyPortfolioProject.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: About
        GenericRepository<TblProjects> repo = new GenericRepository<TblProjects>();
        public ActionResult Index()
        {
            var degerler = repo.list();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult ProjectsAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProjectsAdd(TblProjects p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult ProjectsRemove(int id)
        {
            var degerler = repo.Find(x => x.ProjectID == id);
            repo.Delete(degerler);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ProjectsGet(int id)
        {
            var degerler = repo.Find(x => x.ProjectID == id);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult ProjectsGet(TblProjects p)
        {
            var project = repo.Find(x => x.ProjectID == p.ProjectID);
            project.ImageUrl = p.ImageUrl;
            project.ProjectName = p.ProjectName;
            project.CategoryID = p.CategoryID;
            project.GithubUrl = p.GithubUrl;
            repo.TUpdate(project);
            return RedirectToAction("Index");
        }
    }
}