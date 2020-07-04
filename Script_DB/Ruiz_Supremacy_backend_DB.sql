use master;
go

create database Ruiz_Supremacy_backend_DB;
go

use Ruiz_Supremacy_backend_DB;
go
/***********************************************************************************************/
/***************************** Inicio de configuracion de perfiles *****************************/
/***********************************************************************************************/
create table perfiles(
	Id int primary key identity(1,1),
	Tipo varchar(50) unique not null,
	Estado bit not null 
);

insert into Perfiles values ('Administrador', 1);
insert into Perfiles values ('Recepcionista', 1);
insert into Perfiles values ('Medico', 1);

--update perfiles set tipo= 'alalal', estado=0 where id = 4;  

--delete from perfiles where id=4;

select p.Id, p.Tipo, p.Estado from perfiles as p;

/***********************************************************************************************/
/******************************* Fin de configuracion de perfiles ******************************/
/***********************************************************************************************/

/***********************************************************************************************/
/***************************** Inicio de configuracion de usuarios *****************************/
/***********************************************************************************************/
create table usuarios(
	Id int primary key identity(1,1),
	Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	Correo varchar(120) not null,
	IdPerfil int foreign key references perfiles(Id),
	Usr varchar(50) unique not null,
	Pwd varchar(50) not null,
	Estado bit not null 
);

insert into usuarios values('Norman','Ruiz','norman.ruiz@icloud.com', 1, 'nruiz','Usuario@1234#',1);
insert into usuarios values('Cecilia','Lupani','lalala@icloud.com', 3, 'clupani','Usuario@1234#',1);
insert into usuarios values('Natalia','Spini','maslalala@icloud.com', 2, 'nspini','Usuario@1234#',1);

--update usuarios set Nombre='', Apellido='', Correo='', IdPerfil= 1, Usr='',Pwd='', Estado= 1 where Id = 5

--delete from usuarios where Id = 4

select u.Id, u.Nombre, u.Apellido, u.Correo, u.IdPerfil, p.Tipo, u.Usr, u.Pwd, u.Estado from usuarios as u inner join perfiles as p on u.IdPerfil = p.Id;

/***********************************************************************************************/
/******************************* Fin de configuracion de usuarios ******************************/
/***********************************************************************************************/

/***********************************************************************************************/
/***************************** Inicio de configuracion de medicos ******************************/
/***********************************************************************************************/
create table medicos(
	Id int primary key identity(1,1),
	Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	Correo varchar(120) not null,
	Estado bit not null 
);

insert into medicos values ('Cecilia', 'Lupani', 'maslalala@icloud.com', 1);
insert into medicos values ('Kristen', 'Stewart', 'lalala1@icloud.com', 1);
insert into medicos values ('Emily', 'Blunt', 'lalala2@icloud.com', 1);
insert into medicos values ('Alicia', 'Vikander', 'maslalala3@icloud.com', 1);
insert into medicos values ('Teresa', 'Palmer', 'maslalala4@icloud.com', 1);
insert into medicos values ('Kaya', 'Scodelario', 'maslalala5@icloud.com', 1);
insert into medicos values ('Marion', 'Cotillard', 'maslalala6@icloud.com', 1);
insert into medicos values ('Amy', 'Adams', 'maslalala7@icloud.com', 1);

--update medicos set Nombre='', Apellido='', Correo='', Estado= 1 where Id = 

--delete from medicos where Id = 1

select m.Id, m.Nombre, m.Apellido, m.Correo, m.Estado from medicos as m;

/***********************************************************************************************/
/******************************* Fin de configuracion de medicos *******************************/
/***********************************************************************************************/

/***********************************************************************************************/
/***************************** Inicio de configuracion de notas *****************************/
/***********************************************************************************************/
create table notas(
	Id int primary key identity(1,1),
	IdPaciente int foreign key references pacientes(Id),
	Fecha datetime not null, 
	Detalle varchar(max) not null,
	Estado bit not null

);

insert into notas values (1, '20201231', 'Completa locura, derecho al Borda',1)

--update notas set IdPaciente = , Fecha = , detalle = , Estado =  where Id =

--delete notas where Id =

select n.Id, n.idpaciente, n.Fecha, n.Detalle, n.Estado from notas as n;

/***********************************************************************************************/
/******************************** Fin de configuracion de notas ********************************/
/***********************************************************************************************/

/***********************************************************************************************/
/***************************** Inicio de configuracion de estados ******************************/
/***********************************************************************************************/
create table estados(
	Id int primary key identity(1,1),
	Tipo varchar(100) unique not null,
	Estado bit not null
);

insert into estados values ('Nuevo', 1)
insert into estados values ('Reprogramado', 1)
insert into estados values ('Cancelado', 1)
insert into estados values ('No Asistió', 1)
insert into estados values ('Cerrado', 1)

--update estados set Tipo = @tipo, Estado = @estado where Id = @id

--delete estados where Id = 

select e.Id, e.Tipo, e.Estado from estados as e

/***********************************************************************************************/
/******************************* Fin de configuracion de estados *******************************/
/***********************************************************************************************/

/***********************************************************************************************/
/**************************** Inicio de configuracion de pacientes *****************************/
/***********************************************************************************************/
create table pacientes(
	Id int primary key identity(1,1),
	Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	sexo varchar(1) not null,
	FechaNacimiento datetime not null,
	Estado bit not null 
);

insert into pacientes values ('Norman','Ruiz','M', '19800402', 1);

--update pacientes set Nombre = @nombre, Apellido = @apellido, Sexo = @sexo, FechaNacimiento = @fechaNacimiento, Estado = @estado where Id = @id

--delete from pacientes where Id = @Id

select p.Id, p.Nombre, p.Apellido, p.Sexo, p.FechaNacimiento, p.Estado from pacientes as p;

/***********************************************************************************************/
/****************************** Fin de configuracion de pacientes ******************************/
/***********************************************************************************************/

/***********************************************************************************************/
/***************************** Inicio de configuracion de horarios *****************************/
/***********************************************************************************************/
create table horarios(
	Id int primary key identity(1,1),
	Inicio datetime not null,
	Fin datetime not null,
	Estado bit not null 
);

insert into horarios values('2020-06-29 15:30', '2020-06-29 16:30', 1)
insert into horarios values('2020-06-29 16:30', '2020-06-29 17:30', 1)
insert into horarios values('2020-07-02 15:30', '2020-07-02 16:30', 1)
insert into horarios values('2020-07-02 19:30', '2020-07-02 20:30', 1)

--update horarios set Inicio = , Fin = , Estado =  where Id =

--delete horarios where Id =

select h.Id, h.Inicio, h.Fin, h.Estado from horarios as h

/***********************************************************************************************/
/****************************** Fin de configuracion de horarios *******************************/
/***********************************************************************************************/

/***********************************************************************************************/
/************************** Inicio de configuracion de especialidades **************************/
/***********************************************************************************************/

/***********************************************************************************************/
/*************************** Fin de configuracion de especialidades ****************************/
/***********************************************************************************************/