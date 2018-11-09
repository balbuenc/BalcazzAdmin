using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BalcazzAdmin.Models;

namespace BalcazzAdmin.Controllers
{
    public class ConceptosController : Controller
    {
        private BalcazzEntities db = new BalcazzEntities();

        // GET: Conceptos
        public ActionResult Index()
        {
            var conceptos = db.Conceptos.Include(c => c.Facturas);
            return View(conceptos.ToList());
        }

        // GET: Conceptos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conceptos conceptos = db.Conceptos.Find(id);
            if (conceptos == null)
            {
                return HttpNotFound();
            }
            return View(conceptos);
        }

        // GET: Conceptos/Create
        public ActionResult Create()
        {
            ViewBag.IdFactura = new SelectList(db.Facturas, "IdFactura", "Cliente");
            return View();
        }

        // POST: Conceptos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdConcepto,Concepto,Fecha,Monto,IdFactura")] Conceptos conceptos)
        {
            if (ModelState.IsValid)
            {
                db.Conceptos.Add(conceptos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFactura = new SelectList(db.Facturas, "IdFactura", "Cliente", conceptos.IdFactura);
            return View(conceptos);
        }

        // GET: Conceptos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conceptos conceptos = db.Conceptos.Find(id);
            if (conceptos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFactura = new SelectList(db.Facturas, "IdFactura", "Cliente", conceptos.IdFactura);
            return View(conceptos);
        }

        // POST: Conceptos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdConcepto,Concepto,Fecha,Monto,IdFactura")] Conceptos conceptos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conceptos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFactura = new SelectList(db.Facturas, "IdFactura", "Cliente", conceptos.IdFactura);
            return View(conceptos);
        }

        // GET: Conceptos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conceptos conceptos = db.Conceptos.Find(id);
            if (conceptos == null)
            {
                return HttpNotFound();
            }
            return View(conceptos);
        }

        // POST: Conceptos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Conceptos conceptos = db.Conceptos.Find(id);
            db.Conceptos.Remove(conceptos);
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
