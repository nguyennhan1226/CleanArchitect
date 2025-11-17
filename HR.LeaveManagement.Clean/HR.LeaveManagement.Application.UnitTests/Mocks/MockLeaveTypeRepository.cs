using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;

namespace HR.LeaveManagement.Application.UnitTests.Mocks
{
    public class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaeveTypeMockLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>
        {
            new LeaveType
            {
                Id = 1,
                Name = "Test Vacation",
                DefaultDays = 10
            },
            new LeaveType
            {
                Id = 2,
                Name = "Test Sick",
                DefaultDays = 12
            },
            new LeaveType
            {
                Id = 3,
                Name = "Test Unpaid",
                DefaultDays = 20
            }
        };
            var mockRepo = new Mock<ILeaveTypeRepository>();
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(leaveTypes);
            mockRepo.Setup(re => re.CreateAsync(It.IsAny<LeaveType>())).Returns((LeaveType leaveType) =>
            {
                leaveTypes.Add(leaveType);
                return Task.CompletedTask;
            });

            return mockRepo;
        }
    }
}
