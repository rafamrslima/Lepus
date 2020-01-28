using Lepus.API.Domain.Entities;
using Lepus.API.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.API.Infra.Data.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        readonly IMongoCollection<Transaction> _mongoCollection;

        public TransactionRepository(IMongoCollection<Transaction> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        public async Task<List<Transaction>> Select(string userName, int year, int month)
        {

            return await _mongoCollection.Find(x => x.UserName == userName
                                                    && x.Year == year
                                                    && x.Month == month).ToListAsync(); 
        }
    }
}
