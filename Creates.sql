IF EXISTS(SELECT * FROM SysDataBases WHERE name='ProvEventos')
BEGIN
	DROP DATABASE ProvEventos
END
GO

CREATE DATABASE ProvEventos
GO

USE ProvEventos
GO

BEGIN TRANSACTION 

CREATE TABLE TipoEvento
(
	idtipoevento VARCHAR(10) PRIMARY KEY,
	nombreevento VARCHAR(100) NOT NULL,
	descripcion NVARCHAR(250) NULL
)
GO

CREATE TABLE Rol
(
	idrol int IDENTITY(1000,1) PRIMARY KEY(idrol),
	rol VARCHAR(20) NOT NULL
)
GO

CREATE TABLE Usuario
(
	nombreusuario VARCHAR(30) PRIMARY KEY,
	clave VARCHAR(15) NOT NULL, 
	idrol int FOREIGN KEY REFERENCES Rol(idrol),
	fecharegistro DATE NOT NULL
)
GO

CREATE TABLE Servicio
(
	idservicio VARCHAR(10) PRIMARY KEY,
	rut VARCHAR(30) FOREIGN KEY REFERENCES Usuario(nombreusuario),
	nombreservicio VARCHAR(50) NOT NULL,
	descripcion NVARCHAR(250) NULL,
	imagen NVARCHAR(200) NULL,
	activo BIT DEFAULT 1,
	idtipoevento VARCHAR(10) FOREIGN KEY REFERENCES TipoEvento(idtipoevento)
)
GO

CREATE TABLE Proveedor
(
	rut VARCHAR(30) FOREIGN KEY REFERENCES Usuario(nombreusuario),
	nombrefantasia NVARCHAR(100) NOT NULL,
	email NVARCHAR(100) NULL,
	activo BIT DEFAULT 1,
	PRIMARY KEY(rut)
)
GO

CREATE TABLE ProveedorVIP
(
	rut VARCHAR(30) FOREIGN KEY REFERENCES Proveedor(rut),
	porcentaje DECIMAL(5,2) NULL,
	PRIMARY KEY(rut)
)
GO

CREATE TABLE TelefonoProveedor
(
	rut VARCHAR(30) FOREIGN KEY REFERENCES Proveedor(rut),
	telefono VARCHAR(10) NOT NULL
)
GO

CREATE TABLE Valores
(
	arancel DECIMAL(9,2),
	porcentaje DECIMAL(9,2)
)

--ROLLBACK TRANSACTION
--COMMIT TRANSACTION