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

--LOGIN PROCEDURES--

--Crear y recibir usuarios--
Use El_Salto
GO

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

--PLATAN VIEWS & PROCEDURES--
CREATE VIEW vwPlanta
AS
	SELECT Id, NombreComun, NombreCientifico, TipoPlanta, Descripcion, TiempoRiego, CantidadAgua, Epoca, EsVenenosa, EsAutoctona FROM El_Salto.dbo.Planta
GO

SELECT * FROM vwPlanta
GO

--Functions--
CREATE FUNCTION fxObtenerCantidadVenenosas()
RETURNS INT AS
	BEGIN
		RETURN (SELECT COUNT(Id) FROM vwPlanta WHERE EsVenenosa = '1')
	END
GO

SELECT El_Salto.dbo.fxObtenerCantidadVenenosas() AS 'Plantas Venenosas'
GO

CREATE FUNCTION fxObtenerCantidadAutoctonas()
RETURNS INT AS
	BEGIN
		RETURN (SELECT COUNT(Id) FROM vwPlanta WHERE EsAutoctona = '1')
	END
GO

SELECT El_Salto.dbo.fxObtenerCantidadAutoctonas() AS 'Plantas Autoctonas'
GO

--Procedures--
CREATE PROCEDURE spPlantaSave
	@NombreComun VARCHAR(255),
	@NombreCientifico VARCHAR(255),
	@TipoPlanta VARCHAR(255),
	@Descripcion VARCHAR(255),
	@TiempoRiego INT,	
	@CantidadAgua INT,	
	@Epoca VARCHAR(15),
	@EsVenenosa BIT,
	@EsAutoctona BIT
AS
	INSERT INTO El_Salto.dbo.Planta(NombreComun,NombreCientifico,TipoPlanta,Descripcion,TiempoRiego,CantidadAgua,Epoca,EsVenenosa,EsAutoctona) VALUES (@NombreComun,@NombreCientifico,@TipoPlanta,@Descripcion,@TiempoRiego,@CantidadAgua,@Epoca,@EsVenenosa,@EsAutoctona)
GO

EXEC El_Salto.dbo.spPlantaSave
	@NombreComun ='Arrayán',
	@NombreCientifico ='Luma apiculata',
	@TipoPlanta ='Luma',
	@Descripcion ='Luma apiculata es una especie arbórea perennifolia de la familia de las mirtáceas. Los colonizadores españoles lo llamaron arrayán por la semejanza de sus flores con las del arrayán europeo o mirto.',
	@TiempoRiego =24,	
	@CantidadAgua= 12,	
	@Epoca = 'primavera',
	@EsVenenosa = 0,
	@EsAutoctona = 1
GO

CREATE PROCEDURE spPlantaUpdateById
	@Id INT,
	@NombreComun VARCHAR(255),
	@NombreCientifico VARCHAR(255),
	@TipoPlanta VARCHAR(255),
	@Descripcion VARCHAR(255),
	@TiempoRiego INT,	
	@CantidadAgua INT,	
	@Epoca VARCHAR(15),
	@EsVenenosa BIT,
	@EsAutoctona BIT
AS
	UPDATE El_Salto.dbo.Planta SET NombreComun = @NombreCientifico, NombreCientifico = @NombreComun, TipoPlanta = @TipoPlanta, Descripcion = @Descripcion, TiempoRiego = @TiempoRiego, CantidadAgua = @CantidadAgua, Epoca = @Epoca, EsVenenosa = @EsVenenosa, EsAutoctona = @EsAutoctona   WHERE Id = @Id
GO

EXEC El_Salto.dbo.spPlantaUpdateById
	@Id = 1,
	@NombreComun ='Arrayán',
	@NombreCientifico ='Luma apiculata',
	@TipoPlanta ='Luma',
	@Descripcion ='Luma apiculata es una especie arbórea perennifolia de la familia de las mirtáceas. Los colonizadores españoles lo llamaron arrayán por la semejanza de sus flores con las del arrayán europeo o mirto.',
	@TiempoRiego =12,	
	@CantidadAgua= 6,	
	@Epoca = 'primavera',
	@EsVenenosa = 0,
	@EsAutoctona = 1
GO

CREATE PROCEDURE spPlantaDeleteById
	@Id INT
AS
	DELETE FROM El_Salto.dbo.Planta WHERE Id = @Id
GO

EXEC El_Salto.dbo.spPlantaDeleteById @Id = 1
GO

--Special Procedures--
CREATE PROCEDURE spObtenerCantidadVenenosas
AS
	SELECT El_Salto.dbo.fxObtenerCantidadVenenosas() AS 'Cantidad Venenosas'
GO

EXEC El_Salto.dbo.spObtenerCantidadVenenosas
GO

CREATE PROCEDURE spObtenerCantidadAutoctonas
AS
	SELECT El_Salto.dbo.fxObtenerCantidadAutoctonas() AS 'Cantidad Autoctonas'
GO

EXEC El_Salto.dbo.spObtenerCantidadAutoctonas
GO
