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
    public class TipodeImoveisController : Controller
    {
        private SoftHomeDesenvEntities db = new SoftHomeDesenvEntities();

        // GET: TipodeImoveis
        public ActionResult Index()
        {
            return View(db.TipoImovel.ToList());
        }

        // GET: TipodeImoveis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoImovel tipoImovel = db.TipoImovel.Find(id);
            if (tipoImovel == null)
            {
                return HttpNotFound();
            }
            return View(tipoImovel);
        }

        // GET: TipodeImoveis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipodeImoveis/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoImovel,Descricao")] TipoImovel tipoImovel)
        {
            if (ModelState.IsValid)
            {
                db.TipoImovel.Add(tipoImovel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoImovel);
        }

        // GET: TipodeImoveis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoImovel tipoImovel = db.TipoImovel.Find(id);
            if (tipoImovel == null)
            {
                return HttpNotFound();
            }
            return View(tipoImovel);
        }

        // POST: TipodeImoveis/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoImovel,Descricao")] TipoImovel tipoImovel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoImovel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoImovel);
        }

        // GET: TipodeImoveis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoImovel tipoImovel = db.TipoImovel.Find(id);
            if (tipoImovel == null)
            {
                return HttpNotFound();
            }
            return View(tipoImovel);
        }

        // POST: TipodeImoveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoImovel tipoImovel = db.TipoImovel.Find(id);
            db.TipoImovel.Remove(tipoImovel);
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
