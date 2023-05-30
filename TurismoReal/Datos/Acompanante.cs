using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class Acompanante
{
    public string RutAcomp { get; set; } = null!;

    public string NombreAcomp { get; set; } = null!;

    public string ApaternoAcomp { get; set; } = null!;

    public string AmaternoAcomp { get; set; } = null!;

    public decimal EdadAcomp { get; set; }

    public string SexoAcomp { get; set; } = null!;

    public string CorreoAcomp { get; set; } = null!;

    public decimal? ClienteIdCli { get; set; }

    public virtual Cliente? ClienteIdCliNavigation { get; set; }
}
