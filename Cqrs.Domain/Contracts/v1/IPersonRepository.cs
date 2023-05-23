using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Cqrs.Domain.Entities.v1;
using Microsoft.Extensions.Options;

namespace Cqrs.Domain.Contracts.v1
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        
    }
}
