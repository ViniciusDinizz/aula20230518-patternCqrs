using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs.Domain.Commands.v1.CreatePerson
{
    public class CreatePersonCommand
    {
        public CreatePersonCommand(string? name, string? cpf, string? email, DateTime? dateBirth)
        {
            Name = name;
            Cpf = cpf;
            Email = email;
            DateBirth = dateBirth;
        }

        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public DateTime? DateBirth { get; set; }
    }
}