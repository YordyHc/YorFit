using System.Net.Mail;
using YorFit.Domain.Exceptions;

namespace YorFit.Domain.ValuableObjects;

public class Email
{
    public string Valor { get; private set; } = default!;

    private Email(string valor)
    {
        Valor = valor;
    }

    public static Email Crear(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new BusinessRuleException("El correo electrónico es obligatorio.");

        var emailLimpio = valor.Trim();
        if (emailLimpio.Length > 254 ||
            !MailAddress.TryCreate(emailLimpio, out var direccion) ||
            !string.Equals(direccion.Address, emailLimpio, StringComparison.OrdinalIgnoreCase))
        {
            throw new BusinessRuleException("El correo electrónico no es válido.");
        }

        return new Email(emailLimpio.ToLowerInvariant());
    }
}
