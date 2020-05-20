using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Biblioteca.Services
{
    public class AutorService
    {
        private readonly HttpClient _httpClient;

        public AutorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5000");
        }

        public async Task<IEnumerable<AutorModel>> ObterAutores()
        {
            var stream = await _httpClient.GetStreamAsync($"api/autor");
            return await DeserializarAsync<IEnumerable<AutorModel>>(stream);
        }

        internal async Task<AutorModel> ObterPorId(int id)
        {
            var stream = await _httpClient.GetStreamAsync($"api/autor/{id}");
            return await DeserializarAsync<AutorModel>(stream);
        }

        private static ValueTask<T> DeserializarAsync<T>(System.IO.Stream stream)
        {
            return JsonSerializer.DeserializeAsync<T>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
