using YorFit.Domain.Exceptions;
using YorFit.Domain.ValuableObjects;

namespace YorFit.Domain.Entities;

public class Person
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public IdentityDocument DocumentoIdentidad { get; private set; } = default!;
    public string Nombres { get; private set; } = default!;
    public string Apellidos { get; private set; } = default!;
    public Phone Telefono { get; private set; } = default!;
    public Address Direccion { get; private set; } = default!;
    public DateTime FechaNacimiento { get; private set; }
    public bool Activo { get; private set; } = true;

    public static Person Crear(
        string nombres,
        string apellidos,
        IdentityDocument documentoIdentidad,
        Phone telefono,
        Address direccion,
        DateTime fechaNacimiento)
    {
        ValidarNombre(nombres, "Los nombres");
        ValidarNombre(apellidos, "Los apellidos");
        ValidarDocumentoIdentidad(documentoIdentidad);
        ValidarTelefono(telefono);
        ValidarDireccion(direccion);
        ValidarFechaNacimiento(fechaNacimiento);

        return new Person
        {
            Nombres = nombres.Trim(),
            Apellidos = apellidos.Trim(),
            DocumentoIdentidad = documentoIdentidad,
            Telefono = telefono,
            Direccion = direccion,
            FechaNacimiento = fechaNacimiento.Date
        };
    }

    public void Actualizar(
        string nombres,
        string apellidos,
        IdentityDocument documentoIdentidad,
        Phone telefono,
        Address direccion,
        DateTime fechaNacimiento)
    {
        ValidarNombre(nombres, "Los nombres");
        ValidarNombre(apellidos, "Los apellidos");
        ValidarDocumentoIdentidad(documentoIdentidad);
        ValidarTelefono(telefono);
        ValidarDireccion(direccion);
        ValidarFechaNacimiento(fechaNacimiento);

        Nombres = nombres.Trim();
        Apellidos = apellidos.Trim();
        DocumentoIdentidad = documentoIdentidad;
        Telefono = telefono;
        Direccion = direccion;
        FechaNacimiento = fechaNacimiento.Date;
    }

    public void Activar() => Activo = true;
    public void Desactivar() => Activo = false;

    private static void ValidarNombre(string valor, string campo)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new BusinessRuleException($"{campo} son requeridos.");

        if (valor.Trim().Length > 100)
            throw new BusinessRuleException($"{campo} no pueden exceder los 100 caracteres.");
    }

    private static void ValidarDocumentoIdentidad(IdentityDocument documentoIdentidad)
    {
        if (documentoIdentidad is null)
            throw new BusinessRuleException("El documento de identidad es requerido.");
    }

    private static void ValidarTelefono(Phone telefono)
    {
        if (telefono is null)
            throw new BusinessRuleException("El teléfono es requerido.");
    }

    private static void ValidarDireccion(Address direccion)
    {
        if (direccion is null)
            throw new BusinessRuleException("La dirección es requerida.");
    }

    private static void ValidarFechaNacimiento(DateTime fechaNacimiento)
    {
        if (fechaNacimiento == default)
            throw new BusinessRuleException("La fecha de nacimiento es requerida.");

        if (fechaNacimiento.Date > DateTime.Today)
            throw new BusinessRuleException("La fecha de nacimiento no puede ser futura.");
    }
}
