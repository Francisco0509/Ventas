using System;
using System.Collections.Generic;

namespace SistemaVenta.Model;

public partial class Venta
{
    public int IdVenta { get; set; }

    public string? NumeroDocumento { get; set; }

    public string? TipoPago { get; set; }

    public decimal? Total { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public int? UsuarioRegistro { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? UsuarioModificacion { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
}
