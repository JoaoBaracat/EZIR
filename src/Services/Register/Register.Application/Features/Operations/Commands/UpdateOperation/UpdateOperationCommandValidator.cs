using FluentValidation;
using System;

namespace Register.Application.Features.Operations.Commands.UpdateOperation
{
    public class CreateOperationCommandValidator : AbstractValidator<UpdateOperationCommand>
    {
        public CreateOperationCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(x => x.OperationDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(BeAValidDate).WithMessage("A valid {PropertyName} is required")
                .NotNull();

            RuleFor(x => x.OrderType)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be grater than zero.");

            RuleFor(x => x.Ticker)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be grater than zero.");

            RuleFor(x => x.CostsType)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.StockBrokerId)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.FeeType)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.OperationTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}