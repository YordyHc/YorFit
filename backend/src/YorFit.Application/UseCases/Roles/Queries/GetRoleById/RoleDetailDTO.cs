using System;
using System.Collections.Generic;
using System.Text;

namespace YorFit.Application.UseCases.Roles.Queries.GetRoleById;

public record RoleDetailDTO(Guid Id, string Nombre, string Descripcion, bool Estado);