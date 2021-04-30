**E-bis Maintenance**

Projet réalisé dans le cadre de la formation CDA 2020/2021 de Valarep

Membres du groupe:
    Vincent Brocheton : Chef de projet, développeur
    Cédric Caudron  : Tech Lead
    Ambroise Linquette : Responsable réseau, développeur

Projet sous la forme:
    -d'une API en ASP.NET Core
    -d'une base de données NoSQL sous Cosmos DB
    -d'un client lourd en WPF



Pour tester et lancer:
    
  - Installer et lancer Cosmos DB Emulator
  - Configurer les "secret user" du coté API en y ajoutant ce JSON: (adaptez selon vos besoins)

```
              {
                 "CosmosDB": 
                 {
                  "nomDB": "EbisMaintenanceApp",
                   "nomContainer": "EbisMaintenanceAppContainer",
                    "compte": "https://localhost:8081/",
                    "cle": "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw=="
                  }
              }

```

    - Lancer l'API dans une instance de votre IDE (Visual Studio conseillé)
    - Au premier lancement de l'API, un système de création de fausses données sera lancé. Ce premier lancement est donc assez long (environ 4mn) 
    - Une fois l'API lancée, dans une nouvelle instance de votre IDE, lancez le client lourd WPF
    - Tout est prêt, Enjoy Test ;-)

Vous pouvez, de plus, accéder aux différents endpoints de l'API (mise en forme: Swagger) en suivant cette adresse:
    -  https://localhost:44360/api


Projet réalisé en une semaine. Donc bien sûr il est loin d'être parfait. Les principales fonctionnalités demandées ont par ailleurs été implémentées. De nombreux axes d'améliorations sont possibles, que ce soit coté code (refactorisation, gérénicité), ou coté expérience utilisateur.
