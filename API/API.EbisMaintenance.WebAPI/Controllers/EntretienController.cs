using API.EbisMaintenance.Dto.CrudOperations.EntretiensDTO;
using API.EbisMaintenance.Entities.CrudOperations.EntretienEntitie;
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
    [Route("api/entretiens")]
    public class EntretienController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ICosmosDBService<Entretien> _serviceEntretien;

        public EntretienController(IMapper mapper, ICosmosDBService<Entretien> serviceEntretien)
        {
            _mapper = mapper;
            _serviceEntretien = serviceEntretien;
        }

        [HttpGet]
        public IEnumerable<EntretienDTO> Get()
        {
            var result = _serviceEntretien.GetItemsAsync("select * from c where c.Document = \"entretien\"").GetAwaiter().GetResult();

            List<EntretienDTO> response = new List<EntretienDTO>();

            foreach (var entretien in result)
            {
                response.Add(_mapper.Map<EntretienDTO>(entretien));
            }

            return response;
        }
    }
}