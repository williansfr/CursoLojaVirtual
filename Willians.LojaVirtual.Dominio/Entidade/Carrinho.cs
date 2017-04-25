using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willians.LojaVirtual.Dominio.Entidade
{
    public class Carrinho
    {
        private readonly List<ItensCarrinho> _itemCarrinho = new List<ItensCarrinho>();
        // Adicionar
        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItensCarrinho item = _itemCarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

            if (item == null)
            {
                _itemCarrinho.Add(new ItensCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
                item.Quantidade = quantidade;
        }

        // Remover
        public void RemoverItem(Produto produto)
        {
            _itemCarrinho.RemoveAll(p => p.Produto.ProdutoId == produto.ProdutoId);
        }


        // Limpar Itens do Carrinho
        public void LimparCarrinho() {
            _itemCarrinho.Clear();
        }

        // Obter Valor Total
        public decimal ObterValorTotal()
        {
            return _itemCarrinho.Sum(d => d.Produto.Preco * d.Quantidade);
        }

        // Lista Itens do Carrinho
        public IEnumerable<ItensCarrinho> ItensDoCarrinho() {
            return _itemCarrinho;               
        }
    }
}
