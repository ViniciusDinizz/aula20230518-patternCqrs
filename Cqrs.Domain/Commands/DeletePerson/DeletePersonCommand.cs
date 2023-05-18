using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs.Domain.Commands.DeletePerson
{
    public class DeletePersonCommand
    {
        public DeletePersonCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
