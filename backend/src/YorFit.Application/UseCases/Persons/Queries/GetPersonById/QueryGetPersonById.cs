using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Persons.Queries.GetPersonById;

public record QueryGetPersonById(Guid Id) : IRequest<PersonDetailDTO>;
