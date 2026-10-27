using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YorFit.Domain.Entities;

namespace YorFit.Infrastructure.Persistence.Settings;

public class BranchConfig : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        //builder.HasKey(branch => branch.Id);

        builder.Property(branch => branch.Nombre)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(branch => branch.Nombre)
            .IsUnique();

        builder.Property(branch => branch.Codigo)
            .HasMaxLength(10)
            .IsRequired();

        builder.HasIndex(branch => branch.Codigo)
            .IsUnique();

        //builder.Property(branch => branch.Activo).IsRequired();

        builder.ComplexProperty(branch => branch.Direccion, direccion =>
        {
            direccion.Property(address => address.LineaDireccion1)
                .HasColumnName("D_Linea1")
                .IsRequired();

            direccion.Property(address => address.LineaDireccion2)
                .HasColumnName("D_Linea2")
                .IsRequired(false);

            direccion.Property(address => address.Distrito)
                .HasColumnName("D_Distrito")
                .IsRequired();

            direccion.Property(address => address.Provincia)
                .HasColumnName("D_Provincia")
                .IsRequired();

            direccion.Property(address => address.Referencia)
                .HasColumnName("D_Referencia")
                .IsRequired(false);

            direccion.Property(address => address.Pais)
                .HasColumnName("D_Pais")
                .IsRequired();
        });

        builder.ComplexProperty(branch => branch.Telefono, telefono =>
        {
            telefono.Property(phone => phone.CodigoPais)
                .HasColumnName("T_CodigoPais")
                .IsRequired();

            telefono.Property(phone => phone.NumeroNacional)
                .HasColumnName("T_NumeroNacional")
                .IsRequired();
        });
    }
}