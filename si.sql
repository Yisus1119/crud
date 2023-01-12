create database tienda

use tienda
--tabla empleado --
create table empleado (cedula int not null primary key,
nombreEmpleado varchar(55),
apellidoEmpleado varchar(55),
telefonoEmpleado varchar(55),
direccionEmpleado varchar(55),
cargo varchar(55),
sueldo varchar(55),
tanda varchar(55),
fechaContratacion date default getdate(),
isAdmin char default 0)

--tabla de los ex empleados --
create table exEmpleados (cedula int not null primary key,
nombreEmpleado varchar(55),
apellidoEmpleado varchar(55),
telefonoEmpleado varchar(55),
direccionEmpleado varchar(55),
cargo varchar(55),
sueldo varchar(55),
tanda varchar(55),
fechaContratacion date default getdate(),
isAdmin char default 0)

--triger para automatizar insertado de usuarios en la tabla de ex empleados despues de su desvinculacion --
create trigger bd_empleado
on empleado
after delete 
as
begin
insert into exEmpleados(cedula,nombreEmpleado,apellidoEmpleado,telefonoEmpleado,direccionEmpleado,cargo,sueldo,tanda,fechaContratacion,isAdmin)
select cedula,nombreEmpleado,apellidoEmpleado,telefonoEmpleado,direccionEmpleado,cargo,sueldo,tanda,fechaContratacion,isAdmin from deleted
end

drop trigger bd_empleado


insert into empleado values (40154828, 'Juan','Lopez','809-963-8520','Calle 5ta, no.28, Res. los guaricanos','Supervisor R1','45,000','completa',default,default)

select * from empleado

create proc visualizarUsuario
as
select * from empleado
go

exec visualizarUsuario


create proc insertarUsuario
@cedula int,
@nombreEmpleado varchar(55),
@apellidoEmpleado varchar(55),
@telefonoEmpleado varchar(55),
@direccionEmpleado varchar(55),
@cargo varchar(55),
@sueldo varchar(55),
@tanda varchar(55),
@fechaContratacion date,
@isAdmin char
as
insert into empleado values (@cedula,@nombreEmpleado,@apellidoEmpleado,@telefonoEmpleado,@direccionEmpleado,@cargo,@sueldo,@tanda,@fechaContratacion,@isAdmin)
go


exec insertarUsuario 684694,'Juan','Martinez','809-741-8522','Calle la aguja, no.25','Supervisor R2','43,500','matutina','2023-01-05',1
exec insertarUsuario 684695,'Juliana','Peña','809-741-8522','Calle la aguja, no.25','Supervisor R3','43,500','matutina','2023-01-05',1

select * from empleado
select * from exEmpleados

truncate table empleado

create proc editarUsuario
@cedula int,
@nombreEmpleado varchar(55),
@apellidoEmpleado varchar(55),
@telefonoEmpleado varchar(55),
@direccionEmpleado varchar(55),
@cargo varchar(55),
@sueldo varchar(55),
@tanda varchar(55),
@fechaContratacion date,
@isAdmin char
as
update empleado set nombreEmpleado=@nombreEmpleado,apellidoEmpleado=@apellidoEmpleado,telefonoEmpleado=@telefonoEmpleado,direccionEmpleado=@direccionEmpleado,cargo=@cargo,sueldo=@sueldo,tanda=@tanda,fechaContratacion=@fechaContratacion,
isAdmin=@isAdmin where cedula=@cedula

drop proc editarUsuario

create proc eliminarUsuario
@cedula int
as 
delete from empleado where cedula=@cedula
go

exec eliminarUsuario 5654654

drop proc eliminarUsuario

--select * from empleado where cedula like @cedula OR cargo like @cargo OR nombreEmpleado like @nombre
--@cargo varchar(55),
--@nombre varchar(55)

create proc buscarEmpleado
@cedula int
as
--select * from empleado where cedula like @cedula
select * from empleado where cedula like @cedula
go

exec buscarEmpleado 684695
exec buscarEmpleado 68

select * from empleado;
select * from exEmpleados;

drop proc buscarEmpleado

delete from exEmpleados where cedula = 5654654