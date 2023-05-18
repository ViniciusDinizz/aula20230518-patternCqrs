using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cqrs.Domain.Domain;
using Cqrs.Domain.Helpers;

namespace Cqrs.Domain.Queries.ListPerson
{
    public class ListPersonQueryProfile : Profile
    {
        public ListPersonQueryProfile() 
        {
            CreateMap<Person, ListePersonQueryResponse>()
                .ForMember(fieldOutput => fieldOutput.Cpf, option => option.MapFrom(input => input.Cpf.FormatCpf()));
        }
    }
}
