using MyAcedemyPortfolioProject.Models.Entity;
using MyAcedemyPortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAcedemyPortfolioProject.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: About
        GenericRepository<TblProjects> repo = new GenericRepository<TblProjects>();
        GenericRepository<TblCategories> repom = new GenericRepository<TblCategories>();
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
            List<SelectListItem> valuescat = (from x in repom.list()
                                              select new SelectListItem
                                              {
                                                  Text = x.CategoryName,
                                                  Value = x.CategoryID.ToString()
                                              }
                                              ).ToList();
            ViewBag.ctl = valuescat;
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
        public PartialViewResult ProjectCategory()
        {
            List<SelectListItem> valuescats = (from x in repom.list()
                                              select new SelectListItem
                                              {
                                                  Text = x.CategoryName,
                                                  Value = x.CategoryID.ToString()
                                              }
                                              ).ToList();
            ViewBag.cml = valuescats;
            return PartialView();
        }
    }
}