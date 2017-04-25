using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Willians.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: null,
                url: "",
                defaults: new { controller = "Vitrine", action = "ListaProdutos", categoriaSelecionada = (string)null, pagina = 1 });

            routes.MapRoute(
                name: null,
                url: "Pagina{pagina}",
                defaults: new { controller = "Vitrine", action = "ListaProdutos", categoriaSelecionada = (string)null },
                constraints: new { pagina = @"\d+" });

            routes.MapRoute(
                name: null,
                url: "{categoriaSelecionada}",
                defaults: new { controller = "Vitrine", action = "ListaProdutos", pagina = 1 });

            routes.MapRoute(
                name: null,
                url: "{categoriaSelecionada}/Pagina{pagina}",
                defaults: new { controller = "Vitrine", action = "ListaProdutos" },
                constraints: new { pagina = @"\d+" });

            //routes.MapRoute("ObterImagem",
            //                "Vitrine/ObterImagem/{produtoId}",
            //                new {controller = "Vitrine", action = "ObterImagem", produtoId = UrlParameter.Optional });

            routes.MapRoute(
                        name: null,
                        url: "{controller}/{action}");

            routes.MapRoute(
                        name: "Default",
                        url: "{controller}/{action}/{id}",
                        defaults: new { controller = "Vitrine", action = "ListaProdutos", id = UrlParameter.Optional }
            );
        }
    }
}
