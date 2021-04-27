using API.EbisMaintenance.Dto.CrudOperations.EntretiensDTO;
using API.EbisMaintenance.Entities.CrudOperations.EntretienEntitie;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EbisMaintenance.WebAPI.AutoMapperService
{
    public class EntretienProfile : Profile
    {
        public EntretienProfile()
        {
            MapDtoToEntities();
            MapEntitiesToDto();
        }

        private void MapEntitiesToDto()
        {
            CreateMap<Entretien, EntretienDTO>();
            CreateMap<ElementsVerifies, ElementsVerifiesDTO>();
        }

        private void MapDtoToEntities()
        {
            CreateMap<EntretienDTO, Entretien>();
            CreateMap<ElementsVerifiesDTO, ElementsVerifies>();
        }
    }
}