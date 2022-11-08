CREATE DATABASE El_Salto
GO
USE El_Salto
GO

CREATE TABLE Login(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Username VARCHAR(25) UNIQUE NOT NULL,
	Password VARCHAR(255) NOT NULL
)
GO

INSERT INTO LOGIN (Username, Password) VALUES ('Administrador', 'uUWaCI3ScZ6IzyWLXdoIIdUkWr1/1fjrwiYaDoPUQ7SJ5hPj')
GO

CREATE TABLE Planta(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	NombreComun VARCHAR(255) UNIQUE NOT NULL,
	NombreCientifico VARCHAR(255) UNIQUE NOT NULL,
	TipoPlanta VARCHAR(255) NOT NULL,
	Descripcion VARCHAR(255),
	TiempoRiego INT NOT NULL,
	CantidadAgua INT NOT NULL,
	Epoca VARCHAR(15) NOT NULL,
	EsVenenosa BIT,
	EsAutoctona BIT
)
GO

--PROCEDURES--

--Crear y recibir usuarios--
create procedure spLogin
	@Username VARCHAR(25)
as
	select Password from Login where Username = @Username
go

create procedure spCreateUser
@Username varchar(25),
	@Password varchar(25)
as
	insert into Login (Username, Password) values (@Username, @Password)
go
