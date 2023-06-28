using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class DjangoMigration
{
    public long Id { get; set; }

    public string? App { get; set; }

    public string? Name { get; set; }

    public DateTime Applied { get; set; }
}
