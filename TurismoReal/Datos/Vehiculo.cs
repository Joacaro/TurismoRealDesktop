using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class Vehiculo
{
    public decimal IdVehiculo { get; set; }

    public string TipoVehiculo { get; set; } = null!;

    public string ModeloVeh { get; set; } = null!;

    public decimal MaxPasajeros { get; set; }

    public string ColorVeh { get; set; } = null!;

    public decimal TransporteIdTransporte { get; set; }

    public virtual Transporte TransporteIdTransporteNavigation { get; set; } = null!;
}
