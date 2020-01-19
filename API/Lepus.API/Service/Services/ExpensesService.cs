using Lepus.API.Domain.Entities;
using Lepus.API.Domain.Interfaces;
using Lepus.API.Infra.Data.Repository;
using Lepus.Infra.Data.Context;
using Lepus.Infra.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.API.Service.Services
{
    public class ExpensesService : ITransactionService
    {
        private readonly ExpensesRepository _expenseRepository;
        private readonly BaseRepository<Transaction> _baseRepository;

        public ExpensesService(MongoDbContext mongoDbContext, ExpensesRepository expensesRepository)
        {
            _expenseRepository = expensesRepository;
            _baseRepository = new BaseRepository<Transaction>(mongoDbContext.Expenses);
        }

        public async Task<List<Transaction>> Get(string userName, int year, int month)
        {
            return await _expenseRepository.Select(userName, year, month);
        }

        public async Task Post(Transaction transaction)
        {
            await _baseRepository.Insert(transaction);
        }

        public async Task Put(string id, decimal value, string description)
        {
            var transaction = await _baseRepository.Select(id);

            if (transaction == null)
                throw new KeyNotFoundException("Item not found");

            transaction.Update(value, description);

            await _baseRepository.Update(id, transaction);
        }

        public async Task Delete(string id)
        {
            var item = await _baseRepository.Select(id);
            if (item == null)
                throw new KeyNotFoundException("Item not found");

            await _baseRepository.Delete(id);
        } 
    }
}
