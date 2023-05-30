using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class Comuna
{
    public decimal IdComuna { get; set; }

    public string NombreCom { get; set; } = null!;

    public decimal CodigoPostal { get; set; }

    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();
}
