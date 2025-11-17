using Blazored.LocalStorage;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Infrastructure.Logging;
using Microsoft.Extensions.Logging;

namespace HR.LeaveManagement.BlazorUI.Services.Base
{
    public class BaseHttpService
    {
        protected IClient _client;
        protected readonly ILocalStorageService _localStorageService;
        protected readonly IAppLogger<BaseHttpService> _logger;
        
        public BaseHttpService(IClient client, ILocalStorageService localStorageService, ILoggerFactory loggerFactory)
        {
            _client = client;
            _localStorageService = localStorageService;
             _logger = new LoggerAdapter<BaseHttpService>(loggerFactory);
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException apiException)
        {
            _logger.LogWarning("API Exception occurred. Status Code: {StatusCode}, Response: {Response}", 
                apiException.StatusCode, apiException.Response);

            if (apiException.StatusCode == 400)
            {
                return new Response<Guid>
                {
                    Message = "Validation errors have occurred.",
                    ValidationErrors = apiException.Response,
                    Success = false
                };
            }
            else if (apiException.StatusCode == 401)
            {
                return new Response<Guid>
                {
                    Message = "Unauthorized. Please login again.",
                    Success = false
                };
            }
            else if (apiException.StatusCode == 404)
            {
                return new Response<Guid>
                {
                    Message = "The requested item could not be found.",
                    Success = false
                };
            }
            else 
            {
                return new Response<Guid>
                {
                    Message = "Something went wrong, please try again.",
                    Success = false
                };
            }
        }

        protected async Task AddBearerToken()
        {
            try
            {
                if(await _localStorageService.ContainKeyAsync("token"))
                {
                    var token = await _localStorageService.GetItemAsync<string>("token");
                    
                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        // Clear existing authorization header
                        _client.HttpClient.DefaultRequestHeaders.Authorization = null;
                        
                        // Set new authorization header
                        _client.HttpClient.DefaultRequestHeaders.Authorization = 
                            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                        
                        _logger.LogInformation("Bearer token added successfully");
                    }
                    else
                    {
                        _logger.LogWarning("Token is empty or null");
                    }
                }
                else
                {
                    _logger.LogWarning("No token found in localStorage");
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Error adding bearer token: {ErrorMessage}", ex.Message);
            }
        }
    }
}
