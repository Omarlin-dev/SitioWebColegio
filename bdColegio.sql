USE [master]
GO
/****** Object:  Database [DBColegio]    Script Date: 17/10/2021 5:34:40 p. m. ******/
CREATE DATABASE [DBColegio]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBColegio', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBColegio.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBColegio_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBColegio_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DBColegio] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBColegio].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBColegio] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBColegio] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBColegio] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBColegio] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBColegio] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBColegio] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBColegio] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBColegio] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBColegio] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBColegio] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBColegio] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBColegio] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBColegio] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBColegio] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBColegio] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBColegio] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBColegio] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBColegio] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBColegio] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBColegio] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBColegio] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBColegio] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBColegio] SET RECOVERY FULL 
GO
ALTER DATABASE [DBColegio] SET  MULTI_USER 
GO
ALTER DATABASE [DBColegio] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBColegio] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBColegio] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBColegio] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBColegio] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBColegio] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBColegio', N'ON'
GO
ALTER DATABASE [DBColegio] SET QUERY_STORE = OFF
GO
USE [DBColegio]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 17/10/2021 5:34:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[idAdmin] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NULL,
	[nombreusuario] [varchar](50) NOT NULL,
	[clave] [varchar](50) NOT NULL,
	[idRol] [int] NULL,
 CONSTRAINT [PK_Administrador] PRIMARY KEY CLUSTERED 
(
	[idAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 17/10/2021 5:34:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[idAlumno] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NULL,
	[telefono] [nchar](10) NOT NULL,
	[nombreUsuario] [varchar](50) NOT NULL,
	[clave] [varchar](50) NOT NULL,
	[estado] [bit] NULL,
	[idRol] [int] NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[idAlumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asignatura]    Script Date: 17/10/2021 5:34:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignatura](
	[idAsignatura] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[idProfesor] [int] NOT NULL,
 CONSTRAINT [PK_Asignatura] PRIMARY KEY CLUSTERED 
(
	[idAsignatura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asignatura_Alumno]    Script Date: 17/10/2021 5:34:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignatura_Alumno](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idAsignatura] [int] NOT NULL,
	[idAlumno] [int] NOT NULL,
 CONSTRAINT [PK_Asignatura_Alumno] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 17/10/2021 5:34:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[idProfesor] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NULL,
	[nombreUsuario] [varchar](50) NOT NULL,
	[clave] [varchar](50) NOT NULL,
	[especialidad] [varchar](50) NOT NULL,
	[estado] [bit] NULL,
	[idRol] [int] NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[idProfesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol_Operacion]    Script Date: 17/10/2021 5:34:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol_Operacion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idRol] [int] NULL,
	[idOperacion] [int] NULL,
 CONSTRAINT [PK_Rol_Operacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Administrador]  WITH CHECK ADD  CONSTRAINT [FK_Administrador_Rol_Operacion] FOREIGN KEY([idRol])
REFERENCES [dbo].[Rol_Operacion] ([id])
GO
ALTER TABLE [dbo].[Administrador] CHECK CONSTRAINT [FK_Administrador_Rol_Operacion]
GO
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_Rol_Operacion] FOREIGN KEY([idRol])
REFERENCES [dbo].[Rol_Operacion] ([id])
GO
ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK_Alumno_Rol_Operacion]
GO
ALTER TABLE [dbo].[Asignatura]  WITH CHECK ADD  CONSTRAINT [FK_Asignatura_Profesor] FOREIGN KEY([idProfesor])
REFERENCES [dbo].[Profesor] ([idProfesor])
GO
ALTER TABLE [dbo].[Asignatura] CHECK CONSTRAINT [FK_Asignatura_Profesor]
GO
ALTER TABLE [dbo].[Asignatura_Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Asignatura_Alumno_Alumno] FOREIGN KEY([idAlumno])
REFERENCES [dbo].[Alumno] ([idAlumno])
GO
ALTER TABLE [dbo].[Asignatura_Alumno] CHECK CONSTRAINT [FK_Asignatura_Alumno_Alumno]
GO
ALTER TABLE [dbo].[Asignatura_Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Asignatura_Alumno_Asignatura] FOREIGN KEY([idAsignatura])
REFERENCES [dbo].[Asignatura] ([idAsignatura])
GO
ALTER TABLE [dbo].[Asignatura_Alumno] CHECK CONSTRAINT [FK_Asignatura_Alumno_Asignatura]
GO
ALTER TABLE [dbo].[Profesor]  WITH CHECK ADD  CONSTRAINT [FK_Profesor_Rol_Operacion] FOREIGN KEY([idRol])
REFERENCES [dbo].[Rol_Operacion] ([id])
GO
ALTER TABLE [dbo].[Profesor] CHECK CONSTRAINT [FK_Profesor_Rol_Operacion]
GO
USE [master]
GO
ALTER DATABASE [DBColegio] SET  READ_WRITE 
GO
