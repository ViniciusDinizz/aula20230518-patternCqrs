using System.Net;
using AutoMapper;
using Cqrs.Domain.Contracts;
using Cqrs.Domain.Core;
using Cqrs.Domain.Domain;

namespace Cqrs.Domain.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : BaseHandler
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public UpdatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<Guid> HandleAsync(UpdatePersonCommand command, CancellationToken cancellationToken)
        {
            var dataBaseEntity = await _personRepository.GetByIdAsync(command.Id, cancellationToken);
            if (string.IsNullOrWhiteSpace(dataBaseEntity?.Name))
            {
                AddNotification($"Person with id = {command.Id} does not exist.");
                SetStatusCode(HttpStatusCode.NotFound);
                return Guid.Empty;
            }

            var entity = _mapper.Map<Person>(command);
            entity.CreatedAt = dataBaseEntity.CreatedAt;
            await _personRepository.UpdateAsync(entity, cancellationToken);
            return entity.Id;
        }
    }
}
