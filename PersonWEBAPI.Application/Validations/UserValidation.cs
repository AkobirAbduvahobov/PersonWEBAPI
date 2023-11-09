using FluentValidation;
using PersonWEBAPI.Domain.Entities;

namespace PersonWEBAPI.Application.Validations;

public class UserValidation : AbstractValidator<Person>
{
    public UserValidation()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(20)
            .MinimumLength(4)
            .WithMessage("Name is not valid");

        RuleFor(p => p.PhoneNumber)
              .Matches(@"^\+998\d{9}$")
              .WithMessage("PhoneNumbers is not valid");

        RuleFor(p => p.Login)
            .NotEmpty()
            .NotNull()
            .MaximumLength(20)
            .MinimumLength(3)
            .WithMessage("Login is not valid");

        RuleFor(p => p.Password)
            .NotEmpty()
            .NotNull()
            .MaximumLength(20)
            .MinimumLength(3)
            .WithMessage("Password is not valid");

    }

}
