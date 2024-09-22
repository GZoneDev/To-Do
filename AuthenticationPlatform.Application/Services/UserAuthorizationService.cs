using AuthenticationPlatform.Core.Models;
using AuthenticationPlatform.Application.Interfaces.Auth;
using AuthenticationPlatform.Application.Interfaces.Repositories;
using AuthenticationPlatform.Application.Common;

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
        _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
        _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        _tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
    }

    public async Task<Result<string>> RegisterAsync(string userName, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(userName))
            return Result<string>.Failure("Username cannot be empty.");

        if (string.IsNullOrWhiteSpace(email))
            return Result<string>.Failure("Email cannot be empty.");

        if (string.IsNullOrWhiteSpace(password))
            return Result<string>.Failure("Password cannot be empty.");

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