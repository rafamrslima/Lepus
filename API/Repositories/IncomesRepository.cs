using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using LepusAPI.DataContext;
using LepusAPI.Models;
using MongoDB.Driver;

namespace LepusAPI.Repositories
{
    public class IncomesRepository
    {
        readonly IMongoCollection<Income> _incomes;
        public IncomesRepository(MongoDbContext mongoDbContext)
        {
            _incomes = mongoDbContext.Incomes;
        }
        public async Task<List<Income>> Get(string userName, int year, int month)
        {
            return await _incomes.Find(x => x.userName == userName
                                         && x.Year == year
                                         && x.Month == month).ToListAsync();
        }

        public async Task Post(Income income)
        {
            await _incomes.InsertOneAsync(income);
        }

        public async Task Put(string incomeId, IncomeDto incomeDto)
        { 
            var income = await _incomes.Find(i => i.Id == incomeId).FirstOrDefaultAsync();
            income.Description = incomeDto.Description;
            income.Value = incomeDto.Value;

            _incomes.ReplaceOne(e => e.Id == incomeId, income);
        }

        public async Task Delete(string incomeId)
        { 
            await _incomes.DeleteOneAsync(x => x.Id == incomeId);
        }
    }
}