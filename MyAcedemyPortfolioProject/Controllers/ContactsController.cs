using MyAcedemyPortfolioProject.Models.Entity;
using MyAcedemyPortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAcedemyPortfolioProject.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        GenericRepository<TblContacts> repo = new GenericRepository<TblContacts>();
        public ActionResult Index()
        {
            var degerler = repo.list();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult ContactsAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactsAdd(TblContacts p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult ContactsRemove(int id)
        {
            var degerler = repo.Find(x => x.ContactID == id);
            repo.Delete(degerler);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ContactsGet(int id)
        {
            var degerler = repo.Find(x => x.ContactID == id);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult ContactsGet(TblContacts p)
        {
            var contact = repo.Find(x => x.ContactID == p.ContactID);
            contact.NameSurname = p.NameSurname;
            contact.Adress = p.Adress;
            contact.Phone = p.Phone;
            contact.Email = p.Email;
            repo.TUpdate(contact);
            return RedirectToAction("Index");
        }
    }
}