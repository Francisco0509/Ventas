using System;
using System.Collections.Generic;

namespace SistemaVenta.Model;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public int? Idcategoria { get; set; }

    public int? Stock { get; set; }

    public decimal? Precio { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public int? UsuarioRegistro { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? UsuarioModificacion { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Categoria? IdcategoriaNavigation { get; set; }
}
