using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TurismoReal.Datos;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acompanante> Acompanantes { get; set; }
    public virtual DbSet<Arriendo> Arriendos { get; set; }
    public virtual DbSet<Ciudad> Ciudads { get; set; }
    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<Comuna> Comunas { get; set; }
    public virtual DbSet<Departamento> Departamentos { get; set; }
    public virtual DbSet<Documento> Documentos { get; set; }
    public virtual DbSet<Edificio> Edificios { get; set; }
    public virtual DbSet<Empleado> Empleados { get; set; }
    public virtual DbSet<FormaPago> FormaPagos { get; set; }
    public virtual DbSet<Pago> Pagos { get; set; }
    public virtual DbSet<Servicio> Servicios { get; set; }
    public virtual DbSet<TipoCompaniaServicio> TipoCompaniaServicios { get; set; }
    public virtual DbSet<TipoVat> TipoVats { get; set; }
    public virtual DbSet<Tipoempleado> Tipoempleados { get; set; }
    public virtual DbSet<Transporte> Transportes { get; set; }
    public virtual DbSet<Vehiculo> Vehiculos { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=c##deptos ;Password=dbadmin23;Data Source=localhost:1521/XE; persist security info=false;Validate connection=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("C##DEPTOS")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Acompanante>(entity =>
        {
            entity.HasKey(e => e.RutAcomp).HasName("ACOMPANANTE_PK");

            entity.ToTable("ACOMPANANTE");

            entity.Property(e => e.RutAcomp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("RUT_ACOMP");
            entity.Property(e => e.AmaternoAcomp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AMATERNO_ACOMP");
            entity.Property(e => e.ApaternoAcomp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APATERNO_ACOMP");
            entity.Property(e => e.ClienteIdCli)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CLIENTE_ID_CLI");
            entity.Property(e => e.CorreoAcomp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CORREO_ACOMP");
            entity.Property(e => e.EdadAcomp)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("EDAD_ACOMP");
            entity.Property(e => e.NombreAcomp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_ACOMP");
            entity.Property(e => e.SexoAcomp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SEXO_ACOMP");

            entity.HasOne(d => d.ClienteIdCliNavigation).WithMany(p => p.Acompanantes)
                .HasForeignKey(d => d.ClienteIdCli)
                .HasConstraintName("ACOMPANANTE_CLIENTE_FK");
        });

        modelBuilder.Entity<Arriendo>(entity =>
        {
            entity.HasKey(e => e.IdArriendo).HasName("ARRIENDOS_PK");

            entity.ToTable("ARRIENDOS");

            entity.Property(e => e.IdArriendo)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_ARRIENDO");
            entity.Property(e => e.ClienteIdCli)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CLIENTE_ID_CLI");
            entity.Property(e => e.EdDireccionEd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ED_DIRECCION_ED");
            entity.Property(e => e.FechaFin)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_FIN");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_INICIO");

            entity.HasOne(d => d.ClienteIdCliNavigation).WithMany(p => p.Arriendos)
                .HasForeignKey(d => d.ClienteIdCli)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ARRIENDOS_CLIENTE_FK");

            entity.HasOne(d => d.EdDireccionEdNavigation).WithMany(p => p.Arriendos)
                .HasForeignKey(d => d.EdDireccionEd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ARRIENDOS_EDIFICIO_FK");

            entity.HasMany(d => d.EmpleadoIdEmps).WithMany(p => p.Idarriendos)
                .UsingEntity<Dictionary<string, object>>(
                    "ArriendosEmpleado",
                    r => r.HasOne<Empleado>().WithMany()
                        .HasForeignKey("EmpleadoIdEmp")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ARRIENDOS_EMPLEADO_EMPLEADO_FK"),
                    l => l.HasOne<Arriendo>().WithMany()
                        .HasForeignKey("Idarriendo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ARRIENDOS_EMPLEADO_ARRIENDOS_FK"),
                    j =>
                    {
                        j.HasKey("Idarriendo", "EmpleadoIdEmp").HasName("ARRIENDOS_EMPLEADO_PK");
                        j.ToTable("ARRIENDOS_EMPLEADO");
                        j.IndexerProperty<decimal>("Idarriendo")
                            .HasColumnType("NUMBER(38)")
                            .HasColumnName("IDARRIENDO");
                        j.IndexerProperty<decimal>("EmpleadoIdEmp")
                            .HasColumnType("NUMBER(38)")
                            .HasColumnName("EMPLEADO_ID_EMP");
                    });
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.IdCiudad).HasName("CIUDAD_PK");

            entity.ToTable("CIUDAD");

            entity.Property(e => e.IdCiudad)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_CIUDAD");
            entity.Property(e => e.ComunaIdComuna)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("COMUNA_ID_COMUNA");
            entity.Property(e => e.NombreCiudad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CIUDAD");

            entity.HasOne(d => d.ComunaIdComunaNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.ComunaIdComuna)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CIUDAD_COMUNA_FK");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCli).HasName("CLIENTE_PK");

            entity.ToTable("CLIENTE");

            entity.Property(e => e.IdCli)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_CLI");
            entity.Property(e => e.AmaternoCli)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AMATERNO_CLI");
            entity.Property(e => e.ApaternoCli)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APATERNO_CLI");
            entity.Property(e => e.Clave)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("CLAVE");
            entity.Property(e => e.DireccionCli)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DIRECCION_CLI");
            entity.Property(e => e.EdadCli)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("EDAD_CLI");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.EstadocivilCli)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADOCIVIL_CLI");
            entity.Property(e => e.IsActive)
                .HasColumnType("NUMBER")
                .HasColumnName("IS_ACTIVE");
            entity.Property(e => e.IsAuthenticated)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IS_AUTHENTICATED");
            entity.Property(e => e.LastLogin)
                .HasPrecision(6)
                .HasColumnName("LAST_LOGIN");
            entity.Property(e => e.NombreCli)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CLI");
            entity.Property(e => e.SexoCli)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SEXO_CLI");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
            entity.Property(e => e.TipoVat)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TIPO_VAT");
            entity.Property(e => e.Vat)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VAT");

            entity.HasOne(d => d.TipoVatNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.TipoVat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CLIENTE_TIPO_VAT_FK");
        });

        modelBuilder.Entity<Comuna>(entity =>
        {
            entity.HasKey(e => e.IdComuna).HasName("COMUNA_PK");

            entity.ToTable("COMUNA");

            entity.Property(e => e.IdComuna)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_COMUNA");
            entity.Property(e => e.CodigoPostal)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CODIGO_POSTAL");
            entity.Property(e => e.NombreCom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_COM");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepto).HasName("DEPARTAMENTO_PK");

            entity.ToTable("DEPARTAMENTO");

            entity.Property(e => e.IdDepto)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_DEPTO");
            entity.Property(e => e.CantBan)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CANT_BAN");
            entity.Property(e => e.CantHab)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CANT_HAB");
            entity.Property(e => e.DireccionEdDepto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DIRECCION_ED_DEPTO");
            entity.Property(e => e.Disponibilidad)
                .HasColumnType("NUMBER")
                .HasColumnName("DISPONIBILIDAD");
            entity.Property(e => e.IdTipoComp)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_TIPO_COMP");
            entity.Property(e => e.Mantenimiento)
                .HasColumnType("NUMBER")
                .HasColumnName("MANTENIMIENTO");
            entity.Property(e => e.NDepto)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("N_DEPTO");

            entity.HasOne(d => d.DireccionEdDeptoNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.DireccionEdDepto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DEPARTAMENTO_EDIFICIO_FK");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.IdDoc).HasName("DOCUMENTO_PK");

            entity.ToTable("DOCUMENTO");

            entity.Property(e => e.IdDoc)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_DOC");
            entity.Property(e => e.EstadoPago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADO_PAGO");
            entity.Property(e => e.FechaEmision)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_EMISION");
            entity.Property(e => e.PagoIdPago)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PAGO_ID_PAGO");

            entity.HasOne(d => d.PagoIdPagoNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.PagoIdPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DOCUMENTO_PAGO_FK");
        });

        modelBuilder.Entity<Edificio>(entity =>
        {
            entity.HasKey(e => e.DireccionEd).HasName("EDIFICIO_PK");

            entity.ToTable("EDIFICIO");

            entity.Property(e => e.DireccionEd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DIRECCION_ED");
            entity.Property(e => e.CantPisos)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CANT_PISOS");
            entity.Property(e => e.CiudadIdCiudad)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CIUDAD_ID_CIUDAD");
            entity.Property(e => e.NombreAdm)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_ADM");
            entity.Property(e => e.TelefonoEd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TELEFONO_ED");

            entity.HasOne(d => d.CiudadIdCiudadNavigation).WithMany(p => p.Edificios)
                .HasForeignKey(d => d.CiudadIdCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EDIFICIO_CIUDAD_FK");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmp).HasName("EMPLEADO_PK");

            entity.ToTable("EMPLEADO");

            entity.Property(e => e.IdEmp)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_EMP");
            entity.Property(e => e.AmaternoEmp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AMATERNO_EMP");
            entity.Property(e => e.ApatenoEmp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APATENO_EMP");
            entity.Property(e => e.IdTipoEmpId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_TIPO_EMP_ID");
            entity.Property(e => e.NombreEmp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_EMP");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
            entity.Property(e => e.Vat)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VAT");

            entity.HasOne(d => d.IdTipoEmp).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdTipoEmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EMPLEADO_TIPO_VAT_FK");

            entity.HasOne(d => d.IdTipoEmpNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdTipoEmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EMPLEADO_TIPOEMPLEADO_FK");
        });

        modelBuilder.Entity<FormaPago>(entity =>
        {
            entity.HasKey(e => e.IdMetodoPago).HasName("FORMA_PAGO_PK");

            entity.ToTable("FORMA_PAGO");

            entity.Property(e => e.IdMetodoPago)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_METODO_PAGO");
            entity.Property(e => e.Cuotas)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CUOTAS");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PAGO_PK");

            entity.ToTable("PAGO");

            entity.Property(e => e.IdPago)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_PAGO");
            entity.Property(e => e.ClienteIdCli)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CLIENTE_ID_CLI");
            entity.Property(e => e.MetodoPagoId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("METODO_PAGO_ID");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("MONTO_TOTAL");

            entity.HasOne(d => d.ClienteIdCliNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.ClienteIdCli)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PAGO_CLIENTE_FK");

            entity.HasOne(d => d.MetodoPago).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.MetodoPagoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PAGO_FORMA_PAGO_FK");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdDepto).HasName("SERVICIOS_PK");

            entity.ToTable("SERVICIOS");

            entity.Property(e => e.IdDepto)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_DEPTO");
            entity.Property(e => e.IdComp)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_COMP");

            entity.HasOne(d => d.IdCompNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdComp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SERVICIOS_TIPO_COMPANIA_SERVICIO_FK");

            entity.HasOne(d => d.IdDeptoNavigation).WithOne(p => p.Servicio)
                .HasForeignKey<Servicio>(d => d.IdDepto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SERVICIOS_DEPARTAMENTO_FK");
        });

        modelBuilder.Entity<TipoCompaniaServicio>(entity =>
        {
            entity.HasKey(e => e.IdTipoComp).HasName("TIPO_COMPANIA_SERVICIO_PK");

            entity.ToTable("TIPO_COMPANIA_SERVICIO");

            entity.Property(e => e.IdTipoComp)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_TIPO_COMP");
            entity.Property(e => e.CorreoComp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CORREO_COMP");
            entity.Property(e => e.NombreComp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_COMP");
            entity.Property(e => e.TelefonoComp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TELEFONO_COMP");
        });

        modelBuilder.Entity<TipoVat>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("TIPO_VAT_PK");

            entity.ToTable("TIPO_VAT");

            entity.Property(e => e.IdTipo)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_TIPO");
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_TIPO");
        });

        modelBuilder.Entity<Tipoempleado>(entity =>
        {
            entity.HasKey(e => e.IdTipoEmp).HasName("TIPOEMPLEADO_PK");

            entity.ToTable("TIPOEMPLEADO");

            entity.Property(e => e.IdTipoEmp)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_TIPO_EMP");
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_TIPO");
        });

        modelBuilder.Entity<Transporte>(entity =>
        {
            entity.HasKey(e => e.IdTransporte).HasName("TRANSPORTE_PK");

            entity.ToTable("TRANSPORTE");

            entity.Property(e => e.IdTransporte)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_TRANSPORTE");
            entity.Property(e => e.ArriendoIdArriendo)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ARRIENDO_ID_ARRIENDO");
            entity.Property(e => e.EmpleadoIdEmp)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("EMPLEADO_ID_EMP");
            entity.Property(e => e.FechaViaje)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_VIAJE");
            entity.Property(e => e.HoraInicio)
                .HasColumnType("DATE")
                .HasColumnName("HORA_INICIO");

            entity.HasOne(d => d.ArriendoIdArriendoNavigation).WithMany(p => p.Transportes)
                .HasForeignKey(d => d.ArriendoIdArriendo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TRANSPORTE_ARRIENDOS_FK");

            entity.HasOne(d => d.EmpleadoIdEmpNavigation).WithMany(p => p.Transportes)
                .HasForeignKey(d => d.EmpleadoIdEmp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TRANSPORTE_EMPLEADO_FK");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculo).HasName("VEHICULO_PK");

            entity.ToTable("VEHICULO");

            entity.Property(e => e.IdVehiculo)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_VEHICULO");
            entity.Property(e => e.ColorVeh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COLOR_VEH");
            entity.Property(e => e.MaxPasajeros)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("MAX_PASAJEROS");
            entity.Property(e => e.ModeloVeh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MODELO_VEH");
            entity.Property(e => e.TipoVehiculo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPO_VEHICULO");
            entity.Property(e => e.TransporteIdTransporte)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TRANSPORTE_ID_TRANSPORTE");

            entity.HasOne(d => d.TransporteIdTransporteNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.TransporteIdTransporte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VEHICULO_TRANSPORTE_FK");
        });
        modelBuilder.HasSequence("CLIENTE_SEQ");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
