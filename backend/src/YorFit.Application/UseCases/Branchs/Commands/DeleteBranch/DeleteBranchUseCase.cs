using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Branchs.Commands.DeleteBranch;

public class DeleteBranchUseCase(IBranchRepository repositorio)
    : IRequestHandler<DeleteBranchCommand>
{
    public async Task Handle(DeleteBranchCommand comando)
    {
        var sede = await repositorio.ObtenerPorId(comando.Id);

        if (sede is null)
        {
            throw new NotFoundException();
        }

        await repositorio.Eliminar(sede);
    }
}