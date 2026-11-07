
using Microsoft.AspNetCore.Mvc;
using YorFit.Api.DTOs.Roles;
using YorFit.Application.UseCases.Roles.Commands.UpdateRole;
using YorFit.Application.UseCases.Roles.Commands.ChangeRoleStatus;
using YorFit.Application.UseCases.Roles.Commands.CreateRole;
using YorFit.Application.UseCases.Roles.Queries.GetRoleById;
using YorFit.Application.UseCases.Roles.Queries.FilterRoles;
using YorFit.Application.UseCases.Roles.Commands.DeleteRole;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Api.Controllers;

[Route("api/roles")]
public class RolesController(IMediator mediador): ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<RoleDetailDTO>> Get(Guid id)
    {
        var consulta = new QueryGetRoleById(id);
        return await mediador.Send(consulta);
    }

    [HttpGet("filtrado")]
    public async Task<ActionResult<List<FilteredRoleDTO>>> GetFiltrado(string? nombre, [FromQuery] bool? estado)
    {
        var consulta = new FilterRolesQuery(nombre, estado);
        return await mediador.Send(consulta);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateRoleDTO modelo)
    {
        var comando = new CreateRoleCommand(
            Nombre: modelo.Nombre,
            Descripcion: modelo.Descripcion
        );

        var id = await mediador.Send(comando);

        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] UpdateRoleDTO modelo)
    {
        var comando = new UpdateRoleCommand(
            Id: id,
            Nombre: modelo.Nombre,
            Descripcion: modelo.Descripcion
        );

        await mediador.Send(comando);

        return NoContent();
    }

    [HttpPatch("{id}/estado")]
    public async Task<ActionResult> CambiarEstado(Guid id, [FromBody] ChangeRoleStatusDTO? modelo)
    {
        if (modelo?.Estado is not bool estado)
        {
            return BadRequest("El campo Estado es requerido.");
        }

        await mediador.Send(new ChangeRoleStatusCommand(id, estado));

        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await mediador.Send(new DeleteRoleCommand(id));
        return NoContent();
    }
}
