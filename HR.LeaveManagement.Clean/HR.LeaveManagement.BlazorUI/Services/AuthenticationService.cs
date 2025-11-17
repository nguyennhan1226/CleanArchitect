using Blazored.LocalStorage;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Providers;
using HR.LeaveManagement.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace HR.LeaveManagement.BlazorUI.Services
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public AuthenticationService(
            IClient iclient, 
            ILocalStorageService localStorageService,
            AuthenticationStateProvider authenticationStateProvider, 
            ILoggerFactory loggerFactory) 
            : base(iclient, localStorageService, loggerFactory)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }
        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            try
            {
                _logger.LogInformation("Starting authentication for email: {Email}", email);

                AuthRequest request = new AuthRequest
                {
                    Email = email,
                    Password = password
                };

                var response = await _client.LoginAsync(request);
                _logger.LogInformation("Login response received. Token exists: {HasToken}", !string.IsNullOrEmpty(response.Token));

                if (!string.IsNullOrEmpty(response.Token)) // ✅ Sửa condition
                {
                    await _localStorageService.SetItemAsync("token", response.Token);
                    _logger.LogInformation("Token saved to localStorage");

                    await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();
                    _logger.LogInformation("Authentication state updated successfully");

                    return true;
                }

                _logger.LogWarning("Login failed - empty token received");
                return false;
            }
            catch (ApiException apiEx)
            {
                _logger.LogWarning("API Authentication failed. Status: {StatusCode}, Response: {Response}",
                    apiEx.StatusCode, apiEx.Response);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Authentication failed with unexpected error: {Error}", ex.Message);
                return false;
            }
        }

        public async Task Logout()
        {
           await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
        }

        public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
        {
            RegistrationRequest request = new RegistrationRequest
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Email = email,
                Password = password
            };
            var response = await _client.RegisterAsync(request);
            if (response.UserId != string.Empty)
            {
                return true;
            }

            return false;
        }
    }
}
