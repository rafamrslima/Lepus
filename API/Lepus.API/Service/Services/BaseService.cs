using Lepus.Domain.Entities;
using Lepus.Domain.Interfaces;
using Lepus.Infra.Data.Repository;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Lepus.Service.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly BaseRepository<T> _repository;

        public BaseService(IMongoCollection<T> mongoCollection)
        {
             _repository = new BaseRepository<T>(mongoCollection);
        } 

        public async Task<T> Get(string id)
        {
            return await _repository.Select(id);
        } 
  
        public async Task Post(T obj)
        {
            if (obj == null)
                throw new Exception("Registers not found.");

            obj.Validate();
  
            await _repository.Insert(obj);
        }
  
        public async Task Delete(string id)
        { 
            var item = await _repository.Select(id);
            if (item == null)
                throw new ArgumentException("Item not found");

            await _repository.Delete(id);
        } 
    }
}
