using FluentValidation;

namespace Register.Application.Features.OperationTypes.Commands.CreateOperationType
{
    public class CreateOperationTypeCommandValidator : AbstractValidator<CreateOperationTypeCommand>
    {
        public CreateOperationTypeCommandValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}