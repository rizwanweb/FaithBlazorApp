using FaithWebApp.Shared;

namespace FaithWebApp.Client.Services.Clients
{
    public interface IClientService
    {
        List<Party> ClientsList { get; }
        Task GetClients();
        Task<ServiceResponse<Party>> GetSingleClient(int id);

        Task SearchClients(string searchText);
        Task<List<string>> GetClientSearchSuggestions(string searchText);
    }
}