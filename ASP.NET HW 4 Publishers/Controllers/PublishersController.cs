using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NET_HW_4_Publishers.Models;

namespace ASP.NET_HW_4_Publishers.Controllers
{
    public class PublishersController : Controller
    {
        private PublisherRepository db = PublisherRepository.Instance;
		
        public ActionResult Index()
        {
            return View(db.ToList());
        }
		
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = db.FindById(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }
		
        public ActionResult Create()
        {
            return View();
        }
		
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Add(publisher);
                return RedirectToAction("Index");
            }

            return View(publisher);
        }
		
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = db.FindById(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }
		
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
				db.Edit(publisher.Id, publisher);
                return RedirectToAction("Index");
            }
            return View(publisher);
        }
		
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = db.FindById(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }
		
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
		{
			foreach (Book book in BookRepository.Instance.ToList())
			{
				if (book.Publisher.Id == id)
					book.Publisher = null;
			}
			Publisher publisher = db.FindById(id);
            db.Remove(publisher);
            return RedirectToAction("Index");
        }
    }
}
