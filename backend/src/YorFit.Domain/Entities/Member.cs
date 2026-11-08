using YorFit.Domain.Exceptions;

namespace YorFit.Domain.Entities;

public class Member
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public Guid IdPersona { get; private set; }
    public string CodigoSocio { get; private set; } = default!;
    public DateTime FechaIngreso { get; private set; }
    public bool Estado { get; private set; } = true;

    public static Member Crear(Guid idPersona, string codigoSocio, DateTime fechaIngreso)
    {
        ValidarIdPersona(idPersona);
        ValidarCodigoSocio(codigoSocio);
        ValidarFechaIngreso(fechaIngreso);

        return new Member
        {
            IdPersona = idPersona,
            CodigoSocio = codigoSocio.Trim(),
            FechaIngreso = fechaIngreso.Date
        };
    }

    public void Actualizar(string codigoSocio, DateTime fechaIngreso)
    {
        ValidarCodigoSocio(codigoSocio);
        ValidarFechaIngreso(fechaIngreso);

        CodigoSocio = codigoSocio.Trim();
        FechaIngreso = fechaIngreso.Date;
    }

    public void Activar() => Estado = true;
    public void Desactivar() => Estado = false;

    private static void ValidarIdPersona(Guid idPersona)
    {
        if (idPersona == Guid.Empty)
            throw new BusinessRuleException("La persona del socio es requerida.");
    }

    private static void ValidarCodigoSocio(string codigoSocio)
    {
        if (string.IsNullOrWhiteSpace(codigoSocio))
            throw new BusinessRuleException("El código de socio es obligatorio.");

        if (codigoSocio.Trim().Length > 30)
            throw new BusinessRuleException("El código de socio no puede exceder los 30 caracteres.");
    }

    private static void ValidarFechaIngreso(DateTime fechaIngreso)
    {
        if (fechaIngreso == default)
            throw new BusinessRuleException("La fecha de ingreso del socio es obligatoria.");
    }
}
