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
    public class RolesController : Controller
    {
        private RoleRepository db = RoleRepository.Instance;
		
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
            Role role = db.FindById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }
		
        public ActionResult Create()
        {
            return View();
        }
		
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Role role)
        {
            if (ModelState.IsValid)
            {
                db.Add(role);
                return RedirectToAction("Index");
            }

            return View(role);
        }
		
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.FindById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }
		
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Role role)
        {
            if (ModelState.IsValid)
            {
				db.Edit(role.Id, role);
                return RedirectToAction("Index");
            }
            return View(role);
        }
		
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.FindById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }
		
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
		{
			foreach (User user in UserRepository.Instance.ToList())
			{
				if (user.RoleId == id)
					user.RoleId = null;
			}
			Role role = db.FindById(id);
            db.Remove(role);
            return RedirectToAction("Index");
        }
    }
}
