using FaithWebApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace FaithWebApp.Server.Services.ClientServices
{
    public class ClientService : IClientService
    {
        private readonly DataContext _context;

        public ClientService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<CClient>>> GetClientsAsync()
        {
            var response = new ServiceResponse<List<CClient>>()
            {
                Data = await _context.Clients.ToListAsync(),
            };
            return response;
        }


        public async Task<ServiceResponse<CClient>> GetSingleClient(int clientID)
        {
            var response = new ServiceResponse<CClient>();
            var client = await _context.Clients.SingleOrDefaultAsync(c => c.ClientId == clientID);

            if (client == null)
            {
                response.Success = false;
                response.Message = "This Client does not exist";
            }
            else 
            {
                response.Data = client;
            }
            return response;
        }
    }
}
