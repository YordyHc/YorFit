using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Domain.Entities;

namespace YorFit.Application.UseCases.Branchs.Queries.GetProductById;

internal static class ExtensionsMapper
{
    internal static BranchDetailDTO ADto(this Branch sede)
    {
        return new BranchDetailDTO(
            Id: sede.Id,
            Nombre: sede.Nombre,
            Codigo: sede.Codigo,
            LineaDireccion1: sede.Direccion.LineaDireccion1,
            LineaDireccion2: sede.Direccion.LineaDireccion2,
            Distrito: sede.Direccion.Distrito,
            Provincia: sede.Direccion.Provincia,
            Referencia: sede.Direccion.Referencia,
            Pais: sede.Direccion.Pais,
            CodigoPais: sede.Telefono.CodigoPais,
            NumeroNacional: sede.Telefono.NumeroNacional,
            sede.Activo
        );
    }
}