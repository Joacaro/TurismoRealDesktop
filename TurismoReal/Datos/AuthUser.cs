using System;
using System.Collections.Generic;

namespace TurismoReal.Datos;

public partial class AuthUser
{
    public long Id { get; set; }

    public string? Password { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool IsSuperuser { get; set; }

    public string? Username { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public bool IsStaff { get; set; }

    public bool IsActive { get; set; }

    public DateTime DateJoined { get; set; }

    public virtual ICollection<AuthUserGroup> AuthUserGroups { get; set; } = new List<AuthUserGroup>();

    public virtual ICollection<AuthUserUserPermission> AuthUserUserPermissions { get; set; } = new List<AuthUserUserPermission>();

    public virtual ICollection<DjangoAdminLog> DjangoAdminLogs { get; set; } = new List<DjangoAdminLog>();
}
