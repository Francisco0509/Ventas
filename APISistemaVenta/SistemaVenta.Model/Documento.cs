using System;
using System.Collections.Generic;

namespace SistemaVenta.Model;

public partial class Documento
{
    public int IdDocumento { get; set; }

    public int UltimoNumero { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public int? UsuarioRegistro { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? UsuarioModificacion { get; set; }
}
