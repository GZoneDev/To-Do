using AuthorizationPlatform.API.Contracts.Users;

namespace AuthorizationPlatform.API.Validations.Contracts.Users;

public class LoginUserRequestValidator : UserRequestValidatorBase<LoginUserRequest>
{
    public LoginUserRequestValidator()
    {
        ValidateEmail(request => request.Email);
        ValidatePassword(request => request.Password);
    }
}
