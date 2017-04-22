using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Willians.LojaVirtual.Dominio.Entidade;
using Willians.LojaVirtual.Dominio.Repositorio;

namespace Willians.LojaVirtual.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        AdministradoresRepositorio repositorio;

        [HttpGet]
        public ActionResult Login (string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new Administrador());
        }

        [HttpPost]
        public ActionResult Login(Administrador adm, string returnUrl)
        {
            repositorio = new AdministradoresRepositorio();

            if (ModelState.IsValid)
            {
                var admin = repositorio.ObterAdministrador(adm);
                if (admin == null)
                {
                    ModelState.AddModelError("", "Administrador não localizado!");
                }
                else
                {
                    if (!Equals(adm.Senha.TrimEnd(), admin.Senha.TrimEnd()))
                        ModelState.AddModelError("", "Senha não confere!");
                    else
                    {
                        FormsAuthentication.SetAuthCookie(adm.Login, false);

                        if (Url.IsLocalUrl(returnUrl) &&
                            returnUrl.Length > 1 &&
                            returnUrl.StartsWith("/") &&
                            !returnUrl.StartsWith("//") &&
                            !returnUrl.StartsWith("/\\"))
                            return Redirect(returnUrl);

                    }
                }
            }

            return View(new Administrador());
        }
    }
}