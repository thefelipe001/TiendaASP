using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Librery.Models;

namespace Librery.Controllers
{
    public class editorialesController : Controller
    {
        private ApplicationDB db = new ApplicationDB();

        // GET: editoriales
        public ActionResult Index()
        {
            return View(db.editoriales.ToList());
        }

        // GET: editoriales/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            editoriales editoriales = db.editoriales.Find(id);
            if (editoriales == null)
            {
                return HttpNotFound();
            }
            return View(editoriales);
        }

        // GET: editoriales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: editoriales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nombre")] editoriales editoriales)
        {
            if (ModelState.IsValid)
            {
                db.editoriales.Add(editoriales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(editoriales);
        }

        // GET: editoriales/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            editoriales editoriales = db.editoriales.Find(id);
            if (editoriales == null)
            {
                return HttpNotFound();
            }
            return View(editoriales);
        }

        // POST: editoriales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nombre")] editoriales editoriales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editoriales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editoriales);
        }

        // GET: editoriales/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            editoriales editoriales = db.editoriales.Find(id);
            if (editoriales == null)
            {
                return HttpNotFound();
            }
            return View(editoriales);
        }

        // POST: editoriales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            editoriales editoriales = db.editoriales.Find(id);
            db.editoriales.Remove(editoriales);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
