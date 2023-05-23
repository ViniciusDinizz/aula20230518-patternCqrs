using System.Linq.Expressions;

namespace Cqrs.Domain.Contracts.v1
{
    public interface IBaseRepository<TEntity> where TEntity : IEntity
    {
        Task AddAsync(
            TEntity entity,
            CancellationToken cancellation);
        Task UpdateAsync(
            TEntity entity,
            CancellationToken cancellation);
        Task RemoveAsync(
            Guid id,
            CancellationToken cancellationToken);
        Task<TEntity?> FindByIdAsync(
            Guid entityId,
            CancellationToken cancellation);

        Task<IEnumerable<TEntity>?> FindAsync(
            Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellation);
    }
}