using MyAcedemyPortfolioProject.Models.Entity;
using MyAcedemyPortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAcedemyPortfolioProject.Controllers
{
    public class TestimonialsController : Controller
    {
        // GET: Testimonials
        GenericRepository<TblTestimonials> repo = new GenericRepository<TblTestimonials>();
        public ActionResult Index()
        {
            var degerler = repo.list();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult TestimonialsGet(int id)
        {
            var degerler2 = repo.Find(x => x.TestimonialID == id);
            return View(degerler2);
        }
        [HttpPost]
        public ActionResult TestimonialsGet(TblTestimonials p)
        {
            var testi = repo.Find(x => x.TestimonialID == p.TestimonialID);
            testi.ImageUrl = p.ImageUrl;
            testi.Comment = p.Comment;
            testi.NameSurname = p.NameSurname;
            testi.Title = p.Title;
            testi.Status = p.Status;
            testi.CommentDate = p.CommentDate;
            repo.TUpdate(testi);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult TestimonialsAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TestimonialsAdd(TblTestimonials p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult TestimonialsRemove(int id)
        {
            var degerler = repo.Find(x => x.TestimonialID == id);
            repo.Delete(degerler);
            return RedirectToAction("Index");
        }
    }
}