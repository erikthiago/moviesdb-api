using RestSharp;

namespace DesafioWiz.MoviesDB.Common.RestSharp
{
    public class RestSharpConfig : IRestSharpConfig
    {
        public RestClient ConfigRequest()
        {
            return new RestClient("https://api.themoviedb.org/3/movie/");
        }

        public RestClient ConfigRequestForGenre()
        {
            return new RestClient("https://api.themoviedb.org/3/genre/movie/");
        }
    }
}
