using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Willians.LojaVirtual.Dominio.Entidade;

namespace Willians.LojaVirtual.Web.Models
{
    public class CarrinhoViewModel
    {
        public Carrinho Carrinho { get; set; }

        public string ReturnUrl { get; set; }
    }
}