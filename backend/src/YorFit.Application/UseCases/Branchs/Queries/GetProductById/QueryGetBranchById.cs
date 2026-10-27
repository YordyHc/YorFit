using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Branchs.Queries.GetProductById;

public record QueryGetBranchById(Guid Id) : IRequest<BranchDetailDTO>;