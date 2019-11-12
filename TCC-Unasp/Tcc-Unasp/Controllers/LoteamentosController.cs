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
    public class LoteamentosController : Controller
    {
        private SoftHomeDesenvEntities db = new SoftHomeDesenvEntities();

        // GET: Loteamentos
        public ActionResult Index()
        {
            var loteamento = db.Loteamento.Include(l => l.Imovel).Include(l => l.tblStatus);
            return View(loteamento.ToList());
        }

        // GET: Loteamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loteamento loteamento = db.Loteamento.Find(id);
            if (loteamento == null)
            {
                return HttpNotFound();
            }
            return View(loteamento);
        }

        // GET: Loteamentos/Create
        public ActionResult Create()
        {
            ViewBag.IdImovel = new SelectList(db.Imovel, "IdImovel", "StatusImovel");
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela");
            return View();
        }

        // POST: Loteamentos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLoteamento,IdImovel,NomeLoteamento,nMatricula,nProceRegu,nIncra,IdStatus")] Loteamento loteamento)
        {
            if (ModelState.IsValid)
            {
                db.Loteamento.Add(loteamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdImovel = new SelectList(db.Imovel, "IdImovel", "StatusImovel", loteamento.IdImovel);
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela", loteamento.IdStatus);
            return View(loteamento);
        }

        // GET: Loteamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loteamento loteamento = db.Loteamento.Find(id);
            if (loteamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdImovel = new SelectList(db.Imovel, "IdImovel", "StatusImovel", loteamento.IdImovel);
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela", loteamento.IdStatus);
            return View(loteamento);
        }

        // POST: Loteamentos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLoteamento,IdImovel,NomeLoteamento,nMatricula,nProceRegu,nIncra,IdStatus")] Loteamento loteamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loteamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdImovel = new SelectList(db.Imovel, "IdImovel", "StatusImovel", loteamento.IdImovel);
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela", loteamento.IdStatus);
            return View(loteamento);
        }

        // GET: Loteamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loteamento loteamento = db.Loteamento.Find(id);
            if (loteamento == null)
            {
                return HttpNotFound();
            }
            return View(loteamento);
        }

        // POST: Loteamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loteamento loteamento = db.Loteamento.Find(id);
            db.Loteamento.Remove(loteamento);
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
