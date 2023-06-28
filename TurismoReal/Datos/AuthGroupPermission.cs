﻿using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class AuthGroupPermission
{
    public long Id { get; set; }

    public long GroupId { get; set; }

    public long PermissionId { get; set; }

    public virtual AuthGroup Group { get; set; } = null!;

    public virtual AuthPermission Permission { get; set; } = null!;
}
