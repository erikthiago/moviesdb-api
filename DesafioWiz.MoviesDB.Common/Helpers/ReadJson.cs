using Microsoft.Extensions.Configuration;

namespace DesafioWiz.MoviesDB.Common.Helpers
{
    public class ReadJson
    {
        private readonly IConfiguration _configuration;

        public ReadJson(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ApiKey()
        {
            return GetApiKey();
        }

        private string GetApiKey()
        {
            return _configuration.GetSection("MovieDBKey").GetSection("API_KEY").Value;
        }
    }
}
