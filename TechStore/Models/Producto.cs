using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TechStore.Models;

[Table("Producto")]
public partial class Producto
{
    [Key]
    public int IdProducto { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    [Column(TypeName = "decimal(10, 5)")]
    public decimal Precio { get; set; }

    public int Cantidad { get; set; }

    [Column("Fecha_Creacion", TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    [ForeignKey("IdProducto")]
    [InverseProperty("IdProductos")]
    public virtual ICollection<Categoria> IdCategoria { get; set; } = new List<Categoria>();
}
