using Lepus.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Lepus.API.Infra.Data.Repository
{
    public class ExpensesRepository
    {
        IMongoCollection<Expense> _collection;
        public ExpensesRepository(IMongoCollection<Expense> collection)
        {
            _collection = collection;
        }

        public async Task<List<Expense>> Select(string userName, int year, int month)
        {
            return await _collection.Find(x => x.UserName == userName
                                            && x.Year == year
                                            && x.Month == month).ToListAsync();
        }
    }
}
