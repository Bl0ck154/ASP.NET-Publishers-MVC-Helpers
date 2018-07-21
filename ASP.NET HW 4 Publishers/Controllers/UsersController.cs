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
    public class UsersController : Controller
    {
        private UserRepository db = UserRepository.Instance;
		
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
            User user = db.FindById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
		
        public ActionResult Create()
        {
            return View();
        }
		
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Password,Name,RoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Add(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }
		
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.FindById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Password,Name,RoleId")] User user)
		{
            if (ModelState.IsValid)
			{
				db.Edit(user.Id, user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
		
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.FindById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
		
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.FindById(id);
            db.Remove(user);
            return RedirectToAction("Index");
        }
    }
}
