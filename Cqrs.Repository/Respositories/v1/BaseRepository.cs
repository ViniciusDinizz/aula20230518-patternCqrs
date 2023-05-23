using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Cqrs.Domain.Contracts.v1;
using Cqrs.Domain.Entities;
using Cqrs.Domain.Entities.v1;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cqrs.Repository.Respositories.v1
{
    //Utilizando tipo genérico, passando como herança para a classe PersonRepository
    public abstract class BaseRepository<TEntity> where TEntity : IEntity
    {
        protected BaseRepository(IMongoClient client, IOptions<MongoRepositorySettings> settings)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        protected readonly IMongoCollection<TEntity> collection;

        public async Task AddAsync(TEntity entity, CancellationToken cancellation)
        {
            await collection.InsertOneAsync(entity, cancellationToken: cancellation);
        }

        public async Task RemoveAsync(Guid Id, CancellationToken cancellation)
        {
            var filter = GetFilterById(Id);

            await collection.DeleteOneAsync(filter, cancellationToken: cancellation);
        }

        public async Task<TEntity> FindByIdAsync(Guid Id, CancellationToken cancellation)
        {
            var filter = GetFilterById(Id);

            return await collection.Find(filter).FirstOrDefaultAsync(cancellation);
        }
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>?> expression, CancellationToken cancellation)
        {
            var filter = Builders<TEntity>.Filter.Where(expression);
            return await collection.Find(filter).ToListAsync(cancellation);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellation)
        {
            var filter = GetFilterById(entity.Id);
            await collection.ReplaceOneAsync(filter, entity, cancellationToken : cancellation);
        }

        protected FilterDefinition<TEntity> GetFilterById(Guid id)
        {
            return Builders<TEntity>.Filter.Eq(entity => entity.Id, id);
        }
    }
}
