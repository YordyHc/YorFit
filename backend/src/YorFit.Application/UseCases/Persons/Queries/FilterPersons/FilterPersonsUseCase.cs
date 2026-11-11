using YorFit.Application.Contracts;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Persons.Queries.FilterPersons;

public class FilterPersonsUseCase(IPersonRepository repository)
    : IRequestHandler<FilterPersonsQuery, List<FilteredPersonDTO>>
{
    public async Task<List<FilteredPersonDTO>> Handle(FilterPersonsQuery query)
    {
        var persons = await repository.ObtenerFiltrado(
            query.Nombres,
            query.Apellidos,
            query.NumeroDocumento,
            query.Activo);

        return persons.Select(person => new FilteredPersonDTO(
            person.Id,
            person.Nombres,
            person.Apellidos,
            person.DocumentoIdentidad.Tipo,
            person.DocumentoIdentidad.Numero,
            person.Activo)).ToList();
    }
}
