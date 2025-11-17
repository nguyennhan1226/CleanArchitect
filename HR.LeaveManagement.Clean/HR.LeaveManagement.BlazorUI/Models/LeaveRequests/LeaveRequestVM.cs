using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.BlazorUI.Models.LeaveRequests
{
    public class LeaveRequestVM
    {
        public int Id { get; set; }

        [Display(Name = "Date Requested")]
        public DateTime DateRequested { get; set; }

        [Display(Name = "Date Actioned")]
        public DateTime DateActioned { get; set; }

        [Display(Name ="Approval state")]
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
        public LeaveTypeVM LeaveType { get; set; } = new LeaveTypeVM();
        public EmployeeVM Employee{ get; set; } = new EmployeeVM();

        [Required]
        [Display(Name ="Start Date")]
        public DateTime? StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Required]
        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }

        [MaxLength(300)]
        [Display(Name = "Request Comments")]
        public string? RequestComments { get; set; }



    }
}
