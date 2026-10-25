using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Domain.Exceptions;

namespace YorFit.Domain.ValuableObjects;

public class Phone
{
    public string CodigoPais { get; private set; } = default!;
    public string NumeroNacional { get; private set; } = default!;

    private Phone(string codigoPais, string numeroNacional)
    {
        CodigoPais = codigoPais;
        NumeroNacional = numeroNacional;
    }

    public static Phone Crear(string numeroNacional, string codigoPais = "+51")
    {
        var codigoPaisLimpio = ValidarYLimpiarTexto(codigoPais, "El código de país es obligatorio.");
        var numeroNacionalLimpio = ValidarYLimpiarTexto(numeroNacional, "El número telefónico es obligatorio.");

        return new Phone(codigoPaisLimpio, numeroNacionalLimpio);
    }

    private static string ValidarYLimpiarTexto(string valor, string mensajeError)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new BusinessRuleException(mensajeError);

        return valor.Trim();
    }
}