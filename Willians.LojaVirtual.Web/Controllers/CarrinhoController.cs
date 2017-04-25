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

        public ViewResult Index(Carrinho carrinho, string returnUrl)
        {
            var carrinhoViewModel = new CarrinhoViewModel();
            carrinhoViewModel.Carrinho = carrinho; // ObterCarrinho();
            carrinhoViewModel.ReturnUrl = returnUrl;

            return View(carrinhoViewModel);
        }

        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }

        [HttpPost]
        public ViewResult FecharPedido(Carrinho carrinho, Pedido pedido)
        {
            //Carrinho carrinho = ObterCarrinho();
            EmailConfiguracoes emailConfig = new EmailConfiguracoes();
            emailConfig.EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"]);

            EmailPedido emailPedido = new EmailPedido(emailConfig);

            if (!carrinho.ItensDoCarrinho().Any())
                ModelState.AddModelError("", "Carrinho vazio! \nPedido não pode ser concluído!");

            if (ModelState.IsValid)
            {
                emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }
            else
                return View(pedido);
        }

        public PartialViewResult Resumo(Carrinho carrinho)
        {
            //Carrinho carrinho = ObterCarrinho();
            return PartialView(carrinho);
        }

        // GET: Carrinho
        public RedirectToRouteResult Adicionar(Carrinho carrinho, int produtoId, int quantidade, string returnUrl)
        {
            Produto produto = _produtoRepositorio.Produtos.FirstOrDefault(d => d.ProdutoId == produtoId);

            if (produto != null)
            {
                carrinho.AdicionarItem(produto, quantidade);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        //private Carrinho ObterCarrinho()
        //{           
        //    if (Session["Carrinho"] == null) {
        //        Session["Carrinho"] = new Carrinho();
        //    }

        //    Carrinho carrinho = (Carrinho)Session["Carrinho"];
            
        //    return carrinho;
        //}

        // GET: Carrinho
        public RedirectToRouteResult Remover(Carrinho carrinho, int produtoId, string returnUrl)
        {
            Produto produto = _produtoRepositorio.Produtos.FirstOrDefault(d => d.ProdutoId == produtoId);

            if (produto != null)
            {
                carrinho.RemoverItem(produto);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult PedidoConcluido()
        {
            return View();
        }

    }
}