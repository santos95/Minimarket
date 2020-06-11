USE MASTER
GO

CREATE DATABASE dbventasProyectTer
GO

USE dbventasProyectTer
GO


--Tabla persona
CREATE TABLE cat_persona
(
	cod_persona			INT PRIMARY KEY NOT NULL,
	chrTipoPersona		CHAR(1) CHECK (chrTipoPersona in ('J','N')),
	chrTipoIdent		CHAR(3) CHECK (chrTipoIdent in ('CED','PAS', 'RUC')),
	numIdentificacion	NVARCHAR(20) UNIQUE NOT NULL,
	strNombre			VARCHAR(60) NOT NULL,
	strApellidoRazon	NVARCHAR(60) NOT NULL,
	dtFechaNacConst		DATE NULL,
	chrGenero			CHAR(1) CHECK (chrGenero IN('M','F','N')),  
	chrEstadoCivilNat	CHAR(1) CHECK (chrEstadoCivilNat IN('S','C','D', 'V', 'P', 'E', 'M')),	--soltero, casado, divorciado, viudo, privado, estatal, mixta
	strDireccion		VARCHAR(300) NULL,
)
GO

--Control de cargos
CREATE TABLE cat_cargo
(
id_cargo			int primary key, --identity da muchos problemas
nombre_cargo		varchar(50) not null,
descripcion_cargo	varchar(200) not null,
strRegistrado		varchar(100) not null,
strAutorizado		varchar(100) not null,
fecharegistro		date default getdate(),
estado				char(1)check (estado in ('A','I'))not null
)
GO

--gestión de empleados
CREATE TABLE cat_empleado
(
cod_empleado		int primary key,
codPersona			int not null,
numINSS				varchar(50) null,
tipoContrato		char(2) check (tipoContrato IN ('TD', 'TI')) null,---tiempo determinado, tiempo indefinido.
telefono			nvarchar(12) null,
celular				nvarchar(12) null,
correo				varchar(80) null,
strObservacion		varchar(300) null,
fechaReg			date default getdate(),
estado				char(1) check (estado in ('A','I'))not null---agregar al programa
CONSTRAINT FK_persona FOREIGN KEY (codPersona) REFERENCES cat_persona (cod_persona)
)
GO

--Gestión de cargo-empleado
CREATE TABLE tbl_detalleCargoEmpleado
(
id_detalleCargoEmpleado		int primary key,
codEmpleado					int FOREIGN KEY REFERENCES cat_empleado(cod_empleado),
codCargo					int FOREIGN KEY REFERENCES  cat_cargo(id_cargo),
registrado					varchar(80) null,
autorizado					varchar(80) null,
dtFechaRegis				date default getdate(),
strObservacion				varchar(300) null,
estado						char(1) check(estado in('A','I'))
)
GO


--Roles de acceso al sistema
CREATE TABLE tbl_rolacceso
(
id_rolacceso int primary key,
rol varchar(50) not null,
descripcion varchar(120) not null,
registrado varchar(40) not null,
fechaing date default getdate(),
estado char(1) check(Estado in ('A','I')) --Si el registro se mantiene A, I si no se mantiene
)
GO

--Usuarios del sistema
CREATE TABLE cat_usuario
(
cod_usuario int primary key,
empleado	 int not null,
rolacceso int not null,
usuario varchar(100) unique not null,
pass  varchar(100) unique not null,
registrado varchar(80) null,
autorizado varchar(80) null,
fechaing DATE DEFAULT GETDATE(),
strObservacion varchar(300) null,
estado char(1) check(Estado in ('A','I')), --Si el registro se mantiene A, I si no se mantiene
CONSTRAINT FK_empleado FOREIGN KEY (empleado) REFERENCES cat_empleado (cod_empleado),
CONSTRAINT FK_rolacceso FOREIGN KEY (rolacceso) REFERENCES tbl_rolacceso (id_rolacceso)
)
GO

--Control de acceso de usuarios
CREATE TABLE tbl_control_acceso
(
id_control_acceso	int primary key,
usuario				int not null,
estadoacceso		char(1) check (estadoacceso in ('C','D','B')) not null, --CONTROLA SI EL USUARIO ESTA CONECTADO, DESCONECTADO, BLOQUEADO
dtConexion			datetime default getdate(),
dtDesconexion		datetime null
)
GO

CREATE TABLE tblControlCredenciales
(
	
	idControl		INT PRIMARY KEY NOT NULL,
	codUsuario		INT FOREIGN KEY REFERENCES cat_usuario(cod_usuario),
	strUsuario		VARCHAR(100) NOT NULL,
	strPass			VARCHAR(100) UNIQUE NOT NULL,
	dtRegistrado	DATETIME DEFAULT GETDATE(),
	chrEstado		CHAR(1) CHECK(chrEstado IN('A','I'))

)
GO


--usar
CREATE TABLE tblTasaCambio
(
	
	IdTasaCambio		INT PRIMARY KEY IDENTITY(1,1),
	dtFechaVigencia		date NOT NULL,
	flValorCambio		decimal NOT NULL,
	dtFechaRegistro		DATETIME DEFAULT GETDATE()

)
GO

select * from tblTasaCambio

