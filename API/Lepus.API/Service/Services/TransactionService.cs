using Lepus.API.Domain.Entities;
using Lepus.API.Domain.Interfaces;
using Lepus.API.Infra.Data.Repository;
using Lepus.Infra.Data.Repository;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.API.Service.Services
{
    public class TransactionService : ITransactionService
    {
         private readonly BaseRepository<Transaction> _baseRepository;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(IMongoCollection<Transaction> collection)
        {
            _baseRepository = new BaseRepository<Transaction>(collection);
            _transactionRepository = new TransactionRepository(collection);
        }

        public async Task<List<Transaction>> Get(string userName, int year, int month)
        {
            return await _transactionRepository.Select(userName, year, month);
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
