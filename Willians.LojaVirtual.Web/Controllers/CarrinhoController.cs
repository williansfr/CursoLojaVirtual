using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Willians.LojaVirtual.Dominio.Entidade;
using Willians.LojaVirtual.Dominio.Repositorio;
using Willians.LojaVirtual.Web.Models;

namespace Willians.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private ProdutosRepositorio _produtoRepositorio = new ProdutosRepositorio();

        // GET: Carrinho
        public RedirectToRouteResult Adicionar(int produtoId, string returnUrl)
        {
            Produto produto = _produtoRepositorio.Produtos.FirstOrDefault(d => d.ProdutoId == produtoId);

            if (produto != null)
            {
                ObterCarrinho().AdicionarItem(produto, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        private Carrinho ObterCarrinho()
        {           
            if (Session["Carrinho"] == null) {
                Session["Carrinho"] = new Carrinho();
            }

            Carrinho carrinho = (Carrinho)Session["Carrinho"];
            
            return carrinho;
        }

        // GET: Carrinho
        public RedirectToRouteResult Remover(int produtoId, string returnUrl)
        {
            Produto produto = _produtoRepositorio.Produtos.FirstOrDefault(d => d.ProdutoId == produtoId);

            if (produto != null)
            {
                ObterCarrinho().RemoverItem(produto);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(string returnUrl)
        {
            var carrinho = new CarrinhoViewModel();
            carrinho.Carrinho = ObterCarrinho();
            carrinho.ReturnUrl = returnUrl;

            return View(carrinho);
        }

        public PartialViewResult Resumo()
        {
            Carrinho carrinho = ObterCarrinho();
            return PartialView(carrinho);
        }

        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }

    }
}