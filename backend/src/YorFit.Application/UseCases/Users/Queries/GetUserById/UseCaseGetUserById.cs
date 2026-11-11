using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Users.Queries.GetUserById;

public class UseCaseGetUserById(IUserRepository repository)
    : IRequestHandler<QueryGetUserById, UserDetailDTO>
{
    public async Task<UserDetailDTO> Handle(QueryGetUserById query)
    {
        var user = await repository.ObtenerPorId(query.Id)
            ?? throw new NotFoundException();

        return new UserDetailDTO(
            user.Id,
            user.IdPersona,
            user.IdSede,
            user.IdRol,
            user.NombreUsuario,
            user.Email.Valor,
            user.Estado,
            user.RequiereCambioPassword);
    }
}
