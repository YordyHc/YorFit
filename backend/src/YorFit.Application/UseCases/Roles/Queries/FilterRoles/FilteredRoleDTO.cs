using System;
using System.Collections.Generic;
using System.Text;

namespace YorFit.Application.UseCases.Roles.Queries.FilterRoles;

public record FilteredRoleDTO(Guid Id, string Nombre, string Descripcion);