using FluentValidation;
using Lepus.API.Infra.Data.Repository;
using Lepus.Domain.Entities;
using Lepus.Infra.Data.Repository;
using Lepus.Service.Validators;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lepus.API.Service.Services
{
    public class IncomesService 
    {
        private readonly IncomesRepository _IncomeRepository;
        private readonly BaseRepository<Income> _baseRepository;

        public IncomesService(IMongoCollection<Income> mongoCollection)
        {
            _IncomeRepository = new IncomesRepository(mongoCollection);
            _baseRepository = new BaseRepository<Income>(mongoCollection);
        }

        public async Task<List<Income>> Get(string userName, int year, int month)
        {
            return await _IncomeRepository.Select(userName, year, month);
        }

        public async Task Put(string id, Income obj) 
        {
            Validate(obj, Activator.CreateInstance<IncomeValidator>());

            var item = await _baseRepository.Select(id);

            if (item == null)
                throw new ArgumentException("Item not found");

            item.Value = obj.Value;
            item.Description = obj.Description;

            await _baseRepository.Update(id, item);
        }

        private void Validate(Income obj, AbstractValidator<Income> validator)
        {
            if (obj == null)
                throw new Exception("Registers not found.");

            validator.ValidateAndThrow(obj);
        }
    }
}
