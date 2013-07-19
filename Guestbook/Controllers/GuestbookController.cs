using Guestbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guestbook.Controllers
{
    public class GuestbookController : Controller
    {
        private GuestbookContext _db = new GuestbookContext();

        public ActionResult Index()
        {
            var list = _db.Entries.OrderByDescending(x => x.Id).Take(20).ToList();
            ViewBag.Entries = list;

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GuestbookEntry entry)
        {
            entry.DateAdded = DateTime.Now;
            _db.Entries.Add(entry);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
