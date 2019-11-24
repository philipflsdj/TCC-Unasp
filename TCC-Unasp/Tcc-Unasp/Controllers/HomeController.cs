using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tcc_Unasp.Models;

namespace Tcc_Unasp.Controllers
{
    
    public class HomeController : Controller
    {
        private SoftHomeDesenvEntities db = new SoftHomeDesenvEntities();
        public ActionResult Index()
        {
            db.Database.Log = (s) => System.Diagnostics.Debug.Write(s); // essa linha seta que o log gerado pelo EF6 será exibido no Output do Visual Studio
            var c = db.Cliente.Count();
            var it = db.ImovelTerceiro.Count();
            var lt = db.Loteamento.Count();
            var at = db.Atendimento.Count();
            var rn = db.Reuniao.Count();
            var ng = db.Negociacao.Count();
            ViewBag.ClientesCadastrados = c;
            ViewBag.ImoveisTerceirosCadastrados = it;
            ViewBag.LoteamentosCadastrados = lt;
            ViewBag.AtendimentosCadastrados = at;
            ViewBag.ReuioesCadastrados = rn;
            ViewBag.NegociacoesCadastrados = ng;
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}