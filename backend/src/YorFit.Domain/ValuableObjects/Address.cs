using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Domain.Exceptions;

namespace YorFit.Domain.ValuableObjects;

public class Address
{
    public string LineaDireccion1 { get; private set; } = default!;
    public string? LineaDireccion2 { get; private set; }
    public string Distrito { get; private set; } = default!;
    public string Provincia { get; private set; } = default!;
    public string? Referencia { get; private set; }
    public string Pais { get; private set; } = default!;
    private Address(string lineaDireccion1, string? lineaDireccion2, string distrito, string provincia, string? referencia, string pais)
    {
        LineaDireccion1 = lineaDireccion1;
        LineaDireccion2 = lineaDireccion2;
        Distrito = distrito;
        Provincia = provincia;
        Referencia = referencia;
        Pais = pais;
    }

    public static Address Crear(string lineaDireccion1, string? lineaDireccion2, string distrito, string provincia, string? referencia, string pais)
    {
        var linea1Limpia = ValidarYLimpiarTexto(lineaDireccion1, "La primera línea de dirección es obligatoria.");
        var distritoLimpio = ValidarYLimpiarTexto(distrito, "El distrito es obligatorio.");
        var provinciaLimpia = ValidarYLimpiarTexto(provincia, "La provincia es obligatoria.");
        var paisLimpio = ValidarYLimpiarTexto(pais, "El país es obligatorio.");

        var linea2Limpia = string.IsNullOrWhiteSpace(lineaDireccion2) ? null : lineaDireccion2.Trim();
        var referenciaLimpia = string.IsNullOrWhiteSpace(referencia) ? null : referencia.Trim();

        return new Address(linea1Limpia, linea2Limpia, distritoLimpio, provinciaLimpia, referenciaLimpia, paisLimpio);
    }

    private static string ValidarYLimpiarTexto(string valor, string mensajeError)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new BusinessRuleException(mensajeError);

        return valor.Trim();
    }
}