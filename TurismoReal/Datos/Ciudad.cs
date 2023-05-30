using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class Ciudad
{
    public decimal IdCiudad { get; set; }

    public string NombreCiudad { get; set; } = null!;

    public decimal ComunaIdComuna { get; set; }

    public virtual Comuna ComunaIdComunaNavigation { get; set; } = null!;

    public virtual ICollection<Edificio> Edificios { get; set; } = new List<Edificio>();
}
