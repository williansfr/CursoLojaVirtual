using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Willians.LojaVirtual.Dominio.Entidade
{
    public class Produto
    {
        [HiddenInput(DisplayValue=false)]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage ="Digite o Nome do Produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite a Descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage ="Preço Inválido")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Digite a Categoria")]
        public string Categoria { get; set; }

        public byte[] Imagem { get; set; }

        public string ImagemMimeType { get; set; }
    }
}
