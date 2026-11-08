using YorFit.Domain.Exceptions;

namespace YorFit.Domain.ValuableObjects;

public enum IdentityDocumentType
{
    Dni = 1,
    CarneExtranjeria = 2,
    Pasaporte = 3,
    CarnePermisoTemporalPermanencia = 4
}

public class IdentityDocument
{
    public IdentityDocumentType Tipo { get; private set; }
    public string Numero { get; private set; } = default!;

    private IdentityDocument(IdentityDocumentType tipo, string numero)
    {
        Tipo = tipo;
        Numero = numero;
    }

    public static IdentityDocument Crear(IdentityDocumentType tipo, string numero)
    {
        if (!Enum.IsDefined(tipo))
            throw new BusinessRuleException("El tipo de documento no es válido.");

        var numeroLimpio = ValidarYLimpiarTexto(numero, "El número de documento es obligatorio.");

        return new IdentityDocument(tipo, numeroLimpio);
    }

    private static string ValidarYLimpiarTexto(string valor, string mensajeError)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new BusinessRuleException(mensajeError);

        return valor.Trim();
    }
}
