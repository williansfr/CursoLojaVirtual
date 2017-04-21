using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willians.LojaVirtual.Dominio.Entidade
{
    public class Administradores
    {
        // DataNotations
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o Login")]
        [Display(Name ="Login: ")]
        public String Login { get; set; }

        [Required(ErrorMessage = "Digite a Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public DateTime UltimoAcesso { get; set; }
    }
}
