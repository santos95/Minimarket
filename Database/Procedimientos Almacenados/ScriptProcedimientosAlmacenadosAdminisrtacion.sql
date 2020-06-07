USE Practica
GO
---Procedimientos de Logeo y control de acceso 

CREATE procedure accesologin
(
@usuario varchar(100),
@password varchar(100)
)
AS
BEGIN
SELECT rolacceso,usuario,pass,cod_usuario  FROm cat_usuario where usuario = @usuario and pass = @password
END
GO


CREATE PROC estadoconexion
(
@cod_usuario int
)
as
SELECT TOP 1 * FROM tbl_control_acceso WHERE usuario = @cod_usuario ORDER BY dtConexion DESC
GO



-----------------------------------procedimiento de cargo----------------------------------------------------
-------------------       Created by: Santos Alberto Ortiz Ch�vez         -----------------------------------
-------------------       Date: 28/03/2020                                ----------------------------------- 
-------------------------------------------------------------------------------------------------------------
--Procedimiento para listar todos los cargos
CREATE PROC spMostrarCargo
AS
BEGIN
	SELECT id_cargo AS C�digo, nombre_cargo as Cargo, descripcion_cargo AS Descripci�n, strRegistrado as RegistradoPor, strAutorizado as AutorizadoPor , fecharegistro AS Registrado, estado AS Estado  FROM cat_cargo
END
GO

CREATE PROC spMostrarCargoA
AS
BEGIN
	SELECT id_cargo AS C�digo, nombre_cargo as Cargo, descripcion_cargo AS Descripci�n, strRegistrado AS RegistradoPor, strAutorizado AS AutorizadoPor , fecharegistro AS Registrado, estado AS Estado  FROM cat_cargo WHERE estado = 'A' ORDER BY nombre_cargo;
END
GO

CREATE PROC spMostrarCargoI
AS
BEGIN
	SELECT id_cargo AS C�digo, nombre_cargo as Cargo, descripcion_cargo AS Descripci�n, strRegistrado as RegistradoPor, strAutorizado as AutorizadoPor , fecharegistro AS Registrado, estado AS Estado  FROM cat_cargo WHERE estado = 'I';
END
GO


CREATE PROC spBuscarCargoNombre
@textobuscar varchar(50)
AS
BEGIN
	SELECT id_cargo AS C�digo, nombre_cargo as Cargo, descripcion_cargo AS Descripci�n, strRegistrado as RegistradoPor, strAutorizado as AutorizadoPor , fecharegistro AS Registrado, estado AS Estado  FROM cat_cargo WHERE nombre_cargo LIKE @textobuscar + '%';
END
GO

CREATE PROC spRegistrarCargo
@nombre			varchar(50),
@descripcion	varchar(200),
@registrado		varchar(100),
@autorizado		varchar(100),
@estado			char(1),
@Mensaje		Varchar(80) Out
As 
BEGIN
	If(Exists(SELECT * FROM cat_cargo WHERE nombre_cargo=@nombre))
		SET @Mensaje='El cargo ya se encuentra registrado.';
	ELSE 
		BEGIN
			DECLARE @codCargo INT;
			SELECT @codCargo = ISNULL(MAX(id_cargo), 0) + 1  FROM cat_cargo;

			IF @estado = 'I'
			BEGIN
				
				INSERT INTO cat_cargo
				VALUES (@codCargo,@nombre, @descripcion, @registrado, @autorizado, GETDATE(), @estado);
			
				SET @Mensaje='Se ha registrado el cargo correctamente. El cargo debse ser autorizado.';
		
			END
			ELSE IF @estado = 'A'
			BEGIN

				INSERT INTO cat_cargo
				VALUES(@codCargo, @nombre, @descripcion, @registrado, @autorizado, GETDATE(), @estado)

				SET @Mensaje = 'Se ha registrado el cargo correctamente. Se ha autorizado el cargo.'

			END
			
		END
END
GO


CREATE PROC spAutorizarCargo
@idCargo	int,
@autorizar	varchar(100),
@mensaje	varchar(50) out
AS
BEGIN

	IF(NOT EXISTS(SELECT * FROM cat_cargo WHERE id_cargo = @idCargo))
		SET @mensaje = 'El cargo no se encuentra registrado';
	IF(EXISTS(SELECT * FROM cat_cargo WHERE id_cargo = @idCargo and estado = 'I'))
	BEGIN	
		UPDATE cat_cargo SET strAutorizado = @autorizar, estado = 'A' WHERE id_cargo = @idCargo;
		SET @mensaje = 'Se ha autorizado el cargo.';
	END
	ELSE
		SET @mensaje = 'No se ha podido autorizar el cargo';
END
GO

CREATE PROC spDesautorizarCargo
@idCargo	int,
@autorizar	varchar(100),
@mensaje	varchar(50) out
AS
BEGIN

	IF(NOT EXISTS(SELECT * FROM cat_cargo WHERE id_cargo = @idCargo))
		SET @mensaje = 'El cargo no se encuentra registrado';
	IF(EXISTS(SELECT * FROM cat_cargo WHERE id_cargo = @idCargo and estado = 'A'))
	BEGIN	
		UPDATE cat_cargo SET strAutorizado = @autorizar, estado = 'I' WHERE id_cargo = @idCargo;
		SET @mensaje = 'Se ha Desautorizado el cargo.';
	END
	ELSE
		SET @mensaje = 'No se ha podido desautorizar el cargo';
END
GO

CREATE PROC spActualizarcargo
@idCargo			int,
@nombre				varchar(50),
@descripcion		varchar(200),
@registrado			nvarchar(100),
@autorizado			nvarchar(100),
@estado				char(1),
@mensaje			Varchar(80)  Out
AS
BEGIN
	
	If(NOT EXISTS(SELECT * FROM cat_cargo WHERE @idCargo = id_cargo))
		SET @Mensaje = 'El cargo no se encuentra registrado.';
	ELSE
	BEGIN

		IF @estado = 'A'
		BEGIN
			
			UPDATE cat_cargo SET nombre_cargo=@nombre, descripcion_cargo=@descripcion, strRegistrado = @registrado, strAutorizado = @autorizado,  estado = @estado  WHERE id_cargo = @idCargo;
			SET @Mensaje='Se ha Actualizado los Datos Correctamente. Se ha autorizado el cargo.';
		
		END
		ELSE IF @estado = 'I'
		BEGIN
			
			UPDATE cat_cargo SET nombre_cargo=@nombre, descripcion_cargo=@descripcion, strRegistrado = @registrado, strAutorizado = @autorizado, estado = @estado  WHERE id_cargo = @idCargo;
			SET @Mensaje='Se ha Actualizado los Datos Correctamente. Se ha anulado el cargo.';
		END
	END
END
GO


-----------------------------------procedimiento de EmplEado----------------------------------------------------
-------------------       Created by: Santos Alberto Ortiz Ch�vez         -----------------------------------
-------------------       Date: 1/04/2020                                ----------------------------------- 
-------------------------------------------------------------------------------------------------------------

CREATE PROC spMostrarEmpleado
AS
BEGIN
	SELECT cod_empleado as C�digo, chrTipoIdent as TipoIdentificaci�n, numIdentificacion as Identificaci�n, numInss as INSS, tipoContrato as Tipo_Contrato, strNombre as Nombre, strApellidoRazon as Apellidos, dtFechaNacConst as Fecha_Nacimiento, chrGenero as Genero, chrEstadoCivilNat as Estado_Civil, strDireccion as Direcci�n, celular as Celular, telefono as Telefono, correo as Correo, fechaReg as Registrado, estado as Estado, strObservacion as Observaci�n FROM cat_empleado JOIN cat_persona on codPersona = cod_persona;
END
GO


CREATE PROC spBuscarEmpleadoNombre
@textobuscar varchar(50)
AS
BEGIN
	
	SELECT cod_empleado as C�digo, chrTipoIdent as TipoIdentificaci�n, numIdentificacion as Identificaci�n, numInss as INSS, tipoContrato as Tipo_Contrato, strNombre as Nombre, strApellidoRazon as Apellidos, dtFechaNacConst as Fecha_Nacimiento, chrGenero as Genero, chrEstadoCivilNat as Estado_Civil, strDireccion as Direcci�n, celular as Celular, telefono as Telefono, correo as Correo, fechaReg as Registrado, estado as Estado, strObservacion as Observaci�n FROM cat_empleado JOIN cat_persona on codPersona = cod_persona WHERE strNombre LIKE @textoBuscar + '%';

END
GO


CREATE PROC spBuscarEmpleadoApellido
@textobuscar varchar(50)
AS
BEGIN
	
	SELECT cod_empleado as C�digo, chrTipoIdent as TipoIdentificaci�n, numIdentificacion as Identificaci�n, numInss as INSS, tipoContrato as Tipo_Contrato, strNombre as Nombre, strApellidoRazon as Apellidos, dtFechaNacConst as Fecha_Nacimiento, chrGenero as Genero, chrEstadoCivilNat as Estado_Civil, strDireccion as Direcci�n, celular as Celular, telefono as Telefono, correo as Correo, fechaReg as Registrado, estado as Estado, strObservacion as Observaci�n FROM cat_empleado JOIN cat_persona on codPersona = cod_persona WHERE strApellidoRazon LIKE @textoBuscar + '%';

END
GO

CREATE PROC spBuscarEmpleadoCodigo
@numDocumento int
AS
BEGIN
	SELECT cod_empleado as C�digo, chrTipoIdent as TipoIdentificaci�n, numIdentificacion as Identificaci�n, numInss as INSS, tipoContrato as Tipo_Contrato, strNombre as Nombre, strApellidoRazon as Apellidos, dtFechaNacConst as Fecha_Nacimiento, chrGenero as Genero, chrEstadoCivilNat as Estado_Civil, strDireccion as Direcci�n, celular as Celular, telefono as Telefono, correo as Correo, fechaReg as Registrado, estado as Estado, strObservacion as Observaci�n FROM cat_empleado JOIN cat_persona on codPersona = cod_persona WHERE cod_Empleado = @numDocumento;
END
GO


--Filtros
--Empleados Activos
CREATE PROC spMostrarEmpleadoA
AS
BEGIN
	
	SELECT cod_empleado as C�digo, chrTipoIdent as TipoIdentificaci�n, numIdentificacion as Identificaci�n, numInss as INSS, tipoContrato as Tipo_Contrato, strNombre as Nombre, strApellidoRazon as Apellidos, dtFechaNacConst as Fecha_Nacimiento, chrGenero as Genero, chrEstadoCivilNat as Estado_Civil, strDireccion as Direcci�n, celular as Celular, telefono as Telefono, correo as Correo, fechaReg as Registrado, estado as Estado, strObservacion as Observaci�n FROM cat_empleado JOIN cat_persona on codPersona = cod_persona WHERE estado = 'A';

END
GO

--Empleados Inactivos
CREATE PROC spMostrarEmpleadoI
AS
BEGIN
	
	SELECT cod_empleado as C�digo, chrTipoIdent as TipoIdentificaci�n, numIdentificacion as Identificaci�n, numInss as INSS, tipoContrato as Tipo_Contrato, strNombre as Nombre, strApellidoRazon as Apellidos, dtFechaNacConst as Fecha_Nacimiento, chrGenero as Genero, chrEstadoCivilNat as Estado_Civil, strDireccion as Direcci�n, celular as Celular, telefono as Telefono, correo as Correo, fechaReg as Registrado, estado as Estado, strObservacion as Observaci�n FROM cat_empleado JOIN cat_persona on codPersona = cod_persona WHERE estado = 'i';

END
GO


 CREATE PROCEDURE spGuardarEmpleado
 @tipoIdent		char(3),
 @ident			varchar(20),
 @nombre		varchar(60),
 @apellido		varchar(60),
 @fechaNac		date,
 @genero		char(1),
 @estadoCiv		char(1),
 @direccion		varchar(300),
 @inss			varchar(50),
 @tipoCon		char(2),
 @telefono		nvarchar(12),
 @celular		nvarchar(12),
 @correo		varchar(80),
 @estado		char(1),
 @observacion	varchar(300), 
 @mensaje		varchar(50) output
 AS
		IF(EXISTS(SELECT * FROM cat_persona WHERE numIdentificacion = @ident))
			SET @Mensaje='El Empleado ya se encuentra registrado.';
		ELSE
		BEGIN
		 BEGIN TRANSACTION
			DECLARE @NError int
			DECLARE @codEmpleado INT
			DECLARE @codPersona INT
									
			SELECT @codPersona = ISNULL(MAX(cod_persona), 0) + 1  FROM cat_persona
			
			INSERT INTO cat_persona 
			VALUES(@codPersona, 'N', @tipoIdent, @ident, @nombre, @apellido, @fechaNac, @genero, @estadoCiv, @direccion)

			set @NError = @@ERROR
			IF (@NError <> 0) GOTO Error

			SELECT @codEmpleado = ISNULL(MAX(cod_empleado), 0) + 1 FROM cat_empleado

			INSERT INTO cat_empleado (cod_empleado, codPersona, numInss, tipoContrato, telefono, celular, correo, estado, strObservacion)
			VALUES(@codEmpleado, @codPersona, @inss, @tipoCon, @telefono, @celular, @correo,  @estado, @observacion)

			set @NError = @@ERROR
			IF (@NError <> 0) GOTO Error

			SET @mensaje = 'Se ha insertado el empleado'
			COMMIT TRAN

			Error:
			IF @NError <> 0
			BEGIN
				SET @mensaje = 'Error al momento de insertar el empleado'
				ROLLBACK TRAN
			END
		END
GO


CREATE PROC spActualizarEmpleado
 @codEmpleado	int,
 @tipoIdent		char(3),
 @ident			varchar(20),
 @nombre		varchar(60),
 @apellido		varchar(60),
 @fechaNac		date,
 @genero		char(1),
 @estadoCiv		char(1),
 @direccion		varchar(300),
 @inss			varchar(50),
 @tipoCon		char(2),
 @telefono		nvarchar(12),
 @celular		nvarchar(12),
 @correo		varchar(80),
 @estado		char(1),
 @observacion	varchar(300),
 @mensaje		varchar(50) out
 AS 
	IF (NOT EXISTS (SELECT * FROM cat_empleado WHERE cod_empleado = @codEmpleado))
		SET @mensaje = 'El empleado no se encuentra registrado.';
	ELSE
	BEGIN
		BEGIN TRANSACTION
			DECLARE @NError int
			DECLARE @codPersona int

			SELECT @codPersona =  cod_persona FROM cat_empleado e LEFT JOIN cat_persona p ON e.codPersona = p.cod_persona WHERE cod_empleado = @codEmpleado; 
			
			--Actualizar datos de persona del empleado
			UPDATE cat_persona SET chrTipoIdent = @tipoIdent, numIdentificacion = @ident, strNombre = @nombre, strApellidoRazon = @apellido, dtFechaNacConst = @fechaNac, chrGenero = @genero, chrEstadoCivilNat = @estadoCiv, strDireccion = @direccion WHERE cod_persona = @codPersona;
			
			set @NError = @@ERROR
			IF (@NError <> 0) GOTO Error

			UPDATE cat_empleado SET numINSS = @inss, tipoContrato = @tipoCon, telefono = @telefono, celular = @celular, correo = @correo, estado = @estado, strObservacion = @observacion WHERE cod_empleado = @codEmpleado;
			
			set @NError = @@ERROR
			IF (@NError <> 0) GOTO Error

			SET @mensaje = 'Se ha Actualizado al empleado'
			COMMIT TRAN

			Error:
			IF @NError <> 0
			BEGIN
				SET @mensaje = 'Error al momento de actualizar los datos del empleado'
				ROLLBACK TRAN
			END
	END
GO

-----------------------------------procedimiento de Historial----------------------------------------------------
-------------------       Created by: Santos Alberto Ortiz Ch�vez         -----------------------------------
-------------------       Date: 8/04/2020                                ----------------------------------- 
-------------------------------------------------------------------------------------------------------------

--Listar los todos empleados con cargos asignados
CREATE PROC spMostrarHistorialEmpleadoA
AS 
BEGIN	
	
	SELECT  ISNULL(CE.id_detalleCargoEmpleado, 0) as 'NumHistorial', codEmpleado as 'C�digo de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificaci�n', codCargo as 'C�digo de Cargo', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por', autorizado as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observaci�n.') as 'Observaci�n', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'A';
		
END
GO


CREATE PROC spMostrarHistorialEmpleadoI
AS 
BEGIN	
	
	SELECT  ISNULL(CE.id_detalleCargoEmpleado, 0) as 'NumHistorial', codEmpleado as 'C�digo de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificaci�n', codCargo as 'C�digo de Cargo', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por',  ISNULL(autorizado, 'Sin Autorizar.') as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observaci�n.') as 'Observaci�n', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'I';
		
END
GO

--Listar todos los empleados con y sin cargo asignado
CREATE PROC spMostrarEmpleadosTodos
AS
BEGIN

	SELECT  ISNULL(CE.id_detalleCargoEmpleado, 0) as 'NumHistorial',  E.cod_empleado as 'C�digo de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificaci�n', ISNULL(codCargo, 0) as 'C�digo de Cargo', ISNULL(nombre_cargo, 'No asignado') as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', ISNULL(registrado, 'Sin registrar') as 'Registrado Por', ISNULL(autorizado, 'Sin autorizar') as 'Autorizado Por', ISNULL(dtFechaRegis, '1-1-1990') as Registrado, ISNULL(CE.strObservacion, 'Sin observaci�n.') as 'Observaci�n', ISNULL(CE.estado, 'N') as Estado FROM cat_empleado E LEFT JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado  LEFT JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona

END
GO


--Listar todos los empleados sin cargos asignados
CREATE PROC spMostrarEmpleadosNuevos
AS
BEGIN

	SELECT E.cod_empleado as 'C�digo de Empleado', numIdentificacion as 'Identificaci�n' ,strNombre as Nombre, strApellidoRazon as Apellido, dtFechaNacConst as Fecha_Nacimiento, tipoContrato as Tipo_Contrato, ISNULL (E.strObservacion, 'Sin observaci�n') as Observaci�n, fechaReg as Registrado, E.estado as Estado FROM  tbl_detalleCargoEmpleado CE RIGHT JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN cat_persona P ON P.cod_persona = E.codPersona WHERE CE.id_detalleCargoEmpleado IS NULL AND E.estado = 'A';  

END
GO

--B�squedas 
--B�squeda por documento - filtro -> �ndice del filtro utilizado 0 - todos, 1 - activos, 2 - inactivos, 3 - empleados
CREATE PROC spBuscarC�digoEmpleaado
@codigo int,
@filtro int
AS
BEGIN

	IF @filtro = 0
		SELECT ISNULL(CE.id_detalleCargoEmpleado, 0) as 'NumHistorial', E.cod_empleado as 'C�digo de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificaci�n', ISNULL(codCargo, 0) as 'C�digo de Cargo', ISNULL(nombre_cargo, 'No asignado') as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', ISNULL(registrado, 'Sin registrar') as 'Registrado Por', ISNULL(autorizado, 'Sin autorizar') as 'Autorizado Por', ISNULL(dtFechaRegis, '1-1-1990') as Registrado, ISNULL(CE.strObservacion, 'Sin observaci�n.') as 'Observaci�n', ISNULL(CE.estado, 'N') as Estado FROM cat_empleado E LEFT JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado  LEFT JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE cod_empleado = @codigo;
	ELSE IF @filtro = 1
		SELECT CE.id_detalleCargoEmpleado as NumHistorial,  codEmpleado as 'C�digo de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificaci�n', codCargo as 'C�digo de Cargo', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por', autorizado as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observaci�n.') as 'Observaci�n', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'A' AND E.cod_empleado = @codigo;
	ELSE IF @filtro = 2
		SELECT CE.id_detalleCargoEmpleado as NumHistorial,  codEmpleado as 'C�digo de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificaci�n', codCargo as 'C�digo de Cargo', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por', ISNULL(autorizado, 'Sin Autorizar.')  as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observaci�n.') as 'Observaci�n', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'I' AND E.cod_empleado = @codigo;
	ELSE IF @filtro = 3
		SELECT E.cod_empleado as 'C�digo de Empleado', numIdentificacion as 'Identificaci�n' ,strNombre as Nombre, strApellidoRazon as Apellido, dtFechaNacConst as Fecha_Nacimiento, tipoContrato as Tipo_Contrato, ISNULL (E.strObservacion, 'Sin observaci�n') as Observaci�n, fechaReg as Registrado, E.estado as Estado FROM  tbl_detalleCargoEmpleado CE RIGHT JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN cat_persona P ON P.cod_persona = E.codPersona WHERE CE.id_detalleCargoEmpleado IS NULL AND E.estado = 'A' AND E.cod_empleado = @codigo;  

END
GO

CREATE PROC spBuscarNombre
@nombre varchar(60),
@filtro int
AS
BEGIN

	IF @filtro = 0
		SELECT ISNULL(CE.id_detalleCargoEmpleado, 0) as 'NumHistorial', E.cod_empleado as 'C�digo de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificaci�n' , ISNULL(codCargo, 0) as 'C�digo de Cargo', ISNULL(nombre_cargo, 'No asignado') as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', ISNULL(registrado, 'Sin registrar') as 'Registrado Por', ISNULL(autorizado, 'Sin autorizar') as 'Autorizado Por', ISNULL(dtFechaRegis, '1-1-1990') as Registrado, ISNULL(CE.strObservacion, 'Sin observaci�n.') as 'Observaci�n', ISNULL(CE.estado, 'N') as Estado FROM cat_empleado E LEFT JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado  LEFT JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE P.strNombre LIKE @nombre + '%';
	ELSE IF @filtro = 1
		SELECT CE.id_detalleCargoEmpleado as NumHistorial,  codEmpleado as 'C�digo de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificaci�n', codCargo as 'C�digo de Cargo', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por', autorizado as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observaci�n.') as 'Observaci�n', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'A' AND P.strNombre LIKE @nombre + '%';
	ELSE IF @filtro = 2
		SELECT CE.id_detalleCargoEmpleado as NumHistorial,  codEmpleado as 'C�digo de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificaci�n', codCargo as 'C�digo de Cargo', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por', ISNULL(autorizado, 'Sin Autorizar.')  as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observaci�n.') as 'Observaci�n', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'I' AND P.strNombre LIKE @nombre + '%';
	ELSE IF @filtro = 3
		SELECT E.cod_empleado as 'C�digo de Empleado', numIdentificacion as 'Identificaci�n' ,strNombre as Nombre, strApellidoRazon as Apellido, dtFechaNacConst as Fecha_Nacimiento, tipoContrato as Tipo_Contrato, ISNULL (E.strObservacion, 'Sin observaci�n') as Observaci�n, fechaReg as Registrado, E.estado as Estado FROM  tbl_detalleCargoEmpleado CE RIGHT JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN cat_persona P ON P.cod_persona = E.codPersona WHERE CE.id_detalleCargoEmpleado IS NULL AND E.estado = 'A' AND P.strNombre LIKE @nombre + '%';  

END
GO


CREATE PROC spBuscarApellido
@apellido varchar(60),
@filtro int
AS
BEGIN

	IF @filtro = 0
		SELECT ISNULL(CE.id_detalleCargoEmpleado, 0) as 'NumHistorial', E.cod_empleado as 'C�digo de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificaci�n' ,ISNULL(codCargo, 0) as 'C�digo de Cargo', ISNULL(nombre_cargo, 'No asignado') as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', ISNULL(registrado, 'Sin registrar') as 'Registrado Por', ISNULL(autorizado, 'Sin autorizar') as 'Autorizado Por', ISNULL(dtFechaRegis, '1-1-1990') as Registrado, ISNULL(CE.strObservacion, 'Sin observaci�n.') as 'Observaci�n', ISNULL(CE.estado, 'N') as Estado FROM cat_empleado E LEFT JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado  LEFT JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE P.strApellidoRazon LIKE @apellido + '%';
	ELSE IF @filtro = 1
		SELECT CE.id_detalleCargoEmpleado as NumHistorial,  codEmpleado as 'C�digo de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, codCargo as 'C�digo de Cargo', numIdentificacion as 'Identificaci�n', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por', autorizado as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observaci�n.') as 'Observaci�n', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'A' AND P.strApellidoRazon LIKE @apellido + '%';
	ELSE IF @filtro = 2
		SELECT CE.id_detalleCargoEmpleado as NumHistorial,  codEmpleado as 'C�digo de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificaci�n', codCargo as 'C�digo de Cargo', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por', ISNULL(autorizado, 'Sin Autorizar.')  as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observaci�n.') as 'Observaci�n', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'I' AND P.strApellidoRazon LIKE @apellido + '%';
	ELSE IF @filtro = 3
		SELECT E.cod_empleado as 'C�digo de Empleado', numIdentificacion as 'Identificaci�n' ,strNombre as Nombre, strApellidoRazon as Apellido, dtFechaNacConst as Fecha_Nacimiento, tipoContrato as Tipo_Contrato, ISNULL (E.strObservacion, 'Sin observaci�n') as Observaci�n, fechaReg as Registrado, E.estado as Estado FROM  tbl_detalleCargoEmpleado CE RIGHT JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN cat_persona P ON P.cod_persona = E.codPersona WHERE CE.id_detalleCargoEmpleado IS NULL AND E.estado = 'A' AND P.strApellidoRazon LIKE @apellido + '%';  

END
GO

CREATE PROC spBuscarCargo
@cargo varchar(50),
@filtro int
AS
BEGIN
	
	IF @filtro = 0
		SELECT ISNULL(CE.id_detalleCargoEmpleado, 0) as 'NumHistorial', E.cod_empleado as 'C�digo de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificaci�n' ,ISNULL(codCargo, 0) as 'C�digo de Cargo', ISNULL(nombre_cargo, 'No asignado') as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', ISNULL(registrado, 'Sin registrar') as 'Registrado Por', ISNULL(autorizado, 'Sin autorizar') as 'Autorizado Por', ISNULL(dtFechaRegis, '1-1-1990') as Registrado, ISNULL(CE.strObservacion, 'Sin observaci�n.') as 'Observaci�n', ISNULL(CE.estado, 'N') as Estado FROM cat_empleado E LEFT JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado  LEFT JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE C.nombre_cargo LIKE @cargo + '%';
	ELSE IF @filtro = 1
		SELECT CE.id_detalleCargoEmpleado as NumHistorial,  codEmpleado as 'C�digo de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificaci�n', codCargo as 'C�digo de Cargo', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por', autorizado as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observaci�n.') as 'Observaci�n', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'A' AND C.nombre_cargo LIKE @cargo + '%';
	ELSE IF @filtro = 2
		SELECT CE.id_detalleCargoEmpleado as NumHistorial,  codEmpleado as 'C�digo de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificaci�n', codCargo as 'C�digo de Cargo', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por', ISNULL(autorizado, 'Sin Autorizar.')  as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observaci�n.') as 'Observaci�n', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'I' AND C.nombre_cargo LIKE @cargo + '%';

END
GO

--Guardar historial Sin autorizar

CREATE PROC spGuardarHistorial
@codEmpleado int,
@codCargo int,
@registrado varchar(80),
@observacion varchar(300),
@mensaje varchar(50) out
AS
BEGIN

	DECLARE @numHistorial INT

	SELECT @numHistorial = ISNULL(MAX(id_detalleCargoEmpleado), 0) + 1 FROM tbl_detalleCargoEmpleado
	
	INSERT INTO tbl_detalleCargoEmpleado (id_detalleCargoEmpleado, codEmpleado, codCargo, registrado, strObservacion, estado) 
	VALUES (@numHistorial, @codEmpleado, @codCargo, @registrado, @observacion, 'I')

	SET @mensaje = 'Se ha guardado el historial.';

END
GO

--Guardar Hisgorial Autorizar
CREATE PROC spGuardarAutorizarHistorial
@codEmpleado int,
@codCargo int,
@registrado varchar(80),
@autorizado varchar(80),
@observacion varchar(300),
@mensaje varchar(50) out
AS
BEGIN
	
	If(Exists(SELECT id_detalleCargoEmpleado FROM tbl_detalleCargoEmpleado WHERE codEmpleado = @codEmpleado AND estado = 'A'))
		Set @Mensaje='El empleado posee un cargo asignado activo.'
	ELSE
	BEGIN
		DECLARE @numHistorial INT

		SELECT @numHistorial = ISNULL(MAX(id_detalleCargoEmpleado), 0) + 1 FROM tbl_detalleCargoEmpleado

		INSERT INTO tbl_detalleCargoEmpleado (id_detalleCargoEmpleado, codEmpleado, codCargo, registrado, autorizado, strObservacion, estado) 
		VALUES(@numHistorial, @codEmpleado, @codCargo, @registrado, @autorizado, @observacion, 'A');

		SET @mensaje = 'Se ha guardado el historial.';
	END
END
GO


CREATE PROC spActualizarHistorial
@idDetalle int,
@observacion varchar(300),
@autorizado  varchar(80),
@estado char(1),
@mensaje varchar(80) out
AS
BEGIN
	
	--Estado Actual del registro
	DECLARE @estado1 CHAR(1)

	IF(NOT EXISTS(SELECT id_detalleCargoEmpleado FROM tbl_detalleCargoEmpleado WHERE id_detalleCargoEmpleado = @idDetalle))
		SET @mensaje = 'El historial no se encuentra registrado.';
	ELSE 
		SELECT @estado1 = estado FROM tbl_detalleCargoEmpleado WHERE id_detalleCargoEmpleado = @idDetalle;

		 IF @estado1 = 'I' AND @estado = 'A'
		 BEGIN

			UPDATE tbl_detalleCargoEmpleado SET strObservacion = @observacion, autorizado = @autorizado, estado = @estado WHERE id_detalleCargoEmpleado = @idDetalle;
			SET @mensaje = 'Se ha actualizado el historial. Se ha autorizado la asignaci�n.';
		 
		 END
		 ELSE IF @estado1 = 'A' AND @estado = 'I'
		 BEGIN
			
			UPDATE tbl_detalleCargoEmpleado SET strObservacion = @observacion, estado = @estado WHERE id_detalleCargoEmpleado = @idDetalle;
			SET @mensaje = 'Se ha actualizado el historial. Se ha anulado la asignaci�n.';

		 END	
		 ELSE IF @estado = @estado1
		 BEGIN
			
			UPDATE tbl_detalleCargoEmpleado SET strObservacion = @observacion WHERE id_detalleCargoEmpleado = @idDetalle;
			SET @mensaje = 'Se ha actualizado el historial.';
		 
		 END
END
GO

CREATE PROC spAutorizarHistorial
@idDetalle	int,
@autorizar	varchar(80),
@mensaje	varchar(50) out
AS
BEGIN
	


	IF(NOT EXISTS(SELECT id_detalleCargoEmpleado FROM tbl_detalleCargoEmpleado WHERE id_detalleCargoEmpleado = @idDetalle))
		SET @mensaje = 'No fue posible realizar la operaci�n. El Historial no se encuentra registrado';
	IF(EXISTS(SELECT * FROM tbl_detalleCargoEmpleado WHERE id_detalleCargoEmpleado = @idDetalle and estado = 'I'))
	BEGIN	
			
		UPDATE tbl_detalleCargoEmpleado SET autorizado = @autorizar, estado = 'A' WHERE id_detalleCargoEmpleado = @idDetalle;
		SET @mensaje = 'Se ha autorizado la asignaci�n de cargo.';
		
	END
	ELSE
		SET @mensaje = 'No se ha podido autorizar la asignaci�n de cargo. Ya se encuentra activo.';
END
GO

CREATE PROC spAnularHistorial
@idDetalle int,
@mensaje varchar(50) out
AS
BEGIN
	DECLARE @estado CHAR(1)

	IF(NOT EXISTS (SELECT id_detalleCargoEmpleado  FROM tbl_detalleCargoEmpleado WHERE id_detalleCargoEmpleado = @idDetalle))
		SET @mensaje = 'No fue posible realizar la operaci�n. El Historial no se encuentra registrado'
	ELSE IF (EXISTS (SELECT id_detalleCargoEmpleado FROM tbl_detalleCargoEmpleado WHERE id_detalleCargoEmpleado = @idDetalle AND estado = 'A'))
	BEGIN

		UPDATE tbl_detalleCargoEmpleado SET estado = 'I' WHERE id_detalleCargoEmpleado = @idDetalle;
		SET @mensaje = 'Se ha anulado el cargo';
	
	END
	ELSE
		SET @mensaje = 'No se ha podido anular el cargo. Ya se encuentra Inactivo.';

END
GO


-----------------------------------procedimiento de Usuarios----------------------------------------------------
-------------------       Created by: Santos Alberto Ortiz Ch�vez         -----------------------------------
-------------------       Date: 14/04/2020                                ----------------------------------- 
-------------------------------------------------------------------------------------------------------------

--Usuarios
CREATE PROC spListarUsuarios
AS
	SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificaci�n, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, U.pass AS Contrase�a, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observaci�n.') AS Observaci�n, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo;                                                                                                                                                                                                                                   
GO


CREATE PROC spListarUsuariosA
AS
	SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificaci�n, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, U.pass AS Contrase�a, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observaci�n.') AS Observaci�n, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE U.estado = 'A';
GO

CREATE PROC spListarUsuariosI
AS
	SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificaci�n, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, U.pass AS Contrase�a, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observaci�n.') AS Observaci�n, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE U.estado = 'I';
GO

--Listar empleados activos con historial activo que no tienen usuario asignado
CREATE PROC spListarEmpleados
AS
	SELECT E.cod_empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon AS Apellido, P.numIdentificacion AS Identificaci�n, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, CE.estado AS Estado FROM cat_usuario U RIGHT JOIN tbl_detalleCargoEmpleado CE ON U.empleado = CE.codEmpleado JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN cat_persona P ON E.codPersona = P.cod_persona JOIN cat_cargo C ON CE.codCargo = C.id_cargo  WHERE U.estado IS NULL and CE.estado = 'A'
GO

--anterior
CREATE PROC spNuevoUsuario
@codEmpleado	int,
@rol			int,
@usuario		varchar(100),
@contrase�a		varchar(100),
@registrado		varchar(80),
@autorizado		varchar(80),
@observacion	varchar(300),
@estado			char(1),
@mensaje		varchar(80) out
AS
BEGIN
	
		IF(EXISTS(SELECT cod_usuario FROM cat_usuario WHERE empleado = @codEmpleado))
			SET @mensaje='El empleado ya tiene asignado un usuario.';
		ELSE IF(EXISTS(SELECT cod_usuario FROM cat_usuario WHERE contrase�a = @contrase�a))
			SET @mensaje='Contrase�a no v�lida. Intente con una nueva';
		ELSE
		BEGIN
		
			DECLARE @codUsuario INT;

			SELECT @codUsuario = ISNULL(MAX(cod_usuario), 0) + 1 FROM cat_usuario;

			

			IF @estado = 'A'
			BEGIN
				
				INSERT INTO dbo.cat_usuario  (cod_usuario, empleado, rolacceso, usuario, contrase�a, pass, registrado, autorizado, strObservacion, estado)
				VALUES (@codUsuario, @codEmpleado, @rol, @usuario, ENCRYPTBYPASSPHRASE('SuperSeguridad' ,@contrase�a), @contrase�a, @registrado, @autorizado, @observacion, @estado);
				
				SET @mensaje = 'Se ha registrado nuevo usuario. Se ha Autorizado el usuario.';

				
				IF(NOT EXISTS(SELECT id_control_acceso FROM tbl_control_acceso WHERE usuario = @codUsuario))
				BEGIN
					INSERT INTO tbl_control_acceso (usuario, estadoacceso) VALUES (@codUsuario, 'c')
				END
				
			END
			ELSE IF @estado = 'I'
			BEGIN
				
				INSERT INTO cat_usuario (cod_usuario, empleado, rolacceso, usuario, contrase�a, pass, registrado, strObservacion, estado)
				VALUES (@codUsuario, @codEmpleado, @rol, @usuario, ENCRYPTBYPASSPHRASE('SuperSeguridad' ,@contrase�a), @contrase�a, @registrado, @observacion, @estado);	
				
				SET @mensaje = 'Se ha registrado nuevo usuario. Debe ser autorizado por un usuario autorizado.';
			
			END
			

		END
END
GO
--actual
CREATE PROC spNuevoUsuario
@codEmpleado	int,
@rol			int,
@usuario		varchar(100),
@contrase�a		varchar(100),
@registrado		varchar(80),
@autorizado		varchar(80),
@observacion	varchar(300),
@estado			char(1),
@mensaje		varchar(80) out
AS
BEGIN
	
		IF(EXISTS(SELECT cod_usuario FROM cat_usuario WHERE empleado = @codEmpleado))
			SET @mensaje='El empleado ya tiene asignado un usuario.';
		ELSE IF(EXISTS(SELECT cod_usuario FROM cat_usuario WHERE pass = @contrase�a))
			SET @mensaje='Contrase�a no v�lida. Intente con una nueva';
		ELSE
		BEGIN
		
			DECLARE @codUsuario INT;

			SELECT @codUsuario = ISNULL(MAX(cod_usuario), 0) + 1 FROM cat_usuario;

			DECLARE @codControl INT;

			SELECT @codControl = ISNULL(MAX(idControl), 0) + 1 FROM tblControlCredenciales;

			IF @estado = 'A'
			BEGIN
				--agrega el usuario
				INSERT INTO dbo.cat_usuario  (cod_usuario, empleado, rolacceso, usuario,  pass, registrado, autorizado, strObservacion, estado)
				VALUES (@codUsuario, @codEmpleado, @rol, @usuario, @contrase�a, @registrado, @autorizado, @observacion, @estado);
				--registra sus credenciales actuales
				INSERT INTO tblControlCredenciales(idControl, codUsuario, strUsuario, strPass, chrEstado)
				VALUES(@codControl, @codUsuario, @usuario, @contrase�a, 'A')
					
				SET @mensaje = 'Se ha registrado nuevo usuario. Se ha Autorizado el usuario.';

			
			END
			ELSE IF @estado = 'I'
			BEGIN
				--agregar nuevo usuario
				INSERT INTO cat_usuario (cod_usuario, empleado, rolacceso, usuario, pass, registrado, strObservacion, estado)
				VALUES (@codUsuario, @codEmpleado, @rol, @usuario, @contrase�a, @registrado, @observacion, @estado);	
				--registra sus credenciales actuales
				INSERT INTO tblControlCredenciales(idControl, codUsuario, strUsuario, strPass, chrEstado)
				VALUES(@codControl, @codUsuario, @usuario, @contrase�a, 'A')

				SET @mensaje = 'Se ha registrado nuevo usuario. Debe ser autorizado por un usuario autorizado.';
			
			END
			

		END
END
GO

--Anterior
CREATE PROC spActualizarUsuario
@codUsuario		int,
@rol			int,
@usuario		varchar(100),
@contrase�a		varchar(100),
@autorizado		varchar(80),
@observacion	varchar(300),
@estado			char(1),
@mensaje		varchar(80) out
AS
BEGIN
	IF(NOT EXISTS(SELECT cod_usuario FROM cat_usuario WHERE cod_usuario = @codUsuario))
		SET @mensaje = 'El usuario no se encuentra registrado.';
	ELSE
	BEGIN
		
		DECLARE @contrase�aA VARCHAR(100)
		SELECT @contrase�aA = pass FROM cat_usuario WHERE cod_usuario = @codUsuario;

		IF @estado = 'A'
		BEGIN
			
			IF @contrase�aA = @contrase�a
			BEGIN
				UPDATE cat_usuario SET rolacceso = @rol, usuario = @usuario, autorizado = @autorizado, strObservacion = @observacion, estado = @estado WHERE cod_usuario = @codUsuario;
				SET @mensaje = 'Se ha actualizado el usuario. Se ha autorizado el usuario.'
			END
			ELSE
			BEGIN
				UPDATE cat_usuario SET rolacceso = @rol, usuario = @usuario, autorizado = @autorizado, strObservacion = @observacion, estado = @estado, contrase�a = ENCRYPTBYPASSPHRASE('SuperSeguridad' ,@contrase�a), pass = @contrase�a  WHERE cod_usuario = @codUsuario;
				SET @mensaje = 'Se ha actualizado el usuario. Se ha autorizado. Se ha actualizado la contrase�a.'
			END

			IF(NOT EXISTS(SELECT id_control_acceso FROM tbl_control_acceso WHERE usuario = @codUsuario))
			BEGIN
				INSERT INTO tbl_control_acceso (usuario, estadoacceso) VALUES (@codUsuario, 'c')
			END

		END
		ELSE IF @estado = 'I'
		BEGIN
			IF @contrase�aA = @contrase�a
			BEGIN
				UPDATE cat_usuario SET rolacceso = @rol, usuario = @usuario, autorizado = @autorizado, strObservacion = @observacion, estado = @estado WHERE cod_usuario = @codUsuario;
				SET @mensaje = 'Se ha actualizado el usuario. Se ha anulado el usuario.'
			END
			ELSE
			BEGIN
				UPDATE cat_usuario SET rolacceso = @rol, usuario = @usuario, autorizado = @autorizado, strObservacion = @observacion, estado = @estado, contrase�a = ENCRYPTBYPASSPHRASE('SuperSeguridad' ,@contrase�a), pass = @contrase�a  WHERE cod_usuario = @codUsuario;
				SET @mensaje = 'Se ha actualizado el usuario. Se ha actualizado la contrase�a. Se ha anulado el usuario.'
			END

		END
	END
END
GO

--actual
CREATE PROC spActualizarUsuario
@codUsuario		int,
@rol			int,
@usuario		varchar(100),
@contrase�a		varchar(100),
@autorizado		varchar(80),
@observacion	varchar(300),
@estado			char(1),
@mensaje		varchar(80) out
AS
BEGIN
	IF(NOT EXISTS(SELECT cod_usuario FROM cat_usuario WHERE cod_usuario = @codUsuario))
		SET @mensaje = 'El usuario no se encuentra registrado.';
	ELSE
	BEGIN
		
		DECLARE @contrase�aA VARCHAR(100)
		SELECT @contrase�aA = pass FROM cat_usuario WHERE cod_usuario = @codUsuario;

		DECLARE @usuarioA VARCHAR(100)
		SELECT @usuarioA = usuario FROM cat_usuario WHERE cod_usuario = @codUsuario;

		IF @estado = 'A'
		BEGIN
			
			
			DECLARE @codControl INT;

			SELECT @codControl = ISNULL(MAX(idControl), 0) + 1 FROM tblControlCredenciales;
			
			IF @contrase�aA = @contrase�a AND @usuario = @usuarioA
			BEGIN
				UPDATE cat_usuario SET rolacceso = @rol, autorizado = @autorizado, strObservacion = @observacion, estado = @estado WHERE cod_usuario = @codUsuario;
					
				SET @mensaje = 'Se ha actualizado el usuario. Se ha autorizado el usuario.'

			END
			ELSE
			BEGIN
				IF @contrase�aA = @contrase�a
					SET @mensaje = 'No se ha actualizado el usuario. Ingrese una nueva contrase�a.'
				ELSE
					BEGIN
						--Si no son iguales ya sea el usuario o contrase�a, se actualizan
						UPDATE cat_usuario SET rolacceso = @rol, usuario = @usuario, autorizado = @autorizado, strObservacion = @observacion, estado = @estado, pass = @contrase�a  WHERE cod_usuario = @codUsuario;
				
						--Anulan credenciales actuales
						UPDATE tblControlCredenciales SET chrEstado = 'I' WHERE codUsuario = @codUsuario AND chrEstado = 'A'

						--Se definen nuevas credenciales
						INSERT INTO tblControlCredenciales (idControl, codUsuario, strUsuario, strPass, chrEstado)
						VALUES(@codControl, @codUsuario, @usuario, @contrase�a, 'A')
				
						SET @mensaje = 'Se ha actualizado el usuario y sus credenciales de acceso. Se ha autorizado.'
					END
			END

		END
		ELSE IF @estado = 'I'
		BEGIN
			IF @contrase�aA = @contrase�a AND @usuarioA = @usuario
			BEGIN
				UPDATE cat_usuario SET rolacceso = @rol, autorizado = @autorizado, strObservacion = @observacion, estado = @estado WHERE cod_usuario = @codUsuario;
				SET @mensaje = 'Se ha actualizado el usuario. Se ha anulado el usuario.'
			END
			ELSE
			BEGIN
				IF @contrase�aA = @contrase�a
					SET @mensaje = 'No se ha actualizado el usuario. Debe ingresar una nueva contrase�a.'
				ELSE
					BEGIN
						--Actualiza el usuario
						UPDATE cat_usuario SET rolacceso = @rol, usuario = @usuario, autorizado = @autorizado, strObservacion = @observacion, estado = @estado, pass = @contrase�a  WHERE cod_usuario = @codUsuario;
				
						--Anulan credenciales actuales
						UPDATE tblControlCredenciales SET chrEstado = 'I' WHERE codUsuario = @codUsuario AND chrEstado = 'A'

						--Se definen nuevas credenciales
						INSERT INTO tblControlCredenciales (idControl, codUsuario, strUsuario, strPass, chrEstado)
						VALUES(@codControl, @codUsuario, @usuario, @contrase�a, 'A')
			
						SET @mensaje = 'Se ha actualizado el usuario y sus credenciales de acceso. Se ha anulado el usuario.'
					END
			END

		END
	END
END
GO

CREATE PROC spBuscarCodUsuario
@usuario INT,
@filtro INT
AS
BEGIN
	
	IF @filtro = 0
		SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificaci�n, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, U.pass AS Contrase�a, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observaci�n.') AS Observaci�n, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE U.cod_usuario = @usuario;
	ELSE IF @filtro = 1
		SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificaci�n, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, U.pass AS Contrase�a, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observaci�n.') AS Observaci�n, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE u.cod_usuario = @usuario AND U.estado = 'A';
	ELSE IF @filtro = 2
		SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificaci�n, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, U.pass AS Contrase�a, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observaci�n.') AS Observaci�n, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE u.cod_usuario = @usuario AND U.estado = 'I';
	ELSE IF @filtro = 3
		SELECT E.cod_empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon AS Apellido, P.numIdentificacion AS Identificaci�n, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, CE.estado AS Estado FROM cat_usuario U RIGHT JOIN tbl_detalleCargoEmpleado CE ON U.empleado = CE.codEmpleado JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN cat_persona P ON E.codPersona = P.cod_persona JOIN cat_cargo C ON CE.codCargo = C.id_cargo  WHERE U.estado IS NULL and CE.estado = 'A' AND E.cod_empleado = @usuario;

END
GO

CREATE PROC spBuscarNombreUsuario
@usuario varchar(100),
@filtro int
AS
BEGIN
	
	IF @filtro = 0
		SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificaci�n, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, U.pass AS Contrase�a, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observaci�n.') AS Observaci�n, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE u.usuario LIKE @usuario + '%';
	ELSE IF @filtro = 1
		SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificaci�n, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, U.pass AS Contrase�a, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observaci�n.') AS Observaci�n, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE u.cod_usuario LIKE @usuario + '%' AND U.estado = 'A';
	ELSE IF @filtro = 2
		SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificaci�n, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, U.pass AS Contrase�a, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observaci�n.') AS Observaci�n, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE u.cod_usuario LIKE @usuario + '%' AND U.estado = 'I';
END
GO

CREATE PROC spBuscarUsuarioNombre
@nombre varchar(60),
@filtro int
AS
BEGIN
	
	IF @filtro = 0
		SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificaci�n, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, U.pass AS Contrase�a, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observaci�n.') AS Observaci�n, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE P.strNombre LIKE @nombre + '%';
	ELSE IF @filtro = 1
		SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificaci�n, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, U.pass AS Contrase�a, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observaci�n.') AS Observaci�n, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE P.strNombre LIKE @nombre + '%' AND U.estado = 'A';
	ELSE IF @filtro = 2
		SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificaci�n, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, U.pass AS Contrase�a, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observaci�n.') AS Observaci�n, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE P.strNombre LIKE @nombre + '%' AND U.estado = 'I';
	ELSE IF @filtro = 3
		SELECT E.cod_empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon AS Apellido, P.numIdentificacion AS Identificaci�n, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, CE.estado AS Estado FROM cat_usuario U RIGHT JOIN tbl_detalleCargoEmpleado CE ON U.empleado = CE.codEmpleado JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN cat_persona P ON E.codPersona = P.cod_persona JOIN cat_cargo C ON CE.codCargo = C.id_cargo  WHERE U.estado IS NULL and CE.estado = 'A' AND P.strNombre LIKE @nombre + '%'

END
GO


-----------------------------------procedimiento de Roles----------------------------------------------------
-------------------       Created by: Santos Alberto Ortiz Ch�vez         -----------------------------------
-------------------       Date: 14/04/2020                                ----------------------------------- 
-------------------------------------------------------------------------------------------------------------
select * from cat_usuario

--Roles
CREATE PROC spMostrarRoles
AS
BEGIN
	SELECT id_rolacceso AS ID, rol AS Rol, descripcion AS Descripci�n, registrado as Registrador_Por ,fechaing AS FechaRegistro, estado AS Estado FROM tbl_rolacceso
END
GO

CREATE PROC spMostrarRolesA
AS 
BEGIN

	SELECT id_rolacceso AS ID, rol AS Rol, descripcion AS Descripci�n, registrado as Registrador_Por ,fechaing AS FechaRegistro, estado AS Estado FROM tbl_rolacceso WHERE estado = 'A' ORDER BY rol ASC;

END
GO

CREATE PROC spMostrarRolesI
AS
BEGIN

	SELECT id_rolacceso AS ID, rol AS Rol, descripcion AS Descripci�n, registrado as Registrador_Por ,fechaing AS FechaRegistro, estado AS Estado FROM tbl_rolacceso WHERE estado = 'I';

END
GO

CREATE PROC spInsertarRol
@rol varchar(50),
@descrip varchar(120),
@registrado varchar(40),
@estado char(1),
@mensaje varchar(50) out
AS
BEGIN
	IF(EXISTS(SELECT * FROM tbl_rolacceso WHERE rol = @rol))
		BEGIN
			SET @mensaje = 'El rol ya se encuentra registrado.';
		END
	ELSE
		BEGIN
			
			DECLARE @codRol int

			SELECT @codRol = ISNULL(MAX(id_rolacceso), 0) + 1 FROM tbl_rolacceso

			INSERT INTO tbl_rolacceso (id_rolacceso, rol, descripcion, registrado, estado)
			VALUES (@codRol, @rol, @descrip, @registrado, @estado);
			SET @mensaje = 'El rol ha sido registrado correctamente.';
		END
END
GO

CREATE PROC spActualizarRol
@id INT,
@rol VARCHAR(50),
@descrip VARCHAR(120),
@estado CHAR(1),
@mensaje VARCHAR(50) OUT
AS
BEGIN
	IF(NOT EXISTS(SELECT * From tbl_rolacceso Where id_rolacceso = @id))
		SET @mensaje='El rol no se encuentra registrado.'
	ELSE
		BEGIN
			UPDATE tbl_rolacceso SET rol = @rol, descripcion = @descrip, estado = @estado  Where id_rolacceso = @id
			SET @mensaje='Se ha Actualizado los Datos Correctamente.'
		END
		
END
GO


CREATE PROC spBuscarRolNombre
@textobuscar varchar(50)
AS
BEGIN

	SELECT  id_rolacceso AS ID, rol AS Rol, descripcion AS Descripci�n, registrado as Registrador_Por ,fechaing AS FechaRegistro, estado AS Estado FROM tbl_rolacceso WHERE rol LIKE @textobuscar + '%';

END
GO

--control de acceso
--mostrar acceso

CREATE PROC spControlAcceso
@usuario varchar(100),
@contrase�a varchar(100)
AS
BEGIN
	
		DECLARE @idControlAcceso INT
		SELECT @idControlAcceso = ISNULL(MAX(id_control_acceso), 0) + 1 FROM tbl_control_acceso

		DECLARE @codUsuario INT
		SELECT @codUsuario = cod_usuario FROM cat_usuario WHERE usuario = @usuario 

	--evalua si credenciales son correctas y su estado de usuario es activo
	IF(EXISTS(SELECT cod_usuario FROM cat_usuario WHERE usuario = @usuario AND pass = @contrase�a AND estado = 'A'))
	BEGIN
		--Si esta conectado se bloquea
		IF(EXISTS(SELECT * FROM tbl_control_acceso WHERE usuario = @codUsuario AND estadoacceso = 'C'))
			BEGIN
				
				--Bloquear conexion
				UPDATE tbl_control_acceso SET estadoacceso = 'B' WHERE usuario = @codUsuario AND estadoacceso = 'C' 
				
				--Deshabilitar usuario
				UPDATE cat_usuario SET estado = 'I' WHERE cod_usuario = @codUsuario

			END
		ELSE -- si no esta conectado, se crea nuevo acceso
			BEGIN
			
				INSERT INTO tbl_control_acceso (id_control_acceso, usuario, estadoacceso)
				VALUES(@idControlAcceso, @codUsuario, 'C')


			END
		
	END
	ELSE IF(EXISTS(SELECT cod_usuario FROM cat_usuario WHERE usuario = @usuario AND pass = @contrase�a AND estado = 'I'))
	BEGIN
	
		INSERT INTO tbl_control_acceso VALUES (@idControlAcceso, @codUsuario, 'B', GETDATE(), GETDATE())

	END
		
END

exec spMostrarHistorialAcceso

	SELECT TOP 1 id_control_acceso AS 'ID Conexion', C.usuario AS 'CodUsuario', U.usuario AS 'Usuario', estadoacceso AS 'Estado Conexi�n', dtConexion AS 'Conectado', ISNULL(dtDesconexion, getdate()) AS 'Desconectado' FROM tbl_control_acceso C JOIN cat_usuario U ON C.usuario = U.cod_usuario ORDER BY dtConexion DESC


CREATE PROC spMostrarHistorialAcceso
AS
BEGIN

	SELECT id_control_acceso AS 'ID Conexion', C.usuario AS 'CodUsuario', U.usuario AS 'Usuario', estadoacceso AS 'Estado Conexi�n', dtConexion AS 'Conectado', ISNULL(dtDesconexion, dtConexion) AS 'Desconectado' FROM tbl_control_acceso C JOIN cat_usuario U ON C.usuario = U.cod_usuario ORDER BY dtConexion DESC

END
GO
select * from cat_usuario
EXEC spMostrarHistorialAcceso

CREATE PROC spMostrarHistorialConectado
AS
BEGIN
		SELECT id_control_acceso AS 'ID Conexion', C.usuario AS 'CodUsuario', U.usuario AS 'Usuario', estadoacceso AS 'Estado Conexi�n', dtConexion AS 'Conectado', ISNULL(dtDesconexion, dtConexion) AS 'Desconectado' FROM tbl_control_acceso C JOIN cat_usuario U ON C.usuario = U.cod_usuario WHERE estadoacceso = 'C' ORDER BY dtConexion DESC 
END
GO

CREATE PROC spMostrarHistorialDesconectado
AS
BEGIN
			SELECT id_control_acceso AS 'ID Conexion', C.usuario AS 'CodUsuario', U.usuario AS 'Usuario', estadoacceso AS 'Estado Conexi�n', dtConexion AS 'Conectado', ISNULL(dtDesconexion, dtConexion) AS 'Desconectado' FROM tbl_control_acceso C JOIN cat_usuario U ON C.usuario = U.cod_usuario WHERE estadoacceso = 'D' ORDER BY dtConexion DESC 
END
GO

CREATE PROC spMostrarHistorialBloqueado
AS
BEGIN

	SELECT id_control_acceso AS 'ID Conexion', C.usuario AS 'CodUsuario', U.usuario AS 'Usuario', estadoacceso AS 'Estado Conexi�n', dtConexion AS 'Conectado', ISNULL(dtDesconexion, dtConexion) AS 'Desconectado' FROM tbl_control_acceso C JOIN cat_usuario U ON C.usuario = U.cod_usuario WHERE estadoacceso = 'B' ORDER BY dtConexion DESC 

END
GO

CREATE PROC spBuscarConexion
@usuario VARCHAR(100),
@filtro int
AS 
BEGIN
	
	IF @filtro = 0
			SELECT id_control_acceso AS 'ID Conexion', C.usuario AS 'CodUsuario', U.usuario AS 'Usuario', estadoacceso AS 'Estado Conexi�n', dtConexion AS 'Conectado', ISNULL(dtDesconexion, dtConexion) AS 'Desconectado' FROM tbl_control_acceso C JOIN cat_usuario U ON C.usuario = U.cod_usuario WHERE U.usuario LIKE @usuario + '%' ORDER BY dtConexion DESC
	ELSE IF @filtro = 1
			SELECT id_control_acceso AS 'ID Conexion', C.usuario AS 'CodUsuario', U.usuario AS 'Usuario', estadoacceso AS 'Estado Conexi�n', dtConexion AS 'Conectado', ISNULL(dtDesconexion, dtConexion) AS 'Desconectado' FROM tbl_control_acceso C JOIN cat_usuario U ON C.usuario = U.cod_usuario WHERE U.usuario LIKE @usuario + '%' AND estadoacceso = 'B' ORDER BY dtConexion DESC 
	ELSE IF @filtro = 2
			SELECT id_control_acceso AS 'ID Conexion', C.usuario AS 'CodUsuario', U.usuario AS 'Usuario', estadoacceso AS 'Estado Conexi�n', dtConexion AS 'Conectado', ISNULL(dtDesconexion, dtConexion) AS 'Desconectado' FROM tbl_control_acceso C JOIN cat_usuario U ON C.usuario = U.cod_usuario WHERE U.usuario LIKE @usuario + '%' AND estadoacceso = 'C' ORDER BY dtConexion DESC 
	ELSE IF @filtro = 3
			SELECT id_control_acceso AS 'ID Conexion', C.usuario AS 'CodUsuario', U.usuario AS 'Usuario', estadoacceso AS 'Estado Conexi�n', dtConexion AS 'Conectado', ISNULL(dtDesconexion, dtConexion) AS 'Desconectado' FROM tbl_control_acceso C JOIN cat_usuario U ON C.usuario = U.cod_usuario WHERE U.usuario LIKE @usuario + '%' AND estadoacceso = 'D' ORDER BY dtConexion DESC 

END
GO

CREATE PROC spDesconectar
@conexion INT
@usuario  VARCHAR(100)
AS
BEGIN
	
	IF

END

select * from cat_usuario
EXEC spControlAcceso 'Admin-1', 'Administrador1234'
update cat_usuario set estado = 'A' where cod_usuario = 1
exec spMostrarHistorialAcceso
exec spCerrarCesion 'Admin-1'

CREATE PROC spCerrarCesion
@strUsuario VARCHAR(100)
AS
BEGIN
	
	--obtiene el id de usuario
	DECLARE @codUsuario INT
	SELECT @codUsuario = cod_usuario FROM cat_usuario WHERE usuario = @strUsuario

	--actualiza el estado
	UPDATE tbl_control_acceso SET estadoacceso = 'D', dtDesconexion = GETDATE() WHERE usuario = @codUsuario AND estadoacceso = 'C';

END
GO

--Cambiar contrase�a
CREATE PROC spCambiarCredenciales
@strUsuarioA		VARCHAR(100),
@strUsuarioN		VARCHAR(100),
@strContrase�aA		VARCHAR(100),
@strContrase�aN		VARCHAR(100),
@mensaje			VARCHAR(80) OUT
AS
BEGIN

	--validar que la nueva y vieja sean distintas
	IF(NOT EXISTS(SELECT cod_usuario FROM cat_usuario WHERE usuario = @strUsuarioA AND pass = @strContrase�aA))
		SET @mensaje = 'Debe ingresar sus credenciales activas para actualizarlas.'
	ELSE IF(EXISTS(SELECT idControl FROM tblControlCredenciales WHERE strPass = @strContrase�aN))
		SET @mensaje = 'Debe ingresar una contrase�a distinta.';
	ELSE
		BEGIN
			
			BEGIN TRANSACTION
				
				DECLARE @NError INT;
				DECLARE @codUsuario INT;
				DECLARE @codControl INT;

				SELECT @codUsuario = cod_usuario FROM cat_usuario WHERE usuario = @strUsuarioA;
				SELECT @codControl = ISNULL(MAX(idControl), 0) + 1 FROM tblControlCredenciales;

				--actualizar usuario con nuevas credenciales
				UPDATE cat_usuario SET usuario = @strUsuarioN, pass = @strContrase�aN WHERE cod_usuario = @codUsuario;
				--Evalua ocurrencia de error
				SET @NError = @@ERROR
				IF (@NError <> 0) GOTO Error

				--Desactivar credenciales anteriores
				UPDATE tblControlCredenciales SET chrEstado = 'I' WHERE codUsuario = @codUsuario AND chrEstado = 'A';
				
				SET @NError = @@ERROR
				IF (@NError <> 0) GOTO Error
				
				--Agregar nuevas credenciales a control
				INSERT INTO tblControlCredenciales (idControl, codUsuario, strUsuario, strPass, chrEstado)
				VALUES(@codControl, @codUsuario, @strUsuarioN, @strContrase�aN, 'A')
				
				SET @NError = @@ERROR
				IF (@NError <> 0) GOTO Error

				--SI SE REALIZ� CORRECTAMENTE
				SET @mensaje = 'Se han actualizado las credenciales de acceso.';
				COMMIT TRAN

				--Si existe alg�n error
				Error:
				IF @NError <> 0
				BEGIN
					
					SET @mensaje = 'Error al momento de actualizar los datos del empleado'
					
					ROLLBACK TRAN
				
				END
		END

END

select * from tbl_control_acceso
select * from cat_usuario
update cat_usuario set estado = 'A' where cod_usuario = 1
cd0d59058ed2ea40b916cd9c62c02fbb9025a681b0ce173de5808d44825c6e9b SuperMendax#1 
SuperMendax#2