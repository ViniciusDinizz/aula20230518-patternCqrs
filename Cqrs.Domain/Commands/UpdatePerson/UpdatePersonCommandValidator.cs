using Cqrs.Domain.Helpers;
using FluentValidation;

namespace Cqrs.Domain.Commands.UpdatePerson
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator() 
        {
            RuleFor(person => person.Name).NotEmpty()
                .WithMessage("The field {PropertyName} is mandatory");

            RuleFor(person => person.Cpf)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("The field {PropertyName} is mandatory")
                .Must(StringHelper.IsCpf).WithMessage("The field {PropertyName} is not valid for {PropertyName}");

            RuleFor(person => person.DateBirth)
                .NotEmpty().WithMessage("The field {PropertyName} is mandatory");

            RuleFor(person => person.Email)
                .EmailAddress().WithMessage("The field {PropertyName} is not valid").When(person => !string.IsNullOrWhiteSpace(person.Email));
        }
    }
}
