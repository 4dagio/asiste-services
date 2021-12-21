using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.API.Entities;
using Services.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Services.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _repository;
        private readonly ILogger<ServiceController> _logger;

        public ServiceController(IServiceRepository repository, ILogger<ServiceController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Service>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices() 
        {
            var services = await _repository.GetServices();
            return Ok(services);
        }

        [HttpGet("{id:length(24)}", Name = "GetServiceById")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Service), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Service>> GetServiceById(string id)
        {
            var service = await _repository.GetServiceById(id);
            if (service == null)
            {
                _logger.LogError($"Service with id: {id}, not found.");
                return NotFound();

            }
            return Ok(service);
        }

        [Route("[action]/{stateId}", Name = "GetServicesByStatusId")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Service>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Service>>> GetServicesByStatusId(string id)
        {
            var services = await _repository.GetServiceByStatusId(id);
            return Ok(services);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Service), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Service>> CreateService([FromBody] Service service) 
        {
            await _repository.CreateService(service);
            return CreatedAtRoute("GetServiceById", new { id = service.id }, service);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Service), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateService([FromBody] Service service)
        {
            return Ok(await _repository.UpdateService(service));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteService")]

        [ProducesResponseType(typeof(Service), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteServiceById([FromBody] Service service)
        {
            return Ok(await _repository.DeleteService(service));
        }
    }
}
