namespace Marketing.App.Security;

public class AuthService
{
    public bool IsLoggedIn { get; private set; }

    public event Action OnChange;

    public void SetLoggedIn(bool isLoggedIn)
    {
        IsLoggedIn = isLoggedIn;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
