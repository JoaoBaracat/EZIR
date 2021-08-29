using FluentValidation;

namespace Register.Application.Features.OperationTypes.Commands.UpdateOperationType
{
    public class CreateOperationTypeCommandValidator : AbstractValidator<UpdateOperationTypeCommand>
    {
        public CreateOperationTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}