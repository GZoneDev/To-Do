using FluentValidation;
using System.Linq.Expressions;

namespace TaskPlatform.API.Validations.Contracts;

public abstract class TaskRequestValidatorBase<T> : AbstractValidator<T>
{
    protected void ValidateName(Expression<Func<T, string>> nameSelector)
    {
        RuleFor(nameSelector)
            .NotEmpty().WithMessage("Name is required.")
            .MinimumLength(2).WithMessage("Name must be at least 2 characters long.")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");
    }

    protected void ValidateDescription(Expression<Func<T, string>> descriptionSelector)
    {
        RuleFor(descriptionSelector)
            .NotEmpty().WithMessage("Description is required.")
            .MinimumLength(2).WithMessage("Description must be at least 2 characters long.")
            .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");
    }
}
