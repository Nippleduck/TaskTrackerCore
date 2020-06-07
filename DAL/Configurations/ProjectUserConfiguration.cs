using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    internal class ProjectUserConfiguration : IEntityTypeConfiguration<ProjectUser>
    {
        public void Configure(EntityTypeBuilder<ProjectUser> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(ProjectUser.RefreshTokens));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(u => u.Name)
                .HasMaxLength(80)
                .IsRequired();

            builder.HasIndex(u => u.Name);
        }
    }
}
