using API.EbisMaintenance.Entities.CrudOperations.BorneEntitie;
using API.EbisMaintenance.Services.CosmosService;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EbisMaintenance.WebAPI.CosmosService
{
    public class ServiceDonneesBase
    {
        public static void GenererDonneesBase(CosmosClient client, string nomDB, string nomContainer)
        {
            Station station = new Station()
            {
                Latitude = "33.7866",
                Longitude = "-118.2987",
                AdresseRue = "5 rue de Beverly hills",
                AdresseVille = "Hill Valey",
                CodePostal = "90210"
            };

            TypeCharge tc1 = new TypeCharge()
            {
                Libelle = "efficace et sûre",
                Puissance = "5.4"
            };

            TypeCharge tc2 = new TypeCharge()
            {
                Libelle = "faut se mefier",
                Puissance = "152.2"
            };

            List<TypeCharge> typesCharge = new List<TypeCharge> { tc1, tc2 };

            Borne borne = new Borne()
            {
                DateMiseEnService = new DateTime(1955, 11, 5),
                DateDerniereRevision = new DateTime(1985, 10, 26),
                Station = station,
                TypeCharge = typesCharge,
                Id = Guid.NewGuid(),
                Document = "borne"
            };

            CosmosDBService<Borne> serviceBorne = new CosmosDBService<Borne>(client, nomDB, nomContainer);

            serviceBorne.AjouterItemAsync(borne).GetAwaiter().GetResult();
        }
    }
}
