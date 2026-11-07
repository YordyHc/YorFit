using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Contracts;
using YorFit.Application.Utilities.Mediator;
using YorFit.Domain.Entities;

namespace YorFit.Application.UseCases.Roles.Queries.FilterRoles;

public class FilterRolesUseCase(IRoleRepository repositorio) : IRequestHandler<FilterRolesQuery, List<FilteredRoleDTO>>
{
    public async Task<List<FilteredRoleDTO>> Handle(FilterRolesQuery request)
    {
        List<Role> roles = await repositorio.ObtenerFiltrado(request.Nombre, request.Estado);

        var rolesDTO = roles.Select(sede => sede.ADto()).ToList();

        return rolesDTO;
    }
}