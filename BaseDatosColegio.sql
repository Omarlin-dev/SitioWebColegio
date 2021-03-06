USE [master]
GO
/****** Object:  Database [DBColegio]    Script Date: 24/11/2021 5:39:29 p. m. ******/
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
/****** Object:  Table [dbo].[Administrador]    Script Date: 24/11/2021 5:39:30 p. m. ******/
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
/****** Object:  Table [dbo].[Alumno]    Script Date: 24/11/2021 5:39:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[idAlumno] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NULL,
	[telefono] [varchar](50) NOT NULL,
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
/****** Object:  Table [dbo].[Asignatura]    Script Date: 24/11/2021 5:39:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignatura](
	[idAsignatura] [int] IDENTITY(1,1) NOT NULL,
	[idProfesor] [int] NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Asignatura] PRIMARY KEY CLUSTERED 
(
	[idAsignatura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsignaturaAlumno]    Script Date: 24/11/2021 5:39:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsignaturaAlumno](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[idAlumno] [int] NOT NULL,
	[idAsignatura] [int] NOT NULL,
 CONSTRAINT [PK_AsignaturaAlumno] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 24/11/2021 5:39:30 p. m. ******/
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
/****** Object:  Table [dbo].[Rol_Operacion]    Script Date: 24/11/2021 5:39:30 p. m. ******/
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
SET IDENTITY_INSERT [dbo].[Administrador] ON 

INSERT [dbo].[Administrador] ([idAdmin], [nombre], [apellido], [nombreusuario], [clave], [idRol]) VALUES (7, N'omarlin', N'garces rodriguez', N'omarlindev', N'123', 1)
INSERT [dbo].[Administrador] ([idAdmin], [nombre], [apellido], [nombreusuario], [clave], [idRol]) VALUES (8, N'Rosa', N'Torres Rodriguez', N'rosadev', N'123', 1)
SET IDENTITY_INSERT [dbo].[Administrador] OFF
GO
SET IDENTITY_INSERT [dbo].[Alumno] ON 

INSERT [dbo].[Alumno] ([idAlumno], [nombre], [apellido], [telefono], [nombreUsuario], [clave], [estado], [idRol]) VALUES (1, N'Josefina', N'valdez Rodriguez', N'888-999-9999', N'josefinadev', N'123', NULL, 3)
INSERT [dbo].[Alumno] ([idAlumno], [nombre], [apellido], [telefono], [nombreUsuario], [clave], [estado], [idRol]) VALUES (2, N'Andres', N'Vargas', N'555-444-3333', N'andresdev', N'123', 1, 3)
INSERT [dbo].[Alumno] ([idAlumno], [nombre], [apellido], [telefono], [nombreUsuario], [clave], [estado], [idRol]) VALUES (3, N'Victor ', N'Robles Mendez', N'222-888-9999', N'victordev', N'123', NULL, 3)
INSERT [dbo].[Alumno] ([idAlumno], [nombre], [apellido], [telefono], [nombreUsuario], [clave], [estado], [idRol]) VALUES (5, N'Andres', N'Robles', N'222-888-9999', N'andresdev', N'123', NULL, 3)
INSERT [dbo].[Alumno] ([idAlumno], [nombre], [apellido], [telefono], [nombreUsuario], [clave], [estado], [idRol]) VALUES (6, N'Jose', N'Salas', N'222-888-9999', N'josedev', N'123', NULL, 3)
SET IDENTITY_INSERT [dbo].[Alumno] OFF
GO
SET IDENTITY_INSERT [dbo].[Asignatura] ON 

INSERT [dbo].[Asignatura] ([idAsignatura], [idProfesor], [nombre]) VALUES (1, 1, N'Historia')
INSERT [dbo].[Asignatura] ([idAsignatura], [idProfesor], [nombre]) VALUES (2, 1, N'Matematica')
INSERT [dbo].[Asignatura] ([idAsignatura], [idProfesor], [nombre]) VALUES (4, 2, N'Ciencias Sociales')
INSERT [dbo].[Asignatura] ([idAsignatura], [idProfesor], [nombre]) VALUES (6, 2, N'Ciencias Naturales')
INSERT [dbo].[Asignatura] ([idAsignatura], [idProfesor], [nombre]) VALUES (7, 1, N'Lengua Espanola')
INSERT [dbo].[Asignatura] ([idAsignatura], [idProfesor], [nombre]) VALUES (8, 1, N'Electronica')
INSERT [dbo].[Asignatura] ([idAsignatura], [idProfesor], [nombre]) VALUES (9, 4, N'Electricidad')
INSERT [dbo].[Asignatura] ([idAsignatura], [idProfesor], [nombre]) VALUES (11, 4, N'Artes')
INSERT [dbo].[Asignatura] ([idAsignatura], [idProfesor], [nombre]) VALUES (12, 3, N'Ingles')
INSERT [dbo].[Asignatura] ([idAsignatura], [idProfesor], [nombre]) VALUES (13, 1, N'Historia')
INSERT [dbo].[Asignatura] ([idAsignatura], [idProfesor], [nombre]) VALUES (14, 2, N'Etica')
SET IDENTITY_INSERT [dbo].[Asignatura] OFF
GO
SET IDENTITY_INSERT [dbo].[AsignaturaAlumno] ON 

INSERT [dbo].[AsignaturaAlumno] ([Id], [idAlumno], [idAsignatura]) VALUES (9, 5, 4)
INSERT [dbo].[AsignaturaAlumno] ([Id], [idAlumno], [idAsignatura]) VALUES (15, 2, 2)
INSERT [dbo].[AsignaturaAlumno] ([Id], [idAlumno], [idAsignatura]) VALUES (17, 5, 6)
INSERT [dbo].[AsignaturaAlumno] ([Id], [idAlumno], [idAsignatura]) VALUES (19, 5, 4)
INSERT [dbo].[AsignaturaAlumno] ([Id], [idAlumno], [idAsignatura]) VALUES (20, 6, 8)
INSERT [dbo].[AsignaturaAlumno] ([Id], [idAlumno], [idAsignatura]) VALUES (22, 2, 9)
SET IDENTITY_INSERT [dbo].[AsignaturaAlumno] OFF
GO
SET IDENTITY_INSERT [dbo].[Profesor] ON 

INSERT [dbo].[Profesor] ([idProfesor], [nombre], [apellido], [nombreUsuario], [clave], [especialidad], [estado], [idRol]) VALUES (1, N'omarlin', N'rodriguez', N'omarlindev', N'123', N'Matematica', 1, 2)
INSERT [dbo].[Profesor] ([idProfesor], [nombre], [apellido], [nombreUsuario], [clave], [especialidad], [estado], [idRol]) VALUES (2, N'Rosa', N'rodriguez', N'rosadev', N'123', N'Matematica', 1, 2)
INSERT [dbo].[Profesor] ([idProfesor], [nombre], [apellido], [nombreUsuario], [clave], [especialidad], [estado], [idRol]) VALUES (3, N'Julian', N'Mendez', N'julianmendez', N'123', N'Ciencias Naturales', 1, 2)
INSERT [dbo].[Profesor] ([idProfesor], [nombre], [apellido], [nombreUsuario], [clave], [especialidad], [estado], [idRol]) VALUES (4, N'Pedro', N'Rodriguez Torres', N'pedrodev', N'123', N'Materias Básicas', NULL, 2)
SET IDENTITY_INSERT [dbo].[Profesor] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol_Operacion] ON 

INSERT [dbo].[Rol_Operacion] ([id], [idRol], [idOperacion]) VALUES (1, 1, 1)
INSERT [dbo].[Rol_Operacion] ([id], [idRol], [idOperacion]) VALUES (2, 1, 2)
INSERT [dbo].[Rol_Operacion] ([id], [idRol], [idOperacion]) VALUES (3, 1, 3)
INSERT [dbo].[Rol_Operacion] ([id], [idRol], [idOperacion]) VALUES (4, 1, 4)
INSERT [dbo].[Rol_Operacion] ([id], [idRol], [idOperacion]) VALUES (5, 1, 5)
INSERT [dbo].[Rol_Operacion] ([id], [idRol], [idOperacion]) VALUES (6, 2, 6)
INSERT [dbo].[Rol_Operacion] ([id], [idRol], [idOperacion]) VALUES (7, 2, 7)
INSERT [dbo].[Rol_Operacion] ([id], [idRol], [idOperacion]) VALUES (8, 2, 8)
INSERT [dbo].[Rol_Operacion] ([id], [idRol], [idOperacion]) VALUES (9, 2, 9)
INSERT [dbo].[Rol_Operacion] ([id], [idRol], [idOperacion]) VALUES (10, 2, 10)
INSERT [dbo].[Rol_Operacion] ([id], [idRol], [idOperacion]) VALUES (11, 3, 11)
INSERT [dbo].[Rol_Operacion] ([id], [idRol], [idOperacion]) VALUES (12, 3, 12)
INSERT [dbo].[Rol_Operacion] ([id], [idRol], [idOperacion]) VALUES (13, 3, 13)
INSERT [dbo].[Rol_Operacion] ([id], [idRol], [idOperacion]) VALUES (14, 3, 14)
INSERT [dbo].[Rol_Operacion] ([id], [idRol], [idOperacion]) VALUES (15, 3, 15)
SET IDENTITY_INSERT [dbo].[Rol_Operacion] OFF
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
ALTER TABLE [dbo].[Asignatura]  WITH CHECK ADD  CONSTRAINT [FK_Asignatura_Profesor1] FOREIGN KEY([idProfesor])
REFERENCES [dbo].[Profesor] ([idProfesor])
GO
ALTER TABLE [dbo].[Asignatura] CHECK CONSTRAINT [FK_Asignatura_Profesor1]
GO
ALTER TABLE [dbo].[AsignaturaAlumno]  WITH CHECK ADD  CONSTRAINT [FK_AsignaturaAlumno_Alumno] FOREIGN KEY([idAlumno])
REFERENCES [dbo].[Alumno] ([idAlumno])
GO
ALTER TABLE [dbo].[AsignaturaAlumno] CHECK CONSTRAINT [FK_AsignaturaAlumno_Alumno]
GO
ALTER TABLE [dbo].[AsignaturaAlumno]  WITH CHECK ADD  CONSTRAINT [FK_AsignaturaAlumno_Asignatura] FOREIGN KEY([idAsignatura])
REFERENCES [dbo].[Asignatura] ([idAsignatura])
GO
ALTER TABLE [dbo].[AsignaturaAlumno] CHECK CONSTRAINT [FK_AsignaturaAlumno_Asignatura]
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
