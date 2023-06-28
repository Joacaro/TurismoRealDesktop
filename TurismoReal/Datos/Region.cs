using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class Region
{
    public decimal IdRegion { get; set; }

    public string NombreReg { get; set; } = null!;

    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();
}
