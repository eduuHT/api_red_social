using api_red_social.Models;
using System.Text.Json;

namespace api_red_social.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetUserDTO> GetUserAsync(string username)
        {
            var response = await _httpClient.GetAsync($"/users/{username}"); // Le damos de parametro el usuario a buscar
            response.EnsureSuccessStatusCode(); // Asegura que la peticion fue exitosa, si no lanza una excepcion

            var Json = await response.Content.ReadAsStringAsync(); // Guardamos el contenido de la respuesta como una cadena JSON

            var result = JsonSerializer.Deserialize<GetUserDTO>(Json, new JsonSerializerOptions  // Transformamos el JSON a un objeto GetUserDTO
            {
                PropertyNameCaseInsensitive = true // Ignora mayusculas y minusculas en los nombres de las propiedades
            });
            return result;
        }
    }
}
