using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class Empleado
{
    public decimal IdEmp { get; set; }

    public string Vat { get; set; } = null!;

    public string NombreEmp { get; set; } = null!;

    public string ApatenoEmp { get; set; } = null!;

    public string AmaternoEmp { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public string IsActive { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public decimal IdTipoEmpId { get; set; }

    public virtual TipoVat IdTipoEmp { get; set; } = null!;

    public virtual Tipoempleado IdTipoEmpNavigation { get; set; } = null!;

    public virtual ICollection<Transporte> Transportes { get; set; } = new List<Transporte>();

    public virtual ICollection<Arriendo> Idarriendos { get; set; } = new List<Arriendo>();
}
