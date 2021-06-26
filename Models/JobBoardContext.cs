using Job_Board.Models.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

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


            modelBuilder.Entity<CategoryModel>().HasData(
                new { Id = Guid.NewGuid().ToString(), Name = "Android Developer" },
                new { Id = Guid.NewGuid().ToString(), Name = "IOS Developer" },
                new { Id = Guid.NewGuid().ToString(), Name = "Web Developer" });


            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole { Name = "Recruiter", NormalizedName = "RECRUITER" },
                    new IdentityRole { Name = "Developer", NormalizedName = "DEVELOPER" }
                );


            base.OnModelCreating(modelBuilder);
        }
    }
}
