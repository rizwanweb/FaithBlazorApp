using FaithWebApp.Shared;
using System.Net.Http.Json;

namespace FaithWebApp.Client.Services.Clients
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _http;

        public List<Party> ClientsList { get; set; } = new List<Party>();

        

        public ClientService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetClients()
        {
            var results = await _http.GetFromJsonAsync<ServiceResponse<List<Party>>>("api/party");


            if (results != null && results.Data != null)
            {
                ClientsList = results.Data;                
            }
        }

		public async Task<ServiceResponse<Party>> GetSingleClient(int id)
		{
            var result = await _http.GetFromJsonAsync<ServiceResponse<Party>>($"api/party/{id}");
            return result;
		}
	}
}
