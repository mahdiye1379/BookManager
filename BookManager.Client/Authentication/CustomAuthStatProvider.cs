using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace BookManager.Client.Authentication
{
    public class CustomAuthStatProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _currentUser =
            new(new ClaimsIdentity());

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(
                new AuthenticationState(_currentUser));
        }

        public void Login(string userName)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userName)
            };

            var identity = new ClaimsIdentity(
                claims,
                authenticationType: "BookManagerAuth");

            _currentUser = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(
                GetAuthenticationStateAsync());
        }

        public void Logout()
        {
            _currentUser = new ClaimsPrincipal(
                new ClaimsIdentity());

            NotifyAuthenticationStateChanged(
                GetAuthenticationStateAsync());
        }
    }
}
