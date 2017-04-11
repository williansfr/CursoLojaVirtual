using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Willians.LojaVirtual.Dominio.Entidade;

namespace Willians.LojaVirtual.Web.Models
{
    public class ProdutoViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }

        public Paginacao paginacao { get; set; }

        public string CategoriaAtual { get; set; }
    }
}