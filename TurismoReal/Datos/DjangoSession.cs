using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class DjangoSession
{
    public string SessionKey { get; set; } = null!;

    public string? SessionData { get; set; }

    public DateTime ExpireDate { get; set; }
}
