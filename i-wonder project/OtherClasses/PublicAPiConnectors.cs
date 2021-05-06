using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebApi.Models;

namespace i_wonder_project.OtherClasses
{
    public class PublicAPiConnectors
    {
        public List<Films> GetFilmDetails(IHttpClientFactory _httpClientFactory)
        {

            string[] imdbUniqueIdentifiers = new string[10];
            imdbUniqueIdentifiers[0] = "tt0407887";
            imdbUniqueIdentifiers[1] = "tt0068646";
            imdbUniqueIdentifiers[2] = "tt0468569";
            imdbUniqueIdentifiers[3] = "tt0050083";
            imdbUniqueIdentifiers[4] = "tt0108052";
            imdbUniqueIdentifiers[5] = "tt0167260";
            imdbUniqueIdentifiers[6] = "tt0110912";
            imdbUniqueIdentifiers[7] = "tt0060196";
            imdbUniqueIdentifiers[8] = "tt1375666";
            imdbUniqueIdentifiers[9] = "tt0133093";

            List<Films> films = new List<Films>();

            foreach (string imdbIdentifier in imdbUniqueIdentifiers)
            {
                Films film = OnGet(_httpClientFactory, imdbIdentifier).Result;
                films.Add(film);
            }
            return films;
        }
    }
    public async Task<Films> OnGet(IHttpClientFactory _clientFactory, string filmID)
    {
        Films film = new Films();
        var request = new HttpRequestMessage(HttpMethod.Get, $"http://www.omdbapi.com/?i={filmID}&apikey=1e8fa3a");
        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            film = await JsonSerializer.DeserializeAsync
                <Films>(responseStream);
        }
        return film;
    }
}
