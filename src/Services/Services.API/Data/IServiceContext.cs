using MongoDB.Driver;
using Services.API.Entities;

namespace Services.API.Data
{
    public interface IServiceContext
    {
        IMongoCollection<Service> Services { get;  }
    }
}
