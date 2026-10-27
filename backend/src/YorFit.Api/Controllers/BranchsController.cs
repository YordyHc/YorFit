using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using YorFit.Api.DTOs;
using YorFit.Application.UseCases.Branchs.Commands.UpdateBranch;
using YorFit.Application.UseCases.Branchs.Commands.ChangeBranchStatus;
using YorFit.Application.UseCases.Branchs.Commands.CreateBranch;
using YorFit.Application.UseCases.Branchs.Queries.GetProductById;

// using YorFit.Application.UseCases.Branchs.Queries.FiltrarProductos;
// using YorFit.Application.UseCases.Branchs.Queries.ObtenerProductoPorId;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Api.Controllers;

[Route("api/sedes")]
public class BranchsController(IMediator mediador): ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<BranchDetailDTO>> Get(Guid id)
    {
        var consulta = new QueryGetBranchById(id);
        return await mediador.Send(consulta);
    }

    /*[HttpGet("filtrado")]
    public async Task<ActionResult<List<ProductoFiltradoDTO>>> GetFiltrado(string? nombre, [FromQuery] bool? activo)
    {
        var consulta = new ConsultaFiltrarProductos(nombre, activo);
        return await mediador.Send(consulta);
    }*/

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateBranchDTO modelo)
    {
        var comando = new CreateBranchCommand(
            Nombre: modelo.Nombre,
            Codigo: modelo.Codigo,
            LineaDireccion1: modelo.LineaDireccion1,
            LineaDireccion2: modelo.LineaDireccion2,
            Distrito: modelo.Distrito,
            Provincia: modelo.Provincia,
            Referencia: modelo.Referencia,
            Pais: modelo.Pais,
            CodigoPais: modelo.CodigoPais,
            NumeroNacional: modelo.NumeroNacional
        );

        var id = await mediador.Send(comando);

        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] UpdateBranchDTO modelo)
    {
        var comando = new UpdateBranchCommand(
            Id: id,
            Nombre: modelo.Nombre,
            Codigo: modelo.Codigo,
            LineaDireccion1: modelo.LineaDireccion1,
            LineaDireccion2: modelo.LineaDireccion2,
            Distrito: modelo.Distrito,
            Provincia: modelo.Provincia,
            Referencia: modelo.Referencia,
            Pais: modelo.Pais,
            CodigoPais: modelo.CodigoPais,
            NumeroNacional: modelo.NumeroNacional
        );

        await mediador.Send(comando);

        return NoContent();
    }

    [HttpPatch("{id}/estado")]
    public async Task<ActionResult> CambiarEstado(Guid id, [FromBody] ChangeBranchStatusDTO? modelo)
    {
        if (modelo?.Activo is not bool activo)
        {
            return BadRequest("El campo Activo es requerido.");
        }

        await mediador.Send(new ChangeBranchStatusCommand(id, activo));

        return NoContent();
    }
}
