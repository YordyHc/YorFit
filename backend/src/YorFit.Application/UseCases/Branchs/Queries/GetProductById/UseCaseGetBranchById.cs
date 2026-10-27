using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Contracts;
using YorFit.Application.Exceptions;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Branchs.Queries.GetProductById;

public class UseCaseGetBranchById(IBranchRepository repositorio) : IRequestHandler<QueryGetBranchById, BranchDetailDTO>
{
    public async Task<BranchDetailDTO> Handle(QueryGetBranchById request)
    {
        var sede = await repositorio.ObtenerPorId(request.Id);

        if (sede is null)
        {
            throw new NotFoundException();
        }

        return sede.ADto();
    }
}