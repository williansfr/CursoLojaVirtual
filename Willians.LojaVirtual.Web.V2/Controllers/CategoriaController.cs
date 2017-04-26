using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Willians.LojaVirtual.Dominio.Repositorio;

namespace Willians.LojaVirtual.Web.V2.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaRepositorio _repositorio;

        [OutputCache(Duration =3600, Location =System.Web.UI.OutputCacheLocation.Server, VaryByParam ="none")]
        public JsonResult ObterEsportes()
        {
            _repositorio = new CategoriaRepositorio();

            var cat = _repositorio.ObterCategorias();

            var categoria = from c in cat
                            select new
                            {
                                c.CategoriaDescricao,
                                CategoriaDescricaoSeo = c.CategoriaDescricao.ToSeoUrl(),
                                c.CategoriaCodigo
                            };

            return Json(categoria, JsonRequestBehavior.AllowGet);
        }
    }
}