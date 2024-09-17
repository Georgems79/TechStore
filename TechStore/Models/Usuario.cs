using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TechStore.Models;

public partial class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    [StringLength(250)]
    public string? Nombre { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    [StringLength(50)]
    public string? Clave { get; set; }
}
