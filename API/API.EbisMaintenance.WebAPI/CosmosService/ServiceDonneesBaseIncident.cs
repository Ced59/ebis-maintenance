using API.EbisMaintenance.Entities.CrudOperations.BorneEntitie;
using API.EbisMaintenance.Entities.CrudOperations.IncidentEntitie;
using API.EbisMaintenance.Entities.CrudOperations.OperationRechargeEntitie;
using API.EbisMaintenance.Entities.CrudOperations.UsagerEntitie;
using API.EbisMaintenance.Services.CosmosService;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EbisMaintenance.WebAPI.CosmosService
{
    public class ServiceDonneesBaseIncident
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

            // Usager

            Abonnement abonnement = new Abonnement()
            {
                DateDebut = new DateTime(1970, 5, 15),
                DateFin = new DateTime(2020, 6, 23)
            };

            ForfaitPrepaye forfaitPrepaye = new ForfaitPrepaye()
            {
                SoldeKwHeures = "20.5"
            };

            ModeleBatterie modeleBatterie = new ModeleBatterie()
            {
                Fabricant = "Toyota",
                Capacite = 100F
            };

            Contrat contrat = new Contrat()
            {
                DateContrat = new DateTime(1970, 5, 15),
                NoImmatriculation = "56-BDG-99",
                Abonnement = abonnement,
                ForfaitPrepaye = forfaitPrepaye,
                ModeleBatterie = modeleBatterie
            };

            Usager usager = new Usager()
            {
                Id = Guid.NewGuid(),
                Document = "usager",
                Nom = "Delamarre",
                Prenom = "Théo",
                Adresse = "56 rue des peupliers",
                Ville = "Roulard",
                CodePostal = "56892",
                TelFixe = "03.56.25.22.22",
                TelMobile = "06.88.99.88.88",
                Contrat = contrat
            };

            var serviceUsager = new CosmosDBService<Usager>(client, nomDB, nomContainer);
            serviceUsager.AjouterItemAsync(usager).GetAwaiter().GetResult();

            // Opération Recharge

            Controle controle1 = new Controle()
            {
                Libelle = "Prise",
                Notes = "La prise à une patte cassée"
            };

            Controle controle2 = new Controle()
            {
                Libelle = "Disque Dur",
                Notes = "Disque Dur Plein"
            };

            Controle controle3 = new Controle()
            {
                Libelle = "Appareil Carte",
                Notes = "Lecteur de carte défectueux"
            };

            Controle controle4 = new Controle()
            {
                Libelle = "Routeur",
                Notes = "Routeur HS"
            };

            List<Controle> listControle1 = new List<Controle> { controle1, controle2 };
            List<Controle> listControle2 = new List<Controle> { controle3, controle4 };
            List<Controle> listControle3 = new List<Controle> { controle1, controle3 };
            List<Controle> listControle4 = new List<Controle> { controle2, controle4 };

            OperationRecharge operationRecharge1 = new OperationRecharge()
            {
                Id = Guid.NewGuid(),
                Document = "operation-recharge",
                DateHeureDebut = new DateTime(1999, 5, 11),
                DateHeureFin = new DateTime(1999, 5, 12),
                NbKwHeures = 2.04F,
                Borne = borne,
                NoContrat = "1L",
                Usager = usager,
                Controle = listControle1,
                DemandeEntretien = true
            };

            OperationRecharge operationRecharge2 = new OperationRecharge()
            {
                Id = Guid.NewGuid(),
                Document = "operation-recharge",
                DateHeureDebut = new DateTime(1970, 5, 11),
                DateHeureFin = new DateTime(1970, 5, 12),
                NbKwHeures = 1.04F,
                Borne = borne,
                NoContrat = "2L",
                Usager = usager,
                Controle = listControle2,
                DemandeEntretien = true
            };

            OperationRecharge operationRecharge3 = new OperationRecharge()
            {
                Id = Guid.NewGuid(),
                Document = "operation-recharge",
                DateHeureDebut = new DateTime(2000, 5, 11),
                DateHeureFin = new DateTime(2000, 5, 12),
                NbKwHeures = 6F,
                Borne = borne,
                NoContrat = "3L",
                Usager = usager,
                Controle = listControle3,
                DemandeEntretien = true
            };

            OperationRecharge operationRecharge4 = new OperationRecharge()
            {
                Id = Guid.NewGuid(),
                Document = "operation-recharge",
                DateHeureDebut = new DateTime(2016, 9, 11),
                DateHeureFin = new DateTime(2016, 9, 12),
                NbKwHeures = 2.04F,
                Borne = borne,
                NoContrat = "4L",
                Usager = usager,
                Controle = listControle4,
                DemandeEntretien = true
            };

            var serviceOperationRecharge = new CosmosDBService<OperationRecharge>(client, nomDB, nomContainer);
            serviceOperationRecharge.AjouterItemAsync(operationRecharge1).GetAwaiter().GetResult();
            serviceOperationRecharge.AjouterItemAsync(operationRecharge2).GetAwaiter().GetResult();
            serviceOperationRecharge.AjouterItemAsync(operationRecharge3).GetAwaiter().GetResult();
            serviceOperationRecharge.AjouterItemAsync(operationRecharge4).GetAwaiter().GetResult();

            //Service Incident

            Incident incident1 = new Incident()
            {
                Details = "Prise et Disque dur",
                OperationRecharge = operationRecharge1,
                Id = Guid.NewGuid(),
                Document = "incident"
            };

            Incident incident2 = new Incident()
            {
                Details = "Appareil Carte et Routeur",
                OperationRecharge = operationRecharge2,
                Id = Guid.NewGuid(),
                Document = "incident"
            };

            Incident incident3 = new Incident()
            {
                Details = "Prise et Appareil Carte",
                OperationRecharge = operationRecharge3,
                Id = Guid.NewGuid(),
                Document = "incident"
            };

            Incident incident4 = new Incident()
            {
                Details = "Routeur et Disque dur",
                OperationRecharge = operationRecharge4,
                Id = Guid.NewGuid(),
                Document = "incident"
            };
            var serviceIncident = new CosmosDBService<Incident>(client, nomDB, nomContainer);
            serviceIncident.AjouterItemAsync(incident1).GetAwaiter().GetResult();
            serviceIncident.AjouterItemAsync(incident2).GetAwaiter().GetResult();
            serviceIncident.AjouterItemAsync(incident3).GetAwaiter().GetResult();
            serviceIncident.AjouterItemAsync(incident4).GetAwaiter().GetResult();
        }
    }
}