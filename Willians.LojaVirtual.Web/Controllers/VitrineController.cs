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
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _produtoRepositorio = new ProdutosRepositorio();

        public int ItensPorPagina = 12;

        // GET: Produtos
        //public ViewResult ListaProdutos(int pagina = 1, string categoriaSelecionada = null)
        //{
        //    var produtos = _produtoRepositorio.Produtos
        //                    .Where(p => (categoriaSelecionada == null || p.Categoria == categoriaSelecionada))
        //                    .OrderBy(p => p.Descricao)
        //                    .Skip((pagina - 1) * ItensPorPagina)
        //                    .Take(ItensPorPagina);

        //    ProdutoViewModel model = new ProdutoViewModel();
        //    model.paginacao = new Paginacao();
        //    model.paginacao.PaginaAtual = pagina;
        //    model.paginacao.ItensPorPagina = ItensPorPagina;
        //    model.paginacao.ItensTotal = _produtoRepositorio.Produtos
        //                                    .Count(p => (categoriaSelecionada == null || p.Categoria == categoriaSelecionada));

        //    model.Produtos = produtos;

        //    model.CategoriaAtual = categoriaSelecionada;

        //    return View(model);
        //}

        public ViewResult ListaProdutos(string categoriaSelecionada = null)
        {
            var model = new ProdutoViewModel();

            var rnd = new Random();

            if (categoriaSelecionada != null)
                model.Produtos = _produtoRepositorio.Produtos
                                    .Where(d => d.Categoria == categoriaSelecionada)
                                    .OrderBy(x => rnd.Next()).ToList();
            else
                model.Produtos = _produtoRepositorio.Produtos
                                    .Take(ItensPorPagina)
                                    .OrderBy(x => rnd.Next()).ToList();

            return View(model);
        }

        [Route("DetalhesProdutos/{id}/{produto}")]
        public ViewResult Detalhes(int id)
        {
            Produto produto = _produtoRepositorio.ObterProduto(id);
            return View(produto);
        } 

        [Route("Vitrine/ObterImagem/{produtoId}")]
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