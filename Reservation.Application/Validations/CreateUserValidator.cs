using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Reservation.Application.Commands.TripCommand;
using Reservation.Application.Commands.UserCommand;
using Reservation.Application.Validations.ValidMethod;

namespace Reservation.Application.Validations
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("can't be empty or whitespace please check you model")
                .NotNull().WithMessage("can't be Null or whitespace please check you model");
            RuleFor(d => d.Email)

                .NotEmpty().WithMessage("can't be empty or whitespace please check you model")
                .NotNull().WithMessage("can't be Null or whitespace please check you model")
                .Must(d=>d.IsEmailExist()).WithMessage("this Email is Used");

            RuleFor(p => p.Password)
                .NotNull()
                .WithMessage("Please enter password")
                .MinimumLength(6)
                .WithMessage("please insert valid password is larger than 6 character");
            RuleFor(p => p.Phone)
                .NotNull()
                .WithMessage("Please enter user phone number")
                .Length(11)
                .WithMessage("Please enter valid phone number")
                .Must(p => p.IsUniquePhone())
                .WithMessage("this phone number is repeated")
                .Matches("^[0-9]*$")
                .WithMessage("Please enter numeric data only");
        }
    }
}
