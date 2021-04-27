using API.EbisMaintenance.Entities.CrudOperations.BorneEntitie;
using API.EbisMaintenance.Entities.CrudOperations.OperationRechargeEntitie;
using API.EbisMaintenance.Services.CosmosService;
using Bogus;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.EbisMaintenance.WebAPI.CosmosService
{
    public class ServiceDonneesBase
    {
        public static void GenererDonneesBase(CosmosClient client, string nomDB, string nomContainer)
        {
            var serviceOperationRecharge = new CosmosDBService<OperationRecharge>(client, nomDB, nomContainer);

            if (serviceOperationRecharge.GetItemsAsync("select * from c").GetAwaiter().GetResult().ToList().Count == 0)
            {
                InsertFakeDataInDb();
            }

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
                Puissance = 5.4F
            };

            TypeCharge tc2 = new TypeCharge()
            {
                Libelle = "faut se mefier",
                Puissance = 152.2F
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

        private static void InsertFakeDataInDb()
        {
            List<TypeCharge> typesCharge = GetFakeTypeCharge();
            List<Station> stations = GetFakeStations();
        }

        private static List<Station> GetFakeStations()
        {
            var faker = new Faker("fr");

            List<Station> stations = new List<Station>();

            for (var i = 1; i <= 50; i++)
            {
                stations.Add(new Station
                {
                    Latitude = faker.Address.Latitude(-90, 90).ToString(),
                    Longitude = faker.Address.Longitude(-180, 180).ToString(),
                    AdresseRue = faker.Address.StreetName(),
                    AdresseVille = faker.Address.City(),
                    CodePostal = faker.Address.ZipCode()
                });
            }

            return stations;
        }

        private static List<TypeCharge> GetFakeTypeCharge()
        {
            var typesCharge = new List<TypeCharge>();

            typesCharge.Add(new TypeCharge { Libelle = "Charge lente", Puissance = 3.7F });
            typesCharge.Add(new TypeCharge { Libelle = "Charge moyenne", Puissance = 7.4F });
            typesCharge.Add(new TypeCharge { Libelle = "Charge rapide", Puissance = 11F });
            typesCharge.Add(new TypeCharge { Libelle = "Super-charge", Puissance = 22F });

            return typesCharge;
        }
    }
}