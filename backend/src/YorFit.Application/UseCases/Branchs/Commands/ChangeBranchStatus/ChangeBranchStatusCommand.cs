using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Branchs.Commands.ChangeBranchStatus;

public record ChangeBranchStatusCommand(Guid Id, bool Activo) : IRequest;