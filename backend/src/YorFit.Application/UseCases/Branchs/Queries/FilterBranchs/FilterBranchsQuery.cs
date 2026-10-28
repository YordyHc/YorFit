using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Application.Utilities.Mediator;

namespace YorFit.Application.UseCases.Branchs.Queries.FilterBranchs;

public record FilterBranchsQuery(string? Nombre, string? Codigo, bool? Activo) : IRequest<List<FilteredBranchDTO>>;