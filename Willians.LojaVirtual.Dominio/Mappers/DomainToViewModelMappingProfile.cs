using AutoMapper;

namespace Willians.LojaVirtual.Dominio.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        // Não realizar este override na versão 4.x e superiores
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

    }
}