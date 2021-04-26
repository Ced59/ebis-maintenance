using API.EbisMaintenance.Entities.CrudOperations;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EbisMaintenance.Services.CosmosService
{
    public class CosmosDBService<T> : ICosmosDBService<T> where T : ModelBase
    {
        private Container _container;

        public CosmosDBService(CosmosClient clientDB, string nomDB, string nomContainer)
        {
            _container = clientDB.GetContainer(nomDB, nomContainer);
        }

        public async Task<T> GetItemAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<T>(id, new PartitionKey(typeof(T).ToString()));

                return response.Resource;
            }
            catch (CosmosException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
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

        public async Task<T> AjouterItemAsync(T item)
        {
            try
            {
                ItemResponse<T> response = await _container.CreateItemAsync<T>(item, new PartitionKey(item.Id.ToString()));

                return response.Resource;
            }
            catch (CosmosException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<T> SupprimerItemAsync(string id)
        {
            try
            {
                ItemResponse<T> response = await _container.DeleteItemAsync<T>(id, new PartitionKey(typeof(T).ToString()));

                return response.Resource;
            }
            catch (CosmosException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<T> ModifierItemAsync(T item)
        {
            try
            {
                ItemResponse<T> response = await _container.UpsertItemAsync<T>(item, new PartitionKey(typeof(T).ToString()));

                return response.Resource;
            }
            catch (CosmosException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}