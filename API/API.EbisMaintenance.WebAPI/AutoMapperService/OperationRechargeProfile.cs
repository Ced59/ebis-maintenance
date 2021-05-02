using API.EbisMaintenance.Dto.CrudOperations.OperationsRechargeDTO;
using API.EbisMaintenance.Entities.CrudOperations.OperationRechargeEntitie;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EbisMaintenance.WebAPI.AutoMapperService
{
    public class OperationRechargeProfile : Profile
    {
        public OperationRechargeProfile()
        {
            MapDtoToEntities();
            MapEntitiesToDto();
        }

        private void MapEntitiesToDto()
        {
            CreateMap<OperationRecharge, OperationRechargeDTO>();
            CreateMap<Controle, ControleDTO>();
        }

        private void MapDtoToEntities()
        {
            CreateMap<OperationRechargeDTO, OperationRecharge>();
            CreateMap<ControleDTO, Controle>();
        }
    }
}