using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YorFit.Api.DTOs;

public class CreateBranchDTO
{
   [Required]
   [MaxLength(100)]
    public required string Nombre { get; set; }
    
    [Required]
    [MaxLength(10)]
    public required string Codigo { get; set; }

    [Required]
    public required string LineaDireccion1 { get; set; }

    public string? LineaDireccion2 { get; set; }

    [Required]
    public required string Distrito { get; set; }

    [Required]
    public required string Provincia { get; set; }

    public string? Referencia { get; set; }

    [Required]
    public required string Pais { get; set; }

    [Required]
    public required string CodigoPais { get; set; }

    [Required]
    public required string NumeroNacional { get; set; }
}