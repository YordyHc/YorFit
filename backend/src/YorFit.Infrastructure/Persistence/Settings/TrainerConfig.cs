using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YorFit.Domain.Entities;

namespace YorFit.Infrastructure.Persistence.Settings;

public class TrainerConfig : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
        builder.Property(entrenador => entrenador.Especialidad)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne<Employee>()
            .WithMany()
            .HasForeignKey(entrenador => entrenador.IdEmpleado)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
