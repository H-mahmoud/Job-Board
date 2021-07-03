using Job_Board.Models.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Job_Board.Models
{
    public class JobBoardContext : IdentityDbContext
    {
        public JobBoardContext(DbContextOptions<JobBoardContext> options) : base(options)
        {
        }

        public DbSet<JobModel> jobs { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<UserModel> Useres { get; set; }

        public DbSet<UserJob> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserJobConfiguration());



            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole { Id = "2", Name = "Recruiter", NormalizedName = "RECRUITER" },
                    new IdentityRole { Id = "3", Name = "Developer", NormalizedName = "DEVELOPER" }
                );


            var hasher = new PasswordHasher<UserModel>();
            modelBuilder.Entity<UserModel>().HasData(
                    new UserModel { Id = "1", UserName = "Admin", Email = "admin@jobboard.com", EmailConfirmed = true,
                        FirstName = "Hassan", LastName = "Admin",
                        PasswordHash = hasher.HashPassword(null, "AdminJobBoard@"),
                        SecurityStamp = string.Empty,
                        NormalizedEmail = "ADMIN@JOBBOARD.COM",
                        NormalizedUserName = "ADMIN"
                    }
                );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "1"
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
