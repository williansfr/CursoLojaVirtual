using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Willians.LojaVirtual.Dominio.Dto;
using Willians.LojaVirtual.Dominio.Entidade;

namespace Willians.LojaVirtual.Web.V2.Models
{
    public class ModalidadeSubGrupoViewModel
    {
        public Modalidade modalidade { get; set; }

        public IEnumerable<SubGrupoDto> SubGrupos { get; set; }
    }
}