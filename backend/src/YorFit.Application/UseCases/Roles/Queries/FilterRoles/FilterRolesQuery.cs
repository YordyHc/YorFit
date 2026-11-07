using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Roles.Queries.FilterRoles;

public record FilterRolesQuery(string? Nombre, bool? Estado) : IRequest<List<FilteredRoleDTO>>;