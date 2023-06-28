using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class Inventario
{
    public decimal IdInv { get; set; }

    public string NombreItem { get; set; } = null!;

    public decimal Cantidad { get; set; }

    public decimal TipoItemId { get; set; }

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();

    public virtual TipoItem TipoItem { get; set; } = null!;
}
