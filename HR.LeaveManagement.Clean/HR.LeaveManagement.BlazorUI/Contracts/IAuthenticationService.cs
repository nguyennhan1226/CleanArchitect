namespace HR.LeaveManagement.BlazorUI.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task Logout();
        Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password);
    }
}
