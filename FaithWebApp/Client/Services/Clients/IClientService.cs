namespace FaithWebApp.Client.Services.Clients
{
    public interface IClientService
    {
        List<CClient> ClientsList { get; }
        Task GetClients();
    }
}