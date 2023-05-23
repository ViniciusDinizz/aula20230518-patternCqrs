using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cqrs.Domain.Entities.v1;
using Cqrs.Domain.Helpers.v1;

namespace Cqrs.Domain.Queries.v1.GetPerson
{
    public class GetPersonQueryProfile : Profile
    {
        public GetPersonQueryProfile()
        {
            CreateMap<Person, GetPersonQueryResponse>()
                .ForMember(fieldOutput => fieldOutput.Cpf, option => option
                    .MapFrom(input => input.Cpf.Value.FormatCpf()))
                .ForMember(fieldOutput => fieldOutput.Name, option => option
                    .MapFrom(input => input.Name.Value))
                .ForMember(fieldOutput => fieldOutput.Email, option => option
                    .MapFrom(input => input.Email.Value));
        }
    }
}