using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Job_Board.Models.Configuration
{
    public class JobConfiguration : IEntityTypeConfiguration<JobModel>
    {

        public void Configure(EntityTypeBuilder<JobModel> builder)
        {
            #region Properties

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.Location)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.PublishedAt)
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IsAccepted)
                .HasDefaultValueSql("0")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Vacancy)
                .IsRequired();

            builder.Property(p => p.Salary)
                .IsRequired();

            builder.Property(p => p.JobNature)
                .IsRequired();

            #endregion

            builder.HasOne(d => d.Category)
                    .WithMany(p => p.jobs)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(d => d.Recruter)
                    .WithMany(p => p.MyJobs)
                    .HasForeignKey(d => d.RecruterId);

        }
    }
}
