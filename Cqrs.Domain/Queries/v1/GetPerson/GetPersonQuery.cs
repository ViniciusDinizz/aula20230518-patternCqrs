﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs.Domain.Queries.v1.GetPerson
{
    public class GetPersonQuery
    {
        public GetPersonQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
