using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Willians.LojaVirtual.Dominio.Repositorio;

namespace Willians.LojaVirtual.Web.V2.Controllers
{
    public class MenuController : Controller
    {
        private MenuRepositorio _repositorio;

        [OutputCache(Duration = 3600, Location = System.Web.UI.OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterEsportes()
        {
            _repositorio = new MenuRepositorio();

            var cat = _repositorio.ObterCategorias();

            var categoria = from c in cat
                            select new
                            {
                                c.CategoriaDescricao,
                                CategoriaDescricaoSeo = c.CategoriaDescricao.ToSeoUrl(),
                                c.CategoriaCodigo
                            };

            return Json(categoria, JsonRequestBehavior.AllowGet);
        }


        [OutputCache(Duration = 3600, Location = System.Web.UI.OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterMarcas()
        {
            _repositorio = new MenuRepositorio();

            var marcas = _repositorio.ObterMarcas();

            var marcasSel = from m in marcas
                            select new
                            {
                                m.MarcaDescricao,
                                MarcaDescricaoSeo = m.MarcaDescricao.ToSeoUrl(),
                                m.MarcaCodigo                                
                            };

            return Json(marcasSel, JsonRequestBehavior.AllowGet);
        }
        
        #region Clubes de Futebol

       // [OutputCache(Duration = 3600, Location = System.Web.UI.OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterClubesNacionais()
        {
            _repositorio = new MenuRepositorio();

            var nacionais = _repositorio.ObterClubesNacionais();

            var nacionaisSel = from n in nacionais
                            select new
                            {
                                n.LinhaDescricao,
                                LinhaDescricaoSeo = n.LinhaDescricao.ToSeoUrl(),
                                n.LinhaCodigo
                            };

            return Json(nacionaisSel, JsonRequestBehavior.AllowGet);
        }

       // [OutputCache(Duration = 3600, Location = System.Web.UI.OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterClubesInternacionais()
        {
            _repositorio = new MenuRepositorio();

            var internacionais = _repositorio.ObterClubesInternacionais();

            var internacionaisSel = from i in internacionais
                               select new
                               {
                                   i.LinhaDescricao,
                                   LinhaDescricaoSeo = i.LinhaDescricao.ToSeoUrl(),
                                   i.LinhaCodigo
                               };

            return Json(internacionaisSel, JsonRequestBehavior.AllowGet);
        }

      //  [OutputCache(Duration = 3600, Location = System.Web.UI.OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterSelecoes()
        {
            _repositorio = new MenuRepositorio();

            var selecoes = _repositorio.ObterSelecoes();

            var iselecoesSel = from s in selecoes
                               select new
                                    {
                                        s.LinhaDescricao,
                                        LinhaDescricaoSeo = s.LinhaDescricao.ToSeoUrl(),
                                        s.LinhaCodigo
                                    };

            return Json(iselecoesSel, JsonRequestBehavior.AllowGet);
        }

        #endregion Clubes de Futebol
    }
}