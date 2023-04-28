CREATE DATABASE EvaluacionWepsys

--------Tabla Persona---------
CREATE TABLE persona(
IdPersona int identity(1,1) NOT NULL PRIMARY KEY,
Nombres varchar(100)  NOT NULL CHECK (Nombres <> ''),
Apellidos varchar(100)  NOT NULL CHECK (Apellidos <> ''),
Matricula CHAR(10) NOT NULL CHECK (Matricula LIKE '[1234567890abcdefghijklmnopqrstuvwxy][1234567890abcdefghijklmnopqrstuvwxy][1234567890abcdefghijklmnopqrstuvwxy][1234567890abcdefghijklmnopqrstuvwxy][1234567890abcdefghijklmnopqrstuvwxy][1234567890abcdefghijklmnopqrstuvwxy][1234567890abcdefghijklmnopqrstuvwxy][1234567890abcdefghijklmnopqrstuvwxy][1234567890abcdefghijklmnopqrstuvwxy][1234567890abcdefghijklmnopqrstuvwxy]'),
FechaDeNacimiento DATETIME NOT NULL,
UbicacionLatitud Decimal,
UbicacionLongitud Decimal,
UbicacionAltitud Decimal
)


--------SPGuardarPersona---------
CREATE PROCEDURE GuardarPersona
(
    @Nombres VARCHAR(100),
    @Apellidos VARCHAR(100),
	@Matricula CHAR(10),
    @FechaDeNacimiento DATETIME,
    @UbicacionLatitud Decimal,
    @UbicacionLongitud Decimal,
    @UbicacionAltitud Decimal
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO persona (Nombres, Apellidos, Matricula, FechaDeNacimiento, UbicacionLatitud, UbicacionLongitud, UbicacionAltitud )
    VALUES (@Nombres, @Apellidos, @Matricula, @FechaDeNacimiento, @UbicacionLatitud, @UbicacionLongitud, @UbicacionAltitud  )
END

--------SPConsultarPersonas---------
CREATE PROCEDURE ConsultarPersonas
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM persona;
END

--------SPConsultarMatriculaExacta---------
CREATE PROCEDURE ConsultarMatriculaExacta
(
    @Matricula CHAR(10)
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM persona WHERE Matricula = @Matricula;
END



