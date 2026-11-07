using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Roles.Commands.UpdateRole;

public record UpdateRoleCommand(
    Guid Id,
    string Nombre,
    string Descripcion
) : IRequest;