using FluentValidation;
using System.Linq.Expressions;

namespace AuthorizationPlatform.API.Validations.Contracts.Users;

public abstract class UserRequestValidatorBase<T> : AbstractValidator<T>
{
    protected void ValidateUserName(Expression<Func<T, string>> userNameSelector)
    {
        RuleFor(userNameSelector)
            .NotEmpty().WithMessage("Username is required.")
            .MinimumLength(2).WithMessage("Username must be at least 2 characters long.")
            .MaximumLength(100).WithMessage("Username must not exceed 100 characters.");
    }

    protected void ValidateEmail(Expression<Func<T, string>> emailSelector)
    {
        RuleFor(emailSelector)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
    }

    protected void ValidatePassword(Expression<Func<T, string>> passwordSelector)
    {
        RuleFor(passwordSelector)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"[0-9]").WithMessage("Password must contain at least one number.")
            .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");
    }
}