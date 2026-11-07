using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Roles.Commands.DeleteRole;

public record DeleteRoleCommand(Guid Id) : IRequest;