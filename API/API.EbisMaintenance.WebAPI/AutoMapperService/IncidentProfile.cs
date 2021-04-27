using API.EbisMaintenance.Dto.CrudOperations.IncidentDTO;
using API.EbisMaintenance.Entities.CrudOperations.IncidentEntitie;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EbisMaintenance.WebAPI.AutoMapperService
{
    public class IncidentProfile : Profile
    {
        public IncidentProfile()
        {
            MapDtoToEntities();
            MapEntitiesToDto();
        }

        private void MapEntitiesToDto()
        {
            CreateMap<Incident, IncidentDTO>();
        }

        private void MapDtoToEntities()
        {
            CreateMap<IncidentDTO, Incident>();
        }
    }
}