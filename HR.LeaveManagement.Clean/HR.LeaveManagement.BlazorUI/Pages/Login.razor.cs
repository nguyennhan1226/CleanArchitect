using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages
{
    public partial class Login
    {
        public LoginVM Model { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        public Login()
        {
            
        }

        protected override void OnInitialized()
        {
            Model = new LoginVM();
        }

        protected async Task HandleLogin()
        {
            var result = await AuthenticationService.AuthenticateAsync(Model.Email, Model.Password);
            if (result)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                Message = "Login failed. Please check your credentials.";
            }
        }
    }
}