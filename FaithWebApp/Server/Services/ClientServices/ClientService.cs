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
        public async Task<ServiceResponse<List<Party>>> GetClientsAsync()
        {
            var response = new ServiceResponse<List<Party>>()
            {
                Data = await _context.Clients
                            .Include(c => c.City)
                            .ToListAsync(),
            };
            return response;
        }


        public async Task<ServiceResponse<Party>> GetSingleClient(int clientID)
        {
            var response = new ServiceResponse<Party>();
            var client = await _context.Clients
                .Include(c => c.City)
                .SingleOrDefaultAsync(c => c.Id == clientID);

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
