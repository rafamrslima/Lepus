using Lepus.API.Domain.Entities;
using Lepus.API.Domain.Enums;
using Lepus.API.Domain.Interfaces;
using Lepus.Infra.Data.Context;
using Lepus.Infra.Data.Repository;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.API.Infra.Data.Repository
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {

        public TransactionRepository(MongoDbContext<Transaction> mongoDbContext) : base(mongoDbContext) { }


        public async Task<List<Transaction>> Select(string userName, int year, int month, TransactionType transactionType)
        {
            return await _collection.Find(x => x.UserName == userName
                                                           && x.Year == year
                                                           && x.Month == month
                                                           && x.TransactionType == transactionType).ToListAsync();
        }
    }
}
