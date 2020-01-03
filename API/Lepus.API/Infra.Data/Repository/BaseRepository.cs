using Lepus.Domain.Entities;
using Lepus.Domain.Interfaces;
using Lepus.Infra.Data.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        IMongoCollection<T> _collection;
        public BaseRepository(IMongoCollection<T> collection)
        {
            _collection = collection;
        }

        public async Task Insert(T obj)
        {
            await _collection.InsertOneAsync(obj);
        }

        public async Task Update(string id, T obj)
        {
            await _collection.ReplaceOneAsync(e => e.Id == id, obj);
        }

        public async Task Delete(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<T> Select(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
 
    }
}
