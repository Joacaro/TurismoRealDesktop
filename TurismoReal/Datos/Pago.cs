using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class Pago
{
    public decimal IdPago { get; set; }

    public decimal MontoTotal { get; set; }

    public decimal MetodoPagoId { get; set; }

    public decimal ClienteIdCli { get; set; }

    public virtual Cliente ClienteIdCliNavigation { get; set; } = null!;

    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();

    public virtual FormaPago MetodoPago { get; set; } = null!;
}
