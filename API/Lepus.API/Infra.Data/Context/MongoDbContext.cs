using Lepus.API.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Lepus.Infra.Data.Context
{
    public class MongoDbContext<T> 
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetSection("MongoDB:ConnectionStrings").Value);
            _database = client.GetDatabase(config.GetSection("MongoDB:Database").Value);
        }

        public IMongoCollection<T> Collection
        {
            get
            {
                return _database.GetCollection<T>(typeof(T).Name);
            }
        } 
    }
}
