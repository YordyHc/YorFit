using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Exceptions;
using YorFit.Application.Contracts;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Roles.Commands.ChangeRoleStatus;

public class ChangeRoleStatusUseCase(IRoleRepository repositorio)
    : IRequestHandler<ChangeRoleStatusCommand>
{
    public async Task Handle(ChangeRoleStatusCommand comando)
    {
        var rol = await repositorio.ObtenerPorId(comando.Id);

        if (rol is null)
        {
            throw new NotFoundException();
        }

        if (comando.Estado)
        {
            rol.Activar();
        }
        else
        {
            rol.Desactivar();
        }

        await repositorio.Actualizar(rol);
    }
}