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
    public class ReunioesController : Controller
    {
        private SoftHomeDesenvEntities db = new SoftHomeDesenvEntities();

        // GET: Reunioes
        public ActionResult Index()
        {
            var reuniao = db.Reuniao.Include(r => r.Cliente).Include(r => r.Cliente1).Include(r => r.Imovel).Include(r => r.tblStatus).Include(r => r.Usuario);
            return View(reuniao.ToList());
        }

        // GET: Reunioes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reuniao reuniao = db.Reuniao.Find(id);
            if (reuniao == null)
            {
                return HttpNotFound();
            }
            return View(reuniao);
        }

        // GET: Reunioes/Create
        public ActionResult Create()
        {
            ViewBag.IdVendedor = new SelectList(db.Cliente, "IdCliente", "NomeCliente");
            ViewBag.idComprador = new SelectList(db.Cliente, "IdCliente", "NomeCliente");
            ViewBag.IdImovel = new SelectList(db.Imovel, "IdImovel", "StatusImovel");
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela");
            ViewBag.idCorretor = new SelectList(db.Usuario, "IdUsuario", "emailUsuario");
            return View();
        }

        // POST: Reunioes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReuniao,idCorretor,IdVendedor,idComprador,Comentario,IdStatus,IdImovel,NomeReuniao,DataReuniao")] Reuniao reuniao)
        {
            if (ModelState.IsValid)
            {
                db.Reuniao.Add(reuniao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdVendedor = new SelectList(db.Cliente, "IdCliente", "NomeCliente", reuniao.IdVendedor);
            ViewBag.idComprador = new SelectList(db.Cliente, "IdCliente", "NomeCliente", reuniao.idComprador);
            ViewBag.IdImovel = new SelectList(db.Imovel, "IdImovel", "StatusImovel", reuniao.IdImovel);
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela", reuniao.IdStatus);
            ViewBag.idCorretor = new SelectList(db.Usuario, "IdUsuario", "emailUsuario", reuniao.idCorretor);
            return View(reuniao);
        }

        // GET: Reunioes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reuniao reuniao = db.Reuniao.Find(id);
            if (reuniao == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdVendedor = new SelectList(db.Cliente, "IdCliente", "NomeCliente", reuniao.IdVendedor);
            ViewBag.idComprador = new SelectList(db.Cliente, "IdCliente", "NomeCliente", reuniao.idComprador);
            ViewBag.IdImovel = new SelectList(db.Imovel, "IdImovel", "StatusImovel", reuniao.IdImovel);
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela", reuniao.IdStatus);
            ViewBag.idCorretor = new SelectList(db.Usuario, "IdUsuario", "emailUsuario", reuniao.idCorretor);
            return View(reuniao);
        }

        // POST: Reunioes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReuniao,idCorretor,IdVendedor,idComprador,Comentario,IdStatus,IdImovel,NomeReuniao,DataReuniao")] Reuniao reuniao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reuniao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdVendedor = new SelectList(db.Cliente, "IdCliente", "NomeCliente", reuniao.IdVendedor);
            ViewBag.idComprador = new SelectList(db.Cliente, "IdCliente", "NomeCliente", reuniao.idComprador);
            ViewBag.IdImovel = new SelectList(db.Imovel, "IdImovel", "StatusImovel", reuniao.IdImovel);
            ViewBag.IdStatus = new SelectList(db.tblStatus, "IdStatus", "Tabela", reuniao.IdStatus);
            ViewBag.idCorretor = new SelectList(db.Usuario, "IdUsuario", "emailUsuario", reuniao.idCorretor);
            return View(reuniao);
        }

        // GET: Reunioes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reuniao reuniao = db.Reuniao.Find(id);
            if (reuniao == null)
            {
                return HttpNotFound();
            }
            return View(reuniao);
        }

        // POST: Reunioes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reuniao reuniao = db.Reuniao.Find(id);
            db.Reuniao.Remove(reuniao);
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
