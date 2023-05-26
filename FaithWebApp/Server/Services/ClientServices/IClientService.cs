using FaithWebApp.Server.Models;

namespace FaithWebApp.Server.Services.ClientServices
{
    public interface IClientService
    {
        Task<ServiceResponse<List<CClient>>> GetClientsAsync();
        Task<ServiceResponse<CClient>> GetSingleClient(int clientID);
    }
}