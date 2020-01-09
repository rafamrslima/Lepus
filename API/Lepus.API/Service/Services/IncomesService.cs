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
    public class IncomesService : ITransactionService
    {
        private readonly IncomesRepository _incomesRepository;
        private readonly BaseRepository<Transaction> _baseRepository;

        public IncomesService(MongoDbContext mongoDbContext, IncomesRepository incomesRepository)
        {
            _incomesRepository = incomesRepository;
            _baseRepository = new BaseRepository<Transaction>(mongoDbContext.Incomes);
        }

        public async Task<List<Transaction>> Get(string userName, int year, int month)
        {
            return await _incomesRepository.Select(userName, year, month);
        }

        public async Task Put(string id, Transaction obj) 
        {
            obj.Validate();

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
            obj.Validate(); 
            await _baseRepository.Insert(obj);
        }
    }
}
