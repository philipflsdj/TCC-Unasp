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
    public class ContatosController : Controller
    {
        private SoftHomeDesenvEntities db = new SoftHomeDesenvEntities();

        // GET: Contatos
        public ActionResult Index()
        {
            var contatos = db.Contatos.Include(c => c.Cliente);
            return View(contatos.ToList());
        }

        // GET: Contatos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contatos contatos = db.Contatos.Find(id);
            if (contatos == null)
            {
                return HttpNotFound();
            }
            return View(contatos);
        }

        // GET: Contatos/Create
        public ActionResult Create()
        {
            var listclientes = db.Cliente;
            ViewBag.ListaClientes = listclientes.ToList();
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente");
            return View();
        }
        public JsonResult GetList(string query)
        {
            var list = db.Cliente.Where(c => c.NomeCliente.StartsWith(query)).Take(10).ToList();
            //var list = new SelectList(db.Cliente,"NomeCliente");
            return Json(list.Select(c => new { NomeCliente = c.NomeCliente, IdCliente = c.IdCliente }) ,JsonRequestBehavior.AllowGet);
        }

        // POST: Contatos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdContato,IdCliente,emailCliente,TelResidCliente,CelCliente,FacebookCliente,InstagramCliente")] Contatos contatos)
        {
            if (ModelState.IsValid)
            {
                db.Contatos.Add(contatos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente", contatos.IdCliente);
            return View(contatos);
        }

        // GET: Contatos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contatos contatos = db.Contatos.Find(id);
            if (contatos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente", contatos.IdCliente);
            return View(contatos);
        }

        // POST: Contatos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdContato,IdCliente,emailCliente,TelResidCliente,CelCliente,FacebookCliente,InstagramCliente")] Contatos contatos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contatos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente", contatos.IdCliente);
            return View(contatos);
        }

        // GET: Contatos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contatos contatos = db.Contatos.Find(id);
            if (contatos == null)
            {
                return HttpNotFound();
            }
            return View(contatos);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contatos contatos = db.Contatos.Find(id);
            db.Contatos.Remove(contatos);
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
