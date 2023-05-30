using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class FormaPago
{
    public decimal IdMetodoPago { get; set; }

    public string Cuotas { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
