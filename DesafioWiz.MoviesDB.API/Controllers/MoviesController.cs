using DesafioWiz.MoviesDB.Common.Helpers;
using DesafioWiz.MoviesDB.Common.RestSharp;
using DesafioWiz.MoviesDB.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace DesafioWiz.MoviesDB.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IRestSharpConfig _restSharpConfig;
        private readonly IConfiguration _configuration;

        public MoviesController(IRestSharpConfig restSharpConfig, IConfiguration configuration)
        {
            _restSharpConfig = restSharpConfig;
            _configuration = configuration;
        }

        [HttpGet("{page}")]
        public Movies Get(int page = 1)
        {
            var readJson = new ReadJson(_configuration);

            var movieClient = _restSharpConfig.ConfigRequest();
            var movieRequest = new RestRequest($"upcoming?api_key={readJson.ApiKey()}&language=pt-BR&page={page}", Method.GET);

            var genreClient = _restSharpConfig.ConfigRequestForGenre();
            var genreRequest = new RestRequest($"list?api_key={readJson.ApiKey()}&language=pt-BR", Method.GET);

            var moviesResult = movieClient.Execute(movieRequest);
            var movies = JsonConvert.DeserializeObject<Movies>(moviesResult.Content);

            var genreResult = genreClient.Execute(genreRequest);
            var genres = JsonConvert.DeserializeObject<Genres>(genreResult.Content);

            var filledMovies = new List<Movies>();

            foreach (var movie in movies.results)
            {
                foreach (int genreid in movie.genre_ids)
                {
                    var teste = genres.genres.Find(x => x.id == genreid);
                    movie.genres.genres.Add(genres.genres.Find(x => x.id == genreid));
                }
            }

            return movies;
        }
    }
}