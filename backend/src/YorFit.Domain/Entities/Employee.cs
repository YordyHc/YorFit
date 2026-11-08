using YorFit.Domain.Exceptions;
using YorFit.Domain.ValuableObjects;

namespace YorFit.Domain.Entities;

public class Employee
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public Guid IdPersona { get; private set; }
    public string Cargo { get; private set; } = default!;
    public Money Sueldo { get; private set; } = default!;
    public DateTime FechaIngreso { get; private set; }
    public bool Estado { get; private set; } = true;

    public static Employee Crear(Guid idPersona, string cargo, Money sueldo, DateTime fechaIngreso)
    {
        ValidarIdPersona(idPersona);
        ValidarCargo(cargo);
        ValidarSueldo(sueldo);
        ValidarFechaIngreso(fechaIngreso);

        return new Employee
        {
            IdPersona = idPersona,
            Cargo = cargo.Trim(),
            Sueldo = sueldo,
            FechaIngreso = fechaIngreso.Date
        };
    }

    public void Actualizar(string cargo, Money sueldo, DateTime fechaIngreso)
    {
        ValidarCargo(cargo);
        ValidarSueldo(sueldo);
        ValidarFechaIngreso(fechaIngreso);

        Cargo = cargo.Trim();
        Sueldo = sueldo;
        FechaIngreso = fechaIngreso.Date;
    }

    public void Activar() => Estado = true;
    public void Desactivar() => Estado = false;

    private static void ValidarIdPersona(Guid idPersona)
    {
        if (idPersona == Guid.Empty)
            throw new BusinessRuleException("La persona del empleado es requerida.");
    }

    private static void ValidarCargo(string cargo)
    {
        if (string.IsNullOrWhiteSpace(cargo))
            throw new BusinessRuleException("El cargo del empleado es obligatorio.");

        if (cargo.Trim().Length > 100)
            throw new BusinessRuleException("El cargo no puede exceder los 100 caracteres.");
    }

    private static void ValidarSueldo(Money sueldo)
    {
        if (sueldo is null)
            throw new BusinessRuleException("El sueldo es obligatorio.");
    }

    private static void ValidarFechaIngreso(DateTime fechaIngreso)
    {
        if (fechaIngreso == default)
            throw new BusinessRuleException("La fecha de ingreso es obligatoria.");
    }
}
