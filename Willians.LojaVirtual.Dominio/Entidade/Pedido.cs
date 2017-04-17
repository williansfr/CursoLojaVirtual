using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willians.LojaVirtual.Dominio.Entidade
{
    public class Pedido
    {
        [Display(Name = "Nome do Cliente: ")]
        [Required(ErrorMessage="Informe o Nome")]
        public string NomeCliente { get; set; }

        [Display(Name="CEP: ")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Informe o endereço")]
        [Display(Name = "Endereço: ")]
        public string Endereco { get; set; }

        [Display(Name = "Complemento: ")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Informe a cidade")]
        [Display(Name = "Cidade: ")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o estado")]
        [Display(Name = "Estado: ")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe o bairro")]
        [Display(Name = "Bairro: ")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe o e-mail")]
        [Display(Name = "E-Mail: ")]
        [EmailAddress(ErrorMessage ="EMail Inválido")]
        public string Email { get; set; }

        public bool EmbrulhaPresente { get; set; }


    }
}
