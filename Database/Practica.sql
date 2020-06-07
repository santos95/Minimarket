

create database Practica
Go


use Practica
------------------------------------------------------------------------------------
CREATE TABLE categoria
(
id_categoria int IDENTITY(1,1)PRIMARY KEY NOT NULL,
nombrecat varchar(50) NOT NULL,
observacion varchar(256) NULL,
fecharegistro date
)
GO

create proc spmostrar_categoria
as
select top 200 * from categoria
order by id_categoria desc 
go

create proc spbuscar_categoria
@textobuscar varchar(50)
as 
select * from categoria
where nombrecat like @textobuscar + '%'
go

create proc spinsertar_categoria
@id_categoria int output,
@nombrecat varchar(50),
@observacion varchar(256),
@fecharegistro date
as 
insert into categoria(nombrecat,observacion,fecharegistro)
values(@nombrecat,@observacion,@fecharegistro)
go

create proc speditar_categoria
@id_categoria int,
@nombrecat varchar(50),
@observacion varchar(256),
@fecharegistro date
as 
update categoria set nombrecat=@nombrecat,observacion=@observacion,fecharegistro=@fecharegistro
where id_categoria=@id_categoria
go

create proc speliminar_categoria
@id_categoria int 
as 
delete from categoria
where id_categoria=@id_categoria
go
------------------------------------------------------------------------------------
CREATE TABLE presentacion
(
id_presentacion int IDENTITY(1,1)PRIMARY KEY,
nombre varchar(50),
descripcion varchar(256),
fecharegistro date
)
GO


create proc spmostrar_presentacion
as
select top 200 * from presentacion
order by id_presentacion desc 
go

create proc spbuscar_presentacion
@textobuscar varchar(50)
as 
select * from presentacion
where nombre like @textobuscar + '%'
go

create proc spinsertar_presentacion
@id_presentacion int output,
@nombre varchar(50),
@descripcion varchar(256),
@fecharegistro date
as 
insert into presentacion (nombre,descripcion,fecharegistro)
values(@nombre,@descripcion,@fecharegistro)
go

create proc speditar_presentacion
@id_presentacion int,
@nombre varchar(50),
@descripcion varchar(256),
@fecharegistro date
as 
update presentacion set nombre=@nombre,descripcion=@descripcion,fecharegistro=@fecharegistro
where id_presentacion=@id_presentacion
go

create proc speliminar_presentacion
@id_presentacion int 
as 
delete from presentacion
where id_presentacion=@id_presentacion
go


-----------------------Procedimientos para marca
Create Table marca
(
  id_marca           INT IDENTITY(1,1) PRIMARY KEY,
  Marca_Producto     nvarchar(50) not null
)
GO


create proc spmostrar_marca
as
select top 200 * from marca
order by id_marca desc 
go

create proc spbuscar_marca
@textobuscar varchar(50)
as 
select * from marca
where Marca_Producto like @textobuscar + '%'
go

create proc spinsertar_marca
@id_marca int output,
@Marca_Producto nvarchar(50)
as 
insert into marca(Marca_Producto)
values(@Marca_Producto)
go

create proc speditar_marca
@id_marca int,
@Marca_Producto nvarchar(50)
as 
update marca set Marca_Producto=@Marca_Producto
where id_marca=@id_marca
go

create proc speliminar_marca
@id_marca int 
as 
delete from marca
where id_marca=@id_marca
go
-----------------------------------------------------------------------
CREATE TABLE unidad_medida
(
	idUnidMed	INT IDENTITY(1,1) PRIMARY KEY,
	strUnidadMedida	VARCHAR(10) NOT NULL,	 
	strDescripcion	VARCHAR(120) NOT NULL
)
GO


create proc spmostrar_unidad
as
select top 200 * from unidad_medida
order by idUnidMed desc 
go

create proc spbuscar_unidad
@textobuscar varchar(50)
as 
select * from unidad_medida
where strUnidadMedida like @textobuscar + '%'
go

create proc spinsertar_unidad
@idUnidMed int output,
@strUnidadMedida varchar(10),
@strDescripcion varchar(120)
as 
insert into unidad_medida (strUnidadMedida,strDescripcion)
values(@strUnidadMedida,@strDescripcion)
go

create proc speditar_unidad
@idUnidMed int,
@strUnidadMedida varchar(10),
@strDescripcion varchar(120)
as 
update unidad_medida set strUnidadMedida=@strUnidadMedida,strDescripcion=@strDescripcion
where idUnidMed=@idUnidMed
go

create proc speliminar_Unidad
@idUnidMed int 
as 
delete from unidad_medida
where idUnidMed=@idUnidMed
go
-----------------------------------------------------------------------

Create Table persona
(
 id_persona				int primary key identity (1,1),
 cedula_ruc		        varchar(50) not null,
 nombre_pers_empresa	varchar(50)not null,
 apellido_razonsocial	varchar(50) not null,
 fechanac_fechaconst	date not null,
 telefono				int,
 direccion				varchar(90) null
)
GO


create proc spmostrar_persona
as
select top 200 * from persona
order by id_Persona desc 
go

create proc spbusca_persona
@textobuscar varchar(50)
as 
select * from persona
where nombre_pers_empresa like @textobuscar + '%'
go

create proc spinsertar_persona
 @id_persona				int output,
 @cedula_ruc		        varchar(50),
 @nombre_pers_empresa		varchar(50),
 @apellido_razonsocial		varchar(50),
 @fechanac_fechaconst		date,
 @telefono					int,
 @direccion					varchar(90)
as 
insert into persona(cedula_ruc,nombre_pers_empresa,apellido_razonsocial,fechanac_fechaconst,telefono,direccion)
values(@cedula_ruc,@nombre_pers_empresa,@apellido_razonsocial,@fechaNac_fechaconst,@telefono,@direccion)
go

create proc speditar_persona
 @id_persona				int,
 @cedula_ruc		        varchar(50),
 @nombre_pers_empresa		varchar(50),
 @apellido_razonsocial		varchar(50),
 @fechanac_fechaconst		date,
 @telefono					int,
 @direccion					varchar(90)
as 
update persona set cedula_ruc=@cedula_ruc,nombre_pers_empresa=@nombre_pers_empresa,apellido_razonsocial=@apellido_razonsocial,@fechanac_fechaconst=@fechanac_fechaconst,telefono=@telefono,direccion=@direccion
where id_persona=@id_persona
go

create proc speliminar_persona
@id_persona int 
as 
delete from persona
where id_persona=@id_persona
go



-------------------------------------------------------------------------

CREATE TABLE proveedor
(
	id_proveedor	 INT PRIMARY KEY  identity (1,1),
	id_persona		 INT FOREIGN KEY REFERENCES persona(id_persona),
	politica_venta	 varchar (3),--('CRE','COT', 'CON')) not null, --crédito, contado, consignacion
	observacion		 varchar(200),
	sitioWeb		 NVARCHAR(100),
	estado			 varchar(1)--(estado IN ('A','I'))
)
GO

create proc spmostrar_proveedor
as
select top 200 * from proveedor
order by id_proveedor desc 
go

create proc spbuscar_Proveedor
@textobuscar varchar(50)
as 
select * from proveedor
where estado like @textobuscar + '%'
go

create proc spinsertar_proveedor
@id_proveedor	 INT output,
@id_persona		 INT,
@politica_venta	 varchar(3),
@observacion	 varchar(200),
@sitioWeb		 NVARCHAR(100),
@estado			 varchar(1)
as 
insert into proveedor(id_persona,politica_venta,observacion,sitioWeb,estado)
values(@id_persona,@politica_venta,@observacion,@sitioWeb,@estado)
go

create proc speditar_proveedor
@id_proveedor	 INT,
@id_persona		 INT,
@politica_venta	 varchar(3),
@observacion	 varchar(200),
@sitioWeb		 NVARCHAR(100),
@estado			 varchar(1)
as 
update proveedor set id_persona=@id_persona,politica_venta=@politica_venta,observacion=@observacion,sitioWeb=@sitioWeb,estado=@estado
where id_proveedor=@id_proveedor
go

create proc speliminar_proveedor
@id_proveedor int 
as 
delete from proveedor
where id_proveedor=@id_proveedor
go

----------------------------------------------------------------------------------

CREATE TABLE contactoproveedor
(
	id_Contacto			int primary key identity (1,1),
	Nombre					varchar(200),
	Celular					int,
	Telefono				int,
	descripcion			    varchar(256),
	Email					nvarchar(80) not null,
	Estado				    varchar(1) --('A', 'I'))
)
GO

create proc spmostrar_contacto
as
select top 200 * from contactoproveedor
order by id_Contacto desc 
go

create proc spbuscar_contacto
@textobuscar varchar(50)
as 
select * from contactoproveedor
where Nombre like @textobuscar + '%'
go

create proc spinsertar_contacto
@id_Contacto		int output,
@Nombre					varchar(200),
@Celular				int,
@Telefono				int,
@descripcion			varchar(256),
@Email					nvarchar(80),
@Estado				    varchar(1)
as 
insert into contactoproveedor(Nombre,Celular,Telefono,descripcion,Email,estado)
values(@Nombre,@Celular,@Telefono,@descripcion,@Email,@estado)
go

create proc speditar_contacto
@id_Contacto		    int,
@Nombre					varchar(200),
@Celular				int,
@Telefono				int,
@descripcion			varchar(256),
@Email					nvarchar(80),
@Estado				    varchar(1)
as 
update contactoproveedor set Nombre=@Nombre,Celular=@Celular,Telefono=@Telefono,descripcion=@descripcion,Email=@Email,Estado=@Estado
where id_Contacto=@id_Contacto
go

create proc speliminar_contacto
@id_Contacto int 
as 
delete from contactoproveedor
where id_Contacto=@id_Contacto
go
--------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE articulo
(
id_articulo		    int PRIMARY KEY  identity(1,1),
nombre				varchar(50) NOT NULL,
unidadMedida		varchar(20),
descripcion			varchar(1024) NULL,
imagen				image NULL,
codigo_barra		varchar(40) null,
marca				varchar(500),
categoria_articulo	int foreign key references categoria(id_categoria),
id_presentacion	    int foreign key references presentacion(id_presentacion)
)
GO

create proc spmostrar_articulo
as
select top 200 * from articulo
order by id_articulo desc 
go

create proc spbuscar_articulo
@textobuscar varchar(50)
as 
select * from articulo
where codigo_barra like @textobuscar + '%'
go

create proc spinsertar_articulo
@id_articulo		int output,
@nombre				varchar(50),
@unidadMedida		varchar(20),
@descripcion		varchar(1024),
@imagen				image,
@codigo_barra		varchar(40),
@marca				varchar(500),
@categoria_articulo	int,
@id_presentacion	int
as 
insert into articulo(nombre,unidadMedida,descripcion,imagen,codigo_barra,marca,categoria_articulo,id_presentacion)
values(@nombre,@unidadMedida,@descripcion,@imagen,@codigo_barra,@marca,@categoria_articulo,@id_presentacion)
go

create proc speditar_articulo
@id_articulo		int,
@nombre				varchar(50),
@unidadMedida		varchar(20),
@descripcion		varchar(1024),
@imagen				image,
@codigo_barra		varchar(40),
@marca				varchar(500),
@categoria_articulo	int,
@id_presentacion	int
as 
update articulo set nombre=@nombre,unidadMedida=@unidadMedida,descripcion=@descripcion,imagen=@imagen,codigo_barra=@codigo_barra,marca=@marca,categoria_articulo=@categoria_articulo,id_presentacion=@id_presentacion
where id_articulo=@id_articulo
go

create proc speliminar_articulo
@id_articulo int 
as 
delete from articulo
where id_articulo=@id_articulo
go
------------------------------------------------------------------------------------------------------------------------------------------------------------
--para listar los proveedores que ofertan determinado artículo
CREATE TABLe articuloproveedor
(
	idArtProv		int primary key identity(1,1),
	cod_proveedor	int foreign key references proveedor(id_proveedor),
	cod_articulo	int foreign key references articulo(id_articulo),
	estado			char(1) check (estado in('A', 'I')) --Si el proveedor todavia provee el artículo o no
)
GO


Create table ingreso 
(
    idingreso int IDENTITY(1,1) primary key NOT NULL,
	idtrabajador int NOT NULL ,
	idproveedor int NOT NULL,
	fecha date NOT NULL,
	tipo_comprobante varchar(20) NOT NULL,
	serie varchar(4) NOT NULL,
	correlativo varchar(7) NOT NULL,
	igv decimal(4, 2) NOT NULL,
	estado varchar(7) NOT NULL,
)
GO

Create table detalle_ingreso
(
	iddetalle_ingreso int IDENTITY(1,1) primary key NOT NULL,
	idingreso int NOT NULL,
	idarticulo int NOT NULL,
	precio_compra money NOT NULL,
	precio_venta money NOT NULL,
	stock_inicial int NOT NULL,
	stock_actual int NOT NULL,
	fecha_produccion date NOT NULL,
	fecha_vencimiento date NOT NULL,
	CONSTRAINT FK_idingreso FOREIGN KEY (idingreso) REFERENCES ingreso (idingreso),
	CONSTRAINT FK_idarticulo FOREIGN KEY (idarticulo) REFERENCES articulo (id_articulo)
)
GO

create proc [dbo].[spstock_articulos]
as
SELECT dbo.articulo.id_articulo, dbo.articulo.nombre,
dbo.categoria.nombrecat AS Categoria,
sum(dbo.detalle_ingreso.stock_inicial) as Cantidad_Ingreso,
sum(dbo.detalle_ingreso.stock_actual) as Cantidad_Stock,
(sum(dbo.detalle_ingreso.stock_inicial)-
sum(dbo.detalle_ingreso.stock_actual)) as Cantidad_Venta
FROM dbo.articulo INNER JOIN dbo.categoria 
ON dbo.articulo.categoria_articulo = dbo.categoria.id_categoria 
INNER JOIN dbo.detalle_ingreso 
ON dbo.articulo.id_articulo = dbo.detalle_ingreso.idarticulo 
INNER JOIN dbo.ingreso 
ON dbo.detalle_ingreso.idingreso = dbo.ingreso.idingreso
where ingreso.estado<>'ANULADO'
group by dbo.articulo.id_articulo, dbo.articulo.nombre,
dbo.categoria.nombrecat
GO

------------------------------------------------------------------------------------------------
CREATE TABLE compra
(
id_compra int PRIMARY KEY identity(1,1) NOT NULL,
id_persona int foreign key references persona(id_persona),
id_proveedor int foreign key references proveedor(id_proveedor),
tipo_compra varchar(4), ---check (tipo_compra in ('CRED','CONT','CONS')) NOT NULL,-----credito, contado, consignacion.
subtotal decimal NOT NULL,
IVA float NOT NULL,
total float NOT NULL,
fecharegistro date, --default getdate(),
estado varchar(1)---check (estado in ('A','I'))not null, --se controla si todo lo pedido fue recibido
)
GO
create proc spmostrar_compra
as
select top 200 * from compra
order by id_compra desc 
go

create proc spbusca_compra
@textobuscar varchar(50)
as 
select * from compra
where tipo_compra like @textobuscar + '%'
go

create proc spinsertar_compra
@id_compra int output,
@id_persona int,
@id_proveedor int,
@tipo_compra varchar(4),
@subtotal decimal,
@IVA float,
@total float,
@fecharegistro date,
@estado varchar(1)
as 
insert compra(id_persona,id_proveedor,tipo_compra,subtotal,IVA,total,fecharegistro,estado)
values(@id_persona,@id_proveedor,@tipo_compra,@subtotal,@IVA,@total,@fecharegistro,@estado)
go

create proc speditar_compra
@id_compra int,
@id_persona int,
@id_proveedor int,
@tipo_compra varchar(4),
@subtotal decimal,
@IVA float,
@total float,
@fecharegistro date,
@estado varchar(1)
as 
update compra set id_persona=@id_persona,id_proveedor=@id_proveedor,tipo_compra=@tipo_compra,subtotal=@subtotal,IVA=@IVA,total=@total,fecharegistro=@fecharegistro,estado=@estado
where id_compra=@id_compra
go

create proc speliminar_compra
@id_compra int 
as 
delete from compra
where id_compra=@id_compra
go

---------------------------------------------
CREATE TABLE tbl_detalle_compra
(
id_detalle_compra int IDENTITY(1,1)PRIMARY KEY NOT NULL,
compra int NOT NULL,
articulo int NOT NULL,
cantidad int not null,
cantidad_rec int not null,
precio_compra float not null,
tasa_descuento varchar(20) not null,
descuento float not null,
monto float not null
CONSTRAINT FK_compra FOREIGN KEY (compra) REFERENCES compra (id_compra)
)
GO

------------------------------------------------
Create table anular_compra
(
id_compra_anular int identity(1,1) primary key not null,
id_persona int foreign key references persona(id_persona),
id_compra int foreign key references compra(id_compra),
fecha_anulacion date,
obcervacion nvarchar(200) not null,
estado nvarchar(1)---(A,I)---
)
GO

create proc spmostrar_compra_anulada
as
select top 200 * from anular_compra
order by id_compra_anular desc 
go

create proc spbusca_compra_anulada
@textobuscar varchar(50)
as 
select * from anular_compra
where estado like @textobuscar + '%'
go

create proc spinsertar_compra_anulada
@id_compra_anular int output,
@id_persona int,
@id_compra int,
@fecha_anulacion date,
@obcervacion nvarchar(200),
@estado varchar(1)
as 
insert anular_compra(id_persona,id_compra,fecha_anulacion,obcervacion,estado)
values(@id_persona,@id_compra,@fecha_anulacion,@obcervacion,@estado)
go

create proc speditar_compra_anulada
@id_compra_anular int output,
@id_persona int,
@id_compra int,
@fecha_anulacion date,
@obcervacion nvarchar(200),
@estado varchar(1)
as 
update anular_compra set id_persona=@id_persona,id_compra=@id_compra,fecha_anulacion=@fecha_anulacion,obcervacion=@obcervacion,estado=@estado
where id_compra_anular=@id_compra_anular
go

create proc speliminar_compra_anular
@id_compra_anular int 
as 
delete from anular_compra
where id_compra_anular=@id_compra_anular
go
