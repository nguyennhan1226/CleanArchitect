using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.Configurations
{
    public class RoleConfiguation : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    Id = "8a1c2b3d-4e5f-6789-0abc-def123456789"
                },
                new IdentityRole
                {
                    Name = "Employee",
                    NormalizedName = "Employee",
                    Id = "8a1c2bed-4e5f-6788-0abc-def123456789"
                }
                );
        }
    }
}
