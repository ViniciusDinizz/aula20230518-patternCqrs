﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs.Domain.ValueObjects.v1
{
    public class Email
    {
        public Email(string value)
        {
            Value = value.ToUpperInvariant();
        }
        public string Value { get; }
    }
}
