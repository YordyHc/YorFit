using YorFit.Application.Contracts;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Users.Queries.FilterUsers;

public class FilterUsersUseCase(IUserRepository repository)
    : IRequestHandler<FilterUsersQuery, List<FilteredUserDTO>>
{
    public async Task<List<FilteredUserDTO>> Handle(FilterUsersQuery query)
    {
        var users = await repository.ObtenerFiltrado(
            query.NombreUsuario,
            query.Email,
            query.IdSede,
            query.IdRol,
            query.Estado);

        return users.Select(user => new FilteredUserDTO(
            user.Id,
            user.IdPersona,
            user.IdSede,
            user.IdRol,
            user.NombreUsuario,
            user.Email.Valor,
            user.Estado)).ToList();
    }
}
