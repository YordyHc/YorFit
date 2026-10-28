using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Branchs.Commands.DeleteBranch;

public record DeleteBranchCommand(Guid Id) : IRequest;