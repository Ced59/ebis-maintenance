using API.EbisMaintenance.Dto.CrudOperations;
using API.EbisMaintenance.Dto.CrudOperations.Borne;
using API.EbisMaintenance.Entities.CrudOperations;
using API.EbisMaintenance.Entities.CrudOperations.Borne;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EbisMaintenance.WebAPI.AutoMapperService
{
    public class BorneProfile : Profile
    {

        public BorneProfile()
        {
            MapDtoToEntities();
            MapEntitiesToDto();
        }

        private void MapEntitiesToDto()
        {
            CreateMap<ModelBase, ModelBaseDTO>();
            CreateMap<Borne, BorneDTO>();
            CreateMap<Station, StationDTO>();
            CreateMap<TypeCharge, TypeChargeDTO>();
        }

        private void MapDtoToEntities()
        {
            CreateMap<ModelBaseDTO, ModelBase>();
            CreateMap<BorneDTO, Borne>();
            CreateMap<StationDTO, Station>();
            CreateMap<TypeChargeDTO, TypeCharge>();
        }
    }
}
