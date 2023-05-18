using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cqrs.Domain.Domain;
using Cqrs.Domain.Helpers;

namespace Cqrs.Domain.Queries.GetPerson
{
    public class GetPersonQueryProfile : Profile
    {
        public GetPersonQueryProfile() 
        {
            CreateMap<Person, GetPersonQueryResponse>()
                .ForMember(fieldOutput => fieldOutput.Cpf, option => option
                .MapFrom(input => input.Cpf.FormatCpf()));
        }
    }
}
