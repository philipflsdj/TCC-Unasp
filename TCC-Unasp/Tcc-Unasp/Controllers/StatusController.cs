using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tcc_Unasp.Models;

namespace Tcc_Unasp.Controllers
{
    public class StatusController : Controller
    {
        private SoftHomeDesenvEntities db = new SoftHomeDesenvEntities();

        // GET: Status
        public ActionResult Index()
        {
            return View(db.tblStatus.ToList());
        }

        // GET: Status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStatus tblStatus = db.tblStatus.Find(id);
            if (tblStatus == null)
            {
                return HttpNotFound();
            }
            return View(tblStatus);
        }

        // GET: Status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdStatus,Tabela,Descricao")] tblStatus tblStatus)
        {
            if (ModelState.IsValid)
            {
                db.tblStatus.Add(tblStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblStatus);
        }

        // GET: Status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStatus tblStatus = db.tblStatus.Find(id);
            if (tblStatus == null)
            {
                return HttpNotFound();
            }
            return View(tblStatus);
        }

        // POST: Status/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdStatus,Tabela,Descricao")] tblStatus tblStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblStatus);
        }

        // GET: Status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStatus tblStatus = db.tblStatus.Find(id);
            if (tblStatus == null)
            {
                return HttpNotFound();
            }
            return View(tblStatus);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStatus tblStatus = db.tblStatus.Find(id);
            db.tblStatus.Remove(tblStatus);
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
