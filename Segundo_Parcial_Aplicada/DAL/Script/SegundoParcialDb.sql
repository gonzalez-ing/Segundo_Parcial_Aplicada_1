drop database SegundoParcialDb
use SegundoParcialDb
go
create Table Vehiculos
(
VehiculoId int primary key identity (1,1),
Descripcion varchar (max),
MantenimientoTotal int
);
use SegundoParcialDb
go
create Table Talleres
(
TallerId int primary key identity (1,1),
Nombre varchar (max),

);