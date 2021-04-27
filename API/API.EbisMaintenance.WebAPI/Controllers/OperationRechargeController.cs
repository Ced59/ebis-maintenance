using API.EbisMaintenance.Dto.CrudOperations.OperationRechargeDTO;
using API.EbisMaintenance.Entities.CrudOperations.OperationRechargeEntitie;
using API.EbisMaintenance.Services.CosmosService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EbisMaintenance.WebAPI.Controllers
{
    [ApiController]
    [Route("api/operations-recharge")]
    public class OperationRechargeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ICosmosDBService<OperationRecharge> _serviceOperationRecharge;

        public OperationRechargeController(IMapper mapper, ICosmosDBService<OperationRecharge> serviceOperationRecharge)
        {
            _mapper = mapper;
            _serviceOperationRecharge = serviceOperationRecharge;
        }

        [HttpGet]
        public IEnumerable<OperationRechargeDTO> Get()
        {
            var result = _serviceOperationRecharge.GetItemsAsync("select * from c").GetAwaiter().GetResult();

            List<OperationRechargeDTO> response = new List<OperationRechargeDTO>();

            foreach (var operationRecharge in result)
            {
                response.Add(_mapper.Map<OperationRechargeDTO>(operationRecharge));
            }

            return response;
        }

        [HttpPost]
        public OperationRechargeDTO Post(OperationRecharge operationRechargeDTO)
        {
            OperationRecharge operationRecharge = _mapper.Map<OperationRecharge>(operationRechargeDTO);

            OperationRecharge newOperationRecharge = _serviceOperationRecharge.AjouterItemAsync(operationRecharge).GetAwaiter().GetResult();

            return _mapper.Map<OperationRechargeDTO>(newOperationRecharge);
        }

        [HttpPut]
        public OperationRechargeDTO Put(OperationRechargeDTO operationRechargeDTO)
        {
            OperationRecharge operationRecharge = _mapper.Map<OperationRecharge>(operationRechargeDTO);

            var operationRechargeModifiee = _serviceOperationRecharge.ModifierItemAsync(operationRecharge).GetAwaiter().GetResult();

            return _mapper.Map<OperationRechargeDTO>(operationRechargeModifiee);
        }

        [HttpDelete]
        public OperationRechargeDTO Delete(OperationRechargeDTO operationRechargeDTO)
        {
            OperationRecharge operationRecharge = _mapper.Map<OperationRecharge>(operationRechargeDTO);

            OperationRecharge operationRechargeSupprimee = _serviceOperationRecharge.SupprimerItemAsync(operationRecharge.Id.ToString()).GetAwaiter().GetResult();

            return _mapper.Map<OperationRechargeDTO>(operationRechargeSupprimee);
        }
    }
}