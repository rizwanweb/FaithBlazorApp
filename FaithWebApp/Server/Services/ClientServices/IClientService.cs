using FaithWebApp.Shared.Models;

namespace FaithWebApp.Server.Services.ClientServices
{
    public interface IClientService
    {
        Task<ServiceResponse<List<Party>>> GetClientsAsync();
        Task<ServiceResponse<Party>> GetSingleClient(int clientID);

        Task<ServiceResponse<List<Party>>> SearchClientsAsync(string searchText);
        Task<ServiceResponse<List<string>>> GetClientSearchSuggestions(string searchText);

    }
}