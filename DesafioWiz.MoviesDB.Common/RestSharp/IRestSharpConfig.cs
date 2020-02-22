using RestSharp;

namespace DesafioWiz.MoviesDB.Common.RestSharp
{
    public interface IRestSharpConfig
    {
        RestClient ConfigRequest();
        RestClient ConfigRequestForGenre();

    }
}
