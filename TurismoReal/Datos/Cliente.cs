using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class Cliente
{
    public decimal IdCli { get; set; }

    public decimal TipoVat { get; set; }

    public string Vat { get; set; } = null!;

    public string NombreCli { get; set; } = null!;

    public string ApaternoCli { get; set; } = null!;

    public string AmaternoCli { get; set; } = null!;

    public decimal EdadCli { get; set; }

    public string SexoCli { get; set; } = null!;

    public string DireccionCli { get; set; } = null!;

    public string EstadocivilCli { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public DateTime LastLogin { get; set; }

    public decimal IsActive { get; set; }

    public string IsAuthenticated { get; set; } = null!;

    public virtual ICollection<Acompanante> Acompanantes { get; set; } = new List<Acompanante>();

    public virtual ICollection<Arriendo> Arriendos { get; set; } = new List<Arriendo>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual TipoVat TipoVatNavigation { get; set; } = null!;
}
