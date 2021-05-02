using API.EbisMaintenance.Dto.CalculatedOperations.AverageElementFunctionnementsDTO;
using API.EbisMaintenance.Entities.CalculatedOperations.AverageElementFunctionnementsEntities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EbisMaintenance.WebAPI.AutoMapperService
{
    public class AverageElementFunctionnementProfile : Profile
    {
        public AverageElementFunctionnementProfile()
        {
            MapDtoToEntities();
            MapEntitiesToDto();
        }

        private void MapEntitiesToDto()
        {
            CreateMap<AverageElementFunctionnement, AverageElementFunctionnementDTO>();
            CreateMap<ChangementElements, ChangementElementsDTO>();
        }

        private void MapDtoToEntities()
        {
            CreateMap<AverageElementFunctionnementDTO, AverageElementFunctionnement>();
            CreateMap<ChangementElementsDTO, ChangementElements>();
        }
    }
}
