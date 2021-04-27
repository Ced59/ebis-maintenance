using API.EbisMaintenance.Dto.CrudOperations.UsagerDTO;
using API.EbisMaintenance.Entities.CrudOperations.UsagerEntitie;
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
    [Route("api/usagers")]
    public class UsagerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ICosmosDBService<Usager> _serviceUsager;

        public UsagerController(IMapper mapper, ICosmosDBService<Usager> serviceUsager)
        {
            _mapper = mapper;
            _serviceUsager = serviceUsager;
        }

        [HttpGet]
        public IEnumerable<UsagerDTO> Get()
        {
            var result = _serviceUsager.GetItemsAsync("select * from c").GetAwaiter().GetResult();

            List<UsagerDTO> response = new List<UsagerDTO>();

            foreach (var usager in result)
            {
                response.Add(_mapper.Map<UsagerDTO>(usager));
            }

            return response;
        }
    }
}