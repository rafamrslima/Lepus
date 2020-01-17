using Lepus.API.Domain.Entities;
using Lepus.API.Domain.Interfaces;
using Lepus.API.Infra.Data.Repository;
using Lepus.Infra.Data.Context;
using Lepus.Infra.Data.Repository;
using System;
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

        public async Task Put(string id, Transaction obj)
        { 
            var item = await _baseRepository.Select(id);

            if (item == null)
                throw new ArgumentException("Item not found");

            item.Value = obj.Value;
            item.Description = obj.Description;

            await _baseRepository.Update(id, item);
        }

        public async Task Delete(string id)
        {
            var item = await _baseRepository.Select(id);
            if (item == null)
                throw new ArgumentException("Item not found");

            await _baseRepository.Delete(id);
        }

        public async Task Post(Transaction obj)
        {
            await _baseRepository.Insert(obj);
        }
    }
}
