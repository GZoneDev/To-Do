using AuthorizationPlatform.API.Contracts.Users;

namespace AuthorizationPlatform.API.Validations.Contracts.Users;

public class RegisterUserRequestValidator : UserRequestValidatorBase<RegisterUserRequest>
{
    public RegisterUserRequestValidator()
    {
        ValidateUserName(request => request.UserName);
        ValidateEmail(request => request.Email);
        ValidatePassword(request => request.Password);
    }
}
