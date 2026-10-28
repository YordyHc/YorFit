using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Domain.Entities;

namespace YorFit.Application.Contracts;

public interface IBranchRepository
{
    Task Agregar(Branch sede);
    Task<bool> Existe(string nombre);
    Task<bool> ExisteCodigo(string codigo);
    Task<Branch?> ObtenerPorId(Guid id);
    Task Actualizar(Branch sede);
    Task<List<Branch>> ObtenerFiltrado(string? nombre, string? codigo, bool? activo);
    Task Eliminar(Branch sede);
}