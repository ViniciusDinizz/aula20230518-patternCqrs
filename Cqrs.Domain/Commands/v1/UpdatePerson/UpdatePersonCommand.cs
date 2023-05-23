using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cqrs.Domain.Commands.v1.UpdatePerson
{
    public class UpdatePersonCommand
    {
        public UpdatePersonCommand(string? name, string? cpf, string? email, DateTime? dateBirth)
        {
            Name = name;
            Cpf = cpf;
            Email = email;
            DateBirth = dateBirth;
        }
        [JsonIgnore]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public DateTime? DateBirth { get; set; }
    }
}
