USE ProvEventos
GO

BEGIN TRANSACTION


INSERT INTO TipoEvento VALUES('100','Fiesta de 15','Fiesta para festejar los 15 años de las mujeres')
GO
INSERT INTO TipoEvento VALUES('101','Casamiento','Evento de ceremonia religiosa')
GO
INSERT INTO TipoEvento VALUES('102','Desayuno de trabajo','Reunión informal laboral')
GO
INSERT INTO TipoEvento VALUES('103','Almuerzo de trabajo','Reunión informal laboral')
GO
INSERT INTO TipoEvento VALUES('104','Fiesta temática','Fiesta de cumpleaños con un tema')
GO
INSERT INTO TipoEvento VALUES('105','Despedida','Almuerzo o cena de despedida')
GO
INSERT INTO TipoEvento VALUES('106','Aniversario','Evento de celebración de aniversario')
GO
INSERT INTO TipoEvento VALUES('107','Evento empresarial','Reunión empresarial')
GO
INSERT INTO TipoEvento VALUES('108','Cócteles y brindis','Fiesta de celebración')
GO
INSERT INTO TipoEvento VALUES('109','Baby shower','Fiesta para festejar el nacimiento de un bebé')
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

INSERT INTO Servicio VALUES('500','R5925094','Fotografía','Fotógrafo profesional para eventos',NULL,1,'100')
GO
INSERT INTO Servicio VALUES('501','R5925094','Filmación','Equipo de filmación','imagen1.jpg',1,'101')
GO
INSERT INTO Servicio VALUES('502','R4328956','Cotillón','Paquetes de cotillón varios','imagen2.png',1,'100')
GO
INSERT INTO Servicio VALUES('503','R9202499','Catering','Servicios de catering profesional',NULL,0,'108')
GO
INSERT INTO Servicio VALUES('504','R3563463','Grupo musical','Grupo musical en vivo','imagen3.jpg',0,'105')
GO
INSERT INTO Servicio VALUES('505','R2450054','Lunch','Lunch completos para 20 personas',NULL,1,'103')
GO
INSERT INTO Servicio VALUES('506','R2310342','Personal de salón','Mozos y personal de cocina','imagen4.png',1,'100')
GO
INSERT INTO Servicio VALUES('507','R4562968','Sommelier','Sommelier profesional para eventos',NULL,1,'108')
GO
INSERT INTO Servicio VALUES('508','R1294030','Decoración','Grupo de decoradores profesionales','imagen5.jpg',0,'104')
GO
INSERT INTO Servicio VALUES('509','R2310342','Iluminación','Iluminación profesional',NULL,1,'106')
GO
--SELECT * FROM Servicio

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

INSERT INTO Valores VALUES(6500,15)
GO
--SELECT * FROM Valores

--ROLLBACK TRANSACTION
--COMMIT TRANSACTION	
