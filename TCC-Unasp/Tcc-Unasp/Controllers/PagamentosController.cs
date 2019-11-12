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
    public class PagamentosController : Controller
    {
        private SoftHomeDesenvEntities db = new SoftHomeDesenvEntities();

        // GET: Pagamentos
        public ActionResult Index()
        {
            var pagamento = db.Pagamento.Include(p => p.Cliente).Include(p => p.Negociacao).Include(p => p.tblStatus).Include(p => p.TipoPagamento);
            return View(pagamento.ToList());
        }

        // GET: Pagamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamento pagamento = db.Pagamento.Find(id);
            if (pagamento == null)
            {
                return HttpNotFound();
            }
            return View(pagamento);
        }

        // GET: Pagamentos/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente");
            ViewBag.IdNegociacao = new SelectList(db.Negociacao, "IdNegociacao", "Comentario");
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela");
            ViewBag.IdTipoPagamento = new SelectList(db.TipoPagamento, "IdTipoPagamento", "Descricao");
            return View();
        }

        // POST: Pagamentos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPagamento,IdCliente,IdStatus,nParcela,Valor,IdTipoPagamento,IdNegociacao")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                db.Pagamento.Add(pagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente", pagamento.IdCliente);
            ViewBag.IdNegociacao = new SelectList(db.Negociacao, "IdNegociacao", "Comentario", pagamento.IdNegociacao);
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela", pagamento.IdStatus);
            ViewBag.IdTipoPagamento = new SelectList(db.TipoPagamento, "IdTipoPagamento", "Descricao", pagamento.IdTipoPagamento);
            return View(pagamento);
        }

        // GET: Pagamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamento pagamento = db.Pagamento.Find(id);
            if (pagamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente", pagamento.IdCliente);
            ViewBag.IdNegociacao = new SelectList(db.Negociacao, "IdNegociacao", "Comentario", pagamento.IdNegociacao);
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela", pagamento.IdStatus);
            ViewBag.IdTipoPagamento = new SelectList(db.TipoPagamento, "IdTipoPagamento", "Descricao", pagamento.IdTipoPagamento);
            return View(pagamento);
        }

        // POST: Pagamentos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPagamento,IdCliente,IdStatus,nParcela,Valor,IdTipoPagamento,IdNegociacao")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente", pagamento.IdCliente);
            ViewBag.IdNegociacao = new SelectList(db.Negociacao, "IdNegociacao", "Comentario", pagamento.IdNegociacao);
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela", pagamento.IdStatus);
            ViewBag.IdTipoPagamento = new SelectList(db.TipoPagamento, "IdTipoPagamento", "Descricao", pagamento.IdTipoPagamento);
            return View(pagamento);
        }

        // GET: Pagamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamento pagamento = db.Pagamento.Find(id);
            if (pagamento == null)
            {
                return HttpNotFound();
            }
            return View(pagamento);
        }

        // POST: Pagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pagamento pagamento = db.Pagamento.Find(id);
            db.Pagamento.Remove(pagamento);
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
