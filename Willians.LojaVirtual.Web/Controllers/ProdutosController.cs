using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Willians.LojaVirtual.Dominio.Entidade;
using Willians.LojaVirtual.Dominio.Repositorio;

namespace Willians.LojaVirtual.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutosRepositorio _produtoRepositorio = new ProdutosRepositorio();

        // GET: Produtos
        public ActionResult Index()
        {
            var produtos = _produtoRepositorio.Produtos.Take(10);
            return View(produtos);
        }

        [Route("Produtos/ObterImagemTeste/{produtoId}")]
        public FileContentResult ObterImagem(int produtoId)
        {
            _produtoRepositorio = new ProdutosRepositorio();
            Produto prod = _produtoRepositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (prod != null)
            {
                return File(prod.Imagem, prod.ImagemMimeType);
            }
            return null;
        }
    }
}