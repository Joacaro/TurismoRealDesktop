using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class Arriendo
{
    public decimal IdArriendo { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public string EdDireccionEd { get; set; } = null!;

    public decimal ClienteIdCli { get; set; }

    public virtual Cliente ClienteIdCliNavigation { get; set; } = null!;

    public virtual Edificio EdDireccionEdNavigation { get; set; } = null!;

    public virtual ICollection<Transporte> Transportes { get; set; } = new List<Transporte>();

    public virtual ICollection<Empleado> EmpleadoIdEmps { get; set; } = new List<Empleado>();
}
