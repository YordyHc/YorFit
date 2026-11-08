using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YorFit.Domain.Entities;
using YorFit.Domain.ValuableObjects;

namespace YorFit.Infrastructure.Persistence.Settings;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(usuario => usuario.NombreUsuario)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(usuario => usuario.NombreUsuario)
            .IsUnique();

        builder.Property(usuario => usuario.Email)
            .HasConversion(email => email.Valor, valor => Email.Crear(valor))
            .HasMaxLength(254)
            .IsRequired();

        builder.HasIndex(usuario => usuario.Email)
            .IsUnique();

        builder.Property(usuario => usuario.PasswordHash)
            .IsRequired();

        builder.HasOne<Person>()
            .WithMany()
            .HasForeignKey(usuario => usuario.IdPersona)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Branch>()
            .WithMany()
            .HasForeignKey(usuario => usuario.IdSede)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Role>()
            .WithMany()
            .HasForeignKey(usuario => usuario.IdRol)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
