using AutoMapper;
using Willians.LojaVirtual.Dominio.Dto;
using Willians.LojaVirtual.Web.V2.Models;

namespace Willians.LojaVirtual.Web.V2.Mappers
{
    public class ViewDomainToMappingProfile : Profile
    {
        public ViewDomainToMappingProfile() {
            CreateMap<DetalhesProdutoViewModel, DetalhesProdutoDto>();
        }

        protected void Configure() {
            Mapper.Initialize(c =>
            {
                c.CreateMap<DetalhesProdutoViewModel, DetalhesProdutoDto>();
            });
        }
    }
}