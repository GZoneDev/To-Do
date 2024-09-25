using AuthenticationPlatform.Core.Models;
using AuthenticationPlatform.Application.Interfaces.Auth;
using AuthenticationPlatform.Application.Interfaces.Repositories;
using AuthenticationPlatform.Application.Common;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuthenticationPlatform.Application.Services;

public class UserAuthorizationService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUsersRepository _usersRepository;
    private readonly ITokenProvider _tokenProvider;

    public UserAuthorizationService(
        IUsersRepository usersRepository,
        IPasswordHasher passwordHasher,
        ITokenProvider tokenProvider)
    {
        _usersRepository = usersRepository;
        _passwordHasher = passwordHasher;
        _tokenProvider = tokenProvider;
    }

    public async Task<Result<string>> RegisterAsync(string userName, string email, string password)
    {
        var existingUser = await _usersRepository.GetByEmailAsync(email);

        if (existingUser is not null)
        {
            return Result<string>.Failure("User with this email already exists.", System.Net.HttpStatusCode.Conflict);
        }

        var hashedPassword = _passwordHasher.Generate(password);
        var newUser = User.Create(Guid.NewGuid(), userName, email, hashedPassword);

        await _usersRepository.AddAsync(newUser);

        return Result<string>.Success("Registration completed successfully.");
    }

    private Result<string> UserValidate(User user)
    {
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(user);

        bool isValid = Validator.TryValidateObject(user, context, validationResults, true);

        if (!isValid)
        {
            StringBuilder errors = new StringBuilder();

            foreach (var error in validationResults)
            {
                errors.AppendLine($"{error.ErrorMessage}\n");
            }

            return Result<string>.Failure(errors.ToString());
        }

        return Result<string>.Success(string.Empty);
    }

    public async Task<Result<string>> LoginAsync(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email))
            return Result<string>.Failure("Email cannot be empty.");

        if (string.IsNullOrWhiteSpace(password))
            return Result<string>.Failure("Password cannot be empty.");

        var user = await _usersRepository.GetByEmailAsync(email);

        if (user is null)
        {
            return Result<string>.Failure("User with this email does not exist.", System.Net.HttpStatusCode.NotFound);
        }

        var isPasswordValid = _passwordHasher.Verify(password, user.PasswordHash);

        if (!isPasswordValid)
        {
            return Result<string>.Failure("Invalid password.", System.Net.HttpStatusCode.Unauthorized);
        }

        var token = _tokenProvider.GenerateToken(user);

        return Result<string>.Success(token);
    }
}