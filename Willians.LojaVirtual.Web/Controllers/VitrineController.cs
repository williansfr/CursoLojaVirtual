using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Willians.LojaVirtual.Dominio.Repositorio;
using Willians.LojaVirtual.Web.Models;

namespace Willians.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _produtoRepositorio = new ProdutosRepositorio();

        public int ItensPorPagina = 4;

        // GET: Produtos
        public ViewResult ListaProdutos(int pagina = 1)
        {
            var produtos = _produtoRepositorio.Produtos.OrderBy(p => p.Descricao)
                            .Skip((pagina - 1) * ItensPorPagina)
                            .Take(ItensPorPagina);

            ProdutoViewModel model = new ProdutoViewModel();
            model.paginacao = new Paginacao();
            model.paginacao.PaginaAtual = pagina;
            model.paginacao.ItensPorPagina = ItensPorPagina;
            model.paginacao.ItensTotal = _produtoRepositorio.Produtos.Count();

            model.Produtos = produtos;

            return View(model);
        }
    }
}