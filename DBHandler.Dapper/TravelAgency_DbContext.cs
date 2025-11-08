using Core.Application.DB;
using Microsoft.Extensions.Configuration;

namespace DBHandler.Dapper
{
    public class TravelAgency_DbContext : ITravelAgency_DbContext
    {
        private readonly IConfiguration _config;

        public TravelAgency_DbContext(IConfiguration config)
        {
            _config = config;
        }
    }
}
