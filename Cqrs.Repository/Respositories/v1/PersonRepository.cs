using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Cqrs.Domain.Contracts.v1;
using Cqrs.Domain.Entities.v1;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cqrs.Repository.Respositories.v1
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(
            IMongoClient client,
            IOptions<MongoRepositorySettings> settings)
            : base(client, settings)
        {
        }
    }
}
