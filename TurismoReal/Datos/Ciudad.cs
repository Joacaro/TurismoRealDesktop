using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class Ciudad
{
    public decimal IdCiudad { get; set; }

    public string NombreCiudad { get; set; } = null!;

    public decimal RegionIdReg { get; set; }

    public virtual ICollection<Comuna> Comunas { get; set; } = new List<Comuna>();

    public virtual Region RegionIdRegNavigation { get; set; } = null!;
}
