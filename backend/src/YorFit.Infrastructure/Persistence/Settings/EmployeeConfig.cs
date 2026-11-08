using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YorFit.Domain.Entities;

namespace YorFit.Infrastructure.Persistence.Settings;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(empleado => empleado.Cargo)
            .HasMaxLength(100)
            .IsRequired();

        builder.ComplexProperty(empleado => empleado.Sueldo, sueldo =>
        {
            sueldo.Property(money => money.Amount)
                .HasColumnName("SalaryAmount")
                .HasPrecision(18, 4)
                .IsRequired();

            sueldo.Property(money => money.Currency)
                .HasColumnName("SalaryCurrency")
                .HasMaxLength(3)
                .IsRequired();
        });

        builder.Property(empleado => empleado.FechaIngreso)
            .IsRequired();

        builder.HasOne<Person>()
            .WithMany()
            .HasForeignKey(empleado => empleado.IdPersona)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
