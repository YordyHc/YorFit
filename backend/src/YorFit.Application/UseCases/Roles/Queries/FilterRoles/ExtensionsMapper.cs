using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Domain.Entities;

namespace YorFit.Application.UseCases.Roles.Queries.FilterRoles;

internal static class ExtensionsMapper
{
    internal static FilteredRoleDTO ADto(this Role rol)
    {
        return new FilteredRoleDTO(
            Id: rol.Id, 
            Nombre: rol.Nombre, 
            Descripcion: rol.Descripcion);
    }
    
}