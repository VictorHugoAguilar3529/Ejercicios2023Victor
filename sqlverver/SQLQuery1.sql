CREATE DATABASE InstitutoTich3;


GO 
USE InstitutoTich3;

GO

CREATE TABLE AlumnosBaja (
id  int NOT NULL PRIMARY KEY,
nombre  varchar(255),
primerApellido  varchar(255),
SegundoApellido  varchar(255),
fechaBaja date
);

GO

CREATE TABLE CursosInstructores (
id  smallint IDENTITY(1,1),
idCurso  smallint,
idInstructor  smallint,
fechaContratacion date null,
PRIMARY KEY (id),
FOREIGN KEY (idCurso) REFERENCES Cursos(id),
FOREIGN KEY (idInstructor) REFERENCES Instructores(id)
);

GO


CREATE TABLE Estados (
id smallint IDENTITY(1,1),
nombre VARCHAR(100) NULL,
);

GO

CREATE TABLE EstatusAlumnos (
id  smallint,
clave char(10),
Nombre varchar(100),
PRIMARY KEY (id)
);

GO

CREATE TABLE CatCursos (
id smallint IDENTITY(1,1),
clave VARCHAR(15) ,
nombre VARCHAR(50),
descripcion VARCHAR(1000),
horas tinyint,
idPreRequisito smallint NULL,
activo bit,
PRIMARY KEY (id)
);

GO

CREATE TABLE Cursos (
id smallint IDENTITY(1,1),
idCatCurso smallint null,
fechaInicio VARCHAR(50) null,
fechatermino VARCHAR(1000) null,
activo bit null,
PRIMARY KEY (id),
);

GO

USE InstitutoTich3;

GO

CREATE TABLE Alumnos (
id smallint IDENTITY(1,1),
nombre varchar(60),
primerApellido VARCHAR(50),
segundoApellido VARCHAR(50) null,
correo varchar(80),
telefono nchar(10),
fechaNacimiento date,
curp char(18),
sueldo decimal(9,2),
idEstadoOrigen smallint,
idEstatus smallint,
PRIMARY KEY (id),
FOREIGN KEY (idEstadoOrigen) REFERENCES Estados(id),
FOREIGN KEY (idEstatus) REFERENCES EstatusAlumnos(id)
);

GO


CREATE TABLE Instructores (
id smallint IDENTITY(1,1),
nombre varchar(60),
primerApellido VARCHAR(50),
segundoApellido VARCHAR(50) null,
correo varchar(80),
telefono nchar(10),
fechaNacimiento date,
rfc char(13),
curp char(18),
cuotaHora decimal(9,2),
activo bit,
PRIMARY KEY (id),
);

GO

