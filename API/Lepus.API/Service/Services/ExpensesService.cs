using Lepus.API.Domain.Interfaces;
using Lepus.API.Infra.Data.Repository;
using Lepus.Domain.Entities;
using Lepus.Infra.Data.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.API.Service.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly ExpensesRepository _expenseRepository;
        private readonly BaseRepository<Expense> _baseRepository;

        public ExpensesService(IMongoCollection<Expense> mongoCollection)
        {
            _expenseRepository = new ExpensesRepository(mongoCollection);
            _baseRepository = new BaseRepository<Expense>(mongoCollection);
        }

        public async Task<List<Expense>> Get(string userName, int year, int month)
        {
            return await _expenseRepository.Select(userName, year, month);
        }

        public async Task Put(string id, Expense obj)
        {
            obj.Validate();
            
            var item = await _baseRepository.Select(id);

            if (item == null)
                throw new ArgumentException("Item not found");

            item.Value = obj.Value;
            item.Description = obj.Description;

            await _baseRepository.Update(id, item);
        }
    }
}
