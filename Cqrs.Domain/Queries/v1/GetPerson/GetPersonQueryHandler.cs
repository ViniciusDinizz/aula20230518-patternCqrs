using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cqrs.Domain.Contracts.v1;
using Cqrs.Domain.Core.v1;

namespace Cqrs.Domain.Queries.v1.GetPerson
{
    public class GetPersonQueryHandler : BaseHandler
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public GetPersonQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<GetPersonQueryResponse?> HandleAsync(GetPersonQuery command, CancellationToken cancellationToken)
        {
            var dataBaseEntity = await _personRepository.FindByIdAsync(command.Id, cancellationToken);

            if (dataBaseEntity is not null)
            {
                return _mapper.Map<GetPersonQueryResponse>(dataBaseEntity);
            }

            AddNotification($"Person with id = {command.Id} does not exist.");
            SetStatusCode(HttpStatusCode.NotFound);
            return null;
        }
    }
}
