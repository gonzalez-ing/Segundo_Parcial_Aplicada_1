CREATE DATABASE SegundoParcialDb
GO
USE SegundoParcialDb
GO

CREATE TABLE Vehiculos
(
    VehiculoId int primary key identity(1,1),
	Descripcion varchar(50),
	MantenimientoTotal decimal
);

CREATE TABLE Talleres
(
    TallerId int primary key identity(1,1),
	Nombre varchar(30),
);

CREATE TABLE Articulos
(
 ArticuloId int primary key identity(1,1),
 Descripcion varchar(50),
 costo decimal,
 Ganancia int,
 precio decimal,
 Inventario int
);

CREATE TABLE Mantenimiento
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

CREATE TABLE MantenimientoDetalle
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

CREATE TABLE EntradaArticulo
(
			EntradaId int primary key identity(1,1),
            Fecha varchar,
            ArticuloId int,          
            Cantidad int
           
      
);

select *from Articulos
select * from EntradaArticulo
select * from Talleres
select * from Vehiculos
select* from MantenimientoDetalle
select* from Mantenimiento