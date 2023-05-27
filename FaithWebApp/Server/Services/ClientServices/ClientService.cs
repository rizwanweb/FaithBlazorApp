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

        public async Task<ServiceResponse<List<string>>> GetClientSearchSuggestions(string searchText)
        {
            var clients = await FindClientBySearchText(searchText);
            List<string> result = new List<string>();

            foreach (var c in clients)
            {
                if (c.ClientName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(c.ClientName);
                }                        
            }
            return new ServiceResponse<List<string>> { Data = result };

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

        public async Task<ServiceResponse<List<Party>>> SearchClientsAsync(string searchText)
        {
            var response = new ServiceResponse<List<Party>>
            {
                Data = await FindClientBySearchText(searchText)
            };
            return response;
        }

        private async Task<List<Party>> FindClientBySearchText(string searchText)
        {
            return await _context.Clients
                         .Where(c => c.ClientName.ToLower().Contains(searchText))
                         .Include(c => c.City)
                         .ToListAsync();
        }
    }
}
