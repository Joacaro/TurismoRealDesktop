using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class Documento
{
    public decimal IdDoc { get; set; }

    public DateTime FechaEmision { get; set; }

    public string EstadoPago { get; set; } = null!;

    public decimal PagoIdPago { get; set; }

    public virtual Pago PagoIdPagoNavigation { get; set; } = null!;
}
