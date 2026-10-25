using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Contracts;
using YorFit.Application.Utilities.Mediator;
using YorFit.Domain.Exceptions;
using YorFit.Domain.ValuableObjects;

namespace YorFit.Application.UseCases.Branch.Commands.CreateBranch;

public class CreateBranchUseCase(IBranchRepository repositorioSedes): IRequestHandler<CreateBranchCommand, Guid>
{
    public async Task<Guid> Handle(CreateBranchCommand comando)
    {
        var nombre = comando.Nombre?.Trim();
        var codigo = comando.Codigo?.Trim();

        if (string.IsNullOrWhiteSpace(nombre))
            throw new BusinessRuleException("El nombre de la sede es requerido.");

        if (string.IsNullOrWhiteSpace(codigo))
            throw new BusinessRuleException("El código de la sede es requerido.");

        var existeNombre = await repositorioSedes.Existe(nombre!);
        if (existeNombre)
        {
            throw new BusinessRuleException($"Ya existe una sede con el nombre: {nombre}");
        }

        var existeCodigo = await repositorioSedes.ExisteCodigo(codigo!);
        if (existeCodigo)
        {
            throw new BusinessRuleException($"Ya existe una sede con el código: {codigo}");
        }

        var direccion = Address.Crear(comando.LineaDireccion1, comando.LineaDireccion2, comando.Distrito, comando.Provincia, comando.Referencia, comando.Pais);
        var telefono = Phone.Crear(comando.CodigoPais, comando.NumeroNacional);

        var sede = Domain.Entities.Branch.Crear(
            nombre: nombre!, 
            codigo: codigo!, 
            direccion: direccion, 
            telefono: telefono
        );

        await repositorioSedes.Agregar(sede);
        
        return sede.Id;
    }
}