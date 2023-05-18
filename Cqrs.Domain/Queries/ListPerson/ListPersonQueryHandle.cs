using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cqrs.Domain.Contracts;
using Cqrs.Domain.Domain;

namespace Cqrs.Domain.Queries.ListPerson
{
    public class ListPersonQueryHandle
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public ListPersonQueryHandle(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task <IEnumerable<ListePersonQueryResponse>> HandleAsync(ListPersonQuery query, CancellationToken cancellationToken)
        {
            var people = await _personRepository.GetAsync(person => (query.Name == null || person.Name.Contains(query.Name.ToUpper()))
                && (query.Cpf == null || person.Cpf.Contains(query.Cpf)), cancellationToken);

            return _mapper.Map<IEnumerable<ListePersonQueryResponse>>(people);
        }
    }
}
