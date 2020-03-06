using DesafioWiz.MoviesDB.Common.Helpers;
using DesafioWiz.MoviesDB.Common.RestSharp;
using DesafioWiz.MoviesDB.Domain.Entities;
using DesafioWiz.MoviesDB.Domain.Respositories;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace DesafioWiz.MoviesDB.Repository.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IRestSharpConfig _restSharpConfig;
        private readonly IConfiguration _configuration;

        public MovieRepository(IRestSharpConfig restSharpConfig, IConfiguration configuration)
        {
            _restSharpConfig = restSharpConfig;
            _configuration = configuration;
        }

        public Movies GetMovies(int page = 1)
        {
            return ReturnMovies(GetMoviesList(page));
        }

        private Movies GetMoviesList(int page)
        {
            var movieClient = _restSharpConfig.ConfigRequest();
            var movieRequest = new RestRequest(ReturnUrl("upcoming", page), Method.GET);

            var moviesResult = movieClient.Execute(movieRequest);
            return JsonConvert.DeserializeObject<Movies>(moviesResult.Content);
        }

        private Genres GetGenresList()
        {
            var genreClient = _restSharpConfig.ConfigRequestForGenre();
            var genreRequest = new RestRequest(ReturnUrl("list", null), Method.GET);

            var genreResult = genreClient.Execute(genreRequest);
            return JsonConvert.DeserializeObject<Genres>(genreResult.Content);
        }

        private Movies ReturnMovies(Movies movies)
        {
            var genreList = GetGenresList();

            foreach (var movie in movies.results)
            {
                foreach (int genreid in movie.genre_ids)
                {
                    movie.genres.genres.Add(genreList.genres.Find(x => x.id == genreid));
                }
            }

            return movies;
        }

        private string ReturnUrl(string endpoint, int? page)
        {
            var readJson = new ReadJson(_configuration);
            return !page.HasValue ? $"{endpoint}?api_key={readJson.ApiKey()}&language=pt-BR" : $"{endpoint}?api_key={readJson.ApiKey()}&language=pt-BR&page={page.Value}";
        }
    }
}
