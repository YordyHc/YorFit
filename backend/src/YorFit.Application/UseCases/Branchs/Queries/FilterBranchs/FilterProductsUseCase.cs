using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Contracts;
using YorFit.Application.Utilities.Mediator;
using YorFit.Domain.Entities;

namespace YorFit.Application.UseCases.Branchs.Queries.FilterBranchs;

public class FilterProductsUseCase(IBranchRepository repositorio) : IRequestHandler<FilterBranchsQuery, List<FilteredBranchDTO>>
{
    public async Task<List<FilteredBranchDTO>> Handle(FilterBranchsQuery request)
    {
        List<Branch> sedes = await repositorio.ObtenerFiltrado(request.Nombre, request.Codigo, request.Activo);

        var sedesDTO = sedes.Select(sede => sede.ADto()).ToList();

        return sedesDTO;
    }
}