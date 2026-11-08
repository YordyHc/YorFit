using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YorFit.Domain.Entities;

namespace YorFit.Infrastructure.Persistence.Settings;

public class PersonConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Property(person => person.Nombres)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(person => person.Apellidos)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(person => person.FechaNacimiento)
            .IsRequired();

        builder.ComplexProperty(person => person.DocumentoIdentidad, documento =>
        {
            documento.Property(identityDocument => identityDocument.Tipo)
                .HasColumnName("DI_Tipo")
                .IsRequired();

            documento.Property(identityDocument => identityDocument.Numero)
                .HasColumnName("DI_Numero")
                .HasMaxLength(30)
                .IsRequired();
        });

        builder.ComplexProperty(person => person.Telefono, telefono =>
        {
            telefono.Property(phone => phone.CodigoPais)
                .HasColumnName("T_CodigoPais")
                .IsRequired();

            telefono.Property(phone => phone.NumeroNacional)
                .HasColumnName("T_NumeroNacional")
                .IsRequired();
        });

        builder.ComplexProperty(person => person.Direccion, direccion =>
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
    }
}
