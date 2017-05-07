using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Willians.LojaVirtual.Dominio.Repositorio;
using Willians.LojaVirtual.Web.V2.Models;
using Willians.LojaVirtual.Dominio.Entidade;
using Willians.LojaVirtual.Dominio.Dto;

namespace Willians.LojaVirtual.Web.V2.Controllers
{
    [RoutePrefix("produto")]
    public class DetalhesProdutoController : Controller
    {
        [Route("{codigo}/{marca}/{produto}/{corcodigo}")]
        public ActionResult Detalhes(string codigo, string corCodigo)
        {
            var repositorio = new DetalhesProdutoRepositorio();
            var produto = repositorio.ObterProdutoModelo(codigo, corCodigo);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DetalhesProdutoDto, DetalhesProdutoViewModel>();
                cfg.CreateMap<DetalhesProdutoViewModel, DetalhesProdutoDto>();
                cfg.AddProfile(new MappingProfile());
            });

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<DetalhesProdutoDto, DetalhesProdutoViewModel>();
            //    cfg.CreateMap<DetalhesProdutoViewModel, DetalhesProdutoDto>();
            //});

            //var config = new MapperConfiguration(cfg => cfg.CreateMap<DetalhesProdutoDto, DetalhesProdutoViewModel>());
            var mapper = config.CreateMapper();
            var model = Mapper.Map<DetalhesProdutoViewModel>(produto);

          //  var model =  Mapper.Map<DetalhesProdutoViewModel>(produto);

            model.CoresList = new SelectList(produto.Cores, "CorCodigo", "CorDescricao", corCodigo);
            model.TamanhoList = new SelectList(produto.Tamanhos, "TamanhoCodigo", "TamanhoDescricaoResumida");
            model.Breadcrumb = repositorio.ObterBreadCrumb(produto.Produto.ProdutoModeloCodigo);
            return View(model);
        }
    }

    public class MappingProfile : Profile
    {
        public void Configure()
        {
            CreateMap<DetalhesProdutoViewModel, DetalhesProdutoDto>();
            CreateMap<DetalhesProdutoDto, DetalhesProdutoViewModel>();
        }
    }
}