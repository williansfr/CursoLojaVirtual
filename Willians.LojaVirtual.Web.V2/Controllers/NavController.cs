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
        private MenuRepositorio _menuRepositorio;
        
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

        #region Tenis Por Categoria

        [ChildActionOnly] // Somente Utilizado como Filho, a exemplo de um Web User Control
        //[OutputCache(Duration =3600, VaryByParam ="*")]
        public ActionResult TenisCategoria()
        {
            _menuRepositorio = new MenuRepositorio();
            var categorias = _menuRepositorio.ObterTenisPorCategoria();
            var subGrupo = _menuRepositorio.SubGrupoTenis();

            SubGrupoCategoriasViewModel viewCat = new SubGrupoCategoriasViewModel();
            viewCat.Categorias = categorias;
            viewCat.SubGrupo = subGrupo;

            return PartialView("_TenisCategoria", viewCat);
        }

        [Route("calcados/{subGrupoCodigo}/tenis/{categoriaCodigo}/{categoriaDescricao}")]
        public ActionResult ObterTenisPorCategoria(string subGrupoCodigo, string categoriaCodigo, string categoriaDescricao)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(categoria: categoriaCodigo, subgrupo: subGrupoCodigo);

            _model = new ProdutosViewModel();
            _model.Produtos = produtos;
            _model.Titulo = categoriaDescricao; //.UpperCaseFirst();

            return View("Navegacao", _model);
        }

        #endregion Tenis Por Categoria        
    }
}