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
    public class NegociacoesController : Controller
    {
        private SoftHomeDesenvEntities db = new SoftHomeDesenvEntities();

        // GET: Negociacoes
        public ActionResult Index()
        {
            var negociacao = db.Negociacao.Include(n => n.Reuniao).Include(n => n.tblStatus).Include(n => n.TipoNegociacao);
            return View(negociacao.ToList());
        }

        // GET: Negociacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Negociacao negociacao = db.Negociacao.Find(id);
            if (negociacao == null)
            {
                return HttpNotFound();
            }
            return View(negociacao);
        }

        // GET: Negociacoes/Create
        public ActionResult Create()
        {
            ViewBag.IdReuniao = new SelectList(db.Reuniao, "IdReuniao", "Comentario");
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela");
            ViewBag.IdTipoNegociacao = new SelectList(db.TipoNegociacao, "IdTipoNegociacao", "Descricao");
            return View();
        }

        // POST: Negociacoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdNegociacao,IdReuniao,IdTipoNegociacao,IdStatus,QteDeParc,ValorTot,Comentario")] Negociacao negociacao)
        {
            if (ModelState.IsValid)
            {
                db.Negociacao.Add(negociacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdReuniao = new SelectList(db.Reuniao, "IdReuniao", "Comentario", negociacao.IdReuniao);
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela", negociacao.IdStatus);
            ViewBag.IdTipoNegociacao = new SelectList(db.TipoNegociacao, "IdTipoNegociacao", "Descricao", negociacao.IdTipoNegociacao);
            return View(negociacao);
        }

        // GET: Negociacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Negociacao negociacao = db.Negociacao.Find(id);
            if (negociacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdReuniao = new SelectList(db.Reuniao, "IdReuniao", "Comentario", negociacao.IdReuniao);
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela", negociacao.IdStatus);
            ViewBag.IdTipoNegociacao = new SelectList(db.TipoNegociacao, "IdTipoNegociacao", "Descricao", negociacao.IdTipoNegociacao);
            return View(negociacao);
        }

        // POST: Negociacoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdNegociacao,IdReuniao,IdTipoNegociacao,IdStatus,QteDeParc,ValorTot,Comentario")] Negociacao negociacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(negociacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdReuniao = new SelectList(db.Reuniao, "IdReuniao", "Comentario", negociacao.IdReuniao);
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela", negociacao.IdStatus);
            ViewBag.IdTipoNegociacao = new SelectList(db.TipoNegociacao, "IdTipoNegociacao", "Descricao", negociacao.IdTipoNegociacao);
            return View(negociacao);
        }

        // GET: Negociacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Negociacao negociacao = db.Negociacao.Find(id);
            if (negociacao == null)
            {
                return HttpNotFound();
            }
            return View(negociacao);
        }

        // POST: Negociacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Negociacao negociacao = db.Negociacao.Find(id);
            db.Negociacao.Remove(negociacao);
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
