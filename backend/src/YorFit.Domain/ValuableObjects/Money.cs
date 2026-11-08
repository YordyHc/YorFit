using YorFit.Domain.Exceptions;

namespace YorFit.Domain.ValuableObjects;

public class Money
{
    public decimal Amount { get; private set; }
    public string Currency { get; private set; } = default!;

    private Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money Crear(decimal amount, string currency)
    {
        if (amount < 0)
            throw new BusinessRuleException("El monto no puede ser negativo.");

        if (string.IsNullOrWhiteSpace(currency))
            throw new BusinessRuleException("La moneda es obligatoria.");

        var currencyCode = currency.Trim().ToUpperInvariant();
        if (currencyCode.Length != 3 || currencyCode.Any(character => character is < 'A' or > 'Z'))
            throw new BusinessRuleException("La moneda debe ser un código de tres letras.");

        return new Money(amount, currencyCode);
    }
}
