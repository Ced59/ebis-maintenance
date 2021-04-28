using API.EbisMaintenance.Entities.CrudOperations.BorneEntitie;
using API.EbisMaintenance.Entities.CrudOperations.EntretienEntitie;
using API.EbisMaintenance.Entities.CrudOperations.IncidentEntitie;
using API.EbisMaintenance.Entities.CrudOperations.OperationRechargeEntitie;
using API.EbisMaintenance.Entities.CrudOperations.UsagerEntitie;
using API.EbisMaintenance.Services.CosmosService;
using API.EbisMaintenance.WebAPI.AutoMapperService;
using API.EbisMaintenance.WebAPI.CosmosService;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API.EbisMaintenance.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Auto Mapper
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<BorneProfile>();
                config.AddProfile<OperationRechargeProfile>();
                config.AddProfile<UsagerProfile>();
                config.AddProfile<IncidentProfile>();
                config.AddProfile<EntretienProfile>();
                config.AddProfile<IncidentMonthlyAverageProfile>();
            });

            services.AddAutoMapper(typeof(Startup));

            // Configuration CosmosDB
            IConfigurationSection configurationSection = Configuration.GetSection("CosmosDB");
            string nomDB = configurationSection.GetSection("nomDB").Value;
            string nomContainer = configurationSection.GetSection("nomContainer").Value;
            string compte = configurationSection.GetSection("compte").Value;
            string cle = configurationSection.GetSection("cle").Value;

            CosmosClientBuilder clientBuilder = new CosmosClientBuilder(compte, cle);
            CosmosClient client = clientBuilder
                                                    .WithConnectionModeDirect()
                                                    .Build();

            // Création effective de la BDD
            DatabaseResponse db = client.CreateDatabaseIfNotExistsAsync(nomDB).GetAwaiter().GetResult();

            // Création du container
            db.Database.CreateContainerIfNotExistsAsync(nomContainer, "/id").GetAwaiter().GetResult();

            // Création et enregistrement des services par injection de dépendances
            CosmosDBService<Borne> serviceBorne = new CosmosDBService<Borne>(client, nomDB, nomContainer);
            services.AddSingleton<ICosmosDBService<Borne>>(serviceBorne);

            CosmosDBService<OperationRecharge> serviceOperationRecharge = new CosmosDBService<OperationRecharge>(client, nomDB, nomContainer);
            services.AddSingleton<ICosmosDBService<OperationRecharge>>(serviceOperationRecharge);

            CosmosDBService<Usager> serviceUsager = new CosmosDBService<Usager>(client, nomDB, nomContainer);
            services.AddSingleton<ICosmosDBService<Usager>>(serviceUsager);

            CosmosDBService<Incident> serviceIncident = new CosmosDBService<Incident>(client, nomDB, nomContainer);
            services.AddSingleton<ICosmosDBService<Incident>>(serviceIncident);

            CosmosDBService<Entretien> serviceEntretien = new CosmosDBService<Entretien>(client, nomDB, nomContainer);
            services.AddSingleton<ICosmosDBService<Entretien>>(serviceEntretien);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "E-Bis Maintenance API", Version = "v0.0.1" });
            });

            // Décommenter pour garnir la bdd
            ServiceDonneesBase.GenererDonneesBase(client, nomDB, nomContainer);
            //ServiceDonneesBaseIncident.GenererDonneesBase(client, nomDB, nomContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API E-Bis Maintenance");
                c.RoutePrefix = "api";
            }
            );

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}