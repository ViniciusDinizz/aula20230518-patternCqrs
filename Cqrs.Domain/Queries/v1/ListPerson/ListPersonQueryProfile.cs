using AutoMapper;
using Cqrs.Domain.Entities.v1;
using Cqrs.Domain.Helpers.v1;

namespace Cqrs.Domain.Queries.v1.ListPerson
{
    public class ListPersonQueryProfile : Profile
    {
        public ListPersonQueryProfile()
        {
            CreateMap<Person, PersonItemQueryResponse>()
                .ForMember(fieldOutput => fieldOutput.Cpf, option => option
                    .MapFrom(input => input.Cpf.Value.FormatCpf()))
                .ForMember(fieldOutput => fieldOutput.Name, option => option
                    .MapFrom(input => input.Name.Value))
                .ForMember(fieldOutput => fieldOutput.Email, option => option
                    .MapFrom(input => input.Email.Value));
        }
    }
}