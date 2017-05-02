using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Willians.LojaVirtual.Dominio.Repositorio;
using Willians.LojaVirtual.Web.V2.Models;

namespace Willians.LojaVirtual.Web.V2.Controllers
{
    public class NavController : Controller
    {
        private ProdutoModeloRepositorio _repositorio;
        private ProdutosViewModel _model;
        
        public ActionResult Index()
        {
            _repositorio = new ProdutoModeloRepositorio();

            var produtos = _repositorio.ObterProdutosVitrine();

            _model = new ProdutosViewModel();
            _model.Produtos = produtos;

            return View(_model);
        }

        [Route("nav/{id}/{marca}")]
        public ActionResult ObterProdutosPorMarcas(string id, string marca)
        {
            _repositorio = new ProdutoModeloRepositorio();

            var produtos = _repositorio.ObterProdutosVitrine(marca: id);

            _model = new ProdutosViewModel();
            _model.Produtos = produtos;
            _model.Titulo = marca;

            return View("Navegacao", _model);
        }

        [Route("nav/times/{id}/{clube}")]
        public ActionResult ObterProdutosPorClubes(string id, string clube)
        {
            _repositorio = new ProdutoModeloRepositorio();

            var produtos = _repositorio.ObterProdutosVitrine(linha: id);

            _model = new ProdutosViewModel();
            _model.Produtos = produtos;
            _model.Titulo = clube;

            return View("Navegacao", _model);
        }

        [Route("nav/genero/{id}/{genero}")]
        public ActionResult ObterProdutosPorGenero(string id, string genero)
        {
            _repositorio = new ProdutoModeloRepositorio();

            var produtos = _repositorio.ObterProdutosVitrine(genero: id);

            _model = new ProdutosViewModel();
            _model.Produtos = produtos;
            _model.Titulo = genero;

            return View("Navegacao", _model);
        }
    }
}