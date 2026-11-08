using YorFit.Domain.Exceptions;
using YorFit.Domain.ValuableObjects;

namespace YorFit.Tests;

public class IdentityDocumentTests
{
    [Fact]
    public void Crear_ConDatosValidos_RecortaEspacios()
    {
        var documento = IdentityDocument.Crear(IdentityDocumentType.Dni, "  12345678  ");

        Assert.Equal(IdentityDocumentType.Dni, documento.Tipo);
        Assert.Equal("12345678", documento.Numero);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Crear_ConNumeroVacio_LanzaExcepcion(string numero)
    {
        Assert.Throws<BusinessRuleException>(
            () => IdentityDocument.Crear(IdentityDocumentType.Dni, numero));
    }

    [Fact]
    public void Crear_ConTipoNoDefinido_LanzaExcepcion()
    {
        Assert.Throws<BusinessRuleException>(
            () => IdentityDocument.Crear((IdentityDocumentType)0, "12345678"));
    }
}
