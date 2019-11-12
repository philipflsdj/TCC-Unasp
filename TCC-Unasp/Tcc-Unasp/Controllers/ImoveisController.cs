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
    public class ImoveisController : Controller
    {
        private SoftHomeDesenvEntities db = new SoftHomeDesenvEntities();

        // GET: Imoveis
        public ActionResult Index()
        {
            var imovel = db.Imovel.Include(i => i.tblLogradouros).Include(i => i.TipoImovel1);
            return View(imovel.ToList());
        }

        // GET: Imoveis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imovel imovel = db.Imovel.Find(id);
            if (imovel == null)
            {
                return HttpNotFound();
            }
            return View(imovel);
        }

        // GET: Imoveis/Create
        public ActionResult Create()
        {
            var listTipoImovel = db.TipoImovel;
            var listStatus = db.tblStatus;
            ViewBag.ListaTipoImovel = listTipoImovel.ToList();
            ViewBag.ListadeStatus = listStatus.ToList();
            ViewBag.IdEndereco = new SelectList(db.tblLogradouros, "Codigo", "UF");
            ViewBag.TipoImovel = new SelectList(db.TipoImovel, "IdTipoImovel", "Descricao");
            return View();
        }

        // POST: Imoveis/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Imovel Imovel, string cep)
        {
            var Endereco = db.tblLogradouros.Where(t => t.CEP == cep.Replace("-", "")).FirstOrDefault<tblLogradouros>();
            
            if (ModelState.IsValid)
            {
                try
                {
                    Imovel.DataCadastro = DateTime.Now;
                    Imovel.IdEndereco = Endereco.Codigo;
                    ViewBag.IdEndereco = new SelectList(db.tblLogradouros, "Codigo", "DescricaoNaoAbreviada", Imovel.IdEndereco);
                    ViewBag.TipoImovel = new SelectList(db.TipoImovel, "IdTipoImovel", "Descricao", Imovel.TipoImovel);
                    ViewBag.Collor = "success";
                    ViewBag.Message = "Imovel cadastrado com sucesso";
                    db.Imovel.Add(Imovel);
                    db.SaveChanges();
                    return View();
                }
                catch (Exception ex)
                {

                    ViewBag.Collor = "danger";
                    ViewBag.Message = "Imovel não foi cadastrado" + ex;
                    return View();
                }
            }
            ViewBag.Collor = "danger";
            ViewBag.Message = "Imovel não foi cadastrado";
            return View();
            
        }

        // GET: Imoveis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imovel imovel = db.Imovel.Find(id);
            if (imovel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEndereco = new SelectList(db.tblLogradouros, "Codigo", "UF", imovel.IdEndereco);
            ViewBag.TipoImovel = new SelectList(db.TipoImovel, "IdTipoImovel", "Descricao", imovel.TipoImovel);
            return View(imovel);
        }

        // POST: Imoveis/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdImovel,IdEndereco,NImovel,TipoImovel,StatusImovel,DataCadastro")] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imovel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEndereco = new SelectList(db.tblLogradouros, "Codigo", "UF", imovel.IdEndereco);
            ViewBag.TipoImovel = new SelectList(db.TipoImovel, "IdTipoImovel", "Descricao", imovel.TipoImovel);
            return View(imovel);
        }

        // GET: Imoveis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imovel imovel = db.Imovel.Find(id);
            if (imovel == null)
            {
                return HttpNotFound();
            }
            return View(imovel);
        }

        // POST: Imoveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Imovel imovel = db.Imovel.Find(id);
            db.Imovel.Remove(imovel);
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
