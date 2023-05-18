using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cqrs.Domain.Domain;
using Cqrs.Domain.Helpers;

namespace Cqrs.Domain.Commands.UpdatePerson
{
    public class UpdatePersonCommandProfile : Profile
    {
        public UpdatePersonCommandProfile() 
        {
            CreateMap<UpdatePersonCommand, Person>()
                .ForMember(fieldOutput => fieldOutput.Cpf, option =>
                option.MapFrom(input => input.Cpf.RemoveMaskCpf()))
                .ForMember(fieldOutput => fieldOutput.Name, option =>
                option.MapFrom(input => input.Name.ToUpper()))
                .ForMember(fieldOutput => fieldOutput.Email, option =>
                option.MapFrom(input => input.Email.ToUpper()));
        }
    }
}
