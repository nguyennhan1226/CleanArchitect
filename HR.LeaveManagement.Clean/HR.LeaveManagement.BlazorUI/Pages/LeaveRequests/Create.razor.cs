using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveRequests;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveRequests
{
    public partial class Create
    {
        [Inject] ILeaveTypeService leaveTypeService { get; set; }
        [Inject] ILeaveRequestService leaveRequestService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        LeaveRequestVM LeaveRequest { get; set; } = new LeaveRequestVM();
        List<LeaveTypeVM> leaveTypeVMs = new List<LeaveTypeVM>();
        private async Task HandleValidSubmit()
        {
            await leaveRequestService.CreateLeaveRequest(LeaveRequest);
            NavigationManager.NavigateTo("/leaverequests/");

        }

        protected override async Task OnInitializedAsync()
        {
            leaveTypeVMs = await leaveTypeService.GetLeaveTypes();
            // Set the first leave type as default selection
            if (leaveTypeVMs.Any())
            {
                LeaveRequest.LeaveTypeId = leaveTypeVMs.First().Id;
            }
        }
    }
    
}