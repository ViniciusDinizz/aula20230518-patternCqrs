using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs.Domain.Domain
{
    public class Person 
    {
        public Person()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        } 

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set;}
        public DateTime UpdateAt { get; set;}
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
