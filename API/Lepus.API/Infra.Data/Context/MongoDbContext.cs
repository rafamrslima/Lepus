using Lepus.API.Domain.Entities;
using Lepus.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Lepus.Infra.Data.Context
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetSection("MongoDB:ConnectionStrings").Value);
            _database = client.GetDatabase(config.GetSection("MongoDB:Database").Value);
        }

        public IMongoCollection<Transaction> Incomes
        {
            get
            {
                return _database.GetCollection<Transaction>("Incomes");
            }
        }

        public IMongoCollection<Transaction> Expenses
        {
            get
            {
                return _database.GetCollection<Transaction>("Expenses");
            }
        }
    }
}
