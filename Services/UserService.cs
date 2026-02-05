using api_red_social.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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
            try
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
            catch (HttpRequestException ex)
            {
                return null;
            }

        }

        public async Task<List<GetFollowersDTO>> GetFollowersAsync(string username)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/users/{username}/followers"); // Obtener seguidores del usuario

                response.EnsureSuccessStatusCode(); // Asegura que la peticion fue exitosa

                var json = await response.Content.ReadAsStringAsync(); // Guardamos el contenido de la respuesta como una cadena JSON

                var result = JsonSerializer.Deserialize<List<GetFollowersDTO>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Ignora mayusculas y minusculas en los nombres de las propiedades
                });

                return result ?? new List<GetFollowersDTO>();
            }
            catch (HttpRequestException ex)
            {
                return new List<GetFollowersDTO>();
            }
        }
        public async Task<List<FollowingDTO>> GetFollowingsAsync(string username, int pagina = 1, int porpagina = 30)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/users/{username}/following? page= {pagina}& per_page={porpagina}");
                response.EnsureSuccessStatusCode();

                var Json = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<List<FollowingDTO>>(Json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return result ?? new List<FollowingDTO>();
            }
            catch (HttpRequestException ex)
            {
                return new List<FollowingDTO>();
            }
        }
    }
}
