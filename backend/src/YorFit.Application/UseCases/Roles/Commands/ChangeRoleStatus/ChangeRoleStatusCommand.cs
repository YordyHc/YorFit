using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Roles.Commands.ChangeRoleStatus;

public record ChangeRoleStatusCommand(Guid Id, bool Estado) : IRequest;