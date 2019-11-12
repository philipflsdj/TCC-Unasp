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
    public class TiposdePagamentoController : Controller
    {
        private SoftHomeDesenvEntities db = new SoftHomeDesenvEntities();

        // GET: TiposdePagamento
        public ActionResult Index()
        {
            return View(db.TipoPagamento.ToList());
        }

        // GET: TiposdePagamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPagamento tipoPagamento = db.TipoPagamento.Find(id);
            if (tipoPagamento == null)
            {
                return HttpNotFound();
            }
            return View(tipoPagamento);
        }

        // GET: TiposdePagamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposdePagamento/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoPagamento,Descricao")] TipoPagamento tipoPagamento)
        {
            if (ModelState.IsValid)
            {
                db.TipoPagamento.Add(tipoPagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPagamento);
        }

        // GET: TiposdePagamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPagamento tipoPagamento = db.TipoPagamento.Find(id);
            if (tipoPagamento == null)
            {
                return HttpNotFound();
            }
            return View(tipoPagamento);
        }

        // POST: TiposdePagamento/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoPagamento,Descricao")] TipoPagamento tipoPagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPagamento);
        }

        // GET: TiposdePagamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPagamento tipoPagamento = db.TipoPagamento.Find(id);
            if (tipoPagamento == null)
            {
                return HttpNotFound();
            }
            return View(tipoPagamento);
        }

        // POST: TiposdePagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPagamento tipoPagamento = db.TipoPagamento.Find(id);
            db.TipoPagamento.Remove(tipoPagamento);
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
