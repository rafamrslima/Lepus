using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using LepusAPI.DataContext;
using LepusAPI.Models;
using MongoDB.Driver;

namespace LepusAPI.Repositories
{
    public class ExpensesRepository
    {
        readonly IMongoCollection<Expense> _expenses;
        public ExpensesRepository(MongoDbContext mongoDbContext)
        {
            _expenses = mongoDbContext.Expenses;
        }
        public async Task<List<Expense>> Get(int userId, int year, int month)
        {
            return await _expenses.Find(x => x.UserId == userId
                                          && x.Year == year 
                                          && x.Month == month).ToListAsync();
        }

        public async Task Post(Expense expense)
        {
            await _expenses.InsertOneAsync(expense);
        }

        public async Task Put(string expenseId, ExpenseDto expenseDto)
        { 
            var expense = await _expenses.Find(i => i.Id == expenseId).FirstOrDefaultAsync();
            expense.Description = expenseDto.Description;
            expense.Value = expenseDto.Value;

            _expenses.ReplaceOne(e => e.Id == expenseId, expense);
        }

        public async Task Delete(string expenseId)
        { 
            await _expenses.DeleteOneAsync(x => x.Id == expenseId);
        }
    }
}