using FaithWebApp.Server.Models;
using FaithWebApp.Server.Services.ClientServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FaithWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly IClientService _clientService;

        public PartyController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CClient>>>> GetClients()
        {
            var result = await _clientService.GetClientsAsync();
            return Ok(result);
        }
    }
}
