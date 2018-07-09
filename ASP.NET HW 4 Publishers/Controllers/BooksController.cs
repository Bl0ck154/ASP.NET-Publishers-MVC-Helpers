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
    public class BooksController : Controller
    {
        private BookRepository db = BookRepository.Instance;
		
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
            Book book = db.FindById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
		
        public ActionResult Create()
        {
            return View();
        }
		
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PublishDate,PageCount,ISBN")] Book book, IEnumerable<string> Authors, int? Publisher)
        {
            if (ModelState.IsValid)
            {
				if(Authors != null)
					book.Authors = new List<Author>(Authors.Select(s => AuthorRepository.Instance.FindById(int.Parse(s))));

				book.Publisher = PublisherRepository.Instance.FindById(Publisher);
                db.Add(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }
		
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.FindById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,PublishDate,PageCount,ISBN")] Book book, IEnumerable<string> authors, IEnumerable<string> publisher)
		{
            if (ModelState.IsValid)
			{
				book.Publisher = publisher == null ? null : PublisherRepository.Instance.FindByName(publisher.First());
				book.Authors = authors == null ? null : new List<Author>(authors.Select(s => AuthorRepository.Instance.FindByName(s)));
				db.Edit(book.Id, book);
                return RedirectToAction("Index");
            }
            return View(book);
        }
		
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.FindById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
		
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.FindById(id);
            db.Remove(book);
            return RedirectToAction("Index");
        }
    }
}
