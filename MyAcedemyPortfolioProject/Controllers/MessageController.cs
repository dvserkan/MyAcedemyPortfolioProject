using MyAcedemyPortfolioProject.Models.Entity;
using MyAcedemyPortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAcedemyPortfolioProject.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        GenericRepository<TblMessages> repo = new GenericRepository<TblMessages>();
        public ActionResult Index()
        {
            var degerler = repo.list();
            var sırala = (from TblMessages x in degerler orderby x.MessageID descending select x).ToList();
            return View(sırala);
        }
        [HttpGet]
        public ActionResult MessageGet()
        {
            return View();
        }
    }
}