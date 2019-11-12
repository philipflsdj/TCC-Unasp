using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tcc_Unasp.Models;

namespace Tcc_Unasp.Controllers
{
    public class ClientesController : Controller
    {
        private SoftHomeDesenvEntities db = new SoftHomeDesenvEntities();

        // GET: Clientes
        public ActionResult NaoEncontrado()
        {
            return View();
        }
        public ActionResult Index()
        {
            var cliente = db.Cliente.Include(c => c.tblLogradouros);
            return View(cliente.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("NaoEncontrado");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return RedirectToAction("NaoEncontrado");
                //return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create(string cep)
        {

            ViewBag.IdEndereco = new SelectList(db.tblLogradouros, "Codigo", "DescricaoNaoAbreviada");
            return View();
        }

        // POST: Clientes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente, string cep)
        {
            var Endereco = db.tblLogradouros.Where(t => t.CEP == cep.Replace("-","")).FirstOrDefault<tblLogradouros>();
            
            if (ModelState.IsValid)
            {
                try
                {
                    cliente.IdEndereco = Endereco.Codigo;
                    ViewBag.IdEndereco = new SelectList(db.tblLogradouros, "Codigo", "DescricaoNaoAbreviada", cliente.IdEndereco);
                    ViewBag.Collor = "success";
                    ViewBag.Message = "Cliente " + cliente.NomeCliente + " cadastrado com sucesso";
                    db.Cliente.Add(cliente);
                    db.SaveChanges();
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Collor = "danger";
                    ViewBag.Message = "Cliente não foi cadastrado" + ex;
                    return View();
                }
                
            }
            ViewBag.Collor = "danger";
            ViewBag.Message = "Cliente não foi cadastrado, dados inseridos não são validos";
            return View();

        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEndereco = new SelectList(db.tblLogradouros, "Codigo", "DescricaoNaoAbreviada", cliente.IdEndereco);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente, string cep)
        {
            var Endereco = db.tblLogradouros.Where(t => t.CEP == cep).FirstOrDefault<tblLogradouros>();
            cliente.IdEndereco = Endereco.Codigo;
            ViewBag.IdEndereco = new SelectList(db.tblLogradouros, "Codigo", "DescricaoNaoAbreviada", cliente.IdEndereco);
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
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
