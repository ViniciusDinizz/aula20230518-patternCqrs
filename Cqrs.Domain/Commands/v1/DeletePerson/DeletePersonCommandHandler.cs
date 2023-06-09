﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cqrs.Domain.Contracts.v1;

namespace Cqrs.Domain.Commands.v1.DeletePerson
{
    public class DeletePersonCommandHandler
    {
        private readonly IPersonRepository _personRepository;

        public DeletePersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task HandleAsync(DeletePersonCommand command, CancellationToken cancellationToken)
        {
            await _personRepository.RemoveAsync(command.Id, cancellationToken);
        }
    }
}
