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
    public class AuthorsController : Controller
    {
        private AuthorRepository db = AuthorRepository.Instance;
		
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
            Author author = db.FindById(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }
		
        public ActionResult Create()
        {
            return View();
        }
		
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DateOfBirth,DateOfDeath")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Add(author);
                return RedirectToAction("Index");
            }

            return View(author);
        }
		
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.FindById(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }
		
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DateOfBirth,DateOfDeath")] Author author)
        {
            if (ModelState.IsValid)
            {
				db.Edit(author.Id, author);
                return RedirectToAction("Index");
            }
            return View(author);
        }
		
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.FindById(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }
		
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			foreach (Book book in BookRepository.Instance.ToList())
			{
				book.Authors = book.Authors.Where(a => a.Id != id);
			}
            Author author = db.FindById(id);
            db.Remove(author);
            return RedirectToAction("Index");
        }
    }
}
