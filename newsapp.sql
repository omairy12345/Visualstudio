create database newsapp
use newsapp

create table Category
(
IDcategory int constraint pk_IDcategory primary key identity,
Nombrecategory varchar (40),
);

create table Paises
(
IDpais int constraint pk_IDpais primary key identity,
Nombrepais varchar (40)
);

create table Fuentes
(
IDfuente int constraint pk_IDfuente primary key identity,
Nombrefuente varchar (40)
);

create table Articulos
(
IDarticulo int constraint pk_IDarticulo primary key identity,
Titulo varchar (40),
Contenido varchar (80),
ImagenURL varchar (max),
Descripcion varchar (80),
Autor varchar (40),
Fechapublicacion date,
IDcategory int constraint FK_IDcategory foreign key references Category (IDcategory),
IDpais int constraint FK_IDpais foreign key references Paises (IDpais),
IDfuente int constraint FK_IDfuente foreign key references Fuentes (IDfuente)
);

INSERT into Articulos (IDarticulo,Titulo,Contenido,ImagenURL,Descripcion,Fechapublicacion,IDfuente,IDcategory,IDpais,IDfuente) VALUES ("covid2019","caracteristicas