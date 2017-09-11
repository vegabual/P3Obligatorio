USE ProvEventos
GO

INSERT INTO TipoEvento VALUES('Fiesta de 15','Fiesta para festejar los 15 años de las mujeres')
INSERT INTO TipoEvento VALUES('Casamiento','Evento de ceremonia religiosa')
INSERT INTO TipoEvento VALUES('Desayuno de trabajo','Reunión informal laboral')
INSERT INTO TipoEvento VALUES('Almuerzo de trabajo','Reunión informal laboral')
INSERT INTO TipoEvento VALUES('Fiesta temática','Fiesta de cumpleaños con un tema')
INSERT INTO TipoEvento VALUES('Despedida','Almuerzo o cena de despedida')
INSERT INTO TipoEvento VALUES('Aniversario','Evento de celebración de aniversario')
INSERT INTO TipoEvento VALUES('Evento empresarial','Reunión empresarial')
INSERT INTO TipoEvento VALUES('Cócteles y brindis','Fiesta de celebración')
INSERT INTO TipoEvento VALUES('Baby shower','Fiesta para festejar el nacimiento de un bebé')
--SELECT * FROM TipoEvento

INSERT INTO Servicio VALUES('Fotografía','Fotógrafo profesional para eventos',NULL,107)
INSERT INTO Servicio VALUES('Filmación','Equipo de filmación','imagen1.jpg',102)
INSERT INTO Servicio VALUES('Cotillón','Paquetes de cotillón varios','imagen2.png',101)
INSERT INTO Servicio VALUES('Catering','Servicios de catering profesional',NULL,108)
INSERT INTO Servicio VALUES('Grupo musical','Grupo musical en vivo','imagen3.jpg',105)
INSERT INTO Servicio VALUES('Lunch','Lunch completos para 20 personas',NULL,104)
INSERT INTO Servicio VALUES('Personal de salón','Mozos y personal de cocina','imagen4.png',106)
INSERT INTO Servicio VALUES('Sommelier','Sommelier profesional para eventos',NULL,109)
INSERT INTO Servicio VALUES('Decoración','Grupo de decoradores profesionales',NULL,101)
INSERT INTO Servicio VALUES('Iluminación','Iluminación profesional',NULL,100)
--SELECT * FROM Servicio


INSERT INTO Usuario VALUES('R2310342','pm23mo37ar','20150509')
INSERT INTO Usuario VALUES('R9202499','pin536on3b','20171029')
INSERT INTO Usuario VALUES('R1390114','3ob54ou36b','20120101')
INSERT INTO Usuario VALUES('R9135311','b6b54o64bw','20170806')
INSERT INTO Usuario VALUES('R5925094','3n063n95nn','20141025')
INSERT INTO Usuario VALUES('R2450054','ni2r34inr3','20160219')
INSERT INTO Usuario VALUES('R1294030','s9dgs083hj','20170702')
INSERT INTO Usuario VALUES('R7476853','jr922rh2ht','20170113')
INSERT INTO Usuario VALUES('R4562968','v437g7sa89','20150304')
INSERT INTO Usuario VALUES('R4328956','s80gy98hgs','20161121')
INSERT INTO Usuario VALUES('R3563463','rwgh56jh54','20170211')
INSERT INTO Usuario VALUES('R0525223','cqw44f5y4i','20161115')
INSERT INTO Usuario VALUES('R5734798','b45y3vc4df','20170409')
--SELECT * FROM Usuario

INSERT INTO Rol VALUES('R2310342','Proveedor')
INSERT INTO Rol VALUES('R9202499','Proveedor')
INSERT INTO Rol VALUES('R1390114','Administrador')
INSERT INTO Rol VALUES('R9135311','Administrador')
INSERT INTO Rol VALUES('R5925094','Proveedor')
INSERT INTO Rol VALUES('R2450054','Proveedor')
INSERT INTO Rol VALUES('R1294030','Proveedor')
INSERT INTO Rol VALUES('R7476853','Administrador')
INSERT INTO Rol VALUES('R4562968','Proveedor')
INSERT INTO Rol VALUES('R4328956','Proveedor')
INSERT INTO Rol VALUES('R3563463','Proveedor')
INSERT INTO Rol VALUES('R0525223','Proveedor')
INSERT INTO Rol VALUES('R5734798','Proveedor')
--SELECT * FROM Rol

INSERT INTO Proveedor VALUES('R2310342','ACCE LTDA','acceprov@outlook.com',1,507)
INSERT INTO Proveedor VALUES('R9202499','COVISA','covisa@outlook.com',0,502)
INSERT INTO Proveedor VALUES('R5925094','DITEM','ditem@gmail.com',1,501)
INSERT INTO Proveedor VALUES('R2450054','EIPM','eipm@outlook.com',1,500)
INSERT INTO Proveedor VALUES('R1294030','GSA SA','gsaprov@outlook.com',0,505)
INSERT INTO Proveedor VALUES('R4562968','OPZION SA','opzionsa@yahoo.com',1,503)
INSERT INTO Proveedor VALUES('R4328956','SUMATEC','sumatec@hotmail.com',1,504)
INSERT INTO Proveedor VALUES('R3563463','VITEL','vitel@gmail.com',0,506)
INSERT INTO Proveedor VALUES('R0525223','WENCO S.A','wenco@gmail.com',0,508)
INSERT INTO Proveedor VALUES('R5734798','ROMACO','romacoltda@outlook.com',1,509)
--SELECT * FROM Proveedor

INSERT INTO ProveedorVIP VALUES('R2310342',5.0)
INSERT INTO ProveedorVIP VALUES('R9202499',10.0)
INSERT INTO ProveedorVIP VALUES('R5925094',5.0)
INSERT INTO ProveedorVIP VALUES('R2450054',5.0)
INSERT INTO ProveedorVIP VALUES('R1294030',10.0)
--SELECT * FROM ProveedorVIP

INSERT INTO TelefonoProveedor VALUES('R2310342','099262189')
INSERT INTO TelefonoProveedor VALUES('R9202499','099189184')
INSERT INTO TelefonoProveedor VALUES('R5925094','098498451')
INSERT INTO TelefonoProveedor VALUES('R2450054','099589126')
INSERT INTO TelefonoProveedor VALUES('R1294030','098198712')
INSERT INTO TelefonoProveedor VALUES('R4562968','099489494')
INSERT INTO TelefonoProveedor VALUES('R4328956','098198778')
INSERT INTO TelefonoProveedor VALUES('R3563463','099135181')
INSERT INTO TelefonoProveedor VALUES('R0525223','098979988')
INSERT INTO TelefonoProveedor VALUES('R5734798','099468455')
--SELECT * FROM TelefonoProveedor
