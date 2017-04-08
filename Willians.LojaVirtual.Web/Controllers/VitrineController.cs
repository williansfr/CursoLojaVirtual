using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Willians.LojaVirtual.Dominio.Repositorio;

namespace Willians.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _produtoRepositorio = new ProdutosRepositorio();

        public int ItensPorPagina = 4;

        // GET: Produtos
        public ActionResult ListaProdutos(int pagina = 1)
        {
            var produtos = _produtoRepositorio.Produtos.OrderBy(p => p.Descricao)
                            .Skip((pagina - 1) * ItensPorPagina)
                            .Take(ItensPorPagina);
            return View(produtos);
        }
    }
}