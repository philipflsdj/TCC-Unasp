using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Tcc_Unasp.Models;

namespace Tcc_Unasp.Controllers
{
    public class AutenticationController : Controller
    {
        [AllowAnonymous]
        // GET: Login
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new Usuario
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(Usuario model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if(model.emailUsuario =="dr.sergiomoliveira@gmail.com" && model.SenhaUsuario == "123")
            {
                var identity = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Name, "SÉRGIO MENDES DE OLIVEIRA"),
                    new Claim(ClaimTypes.Email, "dr.sergiomoliveira@gmail.com"),
                    new Claim(ClaimTypes.Country, "Brasil")
                },
                "ApplicationCookie");
                var ctx = Request.GetOwinContext();
                var AuthManager = ctx.Authentication;

                AuthManager.SignIn(identity);
                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }
            ModelState.AddModelError("", "Usuário e Senha inválidos");
            return View();
        }
        private string GetRedirectUrl(string returnUrl)
        {
            if(string.IsNullOrEmpty(returnUrl) ||!Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }
            return returnUrl;
        }
    }
}