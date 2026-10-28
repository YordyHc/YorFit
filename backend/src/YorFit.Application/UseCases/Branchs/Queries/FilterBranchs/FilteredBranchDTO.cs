using System;
using System.Collections.Generic;
using System.Text;

namespace YorFit.Application.UseCases.Branchs.Queries.FilterBranchs;

public record FilteredBranchDTO(Guid Id, string Nombre, string Codigo, string Distrito, string Provincia);