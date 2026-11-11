using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Members.Commands.DeleteMember;

public class DeleteMemberUseCase(IMemberRepository repository)
    : IRequestHandler<DeleteMemberCommand>
{
    public async Task Handle(DeleteMemberCommand command)
    {
        var member = await repository.ObtenerPorId(command.Id)
            ?? throw new NotFoundException();

        await repository.Eliminar(member);
    }
}
