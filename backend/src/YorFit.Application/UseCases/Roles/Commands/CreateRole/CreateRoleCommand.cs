using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Roles.Commands.CreateRole;

public record CreateRoleCommand
(
    string Nombre,
    string Descripcion

): IRequest<Guid>;