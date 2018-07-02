CREATE DATABASE SegundoParcialDb
go
use SegundoParcialDb
go
create table Vehiculo(
VehiculoId int primary key,
Descripcion varchar(100),
Mantenimiento decimal
);

sp_columns Vehiculo;

 insert into Vehiculo (VehiculoId, Descripcion, Mantenimiento)values ('Toyota Corolla 2005 LE',0);
  
 insert into Vehiculo (VehiculoId, Descripcion, Mantenimiento)values ('Honda CRV 2015 Touring',0);

 select * from Vehiculo;