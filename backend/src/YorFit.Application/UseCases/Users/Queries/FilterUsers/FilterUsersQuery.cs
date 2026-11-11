using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Users.Queries.FilterUsers;

public record FilterUsersQuery(
    string? NombreUsuario,
    string? Email,
    Guid? IdSede,
    Guid? IdRol,
    bool? Estado
) : IRequest<List<FilteredUserDTO>>;
