using API.EbisMaintenance.Dto.CrudOperations.Borne;
using API.EbisMaintenance.Entities.CrudOperations.Borne;
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
    [Route("api/bornes")]
    public class BornesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ICosmosDBService<Borne> _serviceBornes;

        public BornesController(IMapper mapper, ICosmosDBService<Borne> serviceBornes)
        {
            _mapper = mapper;
            _serviceBornes = serviceBornes;
        }

        [HttpGet]
        public IEnumerable<BorneDTO> Get()
        {
            var result = _serviceBornes.GetItemsAsync("select * from c").GetAwaiter().GetResult();

            List<BorneDTO> response = new List<BorneDTO>();

            foreach (var borne in result)
            {
                response.Add(_mapper.Map<BorneDTO>(borne));
            }

            return response;
        }


        [HttpPost]
        public BorneDTO Post(BorneDTO borneDTO)
        {
            Borne borne = _mapper.Map<Borne>(borneDTO);

            Borne newBorne = _serviceBornes.AjouterItemAsync(borne).GetAwaiter().GetResult();

            return _mapper.Map<BorneDTO>(newBorne);
        }

        [HttpPut]
        public BorneDTO Put(BorneDTO borneDTO)
        {
            Borne borne = _mapper.Map<Borne>(borneDTO);

            Borne borneModifiee = _serviceBornes.ModifierItemAsync(borne).GetAwaiter().GetResult();

            return _mapper.Map<BorneDTO>(borneModifiee);
        }


        [HttpDelete]
        public BorneDTO Delete(BorneDTO borneDTO)
        {
            Borne borne = _mapper.Map<Borne>(borneDTO);

            Borne borneSupprimee = _serviceBornes.SupprimerItemAsync(borne.Id.ToString()).GetAwaiter().GetResult();

            return _mapper.Map<BorneDTO>(borneSupprimee);
        }

    }
}
