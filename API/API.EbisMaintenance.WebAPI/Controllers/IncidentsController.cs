using API.EbisMaintenance.Dto.CalculatedOperations.IncidentsMonthlyAveragesDTO;
using API.EbisMaintenance.Dto.CalculatedOperations.TopFiveElementsWithIncidentsDTO;
using API.EbisMaintenance.Dto.CrudOperations.IncidentsDTO;
using API.EbisMaintenance.Entities.CalculatedOperations.IncidentsMonthlyAverageEntities;
using API.EbisMaintenance.Entities.CalculatedOperations.TopFiveElementsWithIncidentsEntities;
using API.EbisMaintenance.Entities.CrudOperations.IncidentEntitie;
using API.EbisMaintenance.Services.CosmosService;
using API.EbisMaintenance.WebAPI.CosmosService;
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
        private SpecificsCosmosService<StatElementDefectueux> _serviceTopFive;

        public IncidentsController(IMapper mapper, ICosmosDBService<Incident> serviceIncident, SpecificsCosmosService<StatElementDefectueux> serviceTopFive)
        {
            _mapper = mapper;
            _serviceIncident = serviceIncident;
            _serviceTopFive = serviceTopFive;
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

        [HttpGet]
        [Route("get-average")]
        public IncidentsMonthlyAverageDTO GetAverageIncidents()
        {
            var deltaYear = 5;

            var allIncidents = _serviceIncident.GetItemsAsync("select * from c where c.Document = \"incident\"").GetAwaiter().GetResult().ToList();

            var statsIncidents = new IncidentsMonthlyAverage(allIncidents);
            var result = statsIncidents.GetStats(deltaYear);

            var response = _mapper.Map<IncidentsMonthlyAverageDTO>(result);

            return response;
        }

        [HttpGet]
        [Route("top-five-defective-elements")]
        public List<StatElementDefectueuxDTO> GetTopFiveIncidentsElements()
        {
            List<StatElementDefectueux> statsElements = RequestLaunch();

            var statsDefectivesElementsSorted = statsElements.OrderByDescending(x => x.NbreIncidents).ToList().GetRange(0, 5);

            var response = new List<StatElementDefectueuxDTO>();

            foreach (var elt in statsDefectivesElementsSorted)
            {
                response.Add(_mapper.Map<StatElementDefectueuxDTO>(elt));
            }

            return response;
        }

        [HttpGet]
        [Route("top-five-reliable-elements")]
        public List<StatElementDefectueuxDTO> GetTopFiveReliableElements()
        {
            List<StatElementDefectueux> statsElements = RequestLaunch();

            var statsReliableElementsSorted = statsElements.OrderBy(x => x.NbreIncidents).ToList().GetRange(0, 5);

            var response = new List<StatElementDefectueuxDTO>();

            foreach (var elt in statsReliableElementsSorted)
            {
                response.Add(_mapper.Map<StatElementDefectueuxDTO>(elt));
            }

            return response;
        }

        private List<StatElementDefectueux> RequestLaunch()
        {
            var deltaYear = 5;

            var limitDate = "\"" + DateTime.Now.AddYears(-deltaYear).ToString("yyyy-mm-dd") + "\"";

            var statsDefectivesElements = _serviceTopFive.GetItemsAsync("select c.Details as Element, COUNT(1) as NbreIncidents " +
                "from c " +
                "join(select * from c where c.Document = \"incident\") d " +
                "join(select * from d where d.OperationRecharge.DateHeureFin >= " + limitDate + " ) e " +
                "group by c.Details").GetAwaiter().GetResult().ToList();

            return statsDefectivesElements;
        }
    }
}