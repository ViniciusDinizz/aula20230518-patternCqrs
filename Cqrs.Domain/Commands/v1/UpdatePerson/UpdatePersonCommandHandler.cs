using System.Net;
using AutoMapper;
using Cqrs.Domain.Contracts.v1;
using Cqrs.Domain.Core.v1;
using Cqrs.Domain.Entities.v1;

namespace Cqrs.Domain.Commands.v1.UpdatePerson
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
            var dataBaseEntity = await _personRepository.FindByIdAsync(command.Id, cancellationToken);
            if (dataBaseEntity is null)
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