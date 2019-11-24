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
    public class ImoveisTerceirosController : Controller
    {
        private SoftHomeDesenvEntities db = new SoftHomeDesenvEntities();

        // GET: ImoveisTerceiros
        public ActionResult Index()
        {
            var imovelTerceiro = db.ImovelTerceiro.Include(i => i.Cliente).Include(i => i.Imovel).Include(i => i.tblStatus).Include(i => i.TipoImovelTerceiro);
            return View(imovelTerceiro.ToList());
        }

        // GET: ImoveisTerceiros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImovelTerceiro imovelTerceiro = db.ImovelTerceiro.Find(id);
            if (imovelTerceiro == null)
            {
                return HttpNotFound();
            }
            return View(imovelTerceiro);
        }

        // GET: ImoveisTerceiros/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente");
            ViewBag.IdImovel = new SelectList(db.Imovel, "IdImovel", "StatusImovel");
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela");
            ViewBag.IdTipoImovelTerceiro = new SelectList(db.TipoImovelTerceiro, "IdTipoImovel", "Descricao");
            return View();
        }

        // POST: ImoveisTerceiros/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdImovelTerceiro,AreaTotal,AreaContru,Domitotios,Banheiros,Garagem,TotComodos,Comentarios,IdStatus,IdTipoImovelTerceiro,IdImovel,IdCliente,VlrImovel")] ImovelTerceiro imovelTerceiro)
        {
            if (ModelState.IsValid)
            {
                db.ImovelTerceiro.Add(imovelTerceiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente", imovelTerceiro.IdCliente);
            ViewBag.IdImovel = new SelectList(db.Imovel, "IdImovel", "StatusImovel", imovelTerceiro.IdImovel);
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela", imovelTerceiro.IdStatus);
            ViewBag.IdTipoImovelTerceiro = new SelectList(db.TipoImovelTerceiro, "IdTipoImovel", "IdTipoImovel", imovelTerceiro.IdTipoImovelTerceiro);
            return View(imovelTerceiro);
        }

        // GET: ImoveisTerceiros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImovelTerceiro imovelTerceiro = db.ImovelTerceiro.Find(id);
            if (imovelTerceiro == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente", imovelTerceiro.IdCliente);
            ViewBag.IdImovel = new SelectList(db.Imovel, "IdImovel", "StatusImovel", imovelTerceiro.IdImovel);
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela", imovelTerceiro.IdStatus);
            ViewBag.IdTipoImovelTerceiro = new SelectList(db.TipoImovelTerceiro, "IdTipoImovel", "IdTipoImovel", imovelTerceiro.IdTipoImovelTerceiro);
            return View(imovelTerceiro);
        }

        // POST: ImoveisTerceiros/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdImovelTerceiro,AreaTotal,AreaContru,Domitotios,Banheiros,Garagem,TotComodos,Comentarios,IdStatus,IdTipoImovelTerceiro,IdImovel,IdCliente,VlrImovel")] ImovelTerceiro imovelTerceiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imovelTerceiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente", imovelTerceiro.IdCliente);
            ViewBag.IdImovel = new SelectList(db.Imovel, "IdImovel", "StatusImovel", imovelTerceiro.IdImovel);
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela", imovelTerceiro.IdStatus);
            ViewBag.IdTipoImovelTerceiro = new SelectList(db.TipoImovelTerceiro, "IdTipoImovel", "IdTipoImovel", imovelTerceiro.IdTipoImovelTerceiro);
            return View(imovelTerceiro);
        }

        // GET: ImoveisTerceiros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImovelTerceiro imovelTerceiro = db.ImovelTerceiro.Find(id);
            if (imovelTerceiro == null)
            {
                return HttpNotFound();
            }
            return View(imovelTerceiro);
        }

        // POST: ImoveisTerceiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImovelTerceiro imovelTerceiro = db.ImovelTerceiro.Find(id);
            db.ImovelTerceiro.Remove(imovelTerceiro);
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
