using BirthflowMicroServices.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BirthflowMicroServices.Infraestructure;

public partial class BirthFlowDbContext : DbContext
{
	private readonly IConfiguration _config;

	public BirthFlowDbContext(IConfiguration config)
	{
		this._config = config;
	}

	public BirthFlowDbContext(DbContextOptions<BirthFlowDbContext> options, IConfiguration config)
		: base(options)
	{
		this._config = config;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 => optionsBuilder.UseSqlServer(_config.GetConnectionString($"Birthflow"));

	public virtual DbSet<Configuracione> Configuraciones { get; set; }

	public virtual DbSet<DilatacionesCervicale> DilatacionesCervicales { get; set; }

	public virtual DbSet<DilatacionesCervicalesHistorico> DilatacionesCervicalesHistoricos { get; set; }

	public virtual DbSet<FrecuenciaCardiacaFetal> FrecuenciaCardiacaFetals { get; set; }

	public virtual DbSet<FrecuenciaCardiacaFetalHistorico> FrecuenciaCardiacaFetalHistoricos { get; set; }

	public virtual DbSet<FrecuenciaContracione> FrecuenciaContraciones { get; set; }

	public virtual DbSet<FrecuenciaContracionesHistorico> FrecuenciaContracionesHistoricos { get; set; }

	public virtual DbSet<NotaParto> NotaPartos { get; set; }

	public virtual DbSet<NotaPartoHistorico> NotaPartoHistoricos { get; set; }

	public virtual DbSet<NotificationPartograma> NotificationPartogramas { get; set; }

	public virtual DbSet<Notificatione> Notificationes { get; set; }

	public virtual DbSet<Observacione> Observaciones { get; set; }

	public virtual DbSet<ObservacionesHistorico> ObservacionesHistoricos { get; set; }

	public virtual DbSet<Partograma> Partogramas { get; set; }

	public virtual DbSet<PartogramaEstado> PartogramaEstados { get; set; }

	public virtual DbSet<PartogramaHistorialCambio> PartogramaHistorialCambios { get; set; }

	public virtual DbSet<PartogramaPermiso> PartogramaPermisos { get; set; }

	public virtual DbSet<PartogramasHistorico> PartogramasHistoricos { get; set; }

	public virtual DbSet<Password> Passwords { get; set; }

	public virtual DbSet<Role> Roles { get; set; }

	public virtual DbSet<TiempoTrabajo> TiempoTrabajos { get; set; }

	public virtual DbSet<TiempoTrabajosHistorico> TiempoTrabajosHistoricos { get; set; }

	public virtual DbSet<TipoCambio> TipoCambios { get; set; }

	public virtual DbSet<TipoNotificacione> TipoNotificaciones { get; set; }

	public virtual DbSet<TipoPermiso> TipoPermisos { get; set; }

	public virtual DbSet<TipoPermisosRol> TipoPermisosRols { get; set; }

	public virtual DbSet<Usuario> Usuarios { get; set; }

	public virtual DbSet<VigilanciaMedica> VigilanciaMedicas { get; set; }

	public virtual DbSet<VigilanciaMedicaHistorico> VigilanciaMedicaHistoricos { get; set; }

	public virtual DbSet<Vpp> Vpps { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Configuracione>(entity =>
		{
			entity.HasKey(e => e.UsuarioId).HasName("PK__Configur__2B3DE7981A907EFD");

			entity.Property(e => e.UsuarioId)
				.ValueGeneratedNever()
				.HasColumnName("UsuarioID");
			entity.Property(e => e.CreateAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.Lenguaje)
				.HasMaxLength(15)
				.IsUnicode(false);
			entity.Property(e => e.UpdateAt).HasColumnType("datetime");

			entity.HasOne(d => d.Usuario).WithOne(p => p.Configuracione)
				.HasForeignKey<Configuracione>(d => d.UsuarioId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Configura__Usuar__4222D4EF");
		});

		modelBuilder.Entity<DilatacionesCervicale>(entity =>
		{
			entity.HasKey(e => e.DilatacionCervicalId).HasName("PK__Dilataci__AF44EEABDFE91BA7");

			entity.Property(e => e.DilatacionCervicalId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("DilatacionCervicalID");
			entity.Property(e => e.CreateAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.DeleteAt).HasColumnType("datetime");
			entity.Property(e => e.Hora).HasColumnType("datetime");
			entity.Property(e => e.IsDelete).HasColumnName("isDelete");
			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.RemOram).HasColumnName("RemORam");
			entity.Property(e => e.UpdateAt).HasColumnType("datetime");
			entity.Property(e => e.Valor).HasColumnType("decimal(6, 2)");

			entity.HasOne(d => d.Partograma).WithMany(p => p.DilatacionesCervicales)
				.HasForeignKey(d => d.PartogramaId)
				.HasConstraintName("FK__Dilatacio__Parto__5DCAEF64");
		});

		modelBuilder.Entity<DilatacionesCervicalesHistorico>(entity =>
		{
			entity.HasKey(e => e.HistoricoId).HasName("PK__Dilataci__4A561D7649310E4F");

			entity.ToTable("DilatacionesCervicales_Historico");

			entity.Property(e => e.HistoricoId).HasColumnName("HistoricoID");
			entity.Property(e => e.Accion)
				.HasMaxLength(15)
				.IsUnicode(false);
			entity.Property(e => e.DilatacionCervicalId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("DilatacionCervicalID");
			entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
			entity.Property(e => e.Hora).HasColumnType("datetime");
			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.RemOram).HasColumnName("RemORam");
			entity.Property(e => e.Valor).HasColumnType("decimal(4, 2)");
		});

		modelBuilder.Entity<FrecuenciaCardiacaFetal>(entity =>
		{
			entity.HasKey(e => e.FrecuenciaCardiacaFetalId).HasName("PK__Frecuenc__10979C37346E864D");

			entity.ToTable("FrecuenciaCardiacaFetal");

			entity.Property(e => e.FrecuenciaCardiacaFetalId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("FrecuenciaCardiacaFetalID");
			entity.Property(e => e.CreateAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.DeleteAt).HasColumnType("datetime");
			entity.Property(e => e.IsDelete).HasColumnName("isDelete");
			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.Tiempo).HasColumnType("datetime");
			entity.Property(e => e.UpdateAt).HasColumnType("datetime");
			entity.Property(e => e.Valor)
				.HasMaxLength(20)
				.IsUnicode(false);

			entity.HasOne(d => d.Partograma).WithMany(p => p.FrecuenciaCardiacaFetals)
				.HasForeignKey(d => d.PartogramaId)
				.HasConstraintName("FK__Frecuenci__Parto__70DDC3D8");
		});

		modelBuilder.Entity<FrecuenciaCardiacaFetalHistorico>(entity =>
		{
			entity.HasKey(e => e.HistoricoId).HasName("PK__Frecuenc__4A561D76C42EB14B");

			entity.ToTable("FrecuenciaCardiacaFetal_Historico");

			entity.Property(e => e.HistoricoId).HasColumnName("HistoricoID");
			entity.Property(e => e.Accion)
				.HasMaxLength(15)
				.IsUnicode(false);
			entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
			entity.Property(e => e.FrecuenciaCardiacaFetalId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("FrecuenciaCardiacaFetalID");
			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.Tiempo).HasColumnType("datetime");
			entity.Property(e => e.Valor)
				.HasMaxLength(20)
				.IsUnicode(false);
		});

		modelBuilder.Entity<FrecuenciaContracione>(entity =>
		{
			entity.HasKey(e => e.FrecuenciaContracionesId).HasName("PK__Frecuenc__1B45F4EDD79E165B");

			entity.Property(e => e.FrecuenciaContracionesId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("FrecuenciaContracionesID");
			entity.Property(e => e.CreateAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.DeleteAt).HasColumnType("datetime");
			entity.Property(e => e.IsDelete).HasColumnName("isDelete");
			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.Tiempo).HasColumnType("datetime");
			entity.Property(e => e.UpdateAt).HasColumnType("datetime");
			entity.Property(e => e.Valor)
				.HasMaxLength(20)
				.IsUnicode(false);

			entity.HasOne(d => d.Partograma).WithMany(p => p.FrecuenciaContraciones)
				.HasForeignKey(d => d.PartogramaId)
				.HasConstraintName("FK__Frecuenci__Parto__75A278F5");
		});

		modelBuilder.Entity<FrecuenciaContracionesHistorico>(entity =>
		{
			entity.HasKey(e => e.HistoricoId).HasName("PK__Frecuenc__4A561D7653F0F353");

			entity.ToTable("FrecuenciaContraciones_Historico");

			entity.Property(e => e.HistoricoId).HasColumnName("HistoricoID");
			entity.Property(e => e.Accion)
				.HasMaxLength(15)
				.IsUnicode(false);
			entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
			entity.Property(e => e.FrecuenciaContracionesId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("FrecuenciaContracionesID");
			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.Tiempo).HasColumnType("datetime");
			entity.Property(e => e.Valor)
				.HasMaxLength(20)
				.IsUnicode(false);
		});

		modelBuilder.Entity<NotaParto>(entity =>
		{
			entity.HasKey(e => e.PartogramaId).HasName("PK__NotaPart__2A6C391348ED606B");

			entity.ToTable("NotaParto");

			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.Alumbramiento)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.Apgar)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.Caputto)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.Circular)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.CreateAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.Date).HasColumnType("datetime");
			entity.Property(e => e.Descripcion).IsUnicode(false);
			entity.Property(e => e.Expulsivo)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.Hora)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.HuellaPlantar)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.Lamniotico)
				.HasMaxLength(25)
				.IsUnicode(false)
				.HasColumnName("LAmniotico");
			entity.Property(e => e.Meconio)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.Miccion)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.Pa)
				.HasMaxLength(25)
				.IsUnicode(false)
				.HasColumnName("PA");
			entity.Property(e => e.Placenta)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.Sexo)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.Temperatura)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.UpdateAt).HasColumnType("datetime");

			entity.HasOne(d => d.Partograma).WithOne(p => p.NotaParto)
				.HasForeignKey<NotaParto>(d => d.PartogramaId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__NotaParto__Parto__7A672E12");
		});

		modelBuilder.Entity<NotaPartoHistorico>(entity =>
		{
			entity.HasKey(e => e.HistoricoId).HasName("PK__NotaPart__4A561D76E059B619");

			entity.ToTable("NotaParto_Historico");

			entity.Property(e => e.HistoricoId).HasColumnName("HistoricoID");
			entity.Property(e => e.Accion)
				.HasMaxLength(15)
				.IsUnicode(false);
			entity.Property(e => e.Alumbramiento)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.Apgar)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.Caputto)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.Circular)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.Date).HasColumnType("datetime");
			entity.Property(e => e.Descripcion).IsUnicode(false);
			entity.Property(e => e.Expulsivo)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
			entity.Property(e => e.Hora)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.HuellaPlantar)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.Lamniotico)
				.HasMaxLength(20)
				.IsUnicode(false)
				.HasColumnName("LAmniotico");
			entity.Property(e => e.Meconio)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.Miccion)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.Pa)
				.HasMaxLength(20)
				.IsUnicode(false)
				.HasColumnName("PA");
			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.Placenta)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.Sexo)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.Temperatura)
				.HasMaxLength(20)
				.IsUnicode(false);
		});

		modelBuilder.Entity<NotificationPartograma>(entity =>
		{
			entity
				.HasNoKey()
				.ToTable("NotificationPartograma");

			entity.Property(e => e.NotificacionId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("NotificacionID");
			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

			entity.HasOne(d => d.Notificacion).WithMany()
				.HasForeignKey(d => d.NotificacionId)
				.HasConstraintName("FK__Notificat__Notif__05D8E0BE");

			entity.HasOne(d => d.Partograma).WithMany()
				.HasForeignKey(d => d.PartogramaId)
				.HasConstraintName("FK__Notificat__Parto__03F0984C");

			entity.HasOne(d => d.Usuario).WithMany()
				.HasForeignKey(d => d.UsuarioId)
				.HasConstraintName("FK__Notificat__Usuar__04E4BC85");
		});

		modelBuilder.Entity<Notificatione>(entity =>
		{
			entity.HasKey(e => e.NotificacionId).HasName("PK__Notifica__BCC120C41D39179E");

			entity.Property(e => e.NotificacionId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("NotificacionID");
			entity.Property(e => e.Date).HasColumnType("datetime");
			entity.Property(e => e.NotificationTypeId).HasColumnName("NotificationTypeID");
			entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

			entity.HasOne(d => d.NotificationType).WithMany(p => p.Notificationes)
				.HasForeignKey(d => d.NotificationTypeId)
				.HasConstraintName("FK__Notificat__Notif__01142BA1");

			entity.HasOne(d => d.Usuario).WithMany(p => p.Notificationes)
				.HasForeignKey(d => d.UsuarioId)
				.HasConstraintName("FK__Notificat__Usuar__00200768");
		});

		modelBuilder.Entity<Observacione>(entity =>
		{
			entity.HasKey(e => e.VigilanciaMedicaId).HasName("PK__Observac__7C44AA21ECA9F18E");

			entity.Property(e => e.VigilanciaMedicaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("VigilanciaMedicaID");
			entity.Property(e => e.CreateAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.DeleteAt).HasColumnType("datetime");
			entity.Property(e => e.Descripcion)
				.HasMaxLength(200)
				.IsUnicode(false);
			entity.Property(e => e.Header)
				.HasMaxLength(1)
				.IsUnicode(false);
			entity.Property(e => e.IsDelete).HasColumnName("isDelete");
			entity.Property(e => e.UpdateAt).HasColumnType("datetime");

			entity.HasOne(d => d.VigilanciaMedica).WithOne(p => p.Observacione)
				.HasForeignKey<Observacione>(d => d.VigilanciaMedicaId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Observaci__Vigil__6754599E");
		});

		modelBuilder.Entity<ObservacionesHistorico>(entity =>
		{
			entity.HasKey(e => e.HistoricoId).HasName("PK__Observac__4A561D76B6D4C7C9");

			entity.ToTable("Observaciones_Historico");

			entity.Property(e => e.HistoricoId).HasColumnName("HistoricoID");
			entity.Property(e => e.Accion)
				.HasMaxLength(15)
				.IsUnicode(false);
			entity.Property(e => e.CreateAt).HasColumnType("datetime");
			entity.Property(e => e.DeleteAt).HasColumnType("datetime");
			entity.Property(e => e.Descripcion)
				.HasMaxLength(200)
				.IsUnicode(false);
			entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
			entity.Property(e => e.Header)
				.HasMaxLength(1)
				.IsUnicode(false);
			entity.Property(e => e.IsDelete).HasColumnName("isDelete");
			entity.Property(e => e.UpdateAt).HasColumnType("datetime");
			entity.Property(e => e.VigilanciaMedicaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("VigilanciaMedicaID");
		});

		modelBuilder.Entity<Partograma>(entity =>
		{
			entity.HasKey(e => e.PartogramaId).HasName("PK__Partogra__2A6C3913CC5F9652");

			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.CreateAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.Expediente)
				.HasMaxLength(30)
				.IsUnicode(false);
			entity.Property(e => e.Fecha).HasColumnType("datetime");
			entity.Property(e => e.IsDelete).HasColumnName("isDelete");
			entity.Property(e => e.Nombre)
				.HasMaxLength(60)
				.IsUnicode(false);
			entity.Property(e => e.UpdateAt).HasColumnType("datetime");
			entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

			entity.HasOne(d => d.Usuario).WithMany(p => p.Partogramas)
				.HasForeignKey(d => d.UsuarioId)
				.HasConstraintName("FK__Partogram__Usuar__45F365D3");
		});

		modelBuilder.Entity<PartogramaEstado>(entity =>
		{
			entity.HasKey(e => e.PartogramaId).HasName("PK__Partogra__2A6C391353C62D84");

			entity.ToTable("PartogramaEstado");

			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.CreateAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.DilatacionCervicalesNotificacion).HasDefaultValue(true);
			entity.Property(e => e.Fcfydcnotificacion)
				.HasDefaultValue(true)
				.HasColumnName("FCFYDCNotificacion");
			entity.Property(e => e.PlanoHodgeNotificacion).HasDefaultValue(true);
			entity.Property(e => e.TipoPermisoId).HasColumnName("TipoPermisoID");
			entity.Property(e => e.UltimaModificacion)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.UpdateAt).HasColumnType("datetime");
			entity.Property(e => e.VigilanciaMedicaNotificacion).HasDefaultValue(true);

			entity.HasOne(d => d.Partograma).WithOne(p => p.PartogramaEstado)
				.HasForeignKey<PartogramaEstado>(d => d.PartogramaId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Partogram__Parto__5165187F");

			entity.HasOne(d => d.TipoPermiso).WithMany(p => p.PartogramaEstados)
				.HasForeignKey(d => d.TipoPermisoId)
				.HasConstraintName("FK__Partogram__TipoP__59FA5E80");
		});

		modelBuilder.Entity<PartogramaHistorialCambio>(entity =>
		{
			entity.HasNoKey();

			entity.Property(e => e.Fecha).HasColumnType("datetime");
			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.TipoCambioId).HasColumnName("TipoCambioID");
			entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

			entity.HasOne(d => d.Partograma).WithMany()
				.HasForeignKey(d => d.PartogramaId)
				.HasConstraintName("FK__Partogram__Parto__1332DBDC");

			entity.HasOne(d => d.TipoCambio).WithMany()
				.HasForeignKey(d => d.TipoCambioId)
				.HasConstraintName("FK__Partogram__TipoC__151B244E");

			entity.HasOne(d => d.Usuario).WithMany()
				.HasForeignKey(d => d.UsuarioId)
				.HasConstraintName("FK__Partogram__Usuar__14270015");
		});

		modelBuilder.Entity<PartogramaPermiso>(entity =>
		{
			entity.HasKey(e => e.PermisoPartogramaId).HasName("PK__Partogra__CAF60972E381D3F8");

			entity.Property(e => e.PermisoPartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PermisoPartogramaID");
			entity.Property(e => e.CreateAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.RolId).HasColumnName("RolID");
			entity.Property(e => e.TipoPermisoRolId).HasColumnName("TipoPermisoRolID");
			entity.Property(e => e.UpdateAt).HasColumnType("datetime");
			entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

			entity.HasOne(d => d.Partograma).WithMany(p => p.PartogramaPermisos)
				.HasForeignKey(d => d.PartogramaId)
				.HasConstraintName("FK__Partogram__Parto__0B91BA14");

			entity.HasOne(d => d.Rol).WithMany(p => p.PartogramaPermisos)
				.HasForeignKey(d => d.RolId)
				.HasConstraintName("FK__Partogram__RolID__0D7A0286");

			entity.HasOne(d => d.TipoPermisoRol).WithMany(p => p.PartogramaPermisos)
				.HasForeignKey(d => d.TipoPermisoRolId)
				.HasConstraintName("FK__Partogram__TipoP__0E6E26BF");

			entity.HasOne(d => d.Usuario).WithMany(p => p.PartogramaPermisos)
				.HasForeignKey(d => d.UsuarioId)
				.HasConstraintName("FK__Partogram__Usuar__0C85DE4D");
		});

		modelBuilder.Entity<PartogramasHistorico>(entity =>
		{
			entity.HasKey(e => e.HistoricoId).HasName("PK__Partogra__4A561D766D6EF489");

			entity.ToTable("Partogramas_Historico");

			entity.Property(e => e.HistoricoId).HasColumnName("HistoricoID");
			entity.Property(e => e.Accion)
				.HasMaxLength(15)
				.IsUnicode(false);
			entity.Property(e => e.Expediente)
				.HasMaxLength(30)
				.IsUnicode(false);
			entity.Property(e => e.Fecha).HasColumnType("datetime");
			entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
			entity.Property(e => e.Nombre)
				.HasMaxLength(60)
				.IsUnicode(false);
			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
		});

		modelBuilder.Entity<Password>(entity =>
		{
			entity.HasKey(e => e.PasswordId).HasName("PK__Password__EA7BF0E814DA0B01");

			entity.Property(e => e.PasswordId)
				.ValueGeneratedNever()
				.HasColumnName("PasswordID");
			entity.Property(e => e.CreateAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.PasswordHash).HasMaxLength(64);
			entity.Property(e => e.PasswordSalt).HasMaxLength(16);
			entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

			entity.HasOne(d => d.Usuario).WithMany(p => p.Passwords)
				.HasForeignKey(d => d.UsuarioId)
				.HasConstraintName("FK__Passwords__Usuar__3E52440B");
		});

		modelBuilder.Entity<Role>(entity =>
		{
			entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302D138488F7D");

			entity.Property(e => e.RolId)
				.ValueGeneratedNever()
				.HasColumnName("RolID");
			entity.Property(e => e.Nombre)
				.HasMaxLength(40)
				.IsUnicode(false);
		});

		modelBuilder.Entity<TiempoTrabajo>(entity =>
		{
			entity.HasKey(e => e.PartogramaId).HasName("PK__TiempoTr__2A6C3913842FB72A");

			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.CreateAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.Membranas)
				.HasMaxLength(15)
				.IsUnicode(false);
			entity.Property(e => e.Paridad)
				.HasMaxLength(15)
				.IsUnicode(false);
			entity.Property(e => e.Posicion)
				.HasMaxLength(15)
				.IsUnicode(false);
			entity.Property(e => e.UpdateAt).HasColumnType("datetime");

			entity.HasOne(d => d.Partograma).WithOne(p => p.TiempoTrabajo)
				.HasForeignKey<TiempoTrabajo>(d => d.PartogramaId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__TiempoTra__Parto__4AB81AF0");
		});

		modelBuilder.Entity<TiempoTrabajosHistorico>(entity =>
		{
			entity.HasKey(e => e.HistoricoId).HasName("PK__TiempoTr__4A561D76A74D7F05");

			entity.Property(e => e.HistoricoId).HasColumnName("HistoricoID");
			entity.Property(e => e.Accion)
				.HasMaxLength(15)
				.IsUnicode(false);
			entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
			entity.Property(e => e.Membranas)
				.HasMaxLength(15)
				.IsUnicode(false);
			entity.Property(e => e.Paridad)
				.HasMaxLength(15)
				.IsUnicode(false);
			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.Posicion)
				.HasMaxLength(15)
				.IsUnicode(false);
		});

		modelBuilder.Entity<TipoCambio>(entity =>
		{
			entity.HasKey(e => e.TipoCambioId).HasName("PK__TipoCamb__A510D87FCBE65E7E");

			entity.ToTable("TipoCambio");

			entity.Property(e => e.TipoCambioId)
				.ValueGeneratedOnAdd()
				.HasColumnName("TipoCambioID");
			entity.Property(e => e.Descripcion)
				.HasMaxLength(50)
				.IsUnicode(false);
			entity.Property(e => e.Nombre)
				.HasMaxLength(30)
				.IsUnicode(false);
		});

		modelBuilder.Entity<TipoNotificacione>(entity =>
		{
			entity.HasKey(e => e.TipoNotificacionesId).HasName("PK__TipoNoti__8AE962E24B543620");

			entity.Property(e => e.TipoNotificacionesId)
				.ValueGeneratedOnAdd()
				.HasColumnName("TipoNotificacionesID");
			entity.Property(e => e.Descripcion)
				.HasMaxLength(60)
				.IsUnicode(false);
			entity.Property(e => e.Nombre)
				.HasMaxLength(40)
				.IsUnicode(false);
		});

		modelBuilder.Entity<TipoPermiso>(entity =>
		{
			entity.HasKey(e => e.TipoPermisoId).HasName("PK__TipoPerm__6A7B92F2B33666B3");

			entity.Property(e => e.TipoPermisoId)
				.ValueGeneratedOnAdd()
				.HasColumnName("TipoPermisoID");
			entity.Property(e => e.CreateAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.Nombre)
				.HasMaxLength(25)
				.IsUnicode(false);
		});

		modelBuilder.Entity<TipoPermisosRol>(entity =>
		{
			entity.HasKey(e => e.TipoPermisoRolId).HasName("PK__TipoPerm__92DF0B773ABB90E1");

			entity.ToTable("TipoPermisosRol");

			entity.Property(e => e.TipoPermisoRolId)
				.ValueGeneratedOnAdd()
				.HasColumnName("TipoPermisoRolID");
			entity.Property(e => e.CreateAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.Nombre)
				.HasMaxLength(25)
				.IsUnicode(false);
		});

		modelBuilder.Entity<Usuario>(entity =>
		{
			entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE79832BF79ED");

			entity.Property(e => e.UsuarioId)
				.ValueGeneratedNever()
				.HasColumnName("UsuarioID");
			entity.Property(e => e.Apellidos)
				.HasMaxLength(50)
				.IsUnicode(false);
			entity.Property(e => e.CreateAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.DeleteAt).HasColumnType("datetime");
			entity.Property(e => e.Email)
				.HasMaxLength(50)
				.IsUnicode(false);
			entity.Property(e => e.IsDelete).HasColumnName("isDelete");
			entity.Property(e => e.NombreUsuario)
				.HasMaxLength(50)
				.IsUnicode(false);
			entity.Property(e => e.Nombres)
				.HasMaxLength(50)
				.IsUnicode(false);
			entity.Property(e => e.PhoneNumber).HasColumnType("decimal(8, 0)");
			entity.Property(e => e.RolId).HasColumnName("RolID");
			entity.Property(e => e.UpdateAt).HasColumnType("datetime");

			entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
				.HasForeignKey(d => d.RolId)
				.HasConstraintName("FK__Usuarios__RolID__398D8EEE");
		});

		modelBuilder.Entity<VigilanciaMedica>(entity =>
		{
			entity.HasKey(e => e.VigilanciaMedicaId).HasName("PK__Vigilanc__7C44AA214E17EE5B");

			entity.ToTable("VigilanciaMedica");

			entity.Property(e => e.VigilanciaMedicaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("VigilanciaMedicaID");
			entity.Property(e => e.CreateAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.DeleteAt).HasColumnType("datetime");
			entity.Property(e => e.DolorIntensidad)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.DolorLocalizacion)
				.HasMaxLength(5)
				.IsUnicode(false);
			entity.Property(e => e.DuracionContracciones)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.FrecuenciaCardiacaFetal)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.FrecuenciaContraciones)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.IsDelete).HasColumnName("isDelete");
			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.PosicionMaterna)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.PresionArterial)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.PulsoMaterno)
				.HasMaxLength(20)
				.IsUnicode(false);
			entity.Property(e => e.Tiempo).HasColumnType("datetime");
			entity.Property(e => e.UpdateAt).HasColumnType("datetime");

			entity.HasOne(d => d.Partograma).WithMany(p => p.VigilanciaMedicas)
				.HasForeignKey(d => d.PartogramaId)
				.HasConstraintName("FK__Vigilanci__Parto__628FA481");
		});

		modelBuilder.Entity<VigilanciaMedicaHistorico>(entity =>
		{
			entity.HasKey(e => e.HistoricoId).HasName("PK__Vigilanc__4A561D766DAC597B");

			entity.ToTable("VigilanciaMedica_Historico");

			entity.Property(e => e.HistoricoId).HasColumnName("HistoricoID");
			entity.Property(e => e.Accion)
				.HasMaxLength(15)
				.IsUnicode(false);
			entity.Property(e => e.DolorIntensidad)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.DolorLocalizacion)
				.HasMaxLength(6)
				.IsUnicode(false);
			entity.Property(e => e.DuracionContracciones)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
			entity.Property(e => e.FrecuenciaCardiacaFetal)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.FrecuenciaContraciones)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.PosicionMaterna)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.PresionArterial)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.PulsoMaterno)
				.HasMaxLength(25)
				.IsUnicode(false);
			entity.Property(e => e.Tiempo).HasColumnType("datetime");
			entity.Property(e => e.VigilanciaMedicaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("VigilanciaMedicaID");
		});

		modelBuilder.Entity<Vpp>(entity =>
		{
			entity.HasKey(e => e.VppId).HasName("PK__Vpps__086F0E45231B0BD8");

			entity.Property(e => e.VppId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("VppID");
			entity.Property(e => e.CreateAt)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.DeleteAt).HasColumnType("datetime");
			entity.Property(e => e.IsDelete).HasColumnName("isDelete");
			entity.Property(e => e.PartogramaId)
				.HasMaxLength(15)
				.IsUnicode(false)
				.HasColumnName("PartogramaID");
			entity.Property(e => e.PlanoHodge)
				.HasMaxLength(5)
				.IsUnicode(false);
			entity.Property(e => e.Posicion)
				.HasMaxLength(15)
				.IsUnicode(false);
			entity.Property(e => e.Tiempo).HasColumnType("datetime");
			entity.Property(e => e.UpdateAt).HasColumnType("datetime");

			entity.HasOne(d => d.Partograma).WithMany(p => p.Vpps)
				.HasForeignKey(d => d.PartogramaId)
				.HasConstraintName("FK__Vpps__Partograma__6C190EBB");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}