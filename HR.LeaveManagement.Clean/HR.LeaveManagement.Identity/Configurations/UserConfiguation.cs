using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.Configurations
{
    public class UserConfiguation : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ApplicationUser> builder)
        {

            builder.HasData(
                new ApplicationUser
                {
                    Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = "AQAAAAIAAYagAAAAELbv1MEhKiQQxhZqTYlqD6Y6rJPO++K2Yib1lR3rLctJKDRyZOrFMwKXD2go34HL5w==",
                    EmailConfirmed = true,
                    SecurityStamp = "JXESUAHBQEBJ4EYBCQZQV4KSRTRSQ2L2",
                    ConcurrencyStamp = "c8554266-b401-4519-9aeb-b5c87a9c3c2e"
                },
                new ApplicationUser
                {
                    Id = "b74ddd15-6342-4840-95c2-db12554843e5",
                    Email = "user@localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "User",
                    UserName = "user@localhost.com",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    PasswordHash = "AQAAAAIAAYagAAAAELbv1MEhKiQQxhZqTYlqD6Y6rJPO++K2Yib1lR3rLctJKDRyZOrFMwKXD2go34HL5w==",
                    EmailConfirmed = true,
                    SecurityStamp = "JXESUAHBQEBJ4EYBCQZQV4KSRTRSQ2L3",
                    ConcurrencyStamp = "c8554266-b401-4519-9aeb-b5c87a9c3c2f"
                });
        }
    }
}
