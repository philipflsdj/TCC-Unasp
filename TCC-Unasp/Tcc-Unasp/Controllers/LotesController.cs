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
    public class LotesController : Controller
    {
        private SoftHomeDesenvEntities db = new SoftHomeDesenvEntities();

        // GET: Lotes
        public ActionResult Index()
        {
            var lote = db.Lote.Include(l => l.Cliente).Include(l => l.Loteamento).Include(l => l.tblStatus);
            return View(lote.ToList());
        }

        // GET: Lotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lote lote = db.Lote.Find(id);
            if (lote == null)
            {
                return HttpNotFound();
            }
            return View(lote);
        }

        // GET: Lotes/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente");
            ViewBag.IdLoteamento = new SelectList(db.Loteamento, "IdLoteamento", "NomeLoteamento");
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela");
            return View();
        }

        // POST: Lotes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLote,IdLoteamento,NLote,Nquadra,Mfrente,Mfundo,MLAtDir,MLatEsc,Confrontante,AreaQuadrada,Matricula,IPTU,Rua,IdCliente,IdStatus")] Lote lote)
        {
            if (ModelState.IsValid)
            {
                db.Lote.Add(lote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente", lote.IdCliente);
            ViewBag.IdLoteamento = new SelectList(db.Loteamento, "IdLoteamento", "NomeLoteamento", lote.IdLoteamento);
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela", lote.IdStatus);
            return View(lote);
        }

        // GET: Lotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lote lote = db.Lote.Find(id);
            if (lote == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente", lote.IdCliente);
            ViewBag.IdLoteamento = new SelectList(db.Loteamento, "IdLoteamento", "NomeLoteamento", lote.IdLoteamento);
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela", lote.IdStatus);
            return View(lote);
        }

        // POST: Lotes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLote,IdLoteamento,NLote,Nquadra,Mfrente,Mfundo,MLAtDir,MLatEsc,Confrontante,AreaQuadrada,Matricula,IPTU,Rua,IdCliente,IdStatus")] Lote lote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente", lote.IdCliente);
            ViewBag.IdLoteamento = new SelectList(db.Loteamento, "IdLoteamento", "NomeLoteamento", lote.IdLoteamento);
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela", lote.IdStatus);
            return View(lote);
        }

        // GET: Lotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lote lote = db.Lote.Find(id);
            if (lote == null)
            {
                return HttpNotFound();
            }
            return View(lote);
        }

        // POST: Lotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lote lote = db.Lote.Find(id);
            db.Lote.Remove(lote);
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
