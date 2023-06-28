using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class Departamento
{
    public decimal IdDepto { get; set; }

    public decimal NDepto { get; set; }

    public decimal CantHab { get; set; }

    public decimal CantBan { get; set; }

    public decimal Disponibilidad { get; set; }

    public decimal Mantenimiento { get; set; }

    public string DireccionEdDepto { get; set; } = null!;

    public decimal IdTipoComp { get; set; }

    public decimal IdInv { get; set; }

    public virtual Edificio DireccionEdDeptoNavigation { get; set; } = null!;

    public virtual Inventario IdInvNavigation { get; set; } = null!;

    public virtual Servicio? Servicio { get; set; }
}
