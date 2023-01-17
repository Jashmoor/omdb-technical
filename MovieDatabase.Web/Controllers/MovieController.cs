using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MovieDatabase.Core.Clients;
using MovieDatabase.Core.Configuration;
using MovieDatabase.Core.Models;

namespace MovieDatabase.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieDatabaseClient _Client;
        public MovieController(MovieDatabaseClient client)
        {
            _Client = client;
        }


        [HttpGet]
        [ResponseCache(Duration = 50, VaryByQueryKeys = new string[] { "*" })]
        public async Task<SearchResponse> Get(string term, string type)
        {
            return await _Client.Search(term, type);
        }

        [HttpGet]
        [Route("detail")]
        [ResponseCache(Duration = 360)]
        public async Task<Movie> Detail(string title)
        {
            return await _Client.Detail(title);
        }

        [HttpGet]
        [Route("external")]
        public async Task<MappedMovie> GetDetail(string title)
        {
            return await _Client.External(title);
        }
    }
}
