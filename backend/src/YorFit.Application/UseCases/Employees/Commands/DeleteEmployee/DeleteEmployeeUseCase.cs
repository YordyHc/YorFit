using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Employees.Commands.DeleteEmployee;

public class DeleteEmployeeUseCase(IEmployeeRepository repository)
    : IRequestHandler<DeleteEmployeeCommand>
{
    public async Task Handle(DeleteEmployeeCommand command)
    {
        var employee = await repository.ObtenerPorId(command.Id)
            ?? throw new NotFoundException();

        await repository.Eliminar(employee);
    }
}
