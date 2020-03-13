using AutoMapper;
using funcional_health.Controllers.Resources;
using funcional_health.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API Resource
            CreateMap<ContaCorrente, ContaCorrenteResource>();

            //API Resource to Domain
            CreateMap<ContaCorrenteResource, ContaCorrente>();
            CreateMap<OperacaoResource, Operacao>();
        }
    }
}
