use master;
go

create database Ruiz_Supremacy_backend_DB;
go

use Ruiz_Supremacy_backend_DB;
go

create table perfiles(
	Id int primary key identity(1,1),
	Tipo varchar(50) unique not null,
	Estado bit not null 
);

insert into Perfiles values ('Administrador', 1);
insert into Perfiles values ('Recepcionista', 1);
insert into Perfiles values ('Medico', 1);

update perfiles set tipo= 'alalal', estado=0 where id = 4;  

delete from perfiles where id=4;

select p.Id, p.Tipo, p.Estado from perfiles as p;

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

select u.Id, u.Nombre, u.Apellido, u.Correo, u.IdPerfil, p.Tipo, u.Usr, u.Pwd, u.Estado from usuarios as u inner join perfiles as p on u.IdPerfil = p.Id;

update usuarios set Nombre='', Apellido='', Correo='', IdPerfil= 1, Usr='',Pwd='', Estado= 1 where Id = 5

delete from usuarios where Id = 4

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

select m.Id, m.Nombre, m.Apellido, m.Correo, m.Estado from medicos as m;

update medicos set Nombre='', Apellido='', Correo='', Estado= 1 where Id = 

delete from medicos where Id = 1


create table notas(
	Id int primary key identity(1,1),
	IdPaciente int foreign key references pacientes(Id),
	Fecha datetime not null, 
	Detalle varchar(max) not null,
	Estado bit not null

);

insert into notas values (1, '20201231', 'Completa locura, derecho al Borda',1)

update notas set IdPaciente = , Fecha = , detalle = , Estado =  where Id = 

select n.Id, n.idpaciente, n.Fecha, n.Detalle, n.Estado from notas as n;


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

select e.Id, e.Tipo, e.Estado from estados as e

update estados set Tipo = @tipo, Estado = @estado where Id = @id

create table pacientes(
	Id int primary key identity(1,1),
	Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	sexo varchar(1) not null,
	FechaNacimiento datetime not null,
	Estado bit not null 
);

insert into pacientes values ('Norman','Ruiz','M', '19800402', 1);

select p.Id, p.Nombre, p.Apellido, p.Sexo, p.FechaNacimiento, p.Estado from pacientes as p;


