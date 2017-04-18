using System;
using System.Collections.Generic;
using System.Configuration;
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

        [HttpPost]
        public ViewResult FecharPedido(Pedido pedido)
        {
            Carrinho carrinho = ObterCarrinho();
            EmailConfiguracoes emailConfig = new EmailConfiguracoes();
            emailConfig.EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"]);

            EmailPedido emailPedido = new EmailPedido(emailConfig);

            if (!carrinho.ItensDoCarrinho().Any())
                ModelState.AddModelError("", "Carrinho vazio! \nPedido não pode ser concluído!");

            if (ModelState.IsValid) {
                emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }
            else
                return View(pedido);
        }

        public ViewResult PedidoConcluido()
        {
            return View();
        }

    }
}