using FaithWebApp.Server;
using FaithWebApp.Server.Models;
using System.Net.Http.Json;

namespace FaithWebApp.Client.Services.Clients
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _http;

        public List<CClient> ClientsList { get; set; } = new List<CClient>();

        

        public ClientService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetClients()
        {
            var results = await _http.GetFromJsonAsync<ServiceResponse<List<CClient>>>("api/party");


            if (results != null && results.Data != null)
            {
                ClientsList = results.Data;                
            }
        }
    }
}
