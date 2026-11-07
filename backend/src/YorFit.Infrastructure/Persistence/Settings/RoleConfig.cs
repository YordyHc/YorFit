using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YorFit.Domain.Entities;

namespace YorFit.Infrastructure.Persistence.Settings;

public class RoleConfig: IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(role => role.Nombre)
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(role => role.Nombre)
            .IsUnique();

        builder.Property(role => role.Descripcion)
            .HasMaxLength(100)
            .IsRequired();
    }
}