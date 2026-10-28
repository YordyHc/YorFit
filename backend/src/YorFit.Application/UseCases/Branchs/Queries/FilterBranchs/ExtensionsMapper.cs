using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Domain.Entities;

namespace YorFit.Application.UseCases.Branchs.Queries.FilterBranchs;

internal static class ExtensionsMapper
{
    internal static FilteredBranchDTO ADto(this Branch sede)
    {
        return new FilteredBranchDTO(
            Id: sede.Id, 
            Nombre: sede.Nombre, 
            Codigo: sede.Codigo,
            Distrito: sede.Direccion.Distrito,
            Provincia: sede.Direccion.Provincia);
    }
    
}