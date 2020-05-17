using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(p => p.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(p => p.ProjectManager)
                .WithOne(u => u.Project)
                .HasForeignKey<ProjectUser>(u => u.ProjectId);

            builder.HasMany(p => p.Users);
        }
    }
}
