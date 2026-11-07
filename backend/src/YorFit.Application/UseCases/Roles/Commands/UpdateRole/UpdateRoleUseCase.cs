using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Exceptions;
using YorFit.Application.Contracts;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Roles.Commands.UpdateRole;

public class UpdateRoleUseCase(IRoleRepository repositorio) : IRequestHandler<UpdateRoleCommand>
{
    public async Task Handle(UpdateRoleCommand comando)
    {
        var rol = await repositorio.ObtenerPorId(comando.Id);

        if (rol is null)
        {
            throw new NotFoundException();
        }

        rol.Actualizar(comando.Nombre, comando.Descripcion);

        await repositorio.Actualizar(rol);
    }
}