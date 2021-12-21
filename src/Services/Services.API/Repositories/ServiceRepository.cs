using MongoDB.Driver;
using Services.API.Data;
using Services.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.API.Repositories
{
    public class ServiceRepository : IServiceRepository
    {

        private readonly IServiceContext _context;

        public ServiceRepository(IServiceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Service>> GetServices()
        {
            return await _context
                            .Services
                            .Find(s => true)
                            .ToListAsync();
        }

        public async Task<Service> GetServiceById(string id)
        {
            return await _context
                            .Services
                            .Find(s => s.id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Service>> GetServiceByStatusId(string statusId)
        {
            FilterDefinition<Service> filter = Builders<Service>.Filter.Eq(s => s.StatusService, statusId);

            return await _context
                            .Services
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task CreateService(Service service)
        {
            await _context.Services.InsertOneAsync(service);
        }

        public async Task<bool> UpdateService(Service service)
        {
            var updateResult = await _context
                                        .Services
                                        .ReplaceOneAsync(filter: s => s.id == service.id, replacement: service);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteService(Service service)
        {
            
            var deleteResult = await _context
                                        .Services
                                        .ReplaceOneAsync(filter: s => s.id == service.id, replacement: service);

            return deleteResult.IsAcknowledged && deleteResult.ModifiedCount > 0;
        }


    }
}
