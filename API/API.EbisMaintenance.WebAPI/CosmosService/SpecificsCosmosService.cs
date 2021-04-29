using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EbisMaintenance.WebAPI.CosmosService
{
    public class SpecificsCosmosService<T>
    {
        private Container _container;

        public SpecificsCosmosService(CosmosClient clientDB, string nomDB, string nomContainer)
        {
            _container = clientDB.GetContainer(nomDB, nomContainer);
        }

        public async Task<IEnumerable<T>> GetItemsAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<T>(new QueryDefinition(queryString));

            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }
    }
}