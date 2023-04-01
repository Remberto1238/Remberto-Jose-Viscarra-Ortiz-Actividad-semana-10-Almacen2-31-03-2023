using System;
using System.Collections.Generic;

namespace Almacen2.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? Precio { get; set; }

    public int? Stock { get; set; }
}
