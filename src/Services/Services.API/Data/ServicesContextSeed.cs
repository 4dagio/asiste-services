using MongoDB.Driver;
using Services.API.Entities;
using System;
using System.Collections.Generic;

namespace Services.API.Data
{
    public class ServicesContextSeed
    {
        public static void SeedData(IMongoCollection<Service> serviceCollection) 
        {
            bool existService = serviceCollection.Find(s => true).Any();
            if(!existService)
            {
                serviceCollection.InsertManyAsync(GetpreconfiguredServices());
            }
        }

        private static IEnumerable<Service> GetpreconfiguredServices()
        {
            return new List<Service>()
            {
                new Service()
                {
                    id = "61b7720405357c159437bddd",
                    Expedient = "CE-Test",
                    ServicePlate = "XXX000",
                    ServicePrice = 1000,
                    UserMobile = "+57350123456",
                    UserName = "Test",
                    UserPhone = "+57123456789"


                }
            };
        }
    }
}
