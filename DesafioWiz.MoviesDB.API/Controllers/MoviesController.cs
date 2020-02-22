using DesafioWiz.MoviesDB.Common.Helpers;
using DesafioWiz.MoviesDB.Domain.Entities;
using DesafioWiz.MoviesDB.Domain.Respositories;
using Microsoft.AspNetCore.Mvc;

namespace DesafioWiz.MoviesDB.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public Movies Get([FromQuery] BaseSearch baseSearch)
        {
            return _movieRepository.GetMovies(baseSearch.Page);
        }
    }
}