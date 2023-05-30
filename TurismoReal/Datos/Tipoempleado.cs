using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class Tipoempleado
{
    public decimal IdTipoEmp { get; set; }

    public string NombreTipo { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
