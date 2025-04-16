using System.Security.Claims;
using Blazored.LocalStorage;
using Marketing.Domain.Enums;
using Microsoft.AspNetCore.Components.Authorization;

namespace Marketing.App.Security
{
    public class CustomAuthProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _principal = new ClaimsPrincipal(new ClaimsIdentity());
        private readonly ILocalStorageService _localStorage;

        public CustomAuthProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }


        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
        }

        public async Task MarkUserAsAuthenticated(string username, Role role)
        {
            var identity = new ClaimsIdentity(new[]
            {
        new Claim(ClaimTypes.Name, username),
        new Claim(ClaimTypes.Role, role.ToString())
    }, "apiauth");

            _principal = new ClaimsPrincipal(identity);

            Console.WriteLine($"Authenticate User: {username}, Role: {role}");
            Console.WriteLine($"Identity IsAuthenticated: {_principal.Identity.IsAuthenticated}");

            await _localStorage.SetItemAsync("username", username);
            await _localStorage.SetItemAsync("role", role.ToString());

            await Task.Delay(100);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_principal)));
        }
    }
}
