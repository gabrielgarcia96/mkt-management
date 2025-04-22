using Marketing.Application.DTOs;
using Marketing.Application.Interfaces;
using Marketing.Domain.Enums;
using Marketing.Domain.Models;
using Marketing.Infrastructure.Interfaces;

namespace Marketing.Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public Task<User> GetUserAsync(string username)
    {
        return _accountRepository.GetUserAsync(username);
    }
    public Task<User> GetEmailAsync(string email)
    {
        return _accountRepository.GetEmailAsync(email);
    }

    public async Task RegisterAsync(RegisterDto registerDto)
    {

        var existUser = await _accountRepository.GetUserAsync(registerDto.Username);

        if (registerDto.Password != registerDto.ConfirmPassword)
        {
            throw new ArgumentException("Passwords do not match.");
        }

        if (existUser != null)
        {
            Console.WriteLine("Username already exists!");
            return;
        }

        var newUser = new User
        {
            Username = registerDto.Username.ToLower(),
            Email = registerDto.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
            Role = Role.User

        };

        await _accountRepository.CreateUserAsync(newUser);

    }

    public async Task<LoginDto> ValidadeUserAsync(string username, string password)
    {
        var getUser = await _accountRepository.GetUserAsync(username);


        if (getUser == null)
        {
            throw new UnauthorizedAccessException("User not found!");
        }

        var storedPassword = getUser.Password;

        if (string.IsNullOrEmpty(storedPassword))
        {
            throw new UnauthorizedAccessException("Stored password is null or empty!");
        }

        if (!BCrypt.Net.BCrypt.Verify(password, storedPassword))
        {
            throw new UnauthorizedAccessException("Invalid username or password!");
        }


        return new LoginDto
        {
            Username = username,
            Roles = getUser.Role
        };

    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _accountRepository.GetAllUserAsync();
    }

    public Task UpdateUser(string username, User user)
    {
        return _accountRepository.UpdateUser(username, user);
    }

}
