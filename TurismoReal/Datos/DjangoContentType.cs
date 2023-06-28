using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class DjangoContentType
{
    public long Id { get; set; }

    public string? AppLabel { get; set; }

    public string? Model { get; set; }

    public virtual ICollection<AuthPermission> AuthPermissions { get; set; } = new List<AuthPermission>();

    public virtual ICollection<DjangoAdminLog> DjangoAdminLogs { get; set; } = new List<DjangoAdminLog>();
}
