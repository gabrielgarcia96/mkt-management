using Marketing.Domain.Enums;

namespace Marketing.App.Security;

public class AuthService
{
    public bool IsLoggedIn { get; private set; }
    public LoginDto? CurrentUser { get; private set; }

    public bool IsAdmin => CurrentUser != null && CurrentUser.Roles == Role.Admin;


    public event Action OnChange;

    public void SetLoggedIn(bool isLoggedIn, LoginDto loginDto = null)
    {
        IsLoggedIn = isLoggedIn;
        CurrentUser = loginDto;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
