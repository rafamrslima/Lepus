using LepusAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace LepusAPI.DataContext {
    public class MongoDbContext {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration config)
        {  
            var client = new MongoClient(config.GetSection("MongoDB:ConnectionStrings").Value);
            _database = client.GetDatabase(config.GetSection("MongoDB:Database").Value); 
        }

        public IMongoCollection<Income> Incomes
        {
            get
            {
                return _database.GetCollection<Income>("Incomes");
            }
        }

        public IMongoCollection<Expense> Expenses
        {
            get
            {
                return _database.GetCollection<Expense>("Expenses");
            }
        }
    }
}