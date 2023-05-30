using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class Servicio
{
    public decimal IdDepto { get; set; }

    public decimal IdComp { get; set; }

    public virtual TipoCompaniaServicio IdCompNavigation { get; set; } = null!;

    public virtual Departamento IdDeptoNavigation { get; set; } = null!;
}
