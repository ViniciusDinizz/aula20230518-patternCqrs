using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Cqrs.Domain.Contracts;
using Cqrs.Domain.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cqrs.Repository.Respositories
{
    public class PersonRepository : BaseRepository<Person>,IPersonRepository
    {
        public PersonRepository(
            IMongoClient client, 
            IOptions<MongoRepositorySettings> settings) 
            : base(client, settings)
        {
        }

        public async Task InsertAsync(Person person, CancellationToken cancellation)
        {
            await collection.InsertOneAsync(person, cancellationToken: cancellation);
        }

        public async Task DeleteAsync(Guid personId, CancellationToken cancellation)
        {
            var filter = Builders<Person>.Filter.Eq(person => person.Id, personId);

            await collection.DeleteOneAsync(filter, cancellationToken: cancellation);
        }

        public async Task<Person> GetByIdAsync(Guid personId, CancellationToken cancellation)
        {
            var filter = Builders<Person>.Filter
                .Eq(person => person.Id, personId);

            return await collection.Find(filter).FirstOrDefaultAsync(cancellation);
        }
        public async Task<IEnumerable<Person>> GetAsync(
            Expression<Func<Person, bool>> expression,
            CancellationToken cancellation)
        {
            var filter = Builders<Person>.Filter.Where(expression);
            return await collection.Find(filter).ToListAsync(cancellation);
        }

        public async Task UpdateAsync(Person person, CancellationToken cancellation)
        {
            await collection.ReplaceOneAsync(
                entity => entity.Id!.Equals(person.Id), person,
                new ReplaceOptions { IsUpsert = true }, cancellation);
        }
    }
}
