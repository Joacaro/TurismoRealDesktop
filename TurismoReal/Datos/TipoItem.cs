using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class TipoItem
{
    public decimal IdTipo { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
