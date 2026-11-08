using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YorFit.Domain.Entities;

namespace YorFit.Infrastructure.Persistence.Settings;

public class MemberConfig : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.Property(socio => socio.CodigoSocio)
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(socio => socio.CodigoSocio)
            .IsUnique();

        builder.Property(socio => socio.FechaIngreso)
            .IsRequired();

        builder.HasOne<Person>()
            .WithMany()
            .HasForeignKey(socio => socio.IdPersona)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
