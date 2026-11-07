using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Roles.Queries.GetRoleById;

public record QueryGetRoleById(Guid Id) : IRequest<RoleDetailDTO>;