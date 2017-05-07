using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Willians.LojaVirtual.Web.V2.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings() {
            
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewMappingProfile>();
                x.AddProfile<ViewDomainToMappingProfile>();
                x.CreateMissingTypeMaps = true;
            });
        }

    }
}