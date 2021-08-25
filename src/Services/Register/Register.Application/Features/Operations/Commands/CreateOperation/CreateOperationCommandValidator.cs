using FluentValidation;
using System;

namespace Register.Application.Features.Operations.Commands.CreateOperation
{
    public class CreateOperationCommandValidator : AbstractValidator<CreateOperationCommand>
    {
        public CreateOperationCommandValidator()
        {
            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("{UserId} is required.")
                .NotNull();

            RuleFor(p => p.OperationDate)
                .NotEmpty().WithMessage("{OperationDate} is required.")
                .Must(BeAValidDate).WithMessage("A valid {OperationDate} is required")
                //validate if date not in the future
                .NotNull();

            RuleFor(p => p.Ticker)
                .NotEmpty().WithMessage("{Ticker} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Ticker} must not exceed 50 characters.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}