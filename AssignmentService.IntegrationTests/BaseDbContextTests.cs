using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Presistence;


namespace AssignmentService.IntegrationTests
{
    public class BaseDbContextTests
    {

        private BaseDBContext _dbContext;

        [SetUp]
        public void Setup()
        {
            // Configure and load settings from appsettings.test.json
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json");
            var configuration = builder.Build();

            // Create an instance of BaseDBContext with the configuration
            _dbContext = new BaseDBContext(configuration);
        }

        [Test]
        public void SpecificCollectionShouldExist()
        {
            var collectionName = "Course"; // Replace with the name you're checking for
            var collectionNames = _dbContext.Database.ListCollectionNames().ToList();

            bool collectionExists = collectionNames.Contains(collectionName);
            Assert.IsTrue(collectionExists, $"Collection '{collectionName}' does not exist in the database.");
        }

        [Test]
        public void Should_ConnectToDatabaseAndFindAssignmentServiceCollection()
        {
            var collection = _dbContext.Database.GetCollection<BsonDocument>("CourseService");
            var count = collection.CountDocuments(FilterDefinition<BsonDocument>.Empty);
            Assert.GreaterOrEqual(count, 0);
        }
    }
}
