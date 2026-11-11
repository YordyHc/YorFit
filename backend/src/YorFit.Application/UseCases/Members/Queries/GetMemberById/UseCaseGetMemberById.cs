using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Members.Queries.GetMemberById;

public class UseCaseGetMemberById(IMemberRepository repository)
    : IRequestHandler<QueryGetMemberById, MemberDetailDTO>
{
    public async Task<MemberDetailDTO> Handle(QueryGetMemberById query)
    {
        var member = await repository.ObtenerPorId(query.Id)
            ?? throw new NotFoundException();

        return new MemberDetailDTO(
            member.Id,
            member.IdPersona,
            member.CodigoSocio,
            member.FechaIngreso,
            member.Estado);
    }
}
