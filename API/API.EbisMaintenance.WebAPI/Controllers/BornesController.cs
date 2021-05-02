using API.EbisMaintenance.Dto.CalculatedOperations.AverageElementFunctionnementsDTO;
using API.EbisMaintenance.Dto.CrudOperations.BornesDTO;
using API.EbisMaintenance.Entities.CalculatedOperations.AverageElementFunctionnementsEntities;
using API.EbisMaintenance.Entities.CrudOperations.BorneEntitie;
using API.EbisMaintenance.Services.CosmosService;
using API.EbisMaintenance.WebAPI.CosmosService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.EbisMaintenance.WebAPI.Controllers
{
    [ApiController]
    [Route("api/bornes")]
    public class BornesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ICosmosDBService<Borne> _serviceBornes;
        private SpecificsCosmosService<NombreBorne> _serviceNbBorne;
        private SpecificsCosmosService<ChangementElements> _serviceChangementElements;

        public BornesController(IMapper mapper, ICosmosDBService<Borne> serviceBornes, SpecificsCosmosService<NombreBorne> serviceNbBorne, SpecificsCosmosService<ChangementElements> serviceChangementElements)
        {
            _mapper = mapper;
            _serviceBornes = serviceBornes;
            _serviceNbBorne = serviceNbBorne;
            _serviceChangementElements = serviceChangementElements;
        }

        [HttpGet]
        public IEnumerable<BorneDTO> Get()
        {
            var result = _serviceBornes.GetItemsAsync("select * from c where c.Document = \"borne\"").GetAwaiter().GetResult();

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

        [HttpGet]
        [Route("average-elements-functionnement")]
        public AverageElementFunctionnementDTO GetAverage()
        {

            var nbBornes = _serviceNbBorne.GetItemsAsync("select COUNT(1) as NbreBorne " +
                "from c " +
                "where c.Document = \"borne\"").GetAwaiter().GetResult().ToList();

            var deltaYear = 5;

            var limitDate = "\"" + DateTime.Now.AddYears(-deltaYear).ToString("yyyy-mm-dd") + "\"";

            var changementElement = _serviceChangementElements.GetItemsAsync("select c.Details as Element, COUNT(1) as NbreChangement " +
                "from c " +
                "join(select * from c where c.Document = \"incident\") d " +
                "join(select * from d where d.OperationRecharge.DateHeureFin >= " + limitDate + " ) e " +
                "group by c.Details").GetAwaiter().GetResult().ToList();

            var averageElement = new AverageElementFunctionnement 
            { 
                NbreBorne = nbBornes[0].NbreBorne,
                ChangementElements = changementElement
            };

            var response = _mapper.Map<AverageElementFunctionnementDTO>(averageElement);

            return response;
        }
    }
}