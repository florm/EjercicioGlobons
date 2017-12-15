CREATE DATABASE EjercicioGlobons;
USE EjercicioGlobons;

CREATE TABLE Direccion(
IdDireccion int IDENTITY(1,1),
calle varchar(100) NOT NULL,
numero int NOT NULL,
PRIMARY KEY (idDireccion)
);

CREATE TABLE Persona(
IdPersona int IDENTITY(1,1),
Nombre varchar(50) NOT NULL,
Apellido varchar(50) NOT NULL,
NumeroDocumento int UNIQUE NOT NULL	,
FechaNacimiento date NOT NULL,
DireccionId int NOT NULL,
PRIMARY KEY (IdPersona),
FOREIGN KEY (DireccionId) REFERENCES Direccion (IdDireccion)
);




