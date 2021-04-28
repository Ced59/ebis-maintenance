using API.EbisMaintenance.Dto.CalculatedOperations.IncidentsMonthlyAveragesDTO;
using API.EbisMaintenance.Entities.CalculatedOperations.IncidentsMonthlyAverageEntities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EbisMaintenance.WebAPI.AutoMapperService
{
    public class IncidentMonthlyAverageProfile : Profile
    {
        public IncidentMonthlyAverageProfile()
        {
            MapDtoToEntities();
            MapEntitiesToDto();
        }

        private void MapEntitiesToDto()
        {
            CreateMap<IncidentsMonthlyAverage, IncidentsMonthlyAverageDTO>();
            CreateMap<MonthlyIncidentCount, MonthlyIncidentCountDTO>();
        }

        private void MapDtoToEntities()
        {
            CreateMap<IncidentsMonthlyAverageDTO, IncidentsMonthlyAverageDTO>();
            CreateMap<MonthlyIncidentCountDTO, MonthlyIncidentCount>();
        }
    }
}