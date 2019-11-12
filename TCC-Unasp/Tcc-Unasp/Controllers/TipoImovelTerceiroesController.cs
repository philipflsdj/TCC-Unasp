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
    public class TipoImovelTerceiroesController : Controller
    {
        private SoftHomeDesenvEntities db = new SoftHomeDesenvEntities();

        // GET: TipoImovelTerceiroes
        public ActionResult Index()
        {
            return View(db.TipoImovelTerceiro.ToList());
        }

        // GET: TipoImovelTerceiroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoImovelTerceiro tipoImovelTerceiro = db.TipoImovelTerceiro.Find(id);
            if (tipoImovelTerceiro == null)
            {
                return HttpNotFound();
            }
            return View(tipoImovelTerceiro);
        }

        // GET: TipoImovelTerceiroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoImovelTerceiroes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoImovel,Descricao")] TipoImovelTerceiro tipoImovelTerceiro)
        {
            if (ModelState.IsValid)
            {
                db.TipoImovelTerceiro.Add(tipoImovelTerceiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoImovelTerceiro);
        }

        // GET: TipoImovelTerceiroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoImovelTerceiro tipoImovelTerceiro = db.TipoImovelTerceiro.Find(id);
            if (tipoImovelTerceiro == null)
            {
                return HttpNotFound();
            }
            return View(tipoImovelTerceiro);
        }

        // POST: TipoImovelTerceiroes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoImovel,Descricao")] TipoImovelTerceiro tipoImovelTerceiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoImovelTerceiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoImovelTerceiro);
        }

        // GET: TipoImovelTerceiroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoImovelTerceiro tipoImovelTerceiro = db.TipoImovelTerceiro.Find(id);
            if (tipoImovelTerceiro == null)
            {
                return HttpNotFound();
            }
            return View(tipoImovelTerceiro);
        }

        // POST: TipoImovelTerceiroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoImovelTerceiro tipoImovelTerceiro = db.TipoImovelTerceiro.Find(id);
            db.TipoImovelTerceiro.Remove(tipoImovelTerceiro);
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
