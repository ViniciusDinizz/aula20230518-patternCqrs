using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cqrs.Domain.Helpers.v1;

namespace Cqrs.Domain.ValueObjects.v1
{
    public class Document
    {
        public Document(string value)
        {
            Value = value.RemoveMaskCpf();
        }
        public string Value { get; }
    }
}
