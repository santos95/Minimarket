USE MASTER
GO

USE dbventasProyectTer
GO

--ejecturar estos-------------------------------------------------------------------------------------------------
INSERT INTO cat_persona 
VALUES(1, 'N', 'CED', '001-230495-0010N', 'Santos Alberto', 'Ortiz Chávez', '4-23-2020', 'M', 'S' ,'Mcfly street número 33.')
GO
INSERT INTO cat_cargo 
VALUES(1,'TI Administrador', 'Administrador área de TI', 'Admin-1', 'John Chombo', GETDATE(), 'A')
GO
INSERT INTO cat_empleado
VALUES(1, 1,'99423424323', 'TI', '22345678', '84341859', 'santos95ortiz@gmail.com', 'Administrador del sistema', getdate(), 'A')
GO
INSERT INTO tbl_detalleCargoEmpleado 
VALUES( 1, 1, 1, 'Admin-1', 'John Chombo', getdate(), 'Administrador del sistema. Carga Inicial', 'A')
GO
INSERT INTO tbl_rolacceso (id_rolacceso, rol, descripcion, registrado, estado)
VALUES(1,'Administrador', 'Rol para el mantenimiento, respaldo y seguridad.', 'Admin-1' , 'A')
GO
INSERT INTO tbl_rolacceso (id_rolacceso, rol, descripcion, registrado, estado)
VALUES(2,'Cajero', 'Rol para encargados del proceso de compra', 'Admin-1' , 'A')
GO
INSERT INTO tbl_rolacceso (id_rolacceso, rol, descripcion, registrado, estado)
VALUES(3,'Gerente', 'Rol del gerente con acceso a todos los aspectos del negocio.', 'Admin-1' , 'A')
GO
INSERT INTO tbl_rolacceso (id_rolacceso, rol, descripcion, registrado, estado)
VALUES(4,'Bodeguero', 'Rol para el proceso de compra y control de inventario', 'Admin-1' , 'A')
GO
INSERT INTO tbl_rolacceso (id_rolacceso, rol, descripcion, registrado, estado)
VALUES(5,'Supervisor Venta', 'Rol para la anulación y validez de procesos en el área de venta', 'Admin-1' , 'A')
GO
INSERT INTO cat_usuario
VALUES (1, 1, 1, 'Admin-1', 'b64f39f40e15e21db7b47a559c8195cd5abe1da75360fba56c8bee185b05f3b7', 'Admin-1', 'John Chombo', getdate(), 'Administrador del sistema, carga inicial.','A' )
INSERT INTO tblControlCredenciales
VALUES(1, 1, 'Admin-1', 'b64f39f40e15e21db7b47a559c8195cd5abe1da75360fba56c8bee185b05f3b7', getdate(), 'A');

--User:Admin-1 Contraseña:Administrador#1
---------------------------------------------------------------------------------------------------------------------
