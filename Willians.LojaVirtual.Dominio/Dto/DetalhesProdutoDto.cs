using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willians.LojaVirtual.Dominio.Entidade;

namespace Willians.LojaVirtual.Dominio.Dto
{
    public class DetalhesProdutoDto
    {
        public QuironProduto Produto { get; set; }

        public IEnumerable<Cor> Cores { get; set; }

        public IEnumerable<Tamanho> Tamanhos { get; set; }
    }
}
