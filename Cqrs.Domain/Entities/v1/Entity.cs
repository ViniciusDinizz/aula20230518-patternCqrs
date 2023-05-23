using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cqrs.Domain.Contracts.v1;

namespace Cqrs.Domain.Entities.v1
{
    public class Entity : IEntity
    {
        protected Entity(Guid id, DateTime createdAt, DateTime updateAt) 
        {
            Id = id;
            CreatedAt = createdAt;
            UpdateAt = updateAt;
        }
        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
        //Propriedades
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public bool Equals(IEntity? other)
        {
            if(other is null) return false;
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
