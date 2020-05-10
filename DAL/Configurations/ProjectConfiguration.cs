using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(p => p.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(p => p.Manager)
                .WithOne(u => u.Project)
                .HasForeignKey<User>(u => u.ProjectId);

            builder.HasMany(p => p.Users);
        }
    }
}
