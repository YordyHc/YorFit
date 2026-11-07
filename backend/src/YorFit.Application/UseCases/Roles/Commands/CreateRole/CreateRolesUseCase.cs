using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Contracts;
using YorFit.Application.Utilities.Mediator;
using YorFit.Domain.Exceptions;
using YorFit.Domain.ValuableObjects;

namespace YorFit.Application.UseCases.Roles.Commands.CreateRole;

public class CreateRoleUseCase(IRoleRepository repositorioRoles): IRequestHandler<CreateRoleCommand, Guid>
{
    public async Task<Guid> Handle(CreateRoleCommand comando)
    {
        var nombre = comando.Nombre?.Trim();
        var descripcion = comando.Descripcion?.Trim();

        if (string.IsNullOrWhiteSpace(nombre))
            throw new BusinessRuleException("El nombre del rol es requerido.");

        if (string.IsNullOrWhiteSpace(descripcion))
            throw new BusinessRuleException("La descripcion del rol es requerido.");

        var existeNombre = await repositorioRoles.Existe(nombre!);
        if (existeNombre)
        {
            throw new BusinessRuleException($"Ya existe un rol con el nombre: {nombre}");
        }

        var rol = Domain.Entities.Role.Crear(
            nombre: nombre!, 
            descripcion: descripcion!
        );

        await repositorioRoles.Agregar(rol);
        
        return rol.Id;
    }
}