using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Exceptions;
using YorFit.Application.Contracts;
using YorFit.Application.Utilities.Mediator;
using YorFit.Domain.ValuableObjects;

namespace YorFit.Application.UseCases.Branchs.Commands.UpdateBranch;

public class UpdateBranchUseCase(IBranchRepository repositorio) : IRequestHandler<UpdateBranchCommand>
{
    public async Task Handle(UpdateBranchCommand comando)
    {
        var sede = await repositorio.ObtenerPorId(comando.Id);

        if (sede is null)
        {
            throw new NotFoundException();
        }

        var direccion = Address.Crear(comando.LineaDireccion1, comando.LineaDireccion2, comando.Distrito, comando.Provincia, comando.Referencia, comando.Pais);
        var telefono = Phone.Crear(comando.CodigoPais, comando.NumeroNacional);

        sede.Actualizar(comando.Nombre, comando.Codigo, direccion, telefono);

        await repositorio.Actualizar(sede);
    }
}