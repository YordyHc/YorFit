using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Exceptions;
using YorFit.Application.Contracts;
using YorFit.Application.Utilities.Mediator;
using YorFit.Domain.ValuableObjects;

namespace YorFit.Application.UseCases.Branchs.Commands.ChangeBranchStatus;

public class ChangeBranchStatusUseCase(IBranchRepository repositorio)
    : IRequestHandler<ChangeBranchStatusCommand>
{
    public async Task Handle(ChangeBranchStatusCommand comando)
    {
        var sede = await repositorio.ObtenerPorId(comando.Id);

        if (sede is null)
        {
            throw new NotFoundException();
        }

        if (comando.Activo)
        {
            sede.Activar();
        }
        else
        {
            sede.Desactivar();
        }

        await repositorio.Actualizar(sede);
    }
}