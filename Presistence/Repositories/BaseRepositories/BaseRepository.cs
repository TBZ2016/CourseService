using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Linq.Expressions;


namespace Presistence.BaseRepositories
{

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly BaseDBContext _dbContext;
        private readonly IMongoCollection<T> _collection;

        public BaseRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext;
            _collection = _dbContext.Database.GetCollection<T>(typeof(T).Name);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            // Assuming your entities have an identifier (e.g., Id)
            var filter = Builders<T>.Filter.Eq("Id", GetIdValue(entity));
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync(T entity)
        {
            // Assuming your entities have an identifier (e.g., Id)
            var filter = Builders<T>.Filter.Eq("Id", GetIdValue(entity));
            await _collection.DeleteOneAsync(filter);
        }

        private object GetIdValue(T entity)
        {
            // Replace "Id" with the actual property name of your entity's identifier
            var property = typeof(T).GetProperty("Id");
            return property.GetValue(entity);
        }

        public Task Commit()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            var entities = await _collection.Find(predicate).ToListAsync();
            return entities;
        }



    }

}