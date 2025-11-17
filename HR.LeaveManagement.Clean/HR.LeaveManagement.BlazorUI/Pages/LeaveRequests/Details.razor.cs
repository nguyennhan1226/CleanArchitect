using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveRequests;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveRequests
{
    public partial class Details
    {
        [Inject] ILeaveRequestService LeaveRequestService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Parameter] public int id { get; set; }
        public LeaveRequestVM Model { get; private set; } = new LeaveRequestVM();
        string ClassName;
        string HeadingText;

        protected override async Task OnParametersSetAsync()
        {
            Model = await LeaveRequestService.GetLeaveRequest(id);
        }

        protected override async Task OnInitializedAsync()
        {
            Model = await LeaveRequestService.GetLeaveRequest(id);
            if (Model.Approved == null)
            {
                ClassName = "warning";
                HeadingText = "Pending Approval";
            }
            else if (Model.Approved == true)
            {
                ClassName = "success";
                HeadingText = "Approved";
            }
            else
            {
                ClassName = "danger";
                HeadingText = "Rejected";
            }
        }

        public async Task ChangeApproval(bool approved)
        {
           await LeaveRequestService.ApproveLeaveRequest(id, approved);
           NavigationManager.NavigateTo("/leaverequests/");
        }
    }
}