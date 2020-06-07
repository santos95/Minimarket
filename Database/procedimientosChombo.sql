USE [master]
GO

use dbventas
go

create proc [dbo].[spanular_ingreso]
@idingreso int
as
update ingreso set estado='ANULADO'
where idingreso=@idingreso

GO

create proc [dbo].[spbuscar_articulo_nombre]
@textobuscar varchar(50)
as
SELECT dbo.articulo.idarticulo, dbo.articulo.codigo, dbo.articulo.nombre,
dbo.articulo.descripcion, dbo.articulo.imagen, dbo.articulo.idcategoria,
dbo.categoria.nombre AS Categoria, dbo.articulo.idpresentacion, 
dbo.presentacion.nombre AS Presentacion
FROM dbo.articulo INNER JOIN dbo.categoria 
ON dbo.articulo.idcategoria = dbo.categoria.idcategoria 
INNER JOIN dbo.presentacion 
ON dbo.articulo.idpresentacion = dbo.presentacion.idpresentacion
where dbo.articulo.nombre like @textobuscar + '%'
order by dbo.articulo.idarticulo desc
GO

CREATE proc [dbo].[spbuscar_categoria]
@textobuscar varchar(50)
as
select * from categoria
where nombre like @textobuscar + '%' --Alt +39
GO

create proc [dbo].[spbuscar_cliente_apellidos]
@textobuscar varchar(50)
as
select * from cliente
where apellidos like @textobuscar + '%'
GO

create proc [dbo].[spbuscar_cliente_num_documento]
@textobuscar varchar(50)
as
select * from cliente
where num_documento like @textobuscar + '%'

GO

CREATE proc [dbo].[spbuscar_ingreso_fecha]
@textobuscar varchar(50),
@textobuscar2 varchar(50)
as
SELECT ingreso.idingreso,
(trabajador.apellidos +' '+ trabajador.nombre) as Trabajador, 
proveedor.razon_social	as proveedor,
ingreso.fecha, ingreso.tipo_comprobante, 
ingreso.serie, ingreso.correlativo,
ingreso.estado, sum(detalle_ingreso.precio_compra*
detalle_ingreso.stock_inicial) as Total,ingreso.igv as Impuesto
FROM detalle_ingreso INNER JOIN ingreso 
ON detalle_ingreso.idingreso = ingreso.idingreso 
INNER JOIN proveedor 
ON ingreso.idproveedor = proveedor.idproveedor 
INNER JOIN dbo.trabajador 
ON ingreso.idtrabajador = trabajador.idtrabajador
group by
ingreso.idingreso,
trabajador.apellidos +' '+ trabajador.nombre, 
proveedor.razon_social,
ingreso.fecha, ingreso.tipo_comprobante, 
ingreso.serie, ingreso.correlativo,
ingreso.estado,ingreso.igv
having ingreso.fecha>=@textobuscar and ingreso.fecha<=@textobuscar2

GO


create proc [dbo].[spbuscar_presentacion_nombre]
@textobuscar varchar(50)
as
select * from presentacion
where nombre like @textobuscar + '%' --Alt + 39

GO

create proc [dbo].[spbuscar_proveedor_num_documento]
@textobuscar varchar(20)
as
SELECT * FROM proveedor
where num_documento like @textobuscar + '%'
GO

create proc [dbo].[spbuscar_proveedor_razon_social]
@textobuscar varchar(50)
as
select * from proveedor
where razon_social like @textobuscar + '%'
GO

create proc [dbo].[spbuscar_trabajador_apellidos]
@textobuscar varchar(50)
as
select * from trabajador
where apellidos like @textobuscar +'%'
order by apellidos asc
GO

create proc [dbo].[spbuscar_trabajador_num_documento]
@textobuscar varchar(50)
as
select * from trabajador
where num_documento like @textobuscar +'%'
order by apellidos asc
GO


CREATE proc [dbo].[spbuscar_venta_fecha]
@textobuscar varchar(50),
@textobuscar2 varchar(50)
as
select v.idventa,
(t.apellidos+' '+t.nombre) as Trabajador,
(c.apellidos+' '+c.nombre) as Cliente,
v.fecha,v.tipo_comprobante,v.serie,v.correlativo,
sum((d.cantidad*d.precio_venta)-d.descuento) as Total,v.igv as Impuesto
from detalle_venta d inner join venta v
on d.idventa=v.idventa
inner join cliente c
on v.idcliente=c.idcliente
inner join trabajador t
on v.idtrabajador=t.idtrabajador
group by v.idventa,
(t.apellidos+' '+t.nombre),
(c.apellidos+' '+c.nombre),
v.fecha,v.tipo_comprobante,v.serie,v.correlativo,v.igv
having v.fecha>=@textobuscar and v.fecha<=@textobuscar2
GO

create proc [dbo].[spbuscararticulo_venta_codigo]
@textobuscar varchar(50)
as
select d.iddetalle_ingreso,a.Codigo,a.Nombre,
c.nombre as Categoria,p.nombre as Presentacion,
d.stock_actual,d.precio_compra,d.precio_venta,
d.fecha_vencimiento
from articulo a inner join categoria c
on a.idcategoria=c.idcategoria
inner join presentacion p
on a.idpresentacion=p.idpresentacion
inner join detalle_ingreso d
on a.idarticulo=d.idarticulo
inner join ingreso i
on d.idingreso=i.idingreso
where a.codigo=@textobuscar
and d.stock_actual>0
and i.estado<>'ANULADO'
GO

create proc [dbo].[spbuscararticulo_venta_nombre]
@textobuscar varchar(50)
as
select d.iddetalle_ingreso,a.Codigo,a.Nombre,
c.nombre as Categoria,p.nombre as Presentacion,
d.stock_actual,d.precio_compra,d.precio_venta,
d.fecha_vencimiento
from articulo a inner join categoria c
on a.idcategoria=c.idcategoria
inner join presentacion p
on a.idpresentacion=p.idpresentacion
inner join detalle_ingreso d
on a.idarticulo=d.idarticulo
inner join ingreso i
on d.idingreso=i.idingreso
where a.nombre like @textobuscar + '%'
and d.stock_actual>0
and i.estado<>'ANULADO'

GO

create proc [dbo].[spdisminuir_stock]
@iddetalle_ingreso int,
@cantidad int
as
update detalle_ingreso set stock_actual=stock_actual-@cantidad
where iddetalle_ingreso=@iddetalle_ingreso
GO

create proc [dbo].[speditar_articulo]
@idarticulo int,
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(1024),
@imagen image,
@idcategoria int,
@idpresentacion int
as
update articulo set codigo=@codigo,nombre=@nombre,descripcion=@descripcion,
imagen=@imagen,idcategoria=@idcategoria,idpresentacion=@idpresentacion
where idarticulo=@idarticulo
GO


create proc [dbo].[speditar_categoria]
@idcategoria int,
@nombre varchar(50),
@descripcion varchar(256)
as
update categoria set nombre=@nombre,
descripcion=@descripcion
where idcategoria=@idcategoria
GO

create proc [dbo].[speditar_cliente]
@idcliente int,
@nombre varchar(50),
@apellidos varchar(40),
@sexo varchar(1),
@fecha_nacimiento date,
@tipo_documento varchar(20),
@num_documento varchar(11),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50)
as
update cliente set nombre=@nombre,apellidos=@apellidos,sexo=@sexo,
fecha_nacimiento=@fecha_nacimiento,tipo_documento=@tipo_documento,
num_documento=@num_documento,direccion=@direccion,
telefono=@telefono,email=@email
where idcliente=@idcliente
GO

create proc [dbo].[speditar_presentacion]
@idpresentacion int,
@nombre varchar(50),
@descripcion varchar(256)
as
update presentacion set nombre=@nombre, descripcion=@descripcion
where idpresentacion=@idpresentacion
GO

create proc [dbo].[speditar_proveedor]
@idproveedor int,
@razon_social varchar(150),
@sector_comercial varchar(50),
@tipo_documento varchar(20),
@num_documento varchar(11),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@url varchar(100)
as
update proveedor set razon_social=@razon_social,sector_comercial=@sector_comercial,
tipo_documento=@tipo_documento,num_documento=@num_documento,
direccion=@direccion,telefono=@telefono,email=@email,
url=@url
where idproveedor=@idproveedor
GO

create proc [dbo].[speditar_trabajador]
@idtrabajador int,
@nombre varchar(20),
@apellidos varchar(40),
@sexo varchar(1),
@fecha_nacimiento date,
@num_documento varchar(8),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@acceso varchar(20),
@usuario varchar(20),
@password varchar(20)
as
update trabajador set nombre=@nombre,apellidos=@apellidos,
sexo=@sexo,fecha_nac=@fecha_nacimiento,num_documento=@num_documento,
direccion=@direccion,telefono=@telefono,email=@email,
acceso=@acceso,usuario=@usuario,password=@password
where idtrabajador=@idtrabajador
GO

create proc [dbo].[speliminar_articulo]
@idarticulo int
as
delete from articulo
where idarticulo=@idarticulo
GO

create proc [dbo].[speliminar_categoria]
@idcategoria int
as
delete from categoria
where idcategoria=@idcategoria
GO

create proc [dbo].[speliminar_cliente]
@idcliente int
as
delete from cliente
where idcliente=@idcliente
GO

create proc [dbo].[speliminar_presentacion]
@idpresentacion int
as
delete from presentacion
where idpresentacion=@idpresentacion
GO

create proc [dbo].[speliminar_proveedor]
@idproveedor int
as
delete from proveedor
where idproveedor=@idproveedor
GO

create proc [dbo].[speliminar_trabajador]
@idtrabajador int
as
delete from trabajador
where idtrabajador=@idtrabajador
GO

create proc [dbo].[speliminar_venta]
@idventa int
as
delete from venta
where idventa=@idventa
GO

create proc [dbo].[spinsertar_articulo]
@idarticulo int output,
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(1024),
@imagen image,
@idcategoria int,
@idpresentacion int
as
insert into articulo (codigo,nombre,descripcion,imagen,idcategoria,idpresentacion)
values (@codigo,@nombre,@descripcion,@imagen,@idcategoria,@idpresentacion)
GO

create proc [dbo].[spinsertar_categoria]
@idcategoria int output,
@nombre varchar(50),
@descripcion varchar(256)
as
insert into categoria (nombre,descripcion)
values (@nombre,@descripcion)
GO

create proc [dbo].[spinsertar_cliente]
@idcliente int output,
@nombre varchar(50),
@apellidos varchar(40),
@sexo varchar(1),
@fecha_nacimiento date,
@tipo_documento varchar(20),
@num_documento varchar(11),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50)
as 
insert into cliente (nombre,apellidos,sexo,fecha_nacimiento,
tipo_documento,num_documento,direccion,telefono,email)
values (@nombre,@apellidos,@sexo,@fecha_nacimiento,
@tipo_documento,@num_documento,@direccion,@telefono,@email)
GO

create proc [dbo].[spinsertar_detalle_ingreso]
@iddetalle_ingreso int output,
@idingreso int,
@idarticulo int,
@precio_compra money,
@precio_venta money,
@stock_inicial int,
@stock_actual int,
@fecha_produccion date,
@fecha_vencimiento date
as
insert into detalle_ingreso (idingreso,idarticulo,precio_compra,
precio_venta,stock_inicial,stock_actual,fecha_produccion,
fecha_vencimiento)
values (@idingreso,@idarticulo,@precio_compra,
@precio_venta,@stock_inicial,@stock_actual,@fecha_produccion,
@fecha_vencimiento)
GO

create proc [dbo].[spinsertar_detalle_venta]
@iddetalle_venta int output,
@idventa int,
@iddetalle_ingreso int,
@cantidad int,
@precio_venta money,
@descuento money
as
insert into detalle_venta (idventa,iddetalle_ingreso,cantidad,
precio_venta,descuento)
values (@idventa,@iddetalle_ingreso,@cantidad,
@precio_venta,@descuento)
GO

create proc [dbo].[spinsertar_ingreso]
@idingreso int=null output,
@idtrabajador int,
@idproveedor int,
@fecha date,
@tipo_comprobante varchar(20),
@serie varchar(4),
@correlativo varchar(7),
@igv decimal(4,2),
@estado varchar(7)
as
insert into ingreso (idtrabajador,idproveedor,fecha,tipo_comprobante,
serie,correlativo,igv,estado)
values (@idtrabajador,@idproveedor,@fecha,@tipo_comprobante,
@serie,@correlativo,@igv,@estado)
--Obtener el código autogenerado
SET @idingreso=@@IDENTITY
GO

create proc [dbo].[spinsertar_presentacion]
@idpresentacion int output,
@nombre varchar(50),
@descripcion varchar(256)
as
insert into presentacion (nombre,descripcion)
values (@nombre,@descripcion)
GO

create proc [dbo].[spinsertar_proveedor]
@idproveedor int output,
@razon_social varchar(150),
@sector_comercial varchar(50),
@tipo_documento varchar(20),
@num_documento varchar(11),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@url varchar(100)
as
insert into proveedor (razon_social,sector_comercial,tipo_documento,
num_documento,direccion,telefono,email,url)
values (@razon_social,@sector_comercial,@tipo_documento,
@num_documento,@direccion,@telefono,@email,@url)
GO

create proc [dbo].[spinsertar_trabajador]
@idtrabajador int output,
@nombre varchar(20),
@apellidos varchar(40),
@sexo varchar(1),
@fecha_nacimiento date,
@num_documento varchar(8),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@acceso varchar(20),
@usuario varchar(20),
@password varchar(20)
as
insert into trabajador (nombre,apellidos,sexo,fecha_nac,
num_documento,direccion,telefono,email,acceso,usuario,password)
values (@nombre,@apellidos,@sexo,@fecha_nacimiento,
@num_documento,@direccion,@telefono,@email,@acceso,@usuario,
@password)
GO

create proc [dbo].[spinsertar_venta]
@idventa int=null output,
@idcliente int,
@idtrabajador int,
@fecha date,
@tipo_comprobante varchar(20),
@serie varchar(4),
@correlativo varchar(7),
@igv decimal(4,2)
as
insert into venta (idcliente,idtrabajador,fecha,tipo_comprobante,
serie,correlativo,igv)
values (@idcliente,@idtrabajador,@fecha,@tipo_comprobante,
@serie,@correlativo,@igv)
--Obtenemos el código autogenerado
set @idventa=@@IDENTITY
GO

create proc [dbo].[splogin]
@usuario varchar(20),
@password varchar(20)
as
select idtrabajador,apellidos,nombre,acceso
from trabajador
where usuario=@usuario and password=@password
GO

create proc [dbo].[spmostrar_articulo]
as
SELECT top 100 dbo.articulo.idarticulo, dbo.articulo.codigo, dbo.articulo.nombre,
dbo.articulo.descripcion, dbo.articulo.imagen, dbo.articulo.idcategoria,
dbo.categoria.nombre AS Categoria, dbo.articulo.idpresentacion, 
dbo.presentacion.nombre AS Presentacion
FROM dbo.articulo INNER JOIN dbo.categoria 
ON dbo.articulo.idcategoria = dbo.categoria.idcategoria 
INNER JOIN dbo.presentacion 
ON dbo.articulo.idpresentacion = dbo.presentacion.idpresentacion
order by dbo.articulo.idarticulo desc
GO

create proc [dbo].[spmostrar_categoria]
as
select top 200 * from categoria
order by idcategoria desc
GO

create proc [dbo].[spmostrar_cliente]
as
select top 100 * from cliente
order by apellidos asc
GO

create proc [dbo].[spmostrar_detalle_ingreso]
@textobuscar int
as
select d.idarticulo,a.nombre as Articulo,d.precio_compra,
d.precio_venta,d.stock_inicial,d.fecha_produccion,
d.fecha_vencimiento,(d.stock_inicial*d.precio_compra) as Subtotal
from detalle_ingreso d inner join articulo a
on d.idarticulo=a.idarticulo
where d.idingreso=@textobuscar
GO

create proc [dbo].[spmostrar_detalle_venta]
@textobuscar int
as
select d.iddetalle_ingreso,a.nombre as Artículo,
d.cantidad,d.precio_venta,d.descuento,
((d.precio_venta*d.cantidad)-d.descuento) as Subtotal
from detalle_venta d inner join detalle_ingreso di
on d.iddetalle_ingreso=di.iddetalle_ingreso
inner join articulo a
on di.idarticulo=a.idarticulo
where d.idventa=@textobuscar
GO

CREATE proc [dbo].[spmostrar_ingreso]
as
select top 100 i.idingreso,(t.apellidos+' '+t.nombre) as Trabajador,
p.razon_social as Proveedor,i.fecha,i.tipo_comprobante,
i.serie,i.correlativo,i.estado,
sum(d.precio_compra*d.stock_inicial) as Total,i.igv as Impuesto
from detalle_ingreso d inner join ingreso i
on d.idingreso=i.idingreso
inner join proveedor p
on i.idproveedor=p.idproveedor
inner join trabajador t
on i.idtrabajador=t.idtrabajador
group by
i.idingreso,t.apellidos+' '+t.nombre,
p.razon_social,i.fecha,i.tipo_comprobante,
i.serie,i.correlativo,i.estado,i.igv
order by i.idingreso desc
GO

create proc [dbo].[spmostrar_presentacion]
as
select top 100 * from presentacion
order by idpresentacion desc
GO

create proc [dbo].[spmostrar_proveedor]
as
select top 100 * from proveedor
order by razon_social asc
GO

create proc [dbo].[spmostrar_trabajador]
as
select top 100 * from trabajador
order by apellidos asc
GO

CREATE proc [dbo].[spmostrar_venta]
as
select top 100 v.idventa,
(t.apellidos+' '+t.nombre) as Trabajador,
(c.apellidos+' '+c.nombre) as Cliente,
v.fecha,v.tipo_comprobante,v.serie,v.correlativo,
sum((d.cantidad*d.precio_venta)-d.descuento) as Total,v.igv as Impuesto
from detalle_venta d inner join venta v
on d.idventa=v.idventa
inner join cliente c
on v.idcliente=c.idcliente
inner join trabajador t
on v.idtrabajador=t.idtrabajador
group by v.idventa,
(t.apellidos+' '+t.nombre),
(c.apellidos+' '+c.nombre),
v.fecha,v.tipo_comprobante,v.serie,v.correlativo,v.igv
order by v.idventa desc
GO

create proc [dbo].[spreporte_factura]
@idventa int
as
select 
v.idventa,(t.apellidos+' '+t.nombre) as Trabajador,
(c.apellidos+' '+c.nombre) as Cliente,
c.direccion,c.telefono,c.num_documento,
v.fecha,v.tipo_comprobante,v.serie,v.correlativo,
v.igv,a.nombre,dv.precio_venta,dv.cantidad,dv.descuento,
(dv.cantidad*dv.precio_venta-dv.descuento) as Total_Parcial
 from detalle_venta dv inner join detalle_ingreso di
on dv.iddetalle_ingreso=di.iddetalle_ingreso
inner join articulo a
on a.idarticulo=di.idarticulo
inner join venta v
on v.idventa=dv.idventa
inner join cliente c
on v.idcliente=c.idcliente
inner join trabajador t
on t.idtrabajador=v.idtrabajador
where v.idventa=@idventa
GO

create proc [dbo].[spstock_articulos]
as
SELECT dbo.articulo.codigo, dbo.articulo.nombre,
dbo.categoria.nombre AS Categoria,
sum(dbo.detalle_ingreso.stock_inicial) as Cantidad_Ingreso,
sum(dbo.detalle_ingreso.stock_actual) as Cantidad_Stock,
(sum(dbo.detalle_ingreso.stock_inicial)-
sum(dbo.detalle_ingreso.stock_actual)) as Cantidad_Venta
FROM dbo.articulo INNER JOIN dbo.categoria 
ON dbo.articulo.idcategoria = dbo.categoria.idcategoria 
INNER JOIN dbo.detalle_ingreso 
ON dbo.articulo.idarticulo = dbo.detalle_ingreso.idarticulo 
INNER JOIN dbo.ingreso 
ON dbo.detalle_ingreso.idingreso = dbo.ingreso.idingreso
where ingreso.estado<>'ANULADO'
group by dbo.articulo.codigo, dbo.articulo.nombre,
dbo.categoria.nombre
GO





























































































































































































































































































































