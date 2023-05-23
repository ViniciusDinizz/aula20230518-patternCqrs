using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs.Domain.Queries.v1.ListPerson
{
    public class ListPersonQuery
    {
        public ListPersonQuery(string? name, string? cpf)
        {
            Name = name;
            Cpf = cpf;
        }

        public string? Name { get; }
        public string? Cpf { get; }
    }
}
