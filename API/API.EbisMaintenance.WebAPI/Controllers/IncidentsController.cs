using API.EbisMaintenance.Dto.CrudOperations.IncidentsDTO;
using API.EbisMaintenance.Entities.CrudOperations.IncidentEntitie;
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
    [Route("api/incidents")]
    public class IncidentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ICosmosDBService<Incident> _serviceIncident;

        public IncidentsController(IMapper mapper, ICosmosDBService<Incident> serviceIncident)
        {
            _mapper = mapper;
            _serviceIncident = serviceIncident;
        }

        [HttpGet]
        public IEnumerable<IncidentDTO> Get()
        {
            var result = _serviceIncident.GetItemsAsync("select * from c where c.Document = \"incident\"").GetAwaiter().GetResult();

            List<IncidentDTO> response = new List<IncidentDTO>();

            foreach (var incident in result)
            {
                response.Add(_mapper.Map<IncidentDTO>(incident));
            }

            return response;
        }
    }
}