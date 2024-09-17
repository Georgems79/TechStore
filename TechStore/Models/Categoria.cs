using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TechStore.Models;

public partial class Categoria
{
    [Key]
    public int IdCategoria { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    [ForeignKey("IdCategoria")]
    [InverseProperty("IdCategoria")]
    public virtual ICollection<Producto> IdProductos { get; set; } = new List<Producto>();
}
