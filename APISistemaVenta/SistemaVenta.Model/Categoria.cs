using System;
using System.Collections.Generic;

namespace SistemaVenta.Model;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public int? UsuarioRegistro { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? UsuarioModificacion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
