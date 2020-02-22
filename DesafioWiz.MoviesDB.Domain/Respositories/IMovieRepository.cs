using DesafioWiz.MoviesDB.Domain.Entities;

namespace DesafioWiz.MoviesDB.Domain.Respositories
{
    public interface IMovieRepository
    {
        Movies GetMovies(int page = 1);
    }
}
