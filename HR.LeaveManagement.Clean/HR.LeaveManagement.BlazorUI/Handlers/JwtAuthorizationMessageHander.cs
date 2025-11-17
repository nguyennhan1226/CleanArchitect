using Blazored.LocalStorage;

namespace HR.LeaveManagement.BlazorUI.Handlers
{
    public class JwtAuthorizationMessageHander : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorageService;
        public JwtAuthorizationMessageHander(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _localStorageService.GetItemAsync<string>("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
