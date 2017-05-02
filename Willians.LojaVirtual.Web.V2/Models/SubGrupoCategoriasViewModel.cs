using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Willians.LojaVirtual.Dominio.Entidade;

namespace Willians.LojaVirtual.Web.V2.Models
{
    public class SubGrupoCategoriasViewModel
    {
        public SubGrupo SubGrupo { get; set; }

        public IEnumerable<Categoria> Categorias { get; set; }
    }
}