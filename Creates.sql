USE ProvEventos
GO

CREATE TABLE TipoEvento
(
	idtipoevento INTEGER IDENTITY(100,1) PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	descripcion NVARCHAR(250) NULL
)
GO

CREATE TABLE Usuario
(
	nombreusuario VARCHAR(20) PRIMARY KEY,
	clave VARCHAR(10) NOT NULL,
	fecharegistro DATE NOT NULL
)
GO

CREATE TABLE Proveedor
(
	rut VARCHAR(20) FOREIGN KEY REFERENCES Usuario(nombreusuario),
	nombrefantasia NVARCHAR(100) NOT NULL,
	email NVARCHAR(100) NULL,
	activo BIT DEFAULT 1
	PRIMARY KEY(rut)
)
GO

CREATE TABLE Servicio
(
	idservicio INTEGER IDENTITY(500,1) PRIMARY KEY,
	rut VARCHAR(20) FOREIGN KEY REFERENCES Usuario(nombreusuario),
	nombre VARCHAR(50) NOT NULL,
	descripcion NVARCHAR(250) NULL,
	imagen NVARCHAR(200),
	idtipoevento INTEGER FOREIGN KEY REFERENCES TipoEvento(idtipoevento)
)
GO

CREATE TABLE Rol
(
	nombreusuario VARCHAR(20) FOREIGN KEY REFERENCES Usuario(nombreusuario),
	rol VARCHAR(50) NOT NULL,
	PRIMARY KEY(nombreusuario)
)
GO


CREATE TABLE ProveedorVIP
(
	rut VARCHAR(20) FOREIGN KEY REFERENCES Proveedor(rut),
	porcentaje DECIMAL(5,2) NULL,
	PRIMARY KEY(rut)
)
GO

CREATE TABLE TelefonoProveedor
(
	rut VARCHAR(20) FOREIGN KEY REFERENCES Proveedor(rut),
	telefono VARCHAR(10) NOT NULL
)
GO
