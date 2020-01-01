using FluentValidation;
using Lepus.Domain.Entities;
using Lepus.Domain.Interfaces;
using Lepus.Infra.Data.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {

        private BaseRepository<T> _repository;

        public BaseService(IMongoCollection<T> mongoCollection)
        {
             _repository = new BaseRepository<T>(mongoCollection);
        }
          
        public async Task<List<T>> Get(string userName, int year, int month)
        {
            return await _repository.Select(userName, year, month);
        }

        public async Task<T> Get(string id)
        {
            return await _repository.Select(id);
        } 

        public async Task Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            await _repository.Insert(obj);
        }

        public async Task Put<V>(string id, T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            var item = await _repository.Select(id);
            
            if(item == null)
                throw new ArgumentException("Item not found");

            item.Value = obj.Value;
            item.Description = obj.Description;

            await _repository.Update(id, item);
        }

        public async Task Delete(string id)
        { 
            var item = await _repository.Select(id);
            if (item == null)
                throw new ArgumentException("Item not found");

            await _repository.Delete(id);
        }
  
        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registers not found.");

            validator.ValidateAndThrow(obj);
        }
         
    }
}
