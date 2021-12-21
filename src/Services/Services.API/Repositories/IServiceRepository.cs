using Services.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.API.Repositories
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetServices();

        Task<Service> GetServiceById(string id);

        Task<IEnumerable<Service>> GetServiceByStatusId(string statusId);

        Task CreateService(Service service);
        Task<bool> UpdateService(Service service);
        Task<bool> DeleteService(Service service);





    }
}
