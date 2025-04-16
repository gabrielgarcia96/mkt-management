using System.ComponentModel.DataAnnotations;
using Marketing.Domain.Enums;

namespace Marketing.Application.DTOs;

public class RegisterDto : LoginDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    [Required, Compare(nameof(Password)), DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }

}
