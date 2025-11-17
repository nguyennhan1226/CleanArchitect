using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.IntergrationTests
{
    public class HrDatabaseContextTests
    {
        private HrDatabaseContext _hrDatabaseContext;
        public HrDatabaseContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<HrDatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _hrDatabaseContext = new HrDatabaseContext(dbContextOptions);
        }

        [Fact]
        public async Task Save_SetDatedCreatedValue()
        {
            // Arrange
            var leaveType = new LeaveType
            {
                Id = 1,
                Name = "Test Vacation",
                DefaultDays = 10
            };

            // Act
            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();
            leaveType.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async Task Save_SetDatedModifiedValue()
        {
            // Arrange
            var leaveType = new LeaveType
            {
                Id = 1,
                Name = "Test Vacation",
                DefaultDays = 10
            };
            // Act
            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();

            leaveType.DateModified.ShouldNotBeNull();

        }
    }
}
