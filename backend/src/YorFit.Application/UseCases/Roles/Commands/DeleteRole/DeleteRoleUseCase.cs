using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Roles.Commands.DeleteRole;

public class DeleteRoleUseCase(IRoleRepository repositorio)
    : IRequestHandler<DeleteRoleCommand>
{
    public async Task Handle(DeleteRoleCommand comando)
    {
        var rol = await repositorio.ObtenerPorId(comando.Id);

        if (rol is null)
        {
            throw new NotFoundException();
        }

        await repositorio.Eliminar(rol);
    }
}