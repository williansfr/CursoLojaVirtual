using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willians.LojaVirtual.Dominio.Dto;
using Willians.LojaVirtual.Dominio.Entidade;
using Willians.LojaVirtual.Dominio.Entidade.Vitrine;
using FastMapper;

namespace Willians.LojaVirtual.Dominio.Repositorio
{
    public class MenuRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Categoria> ObterCategorias()
        {
            return _context.Categorias.OrderBy(c => c.CategoriaDescricao);
        }

        /// <summary>
        /// Obter Algumas Marcas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MarcaVitrine> ObterMarcas()
        {
            return _context.MarcaVitrine.OrderBy(c => c.MarcaDescricao);
        }

        #region Clubes
        public IEnumerable<ClubesNacionais> ObterClubesNacionais()
        {
            return _context.ClubesNacionais.OrderBy(c => c.LinhaDescricao);
        }

        public IEnumerable<ClubesInternacionais> ObterClubesInternacionais()
        {
            return _context.ClubesInternacionais.OrderBy(c => c.LinhaDescricao);
        }

        public IEnumerable<Selecoes> ObterSelecoes()
        {
            return _context.Selecoes.OrderBy(c => c.LinhaDescricao);
        }
        #endregion Clubes


        public IEnumerable<Categoria> ObterTenisPorCategoria()
        {
            var categorias = new[] { "0005", "0082", "0112", "0010", "0006", "0063" };
            return _context.Categorias.Where(c => categorias.Contains(c.CategoriaCodigo)).OrderBy(c => c.CategoriaDescricao);
        }

        public SubGrupo SubGrupoTenis()
        {
            return _context.SubGrupos.FirstOrDefault(s => s.SubGrupoCodigo == "0084");
        }

        #region Menu Casual Lateral

        public Modalidade ModalidadeCasual()
        {
            const string CODIGO_MODALIDADE = "0001";

            return _context.Modalidades.FirstOrDefault(m => m.ModalidadeCodigo == CODIGO_MODALIDADE);
        }

        public IEnumerable<SubGrupoDto> ObterCasualSubGrupo()
        {
            var subGrupos = new[] { "0001", "0102", "0103", "0738", "0084", "0921" };

            var query = from s in _context.SubGrupos
                            .Where(c => subGrupos.Contains(c.SubGrupoCodigo))
                            .Select(s => new { s.SubGrupoCodigo, s.SubGrupoDescricao })
                            .Distinct()
                            .OrderBy(d => d.SubGrupoDescricao)

                        select new
                        {
                            s.SubGrupoCodigo,
                            s.SubGrupoDescricao
                        };

                        //Auto Mapeamento FastMapper
                        return query.Project().To<SubGrupoDto>().ToList();

                        //select new SubGrupoDto
                        //{
                        //    SubGrupoCodigo = s.SubGrupoCodigo,
                        //    SubGrupoDescricao = s.SubGrupoDescricao
                        //};

                        //return query;
        }

        #endregion Menu Casual Lateral

        #region [Suplementos]

        public Categoria Suplemento()
        {
            var categoriaSuplementos = "0008";

            return _context.Categorias
                .FirstOrDefault(s => s.CategoriaCodigo == categoriaSuplementos);
        }

        public IEnumerable<SubGrupo> ObterSuplementos()
        {
            var subGrupos = new[]
            {
                "0162","0381","0557","0564","0565","1082","1083","1084","1085", "0977"
            };
            return _context.SubGrupos
                .Where(s => subGrupos.Contains(s.SubGrupoCodigo) && s.GrupoCodigo == "0012")
                .OrderBy(s => s.SubGrupoDescricao);
        }

        #endregion
    }
}
