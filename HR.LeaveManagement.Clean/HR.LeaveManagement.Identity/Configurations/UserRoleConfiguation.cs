using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.Configurations
{
    public class UserRoleConfiguation : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "8a1c2b3d-4e5f-6789-0abc-def123456789",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "8a1c2bed-4e5f-6788-0abc-def123456789",
                    UserId = "b74ddd15-6342-4840-95c2-db12554843e5"
                }
                );
        }
    }
}
