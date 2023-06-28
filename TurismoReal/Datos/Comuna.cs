using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class Comuna
{
    public decimal IdComuna { get; set; }

    public string NombreCom { get; set; } = null!;

    public decimal CiudadIdCiudad { get; set; }

    public virtual Ciudad CiudadIdCiudadNavigation { get; set; } = null!;

    public virtual ICollection<Edificio> Edificios { get; set; } = new List<Edificio>();
}
