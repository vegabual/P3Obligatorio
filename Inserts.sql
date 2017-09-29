USE ProvEventos
GO

BEGIN TRANSACTION


DBCC CHECKIDENT ('TipoEvento', RESEED, 1000);
GO
DBCC CHECKIDENT ('Rol', RESEED, 1000);
GO
DBCC CHECKIDENT ('Servicio', RESEED, 10000);
GO

INSERT INTO TipoEvento VALUES('Fiesta de 15','Fiesta para festejar los 15 a�os de las mujeres')
GO
INSERT INTO TipoEvento VALUES('Casamiento','Evento de ceremonia religiosa')
GO
INSERT INTO TipoEvento VALUES('Desayuno de trabajo','Reuni�n informal laboral')
GO
INSERT INTO TipoEvento VALUES('Almuerzo de trabajo','Reuni�n informal laboral')
GO
INSERT INTO TipoEvento VALUES('Fiesta tem�tica','Fiesta de cumplea�os con un tema')
GO
INSERT INTO TipoEvento VALUES('Despedida','Almuerzo o cena de despedida')
GO
INSERT INTO TipoEvento VALUES('Aniversario','Evento de celebraci�n de aniversario')
GO
INSERT INTO TipoEvento VALUES('Evento empresarial','Reuni�n empresarial')
GO
INSERT INTO TipoEvento VALUES('C�cteles y brindis','Fiesta de celebraci�n')
GO
INSERT INTO TipoEvento VALUES('Baby shower','Fiesta para festejar el nacimiento de un beb�')
GO
--SELECT * FROM TipoEvento

INSERT INTO Rol VALUES('Proveedor')
GO
INSERT INTO Rol VALUES('Administrador')
GO
--SELECT * FROM Rol

INSERT INTO Usuario VALUES('R2310342','pm23mo37ar', 1000,'20150509')
GO
INSERT INTO Usuario VALUES('R9202499','pin536on3b', 1000,'20171029')
GO
INSERT INTO Usuario VALUES('R1390114','3ob54ou36b', 1001,'20120101')
GO
INSERT INTO Usuario VALUES('R9135311','b6b54o64bw', 1001,'20170806')
GO
INSERT INTO Usuario VALUES('R5925094','3n063n95nn', 1000,'20141025')
GO
INSERT INTO Usuario VALUES('R2450054','ni2r34inr3', 1000,'20160219')
GO
INSERT INTO Usuario VALUES('R1294030','s9dgs083hj', 1000,'20170702')
GO
INSERT INTO Usuario VALUES('R7476853','jr922rh2ht', 1001,'20170113')
GO
INSERT INTO Usuario VALUES('R4562968','v437g7sa89', 1000,'20150304')
GO
INSERT INTO Usuario VALUES('R4328956','s80gy98hgs', 1000,'20161121')
GO
INSERT INTO Usuario VALUES('R3563463','rwgh56jh54', 1000,'20170211')
GO
INSERT INTO Usuario VALUES('R0525223','cqw44f5y4i', 1000,'20161115')
GO
INSERT INTO Usuario VALUES('R5734798','b45y3vc4df', 1000,'20170409')
GO
--SELECT * FROM Usuario

INSERT INTO Servicio VALUES('Fotograf�a','Fot�grafo profesional para eventos',NULL)
GO
INSERT INTO Servicio VALUES('Filmaci�n','Equipo de filmaci�n','imagen1.jpg')
GO
INSERT INTO Servicio VALUES('Cotill�n','Paquetes de cotill�n varios','imagen2.png')
GO
INSERT INTO Servicio VALUES('Catering','Servicios de catering profesional',NULL)
GO
INSERT INTO Servicio VALUES('Grupo musical','Grupo musical en vivo','imagen3.jpg')
GO
INSERT INTO Servicio VALUES('Lunch','Lunch completos para 20 personas',NULL)
GO
INSERT INTO Servicio VALUES('Personal de sal�n','Mozos y personal de cocina','imagen4.png')
GO
INSERT INTO Servicio VALUES('Sommelier','Sommelier profesional para eventos',NULL)
GO
INSERT INTO Servicio VALUES('Decoraci�n','Grupo de decoradores profesionales','imagen5.jpg')
GO
INSERT INTO Servicio VALUES('Iluminaci�n','Iluminaci�n profesional',NULL)
GO
--SELECT * FROM Servicio

INSERT INTO ServicioTipoEvento VALUES(1000,10000)
GO
INSERT INTO ServicioTipoEvento VALUES(1001,10000)
GO
INSERT INTO ServicioTipoEvento VALUES(1007,10000)
GO
INSERT INTO ServicioTipoEvento VALUES(1000,10001)
GO
INSERT INTO ServicioTipoEvento VALUES(1000,10002)
GO
INSERT INTO ServicioTipoEvento VALUES(1000,10000)
GO
INSERT INTO ServicioTipoEvento VALUES(1002,10003)
GO
INSERT INTO ServicioTipoEvento VALUES(1003,10003)
GO
INSERT INTO ServicioTipoEvento VALUES(1007,10003)
GO
INSERT INTO ServicioTipoEvento VALUES(1001,10004)
GO
INSERT INTO ServicioTipoEvento VALUES(1003,10005)
GO
INSERT INTO ServicioTipoEvento VALUES(1007,10005)
GO
INSERT INTO ServicioTipoEvento VALUES(1000,10006)
GO
INSERT INTO ServicioTipoEvento VALUES(1001,10006)
GO
INSERT INTO ServicioTipoEvento VALUES(1002,10006)
GO
INSERT INTO ServicioTipoEvento VALUES(1003,10006)
GO
INSERT INTO ServicioTipoEvento VALUES(1005,10006)
GO
INSERT INTO ServicioTipoEvento VALUES(1008,10006)
GO
INSERT INTO ServicioTipoEvento VALUES(1004,10008)
GO
INSERT INTO ServicioTipoEvento VALUES(1009,10008)
GO
INSERT INTO ServicioTipoEvento VALUES(1000,10009)
GO
INSERT INTO ServicioTipoEvento VALUES(1004,10009)
GO
INSERT INTO ServicioTipoEvento VALUES(1008,10009)
GO
--SELECT * FROM ServicioTipoEvento

INSERT INTO Proveedor VALUES('R2310342','ACCE LTDA','acceprov@outlook.com',1)
GO
INSERT INTO Proveedor VALUES('R9202499','COVISA','covisa@outlook.com',0)
GO
INSERT INTO Proveedor VALUES('R5925094','DITEM','ditem@gmail.com',1)
GO
INSERT INTO Proveedor VALUES('R2450054','EIPM','eipm@outlook.com',1)
GO
INSERT INTO Proveedor VALUES('R1294030','GSA SA','gsaprov@outlook.com',0)
GO
INSERT INTO Proveedor VALUES('R4562968','OPZION SA','opzionsa@yahoo.com',1)
GO
INSERT INTO Proveedor VALUES('R4328956','SUMATEC','sumatec@hotmail.com',1)
GO
INSERT INTO Proveedor VALUES('R3563463','VITEL','vitel@gmail.com',0)
GO
INSERT INTO Proveedor VALUES('R0525223','WENCO S.A','wenco@gmail.com',0)
GO
INSERT INTO Proveedor VALUES('R5734798','ROMACO','romacoltda@outlook.com',1)
GO
--SELECT * FROM Proveedor

INSERT INTO ProveedorVIP VALUES('R2310342',15.0)
GO
INSERT INTO ProveedorVIP VALUES('R9202499',15.0)
GO
INSERT INTO ProveedorVIP VALUES('R5925094',15.0)
GO
INSERT INTO ProveedorVIP VALUES('R2450054',15.0)
GO
INSERT INTO ProveedorVIP VALUES('R1294030',15.0)
GO
--SELECT * FROM ProveedorVIP

INSERT INTO ProveedorServicio VALUES('R2310342',10000,1)
GO
INSERT INTO ProveedorServicio VALUES('R9202499',10001,0)
GO
INSERT INTO ProveedorServicio VALUES('R5925094',10002,1)
GO
INSERT INTO ProveedorServicio VALUES('R2450054',10003,1)
GO
INSERT INTO ProveedorServicio VALUES('R1294030',10004,0)
GO
INSERT INTO ProveedorServicio VALUES('R4562968',10005,1)
GO
INSERT INTO ProveedorServicio VALUES('R4328956',10006,1)
GO
INSERT INTO ProveedorServicio VALUES('R3563463',10007,0)
GO
INSERT INTO ProveedorServicio VALUES('R0525223',10008,0)
GO
INSERT INTO ProveedorServicio VALUES('R5734798',10009,1)
GO
--SELECT * FROM ProveedorServicio

INSERT INTO TelefonoProveedor VALUES('R2310342','099262189')
GO
INSERT INTO TelefonoProveedor VALUES('R9202499','099189184')
GO
INSERT INTO TelefonoProveedor VALUES('R5925094','098498451')
GO
INSERT INTO TelefonoProveedor VALUES('R2450054','099589126')
GO
INSERT INTO TelefonoProveedor VALUES('R1294030','098198712')
GO
INSERT INTO TelefonoProveedor VALUES('R4562968','099489494')
GO
INSERT INTO TelefonoProveedor VALUES('R4328956','098198778')
GO
INSERT INTO TelefonoProveedor VALUES('R3563463','099135181')
GO
INSERT INTO TelefonoProveedor VALUES('R0525223','098979988')
GO
INSERT INTO TelefonoProveedor VALUES('R5734798','099468455')
GO
--SELECT * FROM TelefonoProveedor

--ROLLBACK TRANSACTION
--COMMIT TRANSACTION	
