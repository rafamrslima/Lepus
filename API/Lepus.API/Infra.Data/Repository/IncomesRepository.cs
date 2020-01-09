using Lepus.API.Domain.Entities;
using Lepus.API.Domain.Interfaces;
using Lepus.Domain.Entities;
using Lepus.Infra.Data.Context;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.API.Infra.Data.Repository
{
    public class IncomesRepository: ITransactionRepository
    {
        readonly MongoDbContext _mongoDbContext;

        public IncomesRepository(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task<List<Transaction>> Select(string userName, int year, int month)
        {
            return await _mongoDbContext.Incomes.Find(x => x.UserName == userName
                                                      && x.Year == year
                                                      && x.Month == month).ToListAsync();
        }
    }
}
