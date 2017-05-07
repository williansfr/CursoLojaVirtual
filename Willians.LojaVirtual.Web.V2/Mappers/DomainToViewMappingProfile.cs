using AutoMapper;
using Willians.LojaVirtual.Dominio.Dto;
using Willians.LojaVirtual.Web.V2.Models;

namespace Willians.LojaVirtual.Web.V2.Mappers
{
    public class DomainToViewMappingProfile : Profile
    {
        public DomainToViewMappingProfile() {
            CreateMap<DetalhesProdutoDto, DetalhesProdutoViewModel>();
        }

        protected void Configure()
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<DetalhesProdutoDto, DetalhesProdutoViewModel>();
            });
        }
    }
}