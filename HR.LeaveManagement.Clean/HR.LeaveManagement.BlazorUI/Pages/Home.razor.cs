using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Providers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace HR.LeaveManagement.BlazorUI.Pages
{
    public partial class Home
    {
        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ((ApiAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
        }

        protected async Task Logout()
        {
            await AuthenticationService.Logout();
            NavigationManager.NavigateTo("/login");
        }

        protected void Login()
        {
            NavigationManager.NavigateTo("/login");
        }

        protected void Register()
        {
            NavigationManager.NavigateTo("/register");
        }
    }
}