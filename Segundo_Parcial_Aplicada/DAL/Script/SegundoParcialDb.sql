CREATE DATABASE SegundoParcialDb
GO
USE SegundoParcialDb
drop table Vehiculos
GO
CREATE TABLE Vehiculos
(
    VehiculoId int primary key identity(1,1),
	Descripcion varchar(max),
	MantenimientoTotal decimal
);
Go
drop table Talleres
GO
CREATE TABLE Talleres
(

    TallerId int primary key identity(1,1),
	Nombre varchar(30),

);
GO
drop table Articulos
GO
CREATE TABLE Articulos
(
 ArticuloId int primary key identity(1,1),
 Descripcion varchar(max),
 costo decimal,
 Ganancia int,
 precio decimal,
 Inventario int
);
GO
drop table Mantenimiento
GO
CREATE TABLE Mantenimientos
(
			MantenimientoId int primary key identity(1,1),
			VehiculoId int,
            Fecha date,
			ProxFecha date,
			Subtotal decimal,
			ITBIS decimal,
			Total decimal,
			Cantidad decimal
);
GO
drop table Mantenimientos_Detalle
GO
CREATE TABLE MantenimientosDetalles
(
			Id int primary key identity(1,1),
			MantenimientoId int,
            TallerId int,
            ArticulosId int,
            Articulo varchar(30),
            Cantidad decimal,
            Precio decimal,
            Importe decimal
      
);
GO
drop table Entrada_Articulo
GO
CREATE TABLE EntradaArticulos
(
			EntradaId int primary key identity(1,1),
            Fecha varchar,
            ArticuloId int,          
            Cantidad int
           
      
);
GO

select *from Articulos
select * from EntradaArticulos
select * from Talleres
select * from Vehiculos
select* from MantenimientosDetalles
select* from Mantenimientos