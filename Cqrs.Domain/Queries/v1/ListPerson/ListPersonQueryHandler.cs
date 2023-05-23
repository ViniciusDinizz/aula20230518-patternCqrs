using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cqrs.Domain.Contracts.v1;
using Cqrs.Domain.Core.v1;
using Cqrs.Domain.Entities;
using Cqrs.Domain.Helpers.v1;

namespace Cqrs.Domain.Queries.v1.ListPerson
{
    public class ListPersonQueryHandler : BaseHandler
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public ListPersonQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<List<PersonItemQueryResponse>> HandleAsync(ListPersonQuery query, CancellationToken cancellationToken)
        {
            var people = await _personRepository.FindAsync(
                person => 
                (query.Name == null || person.Name.Value.Contains(query.Name.ToUpper()))
                && (query.Cpf == null || person.Cpf.Value.Contains(query.Cpf.RemoveMaskCpf())), cancellationToken);

            return _mapper.Map<List<PersonItemQueryResponse>>(people);
        }
    }
}
