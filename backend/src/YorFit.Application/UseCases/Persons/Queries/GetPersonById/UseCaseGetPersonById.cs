using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Persons.Queries.GetPersonById;

public class UseCaseGetPersonById(IPersonRepository repository)
    : IRequestHandler<QueryGetPersonById, PersonDetailDTO>
{
    public async Task<PersonDetailDTO> Handle(QueryGetPersonById query)
    {
        var person = await repository.ObtenerPorId(query.Id)
            ?? throw new NotFoundException();

        return new PersonDetailDTO(
            person.Id,
            person.Nombres,
            person.Apellidos,
            person.DocumentoIdentidad.Tipo,
            person.DocumentoIdentidad.Numero,
            person.Telefono.CodigoPais,
            person.Telefono.NumeroNacional,
            person.Direccion.LineaDireccion1,
            person.Direccion.LineaDireccion2,
            person.Direccion.Distrito,
            person.Direccion.Provincia,
            person.Direccion.Referencia,
            person.Direccion.Pais,
            person.FechaNacimiento,
            person.Activo);
    }
}
