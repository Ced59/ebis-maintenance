using API.EbisMaintenance.Dto.CrudOperations;
using API.EbisMaintenance.Dto.CrudOperations.BornesDTO;
using API.EbisMaintenance.Entities.CrudOperations;
using API.EbisMaintenance.Entities.CrudOperations.BorneEntitie;
using AutoMapper;

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