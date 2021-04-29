using API.EbisMaintenance.Dto.CalculatedOperations.TopFiveElementsWithIncidentsDTO;
using API.EbisMaintenance.Entities.CalculatedOperations.TopFiveElementsWithIncidentsEntities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EbisMaintenance.WebAPI.AutoMapperService
{
    public class TopFiveElementsDefectueuxProfile : Profile
    {
        public TopFiveElementsDefectueuxProfile()
        {
            MapDtoToEntities();
            MapEntitiesToDto();
        }

        private void MapEntitiesToDto()
        {
            CreateMap<StatElementDefectueux, StatElementDefectueuxDTO>();
        }

        private void MapDtoToEntities()
        {
            CreateMap<StatElementDefectueuxDTO, StatElementDefectueux>();
        }
    }
}