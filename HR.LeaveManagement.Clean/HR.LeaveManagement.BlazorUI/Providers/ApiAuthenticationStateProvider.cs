using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HR.LeaveManagement.BlazorUI.Providers
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly JwtSecurityTokenHandler _tokenHandler;
        public ApiAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
            _tokenHandler = new JwtSecurityTokenHandler();
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            var isTokenPresent = await _localStorageService.ContainKeyAsync("token");
            if(isTokenPresent == false)
            {
                return new AuthenticationState(user);
            }
            var savedToken = await _localStorageService.GetItemAsync<string>("token");
            var tokenContent = _tokenHandler.ReadJwtToken(savedToken);
            if (tokenContent.ValidTo < DateTime.UtcNow)
            {
                await _localStorageService.RemoveItemAsync("token");
                return new AuthenticationState(user);

            }

            var claims = await GetClaims();
            var identity = new ClaimsIdentity(claims, "jwt");
            user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }
        public async Task LoggedIn()
        {
            var claims = await GetClaims();
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);
            var authState = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));

        }
        public async Task LoggedOut()
        {
            await _localStorageService.RemoveItemAsync("token");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            var authState = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        private async Task<List<Claim>> GetClaims()
        {
            var savedToken = await _localStorageService.GetItemAsync<string>("token");
            if (string.IsNullOrWhiteSpace(savedToken))
            {
                return [];
            }
            var tokenContent = _tokenHandler.ReadJwtToken(savedToken);
            
            var claims =  tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }
    }
}
