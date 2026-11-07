using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Domain.Entities;

namespace YorFit.Application.UseCases.Roles.Queries.GetRoleById;

internal static class ExtensionsMapper
{
    internal static RoleDetailDTO ADto(this Role rol)
    {
        return new RoleDetailDTO(
            Id: rol.Id,
            Nombre: rol.Nombre,
            Descripcion: rol.Descripcion,
            Estado: rol.Estado
        );
    }
}