using System;
using System.Collections.Generic;

namespace SistemaVenta.Model;

public partial class Menu
{
    public int IdMenu { get; set; }

    public string? Nombre { get; set; }

    public string? Icono { get; set; }

    public string? UrlMenu { get; set; }

    public virtual ICollection<MenuRol> MenuRols { get; set; } = new List<MenuRol>();
}
