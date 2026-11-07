using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YorFit.Api.DTOs.Roles;

public class CreateRoleDTO
{
   [Required]
   [MaxLength(30)]
    public required string Nombre { get; set; }
    
    [Required]
    [MaxLength(100)]
    public required string Descripcion { get; set; }
}