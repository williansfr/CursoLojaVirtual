using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willians.LojaVirtual.Dominio.Entidade;

namespace Willians.LojaVirtual.Dominio.Repositorio
{
    public class AdministradoresRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public Administrador ObterAdministrador(Administrador adm)
        {
            return _context.Administradores.FirstOrDefault(a => a.Login == adm.Login);
        }

        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produtos; } 
        }

        public void Salvar(Produto produto) {
            if (produto.ProdutoId == 0)
            {
                _context.Produtos.Add(produto);
            } else
            {
                Produto prodAlteracao = _context.Produtos.Find(produto.ProdutoId);

                if (prodAlteracao != null)
                {
                    prodAlteracao.Nome = produto.Nome;
                    prodAlteracao.Preco = produto.Preco;
                    prodAlteracao.Categoria = produto.Categoria;
                    prodAlteracao.Descricao = produto.Descricao;
                }
            }
            _context.SaveChanges();
        }

        public Produto Excluir(int produtoId) {
            Produto prod = _context.Produtos.Find(produtoId);

            if (prod != null)
            {
                _context.Produtos.Remove(prod);
                _context.SaveChanges();
            }

            return prod;
        }
    }
}
