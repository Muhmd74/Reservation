using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Reservation.Application.Commands.TripCommand;

namespace Reservation.Application.Validations
{
    public class CreateTripValidator : AbstractValidator<CreateTripCommand>
    {
        public CreateTripValidator()
        {
            RuleFor(d => d.Title)
                .NotEmpty().WithMessage("can't be empty or whitespace please check you model")
                .NotNull().WithMessage("can't be Null or whitespace please check you model")
                .Length(3, 50)
                .WithMessage("Please Check if length of character is between 3 to 64 or not");

        }
    }
}
