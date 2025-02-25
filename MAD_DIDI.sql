USE [master]
GO
/****** Object:  Database [MAD]    Script Date: 13/06/2023 08:29:54 p. m. ******/
CREATE DATABASE [MAD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MAD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MAD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MAD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MAD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MAD] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MAD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MAD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MAD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MAD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MAD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MAD] SET ARITHABORT OFF 
GO
ALTER DATABASE [MAD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MAD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MAD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MAD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MAD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MAD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MAD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MAD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MAD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MAD] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MAD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MAD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MAD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MAD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MAD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MAD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MAD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MAD] SET RECOVERY FULL 
GO
ALTER DATABASE [MAD] SET  MULTI_USER 
GO
ALTER DATABASE [MAD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MAD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MAD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MAD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MAD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MAD] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MAD', N'ON'
GO
ALTER DATABASE [MAD] SET QUERY_STORE = ON
GO
ALTER DATABASE [MAD] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MAD]
GO
/****** Object:  Table [dbo].[Cancelaciones]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cancelaciones](
	[CancelacionID] [int] IDENTITY(1,1) NOT NULL,
	[ReservacionID] [varchar](255) NULL,
	[FechaCancelacion] [date] NULL,
	[HoraCancelacion] [time](7) NULL,
	[UsuarioOperativo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CancelacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[apellidos] [varchar](100) NULL,
	[nombre] [varchar](100) NULL,
	[domicilioCompleto] [varchar](200) NULL,
	[rfc] [varchar](13) NULL,
	[correoElectronico] [varchar](100) NULL,
	[telefonoCasa] [varchar](20) NULL,
	[telefonoCelular] [varchar](20) NULL,
	[referenciaHotel] [varchar](200) NULL,
	[fechaNacimiento] [date] NULL,
	[estadoCivil] [varchar](20) NULL,
	[fecha] [date] NULL,
	[hora] [time](7) NULL,
	[UsuarioID] [int] NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Habitacion]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Habitacion](
	[NumeroHabitacion] [int] IDENTITY(1,1) NOT NULL,
	[TipoHabitacionID] [varchar](255) NULL,
	[Estado] [bit] NULL,
	[HotelID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[NumeroHabitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[HotelID] [int] IDENTITY(1,1) NOT NULL,
	[NombreHotel] [varchar](255) NULL,
	[Ciudad] [varchar](255) NULL,
	[Estado] [varchar](255) NULL,
	[Pais] [varchar](255) NULL,
	[Domicilio] [varchar](255) NULL,
	[NumeroPisos] [int] NULL,
	[FechaRegistroHotel] [date] NULL,
	[FechaInicioOperaciones] [date] NULL,
	[HoraRegistroHotel] [time](7) NULL,
	[EstadoHotel] [bit] NULL,
	[UsuarioOperativo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[idPago] [int] NOT NULL,
	[ReservacionID] [varchar](255) NULL,
	[idCliente] [int] NULL,
	[tipoPago] [varchar](255) NULL,
	[Concepto] [varchar](255) NULL,
	[monto] [decimal](10, 2) NULL,
	[fecha] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[idPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rel_ReservacionServicios]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rel_ReservacionServicios](
	[ServiciosAdicionalesID] [int] IDENTITY(1,1) NOT NULL,
	[ServicioID] [int] NULL,
	[ReservacionID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservacion]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservacion](
	[ReservacionID] [varchar](255) NOT NULL,
	[ServicioID] [int] NULL,
	[ClienteID] [int] NULL,
	[HotelID] [int] NULL,
	[HabitacionID] [int] NULL,
	[FechaEntrada] [date] NULL,
	[FechaSalida] [date] NULL,
	[Anticipo] [decimal](10, 2) NULL,
	[UsuarioOperativo] [int] NULL,
	[Fecha] [date] NULL,
	[Hora] [time](7) NULL,
	[CantidadHabitaciones] [int] NULL,
	[CantidadPersonasHabitacion] [int] NULL,
	[Estado] [varchar](255) NULL,
	[DuracionExtendida] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReservacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiciosAdicionales]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiciosAdicionales](
	[ServicioID] [int] IDENTITY(1,1) NOT NULL,
	[HotelID] [int] NULL,
	[NombreServicio] [varchar](255) NULL,
	[PrecioServicio] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ServicioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposHabitacion]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposHabitacion](
	[TipoHabitacionID] [varchar](255) NOT NULL,
	[HotelID] [int] NULL,
	[PrecioNochePersona] [decimal](10, 2) NULL,
	[CapacidadMaxima] [int] NULL,
	[NumeroCamas] [int] NULL,
	[TiposCama] [varchar](255) NULL,
	[NivelHabitacion] [int] NULL,
	[UsuarioOperativo] [int] NULL,
	[Fecha] [date] NULL,
	[Hora] [time](7) NULL,
	[EstadoTiposHabitacion] [bit] NULL,
	[CantidadHabitaciones] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoHabitacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[tipoUs] [varchar](255) NULL,
	[CorreoElectronico] [varchar](255) NOT NULL,
	[Contrasena] [varchar](255) NULL,
	[NombreCompleto] [varchar](255) NULL,
	[NumeroNomina] [varchar](255) NULL,
	[FechaNacimiento] [varchar](255) NULL,
	[Domicilio] [varchar](255) NULL,
	[TelefonoCasa] [varchar](20) NULL,
	[TelefonoCelular] [varchar](20) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cancelaciones] ADD  DEFAULT (getdate()) FOR [FechaCancelacion]
GO
ALTER TABLE [dbo].[Cancelaciones] ADD  DEFAULT (getdate()) FOR [HoraCancelacion]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT (getdate()) FOR [fecha]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT (getdate()) FOR [hora]
GO
ALTER TABLE [dbo].[Habitacion] ADD  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Hotel] ADD  DEFAULT (getdate()) FOR [FechaRegistroHotel]
GO
ALTER TABLE [dbo].[Hotel] ADD  DEFAULT (getdate()) FOR [HoraRegistroHotel]
GO
ALTER TABLE [dbo].[Hotel] ADD  DEFAULT ((1)) FOR [EstadoHotel]
GO
ALTER TABLE [dbo].[Reservacion] ADD  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[Reservacion] ADD  DEFAULT (getdate()) FOR [Hora]
GO
ALTER TABLE [dbo].[TiposHabitacion] ADD  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[TiposHabitacion] ADD  DEFAULT (getdate()) FOR [Hora]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Cancelaciones]  WITH CHECK ADD FOREIGN KEY([ReservacionID])
REFERENCES [dbo].[Reservacion] ([ReservacionID])
GO
ALTER TABLE [dbo].[Cancelaciones]  WITH CHECK ADD FOREIGN KEY([UsuarioOperativo])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Habitacion]  WITH CHECK ADD FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotel] ([HotelID])
GO
ALTER TABLE [dbo].[Habitacion]  WITH CHECK ADD FOREIGN KEY([TipoHabitacionID])
REFERENCES [dbo].[TiposHabitacion] ([TipoHabitacionID])
GO
ALTER TABLE [dbo].[Hotel]  WITH CHECK ADD FOREIGN KEY([UsuarioOperativo])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD FOREIGN KEY([ReservacionID])
REFERENCES [dbo].[Reservacion] ([ReservacionID])
GO
ALTER TABLE [dbo].[Reservacion]  WITH CHECK ADD FOREIGN KEY([ClienteID])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[Reservacion]  WITH CHECK ADD FOREIGN KEY([HabitacionID])
REFERENCES [dbo].[Habitacion] ([NumeroHabitacion])
GO
ALTER TABLE [dbo].[Reservacion]  WITH CHECK ADD FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotel] ([HotelID])
GO
ALTER TABLE [dbo].[Reservacion]  WITH CHECK ADD FOREIGN KEY([ServicioID])
REFERENCES [dbo].[ServiciosAdicionales] ([ServicioID])
GO
ALTER TABLE [dbo].[Reservacion]  WITH CHECK ADD FOREIGN KEY([UsuarioOperativo])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[ServiciosAdicionales]  WITH CHECK ADD FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotel] ([HotelID])
GO
ALTER TABLE [dbo].[TiposHabitacion]  WITH CHECK ADD FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotel] ([HotelID])
GO
ALTER TABLE [dbo].[TiposHabitacion]  WITH CHECK ADD FOREIGN KEY([UsuarioOperativo])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
/****** Object:  StoredProcedure [dbo].[GenerarHabitaciones]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GenerarHabitaciones]
  @TipoHabitacionID VARCHAR(255),
  @CantidadHabitaciones INT
AS
BEGIN
  DECLARE @I INT = 1;

  -- Insertar registros en la tabla Habitacion según la cantidad indicada
  WHILE @I <= @CantidadHabitaciones
  BEGIN
    INSERT INTO Habitacion (TipoHabitacionID, Estado, HotelID)
    VALUES (@TipoHabitacionID, 1, (SELECT HotelID FROM TiposHabitacion WHERE TipoHabitacionID = @TipoHabitacionID));

    SET @I = @I + 1;
  END;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarHotelesPorCiudad]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_BuscarHotelesPorCiudad]
    @Ciudad VARCHAR(255)
AS
BEGIN
    SELECT NombreHotel FROM Hotel
     WHERE Ciudad = @Ciudad;
END
GO
/****** Object:  StoredProcedure [dbo].[spBuscarCliente]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spBuscarCliente]
(
    @Busqueda VARCHAR(255),
    @OpcionBusqueda INT
)
AS
BEGIN
    SET @Busqueda = '%' + @Busqueda + '%';

    IF @OpcionBusqueda = 1
    BEGIN
        -- Buscar por apellidos (sin tener en cuenta los acentos)
        SELECT apellidos, nombre, correoElectronico, rfc
        FROM Cliente
        WHERE apellidos COLLATE Latin1_General_CI_AI LIKE @Busqueda COLLATE Latin1_General_CI_AI
        ORDER BY apellidos;
    END;
    ELSE IF @OpcionBusqueda = 2
    BEGIN
        -- Buscar por correo electrónico (sin tener en cuenta los acentos)
        SELECT apellidos, nombre, correoElectronico, rfc
        FROM Cliente
        WHERE correoElectronico COLLATE Latin1_General_CI_AI LIKE @Busqueda COLLATE Latin1_General_CI_AI
        ORDER BY correoElectronico;
    END;
    ELSE IF @OpcionBusqueda = 3
    BEGIN
        -- Buscar por RFC (sin tener en cuenta los acentos)
        SELECT apellidos, nombre, correoElectronico, rfc
        FROM Cliente
        WHERE rfc COLLATE Latin1_General_CI_AI LIKE @Busqueda COLLATE Latin1_General_CI_AI
        ORDER BY rfc;
    END;
    ELSE
    BEGIN
        -- Opción de búsqueda inválida
        SELECT 'Opción de búsqueda inválida' AS Mensaje;
    END;
END;

EXEC spBuscarCliente 'o', 1;
GO
/****** Object:  StoredProcedure [dbo].[spGestionarCliente]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGestionarCliente]
(
    @apellidos VARCHAR(100),
    @nombre VARCHAR(100),
    @domicilioCompleto VARCHAR(200),
    @rfc VARCHAR(13),
    @correoElectronico VARCHAR(100),
    @telefonoCasa VARCHAR(20),
    @telefonoCelular VARCHAR(20),
    @referenciaHotel VARCHAR(200),
    @fechaNacimiento DATE,
    @estadoCivil VARCHAR(20), 

    @Accion VARCHAR(1) -- Se agrega el parámetro @Accion que parece estar faltando
)
AS
BEGIN
    IF @Accion = 'C'
    BEGIN
        -- Insertar el nuevo cliente
        INSERT INTO Cliente (apellidos, nombre, domicilioCompleto, rfc, correoElectronico, telefonoCasa, telefonoCelular, referenciaHotel, fechaNacimiento, estadoCivil )
        VALUES (@apellidos, @nombre, @domicilioCompleto, @rfc, @correoElectronico, @telefonoCasa, @telefonoCelular, @referenciaHotel, @fechaNacimiento, @estadoCivil);

        SELECT 'Cliente creado exitosamente.' AS Mensaje;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[spGestionarHotel]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGestionarHotel]
(
    @nombreHotel VARCHAR(255),
    @ciudad VARCHAR(255),
    @estado VARCHAR(255),
    @pais VARCHAR(255),
    @domicilio VARCHAR(255),
    @numeroPisos INT,
	@FechaInicioOperaciones date,

    @accion VARCHAR(1)
)
AS
BEGIN
    IF @accion = 'C'
    BEGIN
        -- Insertar un nuevo hotel
        INSERT INTO Hotel (NombreHotel, Ciudad, Estado, Pais, Domicilio, NumeroPisos, FechaInicioOperaciones)
        VALUES (@nombreHotel, @ciudad, @estado, @pais, @domicilio, @numeroPisos, @FechaInicioOperaciones);

        SELECT 'Hotel creado exitosamente.' AS Mensaje;
    END

END;

GO
/****** Object:  StoredProcedure [dbo].[spGestionarTipoHabitacion]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGestionarTipoHabitacion]
(
    @tipoHabitacionID VARCHAR(255),
    @hotelID INT,
    @precioNochePersona DECIMAL(10, 2),
    @capacidadMaxima INT,
    @numeroCamas INT,
    @tiposCama VARCHAR(255),
    @nivelHabitacion INT,
    @cantidadHabitaciones INT,
    @accion VARCHAR(1)
)
AS
BEGIN
    IF @accion = 'C'
    BEGIN
        -- Insertar un nuevo tipo de habitación
        INSERT INTO TiposHabitacion (TipoHabitacionID, HotelID, PrecioNochePersona, CapacidadMaxima, NumeroCamas, TiposCama, NivelHabitacion,  CantidadHabitaciones)
        VALUES (@tipoHabitacionID, @hotelID, @precioNochePersona, @capacidadMaxima, @numeroCamas, @tiposCama, @nivelHabitacion,  @cantidadHabitaciones);

        SELECT 'Tipo de habitación creado exitosamente.' AS Mensaje;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[spMostrarCiudades]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spMostrarCiudades]
AS
BEGIN
    SELECT Ciudad
    FROM Hotel;
END;
GO
/****** Object:  StoredProcedure [dbo].[spMostrarHoteles]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spMostrarHoteles]

AS
BEGIN
    SELECT NombreHotel
    FROM Hotel;
END;
GO
/****** Object:  StoredProcedure [dbo].[spObtenerHabitacionesDisponibles]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spObtenerHabitacionesDisponibles]
(
  @HotelID INT,
  @FechaSeleccionada DATE
)
AS
BEGIN

  -- Obtener las habitaciones disponibles para el hotel seleccionado en la fecha especificada
  SELECT h.NumeroHabitacion, th.TipoHabitacionID, th.PrecioNochePersona, th.CapacidadMaxima, th.NumeroCamas, th.TiposCama
  FROM Habitacion h
  INNER JOIN TiposHabitacion th ON h.TipoHabitacionID = th.TipoHabitacionID
  LEFT JOIN Reservacion r ON h.NumeroHabitacion = r.HabitacionID
  WHERE h.HotelID = @HotelID
    AND h.Estado = 1 -- Habitación disponible
    AND (r.ReservacionID IS NULL OR r.FechaSalida < @FechaSeleccionada);

END;
GO
/****** Object:  StoredProcedure [dbo].[spObtenerHotelIDPorNombre]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spObtenerHotelIDPorNombre]
(
    @nombreHotel VARCHAR(255)
)
AS
BEGIN
    SELECT HotelID
    FROM Hotel
    WHERE NombreHotel = @nombreHotel;
END;
GO
/****** Object:  StoredProcedure [dbo].[spRegistrarServicioAdicional]    Script Date: 13/06/2023 08:29:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRegistrarServicioAdicional]
(
    @hotelID INT,
    @nombreServicio VARCHAR(255),
    @precioServicio DECIMAL(10, 2)
)
AS
BEGIN
    -- Insertar un nuevo servicio adicional para el hotel
    INSERT INTO ServiciosAdicionales (HotelID, NombreServicio, PrecioServicio)
    VALUES (@hotelID, @nombreServicio, @precioServicio);

    SELECT 'Servicio adicional registrado exitosamente.' AS Mensaje;
END;
GO
USE [master]
GO
ALTER DATABASE [MAD] SET  READ_WRITE 
GO
