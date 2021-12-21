using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Services.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.API.Data
{
    public class ServiceContext : IServiceContext
    {

        public ServiceContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Services = database.GetCollection<Service>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            ServicesContextSeed.SeedData(Services);

        }

        public IMongoCollection<Service> Services { get; }
    }
}
