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
    public class AtendimentosController : Controller
    {
        private SoftHomeDesenvEntities db = new SoftHomeDesenvEntities();

        public ActionResult ListCliente()
        {
            var listclientes = db.Cliente;
            return View("Create", listclientes.ToList());
        }

        // GET: Atendimentos
        public ActionResult Index()
        {
            var atendimento = db.Atendimento.Include(a => a.Cliente).Include(a => a.Reuniao).Include(a => a.Usuario);
            return View(atendimento.ToList());
        }

        // GET: Atendimentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atendimento atendimento = db.Atendimento.Find(id);
            if (atendimento == null)
            {
                return HttpNotFound();
            }
            return View(atendimento);
        }

        // GET: Atendimentos/Create
        public ActionResult Create()
        {
            var listclientes = db.Cliente;
            ViewBag.ListaClientes = listclientes.ToList();
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente");
            ViewBag.IdReuniao = new SelectList(db.Reuniao, "IdReuniao", "Comentario");
            ViewBag.IdAtendente = new SelectList(db.Usuario, "IdUsuario", "NomeUsuario");
            // ViewBag.IdEndereco = new SelectList(db.tblLogradouros, "Codigo", "UF");

            return View(new Atendimento { Cliente = new Cliente() });
        }

        // POST: Atendimentos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAtendimento,IdCliente,IdAtendente,NomeAtendimento,Comentario,DataAtendimento,IdReuniao")] Atendimento atendimento)
        {
            var listclientes = db.Cliente;
            ViewBag.ListaClientes = listclientes.ToList();
            if (ModelState.IsValid)
            {
                db.Atendimento.Add(atendimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente", atendimento.IdCliente);
            ViewBag.IdReuniao = new SelectList(db.Reuniao, "IdReuniao", "Comentario", atendimento.IdReuniao);
            ViewBag.IdAtendente = new SelectList(db.Usuario, "IdUsuario", "emailUsuario", atendimento.IdAtendente);
            return View(atendimento);
        }

        // GET: Atendimentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atendimento atendimento = db.Atendimento.Find(id);
            if (atendimento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente", atendimento.IdCliente);
            ViewBag.IdReuniao = new SelectList(db.Reuniao, "IdReuniao", "Comentario", atendimento.IdReuniao);
            ViewBag.IdAtendente = new SelectList(db.Usuario, "IdUsuario", "emailUsuario", atendimento.IdAtendente);
            return View(atendimento);
        }

        // POST: Atendimentos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAtendimento,IdCliente,IdAtendente,NomeAtendimento,Comentario,DataAtendimento,IdReuniao")] Atendimento atendimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atendimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NomeCliente", atendimento.IdCliente);
            ViewBag.IdReuniao = new SelectList(db.Reuniao, "IdReuniao", "Comentario", atendimento.IdReuniao);
            ViewBag.IdAtendente = new SelectList(db.Usuario, "IdUsuario", "emailUsuario", atendimento.IdAtendente);
            return View(atendimento);
        }

        // GET: Atendimentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atendimento atendimento = db.Atendimento.Find(id);
            if (atendimento == null)
            {
                return HttpNotFound();
            }
            return View(atendimento);
        }

        // POST: Atendimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atendimento atendimento = db.Atendimento.Find(id);
            db.Atendimento.Remove(atendimento);
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
