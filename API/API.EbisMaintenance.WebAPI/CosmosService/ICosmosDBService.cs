using API.EbisMaintenance.Entities.CrudOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.EbisMaintenance.Services.CosmosService
{
    public interface ICosmosDBService<T> where T : ModelBase
    {
        Task<T> GetItemAsync(string id);

        Task<IEnumerable<T>> GetItemsAsync(string queryString);

        Task<T> AjouterItemAsync(T item);

        Task<T> SupprimerItemAsync(string id);

        Task<T> ModifierItemAsync(T item);
    }
}