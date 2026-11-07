using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Roles.Queries.GetRoleById;

public class UseCaseGetRoleById(IRoleRepository repositorio) : IRequestHandler<QueryGetRoleById, RoleDetailDTO>
{
    public async Task<RoleDetailDTO> Handle(QueryGetRoleById request)
    {
        var rol = await repositorio.ObtenerPorId(request.Id);

        if (rol is null)
        {
            throw new NotFoundException();
        }

        return rol.ADto();
    }
}