using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirthflowMicroServices.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanosHodge",
                 columns: table => new
                 {
                     PlanoHodgeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                     Descripcion = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                     Valor = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                     CreateAt = table.Column<DateTime>(type: "datetime", nullable: true)
                 },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PlanoHodge__4A561D7649310E4F", x => x.PlanoHodgeID);
                });

            migrationBuilder.CreateTable(
                name: "PosicionesFetales",
                 columns: table => new
                 {
                     PosicionFetalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                     Descripcion = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                     Valor = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                     CreateAt = table.Column<DateTime>(type: "datetime", nullable: true)
                 },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PosicionFetal__4A561D7649310E4F", x => x.PosicionFetalID);
                });

            migrationBuilder.CreateTable(
                name: "DilatacionesCervicales_Historico",
                columns: table => new
                {
                    HistoricoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DilatacionCervicalID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    Hora = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemORam = table.Column<bool>(type: "bit", nullable: true),
                    Accion = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Dilataci__4A561D7649310E4F", x => x.HistoricoID);
                });

            migrationBuilder.CreateTable(
                name: "FrecuenciaCardiacaFetal_Historico",
                columns: table => new
                {
                    HistoricoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrecuenciaCardiacaFetalID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Valor = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Tiempo = table.Column<DateTime>(type: "datetime", nullable: true),
                    Accion = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Frecuenc__4A561D76C42EB14B", x => x.HistoricoID);
                });

            migrationBuilder.CreateTable(
                name: "FrecuenciaContraciones_Historico",
                columns: table => new
                {
                    HistoricoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrecuenciaContracionesID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Valor = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Tiempo = table.Column<DateTime>(type: "datetime", nullable: true),
                    Accion = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Frecuenc__4A561D7653F0F353", x => x.HistoricoID);
                });

            migrationBuilder.CreateTable(
                name: "NotaParto_Historico",
                columns: table => new
                {
                    HistoricoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Hora = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Sexo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Apgar = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Temperatura = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Caputto = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Circular = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    LAmniotico = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Miccion = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Meconio = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    PA = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Expulsivo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Placenta = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Alumbramiento = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    HuellaPlantar = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Accion = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotaPart__4A561D76E059B619", x => x.HistoricoID);
                });

            migrationBuilder.CreateTable(
                name: "Observaciones_Historico",
                columns: table => new
                {
                    HistoricoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VigilanciaMedicaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Header = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Accion = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Observac__4A561D76B6D4C7C9", x => x.HistoricoID);
                });

            migrationBuilder.CreateTable(
                name: "Partogramas_Historico",
                columns: table => new
                {
                    HistoricoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Expediente = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Accion = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Partogra__4A561D766D6EF489", x => x.HistoricoID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__F92302D138488F7D", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "TiempoTrabajosHistoricos",
                columns: table => new
                {
                    HistoricoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Posicion = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Paridad = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Membranas = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Accion = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TiempoTr__4A561D76A74D7F05", x => x.HistoricoID);
                });

            migrationBuilder.CreateTable(
                name: "TipoCambio",
                columns: table => new
                {
                    TipoCambioID = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoCamb__A510D87FCBE65E7E", x => x.TipoCambioID);
                });

            migrationBuilder.CreateTable(
                name: "TipoNotificaciones",
                columns: table => new
                {
                    TipoNotificacionesID = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoNoti__8AE962E24B543620", x => x.TipoNotificacionesID);
                });

            migrationBuilder.CreateTable(
                name: "TipoPermisos",
                columns: table => new
                {
                    TipoPermisoID = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoPerm__6A7B92F2B33666B3", x => x.TipoPermisoID);
                });

            migrationBuilder.CreateTable(
                name: "TipoPermisosRol",
                columns: table => new
                {
                    TipoPermisoRolID = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoPerm__92DF0B773ABB90E1", x => x.TipoPermisoRolID);
                });

            migrationBuilder.CreateTable(
                name: "VigilanciaMedica_Historico",
                columns: table => new
                {
                    HistoricoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VigilanciaMedicaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    PosicionMaterna = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    PresionArterial = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    PulsoMaterno = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    FrecuenciaCardiacaFetal = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    DuracionContracciones = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    FrecuenciaContraciones = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    DolorIntensidad = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    DolorLocalizacion = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    Tiempo = table.Column<DateTime>(type: "datetime", nullable: true),
                    Accion = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vigilanc__4A561D766DAC597B", x => x.HistoricoID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombres = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Apellidos = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NombreUsuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<decimal>(type: "decimal(8,0)", nullable: true),
                    RolID = table.Column<int>(type: "int", nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__2B3DE79832BF79ED", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK__Usuarios__RolID__398D8EEE",
                        column: x => x.RolID,
                        principalTable: "Roles",
                        principalColumn: "RolID");
                });

            migrationBuilder.CreateTable(
                name: "Configuraciones",
                columns: table => new
                {
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermisoNotificacion = table.Column<bool>(type: "bit", nullable: true),
                    PermisoVibracion = table.Column<bool>(type: "bit", nullable: true),
                    Lenguaje = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Configur__2B3DE7981A907EFD", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK__Configura__Usuar__4222D4EF",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateTable(
                name: "Notificationes",
                columns: table => new
                {
                    NotificacionID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NotificationTypeID = table.Column<byte>(type: "tinyint", nullable: true),
                    Leido = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__BCC120C41D39179E", x => x.NotificacionID);
                    table.ForeignKey(
                        name: "FK__Notificat__Notif__01142BA1",
                        column: x => x.NotificationTypeID,
                        principalTable: "TipoNotificaciones",
                        principalColumn: "TipoNotificacionesID");
                    table.ForeignKey(
                        name: "FK__Notificat__Usuar__00200768",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateTable(
                name: "Partogramas",
                columns: table => new
                {
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Expediente = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Partogra__2A6C3913CC5F9652", x => x.PartogramaID);
                    table.ForeignKey(
                        name: "FK__Partogram__Usuar__45F365D3",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateTable(
                name: "Passwords",
                columns: table => new
                {
                    PasswordID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(64)", maxLength: 64, nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(16)", maxLength: 16, nullable: true),
                    PassActual = table.Column<bool>(type: "bit", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Password__EA7BF0E814DA0B01", x => x.PasswordID);
                    table.ForeignKey(
                        name: "FK__Passwords__Usuar__3E52440B",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateTable(
                name: "DilatacionesCervicales",
                columns: table => new
                {
                    DilatacionCervicalID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Hora = table.Column<DateTime>(type: "datetime", nullable: false),
                    RemORam = table.Column<bool>(type: "bit", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Dilataci__AF44EEABDFE91BA7", x => x.DilatacionCervicalID);
                    table.ForeignKey(
                        name: "FK__Dilatacio__Parto__5DCAEF64",
                        column: x => x.PartogramaID,
                        principalTable: "Partogramas",
                        principalColumn: "PartogramaID");
                });

            migrationBuilder.CreateTable(
                name: "FrecuenciaCardiacaFetal",
                columns: table => new
                {
                    FrecuenciaCardiacaFetalID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Valor = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Tiempo = table.Column<DateTime>(type: "datetime", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Frecuenc__10979C37346E864D", x => x.FrecuenciaCardiacaFetalID);
                    table.ForeignKey(
                        name: "FK__Frecuenci__Parto__70DDC3D8",
                        column: x => x.PartogramaID,
                        principalTable: "Partogramas",
                        principalColumn: "PartogramaID");
                });

            migrationBuilder.CreateTable(
                name: "FrecuenciaContraciones",
                columns: table => new
                {
                    FrecuenciaContracionesID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Valor = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Tiempo = table.Column<DateTime>(type: "datetime", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Frecuenc__1B45F4EDD79E165B", x => x.FrecuenciaContracionesID);
                    table.ForeignKey(
                        name: "FK__Frecuenci__Parto__75A278F5",
                        column: x => x.PartogramaID,
                        principalTable: "Partogramas",
                        principalColumn: "PartogramaID");
                });

            migrationBuilder.CreateTable(
                name: "NotaParto",
                columns: table => new
                {
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Hora = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Sexo = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Apgar = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Temperatura = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Caputto = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Circular = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    LAmniotico = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Miccion = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Meconio = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    PA = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Expulsivo = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Placenta = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Alumbramiento = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    HuellaPlantar = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotaPart__2A6C391348ED606B", x => x.PartogramaID);
                    table.ForeignKey(
                        name: "FK__NotaParto__Parto__7A672E12",
                        column: x => x.PartogramaID,
                        principalTable: "Partogramas",
                        principalColumn: "PartogramaID");
                });

            migrationBuilder.CreateTable(
                name: "NotificationPartograma",
                columns: table => new
                {
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NotificacionID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Notificat__Notif__05D8E0BE",
                        column: x => x.NotificacionID,
                        principalTable: "Notificationes",
                        principalColumn: "NotificacionID");
                    table.ForeignKey(
                        name: "FK__Notificat__Parto__03F0984C",
                        column: x => x.PartogramaID,
                        principalTable: "Partogramas",
                        principalColumn: "PartogramaID");
                    table.ForeignKey(
                        name: "FK__Notificat__Usuar__04E4BC85",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateTable(
                name: "PartogramaEstado",
                columns: table => new
                {
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Archivado = table.Column<bool>(type: "bit", nullable: false),
                    Silenciado = table.Column<bool>(type: "bit", nullable: false),
                    Permanente = table.Column<bool>(type: "bit", nullable: false),
                    UltimaModificacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DilatacionCervicalesNotificacion = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PlanoHodgeNotificacion = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    VigilanciaMedicaNotificacion = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    FCFYDCNotificacion = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    TipoPermisoID = table.Column<byte>(type: "tinyint", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Partogra__2A6C391353C62D84", x => x.PartogramaID);
                    table.ForeignKey(
                        name: "FK__Partogram__Parto__5165187F",
                        column: x => x.PartogramaID,
                        principalTable: "Partogramas",
                        principalColumn: "PartogramaID");
                    table.ForeignKey(
                        name: "FK__Partogram__TipoP__59FA5E80",
                        column: x => x.TipoPermisoID,
                        principalTable: "TipoPermisos",
                        principalColumn: "TipoPermisoID");
                });

            migrationBuilder.CreateTable(
                name: "PartogramaHistorialCambios",
                columns: table => new
                {
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TipoCambioID = table.Column<byte>(type: "tinyint", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Partogram__Parto__1332DBDC",
                        column: x => x.PartogramaID,
                        principalTable: "Partogramas",
                        principalColumn: "PartogramaID");
                    table.ForeignKey(
                        name: "FK__Partogram__TipoC__151B244E",
                        column: x => x.TipoCambioID,
                        principalTable: "TipoCambio",
                        principalColumn: "TipoCambioID");
                    table.ForeignKey(
                        name: "FK__Partogram__Usuar__14270015",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateTable(
                name: "PartogramaPermisos",
                columns: table => new
                {
                    PermisoPartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RolID = table.Column<int>(type: "int", nullable: true),
                    TipoPermisoRolID = table.Column<byte>(type: "tinyint", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Partogra__CAF60972E381D3F8", x => x.PermisoPartogramaID);
                    table.ForeignKey(
                        name: "FK__Partogram__Parto__0B91BA14",
                        column: x => x.PartogramaID,
                        principalTable: "Partogramas",
                        principalColumn: "PartogramaID");
                    table.ForeignKey(
                        name: "FK__Partogram__RolID__0D7A0286",
                        column: x => x.RolID,
                        principalTable: "Roles",
                        principalColumn: "RolID");
                    table.ForeignKey(
                        name: "FK__Partogram__TipoP__0E6E26BF",
                        column: x => x.TipoPermisoRolID,
                        principalTable: "TipoPermisosRol",
                        principalColumn: "TipoPermisoRolID");
                    table.ForeignKey(
                        name: "FK__Partogram__Usuar__0C85DE4D",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateTable(
                name: "TiempoTrabajos",
                columns: table => new
                {
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Posicion = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Paridad = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Membranas = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TiempoTr__2A6C3913842FB72A", x => x.PartogramaID);
                    table.ForeignKey(
                        name: "FK__TiempoTra__Parto__4AB81AF0",
                        column: x => x.PartogramaID,
                        principalTable: "Partogramas",
                        principalColumn: "PartogramaID");
                });

            migrationBuilder.CreateTable(
                name: "VigilanciaMedica",
                columns: table => new
                {
                    VigilanciaMedicaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    PosicionMaterna = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    PresionArterial = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    PulsoMaterno = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    FrecuenciaCardiacaFetal = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DuracionContracciones = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    FrecuenciaContraciones = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DolorIntensidad = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DolorLocalizacion = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Tiempo = table.Column<DateTime>(type: "datetime", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vigilanc__7C44AA214E17EE5B", x => x.VigilanciaMedicaID);
                    table.ForeignKey(
                        name: "FK__Vigilanci__Parto__628FA481",
                        column: x => x.PartogramaID,
                        principalTable: "Partogramas",
                        principalColumn: "PartogramaID");
                });

            migrationBuilder.CreateTable(
                name: "Vpps",
                columns: table => new
                {
                    VppID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    PartogramaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    PlanoHodgeID = table.Column<int>(type: "int", unicode: false, nullable: false),
                    PosicionFetalID = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Tiempo = table.Column<DateTime>(type: "datetime", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vpps__086F0E45231B0BD8", x => x.VppID);
                    table.ForeignKey(
                        name: "FK__Vpps__Partograma__6C190EBB",
                        column: x => x.PartogramaID,
                        principalTable: "Partogramas",
                        principalColumn: "PartogramaID");
                    table.ForeignKey(
                        name: "FK_Vpps_PlanosHodge_PlanoHodgeID",
                        column: x => x.PlanoHodgeID,
                        principalTable: "PlanosHodge",
                        principalColumn: "PlanoHodgeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vpps_PosicionesFetal_PosicionFetalID",
                        column: x => x.PosicionFetalID,
                        principalTable: "PosicionesFetales",
                        principalColumn: "PosicionFetalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Observaciones",
                columns: table => new
                {
                    VigilanciaMedicaID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Header = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Observac__7C44AA21ECA9F18E", x => x.VigilanciaMedicaID);
                    table.ForeignKey(
                        name: "FK__Observaci__Vigil__6754599E",
                        column: x => x.VigilanciaMedicaID,
                        principalTable: "VigilanciaMedica",
                        principalColumn: "VigilanciaMedicaID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DilatacionesCervicales_PartogramaID",
                table: "DilatacionesCervicales",
                column: "PartogramaID");

            migrationBuilder.CreateIndex(
                name: "IX_FrecuenciaCardiacaFetal_PartogramaID",
                table: "FrecuenciaCardiacaFetal",
                column: "PartogramaID");

            migrationBuilder.CreateIndex(
                name: "IX_FrecuenciaContraciones_PartogramaID",
                table: "FrecuenciaContraciones",
                column: "PartogramaID");

            migrationBuilder.CreateIndex(
                name: "IX_Notificationes_NotificationTypeID",
                table: "Notificationes",
                column: "NotificationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Notificationes_UsuarioID",
                table: "Notificationes",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationPartograma_NotificacionID",
                table: "NotificationPartograma",
                column: "NotificacionID");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationPartograma_PartogramaID",
                table: "NotificationPartograma",
                column: "PartogramaID");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationPartograma_UsuarioID",
                table: "NotificationPartograma",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_PartogramaEstado_TipoPermisoID",
                table: "PartogramaEstado",
                column: "TipoPermisoID");

            migrationBuilder.CreateIndex(
                name: "IX_PartogramaHistorialCambios_PartogramaID",
                table: "PartogramaHistorialCambios",
                column: "PartogramaID");

            migrationBuilder.CreateIndex(
                name: "IX_PartogramaHistorialCambios_TipoCambioID",
                table: "PartogramaHistorialCambios",
                column: "TipoCambioID");

            migrationBuilder.CreateIndex(
                name: "IX_PartogramaHistorialCambios_UsuarioID",
                table: "PartogramaHistorialCambios",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_PartogramaPermisos_PartogramaID",
                table: "PartogramaPermisos",
                column: "PartogramaID");

            migrationBuilder.CreateIndex(
                name: "IX_PartogramaPermisos_RolID",
                table: "PartogramaPermisos",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_PartogramaPermisos_TipoPermisoRolID",
                table: "PartogramaPermisos",
                column: "TipoPermisoRolID");

            migrationBuilder.CreateIndex(
                name: "IX_PartogramaPermisos_UsuarioID",
                table: "PartogramaPermisos",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Partogramas_UsuarioID",
                table: "Partogramas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Passwords_UsuarioID",
                table: "Passwords",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolID",
                table: "Usuarios",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_VigilanciaMedica_PartogramaID",
                table: "VigilanciaMedica",
                column: "PartogramaID");

            migrationBuilder.CreateIndex(
                name: "IX_Vpps_PartogramaID",
                table: "Vpps",
                column: "PartogramaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuraciones");

            migrationBuilder.DropTable(
                name: "DilatacionesCervicales");

            migrationBuilder.DropTable(
                name: "DilatacionesCervicales_Historico");

            migrationBuilder.DropTable(
                name: "FrecuenciaCardiacaFetal");

            migrationBuilder.DropTable(
                name: "FrecuenciaCardiacaFetal_Historico");

            migrationBuilder.DropTable(
                name: "FrecuenciaContraciones");

            migrationBuilder.DropTable(
                name: "FrecuenciaContraciones_Historico");

            migrationBuilder.DropTable(
                name: "NotaParto");

            migrationBuilder.DropTable(
                name: "NotaParto_Historico");

            migrationBuilder.DropTable(
                name: "NotificationPartograma");

            migrationBuilder.DropTable(
                name: "Observaciones");

            migrationBuilder.DropTable(
                name: "Observaciones_Historico");

            migrationBuilder.DropTable(
                name: "PartogramaEstado");

            migrationBuilder.DropTable(
                name: "PartogramaHistorialCambios");

            migrationBuilder.DropTable(
                name: "PartogramaPermisos");

            migrationBuilder.DropTable(
                name: "Partogramas_Historico");

            migrationBuilder.DropTable(
                name: "Passwords");

            migrationBuilder.DropTable(
                name: "TiempoTrabajos");

            migrationBuilder.DropTable(
                name: "TiempoTrabajosHistoricos");

            migrationBuilder.DropTable(
                name: "VigilanciaMedica_Historico");

            migrationBuilder.DropTable(
                name: "Vpps");

            migrationBuilder.DropTable(
                name: "Notificationes");

            migrationBuilder.DropTable(
                name: "VigilanciaMedica");

            migrationBuilder.DropTable(
                name: "TipoPermisos");

            migrationBuilder.DropTable(
                name: "TipoCambio");

            migrationBuilder.DropTable(
                name: "TipoPermisosRol");

            migrationBuilder.DropTable(
                name: "TipoNotificaciones");

            migrationBuilder.DropTable(
                name: "Partogramas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}