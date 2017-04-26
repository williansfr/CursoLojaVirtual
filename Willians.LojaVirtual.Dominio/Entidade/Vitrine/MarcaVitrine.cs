using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willians.LojaVirtual.Dominio.Entidade.Vitrine
{
    public class MarcaVitrine
    {
        [Key]
        public string MarcaCodigo { get; set; }

        public string MarcaDescricao { get; set; }
    }
}
