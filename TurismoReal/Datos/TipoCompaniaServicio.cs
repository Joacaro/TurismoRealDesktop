using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class TipoCompaniaServicio
{
    public decimal IdTipoComp { get; set; }

    public string NombreComp { get; set; } = null!;

    public string TelefonoComp { get; set; } = null!;

    public string CorreoComp { get; set; } = null!;

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
