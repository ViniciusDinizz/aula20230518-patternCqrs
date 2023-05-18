using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cqrs.Domain.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cqrs.Repository.Respositories
{
    public class BaseRepository<TEntity>
    {
        protected BaseRepository(IMongoClient client, IOptions<MongoRepositorySettings> settings) 
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        protected readonly IMongoCollection<TEntity> collection;
    }
}
