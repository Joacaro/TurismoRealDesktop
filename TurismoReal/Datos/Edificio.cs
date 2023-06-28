using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class Edificio
{
    public string DireccionEd { get; set; } = null!;

    public string TelefonoEd { get; set; } = null!;

    public decimal CantPisos { get; set; }

    public string NombreAdm { get; set; } = null!;

    public decimal ComunaIdCom { get; set; }

    public virtual ICollection<Arriendo> Arriendos { get; set; } = new List<Arriendo>();

    public virtual Comuna ComunaIdComNavigation { get; set; } = null!;

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
