using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Willians.LojaVirtual.Dominio.Repositorio;

namespace Willians.LojaVirtual.Web.Controllers
{
    public class CategoriasController : Controller
    {
        private ProdutosRepositorio _produtoRepositorio = new ProdutosRepositorio();

        // GET: Categorias
        public PartialViewResult Menu(string categoriaSelecionada = null)
        {
            @ViewBag.CategoriaSelecionada = categoriaSelecionada;

            IEnumerable<string> categorias = _produtoRepositorio.Produtos
                                                .Select(d => d.Categoria)
                                                .Distinct()
                                                .OrderBy(d => d);

            return PartialView(categorias);
        }
    }
}