using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class AuthUserGroup
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long GroupId { get; set; }

    public virtual AuthGroup Group { get; set; } = null!;

    public virtual AuthUser User { get; set; } = null!;
}
