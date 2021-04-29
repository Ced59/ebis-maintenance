using API.EbisMaintenance.Entities.CrudOperations.BorneEntitie;
using API.EbisMaintenance.Entities.CrudOperations.EntretienEntitie;
using API.EbisMaintenance.Entities.CrudOperations.IncidentEntitie;
using API.EbisMaintenance.Entities.CrudOperations.OperationRechargeEntitie;
using API.EbisMaintenance.Entities.CrudOperations.UsagerEntitie;
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
                InsertFakeDataInDb(client, nomDB, nomContainer);
            }
        }

        private static void InsertFakeDataInDb(CosmosClient client, string nomDB, string nomContainer)
        {
            List<TypeCharge> typesCharge = GetFakeTypeCharge();
            List<Station> stations = GetFakeStations();
            List<Borne> bornes = GetFakeBornes(typesCharge, stations);

            SaveBornes(bornes, client, nomDB, nomContainer);

            List<Abonnement> abonnements = GetFakeAbonnements();
            List<ForfaitPrepaye> forfaitPrepayes = GetFakeForfaits();
            List<ModeleBatterie> modeleBatteries = GetModeleBatteries();
            List<Contrat> contrats = GetFakeContrats(abonnements, forfaitPrepayes, modeleBatteries);
            List<Usager> usagers = GetFakeUsagers(contrats);

            SaveUsager(usagers, client, nomDB, nomContainer);

            List<Controle> controles = GetFakeControles();
            List<OperationRecharge> operationRecharges = GetOperationsRecharge(controles, bornes, usagers);

            SaveOperationRecharge(operationRecharges, client, nomDB, nomContainer);

            List<Incident> incidents = GetFakeIncidents(operationRecharges);

            SaveIncidents(incidents, client, nomDB, nomContainer);

            List<ElementsVerifies> elementsVerifies = GetFakeElementsVerifies(controles);
            List<Entretien> entretiens = GetFakeEntretiens(elementsVerifies, incidents, bornes);

            SaveEntretiens(entretiens, client, nomDB, nomContainer);
        }

        private static List<Entretien> GetFakeEntretiens(List<ElementsVerifies> elementsVerifies, List<Incident> incidents, List<Borne> bornes)
        {
            var faker = new Faker("fr");

            var entretiens = new List<Entretien>();

            for (var i = 0; i < faker.Random.Int(1, incidents.Count - 5); i++)
            {
                var incident = faker.PickRandom(incidents);

                entretiens.Add(new Entretien
                {
                    Id = Guid.NewGuid(),
                    Document = "entretien",
                    Resolu = faker.Random.Bool(),
                    Borne = faker.PickRandom(bornes),
                    Incident = incident,
                    ElementsVerifies = elementsVerifies.Where(e => e.Libelle == incident.Details).ToList()
                });
            }

            return entretiens;
        }

        private static List<Controle> GetFakeControles()
        {
            var controles = new List<Controle>
            {
                new Controle {Libelle = "Connectiques", Notes = "La prise a une patte cassée"},
                new Controle {Libelle = "Disque dur", Notes = "Disque Dur Plein"},
                new Controle {Libelle = "Appareil Carte Bleue", Notes = "Lecteur de carte défectueux"},
                new Controle {Libelle = "Ecran", Notes = "Ecran déconnecté"},
                new Controle {Libelle = "Ecran", Notes = "Ecran cassé"},
                new Controle {Libelle = "Appareil Carte Bleue", Notes = "Clavier numérique HS"},
                new Controle {Libelle = "Disque Dur", Notes = "Disque Dur défectueux"},
                new Controle {Libelle = "Général", Notes = "Borne en feu: appelez les pompiers"},
                new Controle {Libelle = "Général", Notes = "Borne renversée par poids lourd"},
                new Controle {Libelle = "Connectiques", Notes = "Càble de recharge arraché"},
                new Controle {Libelle = "Routeur", Notes = "WI-FI HS"},
                new Controle {Libelle = "Carte mère", Notes = "L'OS ne démarre plus"},
                new Controle {Libelle = "Alimentation electrique", Notes = "Coupure générale de courant"}
            };

            return controles;
        }

        private static List<Incident> GetFakeIncidents(List<OperationRecharge> operationRecharges)
        {
            var faker = new Faker("fr");

            var detailsIncident = new List<string>
            {
                "Appareil Carte Bleue",
                "Routeur",
                "Carte mère",
                "Alimentation electrique",
                "Disque dur",
                "Général",
                "Connectiques",
                "Joints d'étanchéité",
                "Ecran",
                "Châssis",
                "Controleur de puissance",
                "Disjoncteur",
                "RAM",
                "Carte graphique",
                "Ventilateur"
            };

            var incidents = new List<Incident>();

            for (var i = 0; i < 2000; i++)
            {
                incidents.Add(new Incident
                {
                    Id = Guid.NewGuid(),
                    Document = "incident",
                    Details = faker.PickRandom(detailsIncident),
                    OperationRecharge = faker.PickRandom(operationRecharges)
                });
            }

            return incidents;
        }

        private static List<ElementsVerifies> GetFakeElementsVerifies(List<Controle> controles)
        {
            var elementsverifies = new List<ElementsVerifies>();

            foreach (var controle in controles)
            {
                elementsverifies.Add(new ElementsVerifies
                {
                    Libelle = controle.Libelle,
                    Notes = controle.Notes
                });
            }

            return elementsverifies;
        }

        private static List<OperationRecharge> GetOperationsRecharge(List<Controle> controles, List<Borne> bornes, List<Usager> usagers)
        {
            var faker = new Faker("fr");

            var operationRecharges = new List<OperationRecharge>();

            for (var i = 0; i < 2000; i++)
            {
                var borne = faker.PickRandom(bornes);
                var usager = faker.PickRandom(usagers);
                var dateDebut = faker.Date.Between(borne.DateMiseEnService, DateTime.Now);
                var dateFin = dateDebut.AddHours(faker.Random.Int(1, 24));
                var nbreKwH = (float)(dateFin.Subtract(dateDebut).TotalSeconds * .02);
                var controle = new List<Controle>
                {
                    faker.PickRandom(controles),
                    faker.PickRandom(controles)
                };

                operationRecharges.Add(new OperationRecharge
                {
                    Id = Guid.NewGuid(),
                    Document = "operation-recharge",
                    DateHeureDebut = dateDebut,
                    DateHeureFin = dateFin,
                    NbKwHeures = nbreKwH,
                    Borne = borne,
                    NoContrat = usager.Contrat.NoImmatriculation,
                    Usager = usager,
                    Controle = controle,
                    DemandeEntretien = faker.Random.Bool()
                });
            }

            return operationRecharges;
        }

        private static List<Usager> GetFakeUsagers(List<Contrat> contrats)
        {
            var faker = new Faker("fr");

            var usagers = new List<Usager>();

            for (var i = 0; i < 100; i++)
            {
                usagers.Add(new Usager
                {
                    Id = Guid.NewGuid(),
                    Document = "usager",
                    Nom = faker.Person.LastName,
                    Prenom = faker.Person.FirstName,
                    Adresse = faker.Address.StreetName(),
                    Ville = faker.Address.City(),
                    CodePostal = faker.Address.ZipCode(),
                    TelFixe = faker.Phone.PhoneNumber(),
                    TelMobile = faker.Phone.PhoneNumber(),
                    Contrat = contrats[i]
                });
            }

            return usagers;
        }

        private static List<Contrat> GetFakeContrats(List<Abonnement> abonnements, List<ForfaitPrepaye> forfaitPrepayes, List<ModeleBatterie> modeleBatteries)
        {
            var contrats = new List<Contrat>();

            for (var i = 0; i < 100; i++)
            {
                var dateAbonnement = abonnements[i].DateDebut;

                contrats.Add(new Contrat
                {
                    DateContrat = dateAbonnement.AddDays(15),
                    NoImmatriculation = new Randomizer().Replace("##-???-##"),
                    Abonnement = abonnements[i],
                    ForfaitPrepaye = forfaitPrepayes[i],
                    ModeleBatterie = modeleBatteries[i]
                });
            }

            return contrats;
        }

        private static List<ModeleBatterie> GetModeleBatteries()
        {
            var faker = new Faker("fr");

            List<ModeleBatterie> modeleBatteries = new List<ModeleBatterie>();

            List<string> marquesVoiture = new List<string>
            {
                "Renault",
                "Tesla",
                "Nissan",
                "Lamborghini",
                "Ferrari",
                "Mercedes",
                "Peugeot",
                "Subaru",
                "Audi",
                "Dacia",
                "Porsche",
                "Mini"
            };

            for (var i = 1; i <= 100; i++)
            {
                modeleBatteries.Add(new ModeleBatterie
                {
                    Capacite = faker.Random.Float(80, 560),
                    Fabricant = faker.PickRandom(marquesVoiture)
                });
            }

            return modeleBatteries;
        }

        private static List<ForfaitPrepaye> GetFakeForfaits()
        {
            var faker = new Faker("fr");

            List<ForfaitPrepaye> forfaitPrepayes = new List<ForfaitPrepaye>();

            for (var i = 1; i <= 100; i++)
            {
                forfaitPrepayes.Add(new ForfaitPrepaye
                {
                    SoldeKwHeures = faker.Random.Float(1, 750).ToString()
                });
            }

            return forfaitPrepayes;
        }

        private static List<Abonnement> GetFakeAbonnements()
        {
            var faker = new Faker("fr");

            List<Abonnement> abonnements = new List<Abonnement>();

            for (var i = 1; i <= 100; i++)
            {
                var dateDebut = faker.Date.Between(new DateTime(1980, 1, 1), new DateTime(2020, 1, 1));

                var dateFin = faker.Date.Between(dateDebut, new DateTime(2030, 1, 1));

                abonnements.Add(new Abonnement
                {
                    DateDebut = dateDebut,
                    DateFin = dateFin
                });
            }

            return abonnements;
        }

        private static List<Borne> GetFakeBornes(List<TypeCharge> typesCharge, List<Station> stations)
        {
            var faker = new Faker("fr");

            List<Borne> bornes = new List<Borne>();

            for (var i = 1; i <= 300; i++)
            {
                var dateMiseService = faker.Date.Between(new DateTime(2010, 1, 1), DateTime.Now);

                var dateDerniereRevision = faker.Date.Between(dateMiseService, DateTime.Now);

                var randomNumberStation = faker.Random.Int(1, 4);

                var listTypeChargesSelected = new List<TypeCharge>();

                for (var j = 0; j < randomNumberStation; j++)
                {
                    listTypeChargesSelected.Add(typesCharge[j]);
                }

                bornes.Add(new Borne
                {
                    DateMiseEnService = dateMiseService,
                    DateDerniereRevision = dateDerniereRevision,
                    Station = faker.PickRandom(stations),
                    TypeCharge = listTypeChargesSelected,
                    Document = "borne",
                    Id = Guid.NewGuid()
                });
            }

            return bornes;
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
            var typesCharge = new List<TypeCharge>
            {
                new TypeCharge { Libelle = "Charge lente", Puissance = 3.7F },
                new TypeCharge { Libelle = "Charge moyenne", Puissance = 7.4F },
                new TypeCharge { Libelle = "Charge rapide", Puissance = 11F },
                new TypeCharge { Libelle = "Super-charge", Puissance = 22F }
            };

            return typesCharge;
        }

        private static void SaveBornes(List<Borne> bornes, CosmosClient client, string nomDB, string nomContainer)
        {
            CosmosDBService<Borne> serviceBorne = new CosmosDBService<Borne>(client, nomDB, nomContainer);

            foreach (var borne in bornes)
            {
                serviceBorne.AjouterItemAsync(borne).GetAwaiter().GetResult();
            }
        }

        private static void SaveUsager(List<Usager> usagers, CosmosClient client, string nomDB, string nomContainer)
        {
            CosmosDBService<Usager> serviceUsager = new CosmosDBService<Usager>(client, nomDB, nomContainer);

            foreach (var usager in usagers)
            {
                serviceUsager.AjouterItemAsync(usager).GetAwaiter().GetResult();
            }
        }

        private static void SaveOperationRecharge(List<OperationRecharge> operationRecharges, CosmosClient client, string nomDB, string nomContainer)
        {
            CosmosDBService<OperationRecharge> serviceOperationRecharge = new CosmosDBService<OperationRecharge>(client, nomDB, nomContainer);

            foreach (var op in operationRecharges)
            {
                serviceOperationRecharge.AjouterItemAsync(op).GetAwaiter().GetResult();
            }
        }

        private static void SaveIncidents(List<Incident> incidents, CosmosClient client, string nomDB, string nomContainer)
        {
            CosmosDBService<Incident> serviceIncident = new CosmosDBService<Incident>(client, nomDB, nomContainer);

            foreach (var ic in incidents)
            {
                serviceIncident.AjouterItemAsync(ic).GetAwaiter().GetResult();
            }
        }

        private static void SaveEntretiens(List<Entretien> entretiens, CosmosClient client, string nomDB, string nomContainer)
        {
            CosmosDBService<Entretien> serviceEntretien = new CosmosDBService<Entretien>(client, nomDB, nomContainer);

            foreach (var e in entretiens)
            {
                serviceEntretien.AjouterItemAsync(e).GetAwaiter().GetResult();
            }
        }
    }
}