using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cqrs.Domain.Contracts.v1;
using Cqrs.Domain.Entities.v1;

namespace Cqrs.Domain.Commands.v1.CreatePerson
{
    public class CreatePersonCommandHandler
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<Guid> HandleAsync(
            CreatePersonCommand command,
            CancellationToken cancellationToken)
        {
            Person personReturn = _mapper.Map<Person>(command);
            await _personRepository.AddAsync(personReturn, cancellationToken);
            return personReturn.Id;
        }
    }
}
