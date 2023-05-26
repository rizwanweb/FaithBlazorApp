using FaithWebApp.Shared.Models;

namespace FaithWebApp.Server.Services.ClientServices
{
    public interface IClientService
    {
        Task<ServiceResponse<List<Party>>> GetClientsAsync();
        Task<ServiceResponse<Party>> GetSingleClient(int clientID);
    }
}