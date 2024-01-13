using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Presistence
{
    public class BaseDBContext
    {
        protected MongoClient dbClient;
        public IMongoDatabase Database { get; private set; }
        private IConfiguration _configuration;

        public BaseDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            InitializeConnection();
        }

        protected void InitializeConnection()
        {
            try
            {
                var mongoDbSettings = _configuration.GetSection("MongoDBConnection");
                dbClient = new MongoClient(mongoDbSettings["DBConnectionString"]);
                Database = dbClient.GetDatabase(mongoDbSettings["DatabaseName"]);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
            }
        }


    }


}

