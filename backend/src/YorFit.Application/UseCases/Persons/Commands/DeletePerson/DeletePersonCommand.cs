using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Persons.Commands.DeletePerson;

public record DeletePersonCommand(Guid Id) : IRequest;
