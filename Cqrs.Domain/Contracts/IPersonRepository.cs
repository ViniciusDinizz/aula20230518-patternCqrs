using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Cqrs.Domain.Domain;

namespace Cqrs.Domain.Contracts
{
    public interface IPersonRepository
    {
        Task InsertAsync(
            Person person,
            CancellationToken cancellation);

        Task<IEnumerable<Person>> GetAsync(
            Expression<Func<Person, bool>> expression,
            CancellationToken cancellation);

        Task<Person> GetByIdAsync(
            Guid personId, 
            CancellationToken cancellation);

        Task UpdateAsync(
            Person person,
            CancellationToken cancellation);

        Task DeleteAsync(
            Guid id, 
            CancellationToken cancellationToken);
    }
}
