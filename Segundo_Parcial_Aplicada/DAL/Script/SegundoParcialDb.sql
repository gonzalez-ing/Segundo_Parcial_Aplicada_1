CREATE DATABASE SegundoParcialDb
GO
USE SegundoParcialDb
GO
create table Vehiculo(
VehiculoId int primary key,
Descripcion varchar(50),
Mantenimiento decimal
);

select * from Vehiculo;