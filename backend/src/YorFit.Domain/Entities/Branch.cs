using System;
using System.Collections.Generic;
using System.Text;
using YorFit.Domain.Exceptions;
using YorFit.Domain.ValuableObjects;

namespace YorFit.Domain.Entities;
public class Branch
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public string Nombre { get; private set; } = default!;
    public string Codigo { get; private set; } = default!;
    public Address Direccion { get; private set; } = default!;
    public Phone Telefono { get; private set; } = default!;
    public bool Activo { get; private set; } = true;

    public static Branch Crear(string nombre,string codigo, Address direccion, Phone telefono)
    {
        ValidarNombre(nombre);
        ValidarCodigo(codigo);

        if (direccion is null)
            throw new BusinessRuleException("La dirección de la sede es requerida.");

        if (telefono is null)
            throw new BusinessRuleException("El teléfono de la sede es requerido.");

        return new Branch{
            Nombre = nombre.Trim(),
            Codigo = codigo.Trim(),
            Direccion = direccion, 
            Telefono = telefono
        };
    }

    public void Actualizar(string nombre, string codigo, Address direccion, Phone telefono)
    {
        ValidarNombre(nombre);
        ValidarCodigo(codigo);

        Nombre = nombre.Trim();
        Codigo = codigo.Trim();
        Direccion = direccion;
        Telefono = telefono;
    }

    public void Activar() => Activo = true;
    public void Desactivar() => Activo = false;

    private static void ValidarNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new BusinessRuleException("El nombre de la sede es requerido.");
        }
        if(nombre.Trim().Length > 100)
        {
            throw new BusinessRuleException("El nombre de la sede no puede exceder los 100 caracteres.");
        }
    }
    private static void ValidarCodigo(string codigo)
    {
        if (string.IsNullOrWhiteSpace(codigo))
        {
            throw new BusinessRuleException("El código de la sede es requerido.");
        }
        if(codigo.Trim().Length > 10)
        {
            throw new BusinessRuleException("El codigo de la sede no puede exceder los 10 caracteres.");
        }
    }
}