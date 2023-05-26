using FaithWebApp.Server.Services.ClientServices;
using FaithWebApp.Shared;
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
        public async Task<ActionResult<ServiceResponse<List<Party>>>> GetClients()
        {
            var result = await _clientService.GetClientsAsync();
            return Ok(result);
        }

		[HttpGet("{clientID}")]
		public async Task<ActionResult<ServiceResponse<Party>>> GetSingleClient(int clientID)
		{
			var result = await _clientService.GetSingleClient(clientID);
			return Ok(result);
		}
	}
}
