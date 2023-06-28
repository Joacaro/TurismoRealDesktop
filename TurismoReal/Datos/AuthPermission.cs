﻿using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class AuthPermission
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public long ContentTypeId { get; set; }

    public string? Codename { get; set; }

    public virtual ICollection<AuthGroupPermission> AuthGroupPermissions { get; set; } = new List<AuthGroupPermission>();

    public virtual ICollection<AuthUserUserPermission> AuthUserUserPermissions { get; set; } = new List<AuthUserUserPermission>();

    public virtual DjangoContentType ContentType { get; set; } = null!;
}
