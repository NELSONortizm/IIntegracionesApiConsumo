using IntegracionesApiConsumo.Models;

namespace IntegracionesApiConsumo.Services
{
    public class IntegracionService
    {
        private readonly HttpClient _httpClient;
        public IntegracionService(HttpClient httpClient) 
        {
          _httpClient = httpClient;
        }

        public async Task<IEnumerable<Integracion>> GetAllIntegraciones()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Integracion>>("http://localhost:5075/api/integracion/");
        }

        public async Task<Integracion> GetIntegracion(int id)
        {
            return await _httpClient.GetFromJsonAsync<Integracion>($"http://localhost:5075/api/integracion/{id}");
        }

        public async Task CreateIntegracion(Integracion integracion)
        {
            await _httpClient.PostAsJsonAsync("http://localhost:5075/api/integracion/", integracion);
        }
        public async Task UpdateIntegracion(Integracion integracion)
        {
            await _httpClient.PutAsJsonAsync($"http://localhost:5075/api/integraciones/{integracion.Id}", integracion);
        }

        public async Task DeleteIntegracion(int id)
        {
            await _httpClient.DeleteAsync($"http://localhost:5075/api/integraciones/{id}");
        }
    }//
}
