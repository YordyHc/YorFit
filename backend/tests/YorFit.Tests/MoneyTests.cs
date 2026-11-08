using YorFit.Domain.Exceptions;
using YorFit.Domain.ValuableObjects;

namespace YorFit.Tests;

public class MoneyTests
{
    [Fact]
    public void Crear_ConMontoYMonedaValidos_NormalizaLaMoneda()
    {
        var money = Money.Crear(1200.50m, " pen ");

        Assert.Equal(1200.50m, money.Amount);
        Assert.Equal("PEN", money.Currency);
    }

    [Fact]
    public void Crear_ConMontoNegativo_LanzaExcepcion()
    {
        Assert.Throws<BusinessRuleException>(() => Money.Crear(-0.01m, "PEN"));
    }

    [Theory]
    [InlineData("")]
    [InlineData("US")]
    [InlineData("P3N")]
    public void Crear_ConMonedaInvalida_LanzaExcepcion(string currency)
    {
        Assert.Throws<BusinessRuleException>(() => Money.Crear(10m, currency));
    }
}
