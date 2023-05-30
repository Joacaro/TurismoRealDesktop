using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class TipoVat
{
    public decimal IdTipo { get; set; }

    public string NombreTipo { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
