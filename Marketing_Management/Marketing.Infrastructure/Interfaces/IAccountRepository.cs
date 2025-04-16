using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing.Domain.Models;

namespace Marketing.Infrastructure.Interfaces
{
    public interface IAccountRepository
    {
        Task<User> GetUserAsync(string username);
        Task<User> GetEmailAsync(string email);
        Task<List<User>> GetAllUserAsync();
        Task CreateUserAsync(User user);
        Task UpdateUser(string username, User user);
        Task DeleteUserAsync(string username);

    }
}
