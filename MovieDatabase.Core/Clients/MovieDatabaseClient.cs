using Microsoft.Extensions.Options;
using MovieDatabase.Core.Configuration;
using MovieDatabase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieDatabase.Core.Clients
{
    public class MovieDatabaseClient
    {
        private readonly HttpClient httpClient;
        private readonly IOptions<MovieClientConfiguration> Configuration;

        public MovieDatabaseClient(HttpClient client, IOptions<MovieClientConfiguration> configuration)
        {
            httpClient = client;
            Configuration = configuration;
            httpClient.BaseAddress = new Uri($"http://www.omdbapi.com/?apiKey={configuration.Value.ClientKey}");
        }

        public async Task<SearchResponse> Search(string title, string type = "movie", CancellationToken token = default)
        {
            using var response = await httpClient.GetAsync(WithKey($"?&s={title}&type={type}"), token);

            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync(token);
            return await JsonSerializer.DeserializeAsync<SearchResponse>(stream, cancellationToken: token) ?? default!;
        }

        public async Task<Movie> Detail(string title, CancellationToken token = default)
        {
            using var response = await httpClient.GetAsync(WithKey($"?&t={title}"), token);

            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync(token);
            return await JsonSerializer.DeserializeAsync<Movie>(stream, cancellationToken: token) ?? default!;
        }

        public async Task<MappedMovie> External(string title, CancellationToken token = default)
        {
            using var response = await httpClient.GetAsync(WithKey($"?&t={title}"), token);

            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync(token);
            return await JsonSerializer.DeserializeAsync<MappedMovie>(stream, cancellationToken: token) ?? default!;
        }


        internal string WithKey(string uri)
        {
            return $"{uri}&apiKey={Configuration.Value.ClientKey}";
        }
    }
}
