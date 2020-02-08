using Lepus.API.Domain.Entities;
using Lepus.API.Domain.Enums;
using Lepus.API.Domain.Interfaces;
using Lepus.API.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.API.Service.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<List<Transaction>> Get(string userName, int year, int month, TransactionType transactionType)
        {
            return await _transactionRepository.Select(userName, year, month, transactionType);
        }

        public async Task Post(TransactionDto transactionDto)
        {
            var transaction = new Transaction(transactionDto.Description, transactionDto.Value, transactionDto.Month, 
                                                transactionDto.Year, transactionDto.UserName, transactionDto.TransactionType);

            await _transactionRepository.Insert(transaction);
        }

        public async Task Put(string id, decimal value, string description)
        {
            var transaction = await _transactionRepository.Select(id);

            if (transaction == null)
                throw new KeyNotFoundException("Item not found");

            transaction.Update(value, description);

            await _transactionRepository.Update(id, transaction);
        }

        public async Task Delete(string id)
        {
            var item = await _transactionRepository.Select(id);
            if (item == null)
                throw new KeyNotFoundException("Item not found");

            await _transactionRepository.Delete(id);
        }
    }
}
