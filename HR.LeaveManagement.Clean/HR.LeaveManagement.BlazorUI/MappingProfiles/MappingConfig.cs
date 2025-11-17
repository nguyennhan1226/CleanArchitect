using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using HR.LeaveManagement.BlazorUI.Models;
using HR.LeaveManagement.BlazorUI.Models.LeaveRequests;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.MappingProfiles
{
    public class MappingConfig : Profile
    {

        public MappingConfig()
        {
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
            CreateMap<CreateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();
            CreateMap<UpdateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();
            CreateMap<CreateLeaveRequestCommand, LeaveRequestVM>().ReverseMap();
            CreateMap<UpdateLeaveRequestCommand, LeaveRequestVM>().ReverseMap();

            // Fix for DateTimeOffset to DateTime conversion
            CreateMap<LeaveRequestDto, LeaveRequestVM>()
                .ForMember(dest => dest.DateRequested, opt => opt.MapFrom(src => src.DateRequested.DateTime))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.DateTime))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.DateTime))
                .ReverseMap()
                .ForMember(dest => dest.DateRequested, opt => opt.MapFrom(src => new DateTimeOffset(src.DateRequested)))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => new DateTimeOffset(src.StartDate.Value)))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => new DateTimeOffset(src.EndDate.Value)));

            CreateMap<LeaveRequestsDetailDto, LeaveRequestVM>().ReverseMap();
            CreateMap<EmployeeVM, Employee>().ReverseMap();

            // Global type converter for DateTimeOffset to DateTime
            CreateMap<DateTimeOffset, DateTime>().ConvertUsing(src => src.DateTime);
            CreateMap<DateTimeOffset?, DateTime?>().ConvertUsing(src => src.HasValue ? src.Value.DateTime : null);
        }
    }
}
