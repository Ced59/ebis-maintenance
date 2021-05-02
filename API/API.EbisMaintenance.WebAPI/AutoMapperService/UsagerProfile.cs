using API.EbisMaintenance.Dto.CrudOperations.UsagerDTO;
using API.EbisMaintenance.Entities.CrudOperations.UsagerEntitie;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EbisMaintenance.WebAPI.AutoMapperService
{
    public class UsagerProfile : Profile
    {
        public UsagerProfile()
        {
            MapDtoToEntities();
            MapEntitiesToDto();
        }

        private void MapEntitiesToDto()
        {
            CreateMap<Usager, UsagerDTO>();
            CreateMap<ModeleBatterie, ModeleBatterieDTO>();
            CreateMap<ForfaitPrepaye, ForfaitPrepayeDTO>();
            CreateMap<Contrat, ContratDTO>();
            CreateMap<Abonnement, AbonnementDTO>();
        }

        private void MapDtoToEntities()
        {
            CreateMap<UsagerDTO, Usager>();
            CreateMap<ModeleBatterieDTO, ModeleBatterie>();
            CreateMap<ForfaitPrepayeDTO, ForfaitPrepaye>();
            CreateMap<ContratDTO, Contrat>();
            CreateMap<AbonnementDTO, Abonnement>();
        }
    }
}