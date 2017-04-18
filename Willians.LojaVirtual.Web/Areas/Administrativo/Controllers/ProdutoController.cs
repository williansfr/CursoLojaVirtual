using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Willians.LojaVirtual.Dominio.Repositorio;

namespace Willians.LojaVirtual.Web.Areas.Administrativo.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutosRepositorio _repositorio;

        // GET: Administrativo/Produto
        public ActionResult Index()
        {
            return View();
        }
    }
}