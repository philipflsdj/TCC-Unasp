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
    public class TiposDeNegociacaoController : Controller
    {
        private SoftHomeDesenvEntities db = new SoftHomeDesenvEntities();

        // GET: TiposDeNegociacao
        public ActionResult Index()
        {
            return View(db.TipoNegociacao.ToList());
        }

        // GET: TiposDeNegociacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoNegociacao tipoNegociacao = db.TipoNegociacao.Find(id);
            if (tipoNegociacao == null)
            {
                return HttpNotFound();
            }
            return View(tipoNegociacao);
        }

        // GET: TiposDeNegociacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposDeNegociacao/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoNegociacao,Descricao")] TipoNegociacao tipoNegociacao)
        {
            if (ModelState.IsValid)
            {
                db.TipoNegociacao.Add(tipoNegociacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoNegociacao);
        }

        // GET: TiposDeNegociacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoNegociacao tipoNegociacao = db.TipoNegociacao.Find(id);
            if (tipoNegociacao == null)
            {
                return HttpNotFound();
            }
            return View(tipoNegociacao);
        }

        // POST: TiposDeNegociacao/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoNegociacao,Descricao")] TipoNegociacao tipoNegociacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoNegociacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoNegociacao);
        }

        // GET: TiposDeNegociacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoNegociacao tipoNegociacao = db.TipoNegociacao.Find(id);
            if (tipoNegociacao == null)
            {
                return HttpNotFound();
            }
            return View(tipoNegociacao);
        }

        // POST: TiposDeNegociacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoNegociacao tipoNegociacao = db.TipoNegociacao.Find(id);
            db.TipoNegociacao.Remove(tipoNegociacao);
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
