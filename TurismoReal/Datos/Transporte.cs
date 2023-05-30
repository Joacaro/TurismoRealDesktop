using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class Transporte
{
    public decimal IdTransporte { get; set; }

    public DateTime FechaViaje { get; set; }

    public DateTime HoraInicio { get; set; }

    public decimal ArriendoIdArriendo { get; set; }

    public decimal EmpleadoIdEmp { get; set; }

    public virtual Arriendo ArriendoIdArriendoNavigation { get; set; } = null!;

    public virtual Empleado EmpleadoIdEmpNavigation { get; set; } = null!;

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
