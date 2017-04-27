﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Willians.LojaVirtual.Web.V2.Models;

namespace Willians.LojaVirtual.Web.V2.Controllers
{
    public class NavController : Controller
    {       
        public ActionResult Index()
        {
            return View();
        }

        [Route("nav/{id}/{marca}")]
        public ActionResult ObterProdutosPorMarcas(string id)
        {
            var model = new ProdutosViewModel {Produtos = null};

            return View(model);
        }
    }
}