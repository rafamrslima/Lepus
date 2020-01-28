using Lepus.Domain.Entities;
using Lepus.Domain.Interfaces;
using Lepus.Infra.Data.Context;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Lepus.Infra.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly IMongoCollection<T> _collection;
        public BaseRepository(MongoDbContext<T> mongoDbContext)
        {
            _collection = mongoDbContext.Collection;
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
