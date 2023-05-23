using Cqrs.Domain.Helpers.v1;
using FluentValidation;

namespace Cqrs.Domain.Commands.v1.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(person => person.Name).NotEmpty().WithMessage("The field {PropertyName} is mandatory")
                .MaximumLength(50).WithMessage("The field {PropertyName} maximum string 50");

            RuleFor(person => person.Cpf).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("The field {PropertyName} is mandatory")
                .Must(StringHelper.IsCpf).WithMessage("The value {PropertyValue} is not valid for {PropertyName}");

            RuleFor(person => person.DateBirth)
                .NotEmpty().WithMessage("The field {PropertyName} is mandatory");

            RuleFor(person => person.Email)
                .EmailAddress().WithMessage("The field {PropertyName} is not valid")
                .When(person => !string.IsNullOrWhiteSpace(person.Email));
        }
    }
}