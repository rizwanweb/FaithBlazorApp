using FaithWebApp.Shared;
using System.Net.Http.Json;

namespace FaithWebApp.Client.Services.Clients
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _http;

        public List<Party> ClientsList { get; set; } = new List<Party>();
        string message = "Loading Clients";

        

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

        public async Task SearchClients(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Party>>>($"api/party/search/{searchText}");
            if (result != null && result.Data != null)
            {
                ClientsList = result.Data;
            }
            if (ClientsList.Count == 0) message = "No Client Found";
        }

        public async Task<List<string>> GetClientSearchSuggestions(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/party/searchsuggestions/{searchText}");
            
            return result.Data;

        }
    }
}
