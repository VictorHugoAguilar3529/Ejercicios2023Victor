use InstitutoTich3;
GO
-----------------------Procedimientos almacenados-------------------

--1
/*
Crear un store procedureCodigoAscii que imprima los caracteres con su respectivo
código ascii en decimal. Solo para los caracteres cuyo código sea mayor a 32
*/
ALTER PROCEDURE calcularAnsi
AS
BEGIN
DECLARE @Codigonu Int
DECLARE @Ansi  char(1)
DECLARE @i Int = 32



 	   while (@i <= 127)
	   BEGIN
	   
       SET @Ansi = CHAR(@i)
	   SET @Codigonu= (select ASCII(@Codigonu))
	   
	   print CONCAT( @Ansi,' ', 'ANCII','=>',' ',@i)
       SET @i = @i +1
	   END
END
--
select ASCII('@')
select CHAR(64)

EXECUTE calcularAnsi 

--2
/*
Crear el store procedure Factorial que reciba como parámetro un número entero y
que devuelve el factorial calculado en un parámetro de salida
*/
ALTER PROCEDURE ProceFactorial
@numero int,
@Resultado int OUTPUT
AS
BEGIN
--DECLARE @i  int 

    IF @numero <= 1
        SET @Resultado = 1
    ELSE
        SET @Resultado = @numero * dbo.factorial( @numero - 1 )
		print @Resultado
RETURN (@Resultado)
END
GO
--
DECLARE @ResultadoOperacion INT;

EXEC ProceFactorial  @numero =5,@Resultado =@ResultadoOperacion OUTPUT;  

SELECT @ResultadoOperacion AS Resultado;
---



---3
/*
crear las tablas
*/



CREATE TABLE Saldos (
    id INT,
    Nombre VARCHAR(50) NOT NULL,
    Saldo DECIMAL(19,2)
);

CREATE TABLE Transacciones (
    id INT,
    idOrigen int NOT NULL,
    idDestino int,
	monto DECIMAL(19,2)
);



--4
/*
Crear un store procedure “Transacciones” que recibirá como parámetros el id de la
cuenta de origen, el id de la cuenta destino y el monto de la transacción. Se
deberá crear dentro de una transacción a fin de que los saldos de las cuentas
involucradas y la tabla de transacciones quede perfectamente consistente.
*/

CREATE PROCEDURE TransaccionMonetaria
    @CuentaOrigen INT,
    @CuentaDestino INT,
    @Cantidad DECIMAL(18, 2)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Verificar saldo suficiente en la cuenta origen
        DECLARE @SaldoOrigen DECIMAL(18, 2);
        SELECT @SaldoOrigen = Saldo FROM Saldos WHERE ID = @CuentaOrigen;

        IF @SaldoOrigen >= @Cantidad
        BEGIN
            -- Restar la cantidad de la cuenta origen
            UPDATE Saldos SET Saldo = Saldo - @Cantidad WHERE ID = @CuentaOrigen;

            -- Sumar la cantidad a la cuenta destino
            UPDATE Saldos SET Saldo = Saldo + @Cantidad WHERE ID = @CuentaDestino;
            COMMIT;
            PRINT 'Transacción completada exitosamente.';
        END
        ELSE
        BEGIN
            ROLLBACK;
            PRINT 'Saldo insuficiente en la cuenta origen.';
        END
    END TRY
    BEGIN CATCH
        ROLLBACK;
        PRINT 'Error en la transacción. Se ha realizado un rollback.';
		THROW 51000,'Error al realizar la transferencia', 1;
    END CATCH;
END;

----------
EXECUTE TransaccionMonetaria @CuentaOrigen=1,@CuentaDestino=2,@Cantidad=1000











-----------------------------ACTIVIDADES FINALES--------------------------------

--1
/*
Realizar una vista vAlumnos que obtenga el siguiente resultado
*/
use InstitutoTich3;
GO
CREATE VIEW V_Alumnos
AS
SELECT Alumnos.id as id, Alumnos.nombre as nombre, Alumnos.primerApellido as apellido_paterno,
	   Alumnos.segundoApellido as apellidoMaterno, Alumnos.correo as correo, Alumnos.telefono as telefono,
Estados.nombre as estado, EstatusAlumnos.Nombre as estatus
FROM Alumnos INNER JOIN 
	 EstatusAlumnos ON Alumnos.idEstatus = EstatusAlumnos.id INNER JOIN
	 Estados ON Alumnos.idEstadoOrigen = Estados.id
GO
--Ejecutar una vista:
SELECT *
FROM V_Alumnos



--2
/*
Realizar el procedimiento almacenado consultarEstados el cual obtendrá la
siguiente consulta, recibiendo como parámetro el id del registro que se
requiere consultar de la tabla Estados. En caso de que el valor sea -1 (menos
uno) deberá regresar todos los registros de dicha tabla.
*/
ALter procedure consultarEstados
@id int 
as
select id, nombre
from Estados
where id=@id OR @id< 0 
GO
--ejecutar procedure
exec consultarEstados @id = 1;

--3
/*
Realizar el procedimiento almacenado consultarEstatusAlumnos el cual
obtendrá la siguiente consulta, recibiendo como parámetro el id del registro
que se requiere consultar de la tabla estatusAlumnos. En caso de que el valor
sea -1 (menos uno) deberá regresar todos los registros de dicha tabla
*/
ALTER procedure consultarEstatus
@id int 
as
select id, nombre
from EstatusAlumnos
where id=@id OR @id< 0 
GO
--ejecutar procedure
exec consultarEstatus @id = -1;


--4
/*
Realizar el procedimiento almacenado consultarAlumnos el cual obtendrá la
siguiente consulta, recibiendo como parámetro el id del registro que se
requiere consultar de la tabla Alumnos. En caso de que el valor sea -1 (menos
uno) deberá regresar todos los registros de dicha tabla.
*/
ALTER procedure consultarAlumnos
@id int 
as
select Alumnos.id as id, Alumnos.nombre as nombre, Alumnos.primerApellido as apellidoPaterno, Alumnos.segundoApellido as apellidoMaterno,
	   Alumnos.fechaNacimiento as fechaNacimieto, Alumnos.telefono as telefono, Alumnos.correo as correo,
	   Estados.nombre as estado,
	   EstatusAlumnos.Nombre as estatus
from Alumnos INNER JOIN
	 Estados ON Alumnos.idEstadoOrigen = Estados.id INNER JOIN
	 EstatusAlumnos ON  Alumnos.idEstatus = EstatusAlumnos.id
where Alumnos.id=@id OR @id< 0 
GO
--ejecutar
exec consultarAlumnos @id = -2;
GO

--5
/*
Realizar el procedimiento almacenado consultarEAlumnos el cual obtendrá la
siguiente consulta, recibiendo como parámetro el id del registro que se
requiere consultar de la tabla Alumnos. En caso de que el valor sea -1 (menos
uno) deberá regresar todos los registros de dicha tabla
*/
CREATE procedure consultarEAlumnos
@id int 
as
select Alumnos.id as id, Alumnos.nombre as nombre, Alumnos.primerApellido as apellidoPaterno, Alumnos.segundoApellido as apellidoMaterno,
	   Alumnos.fechaNacimiento as fechaNacimieto, Alumnos.telefono as telefono, Alumnos.correo as correo,
	   Estados.id as estado,
	   EstatusAlumnos.id as estatus
from Alumnos INNER JOIN
	 Estados ON Alumnos.idEstadoOrigen = Estados.id INNER JOIN
	 EstatusAlumnos ON  Alumnos.idEstatus = EstatusAlumnos.id
where Alumnos.id=@id OR @id< 0 
GO
--ejecutar
exec consultarEAlumnos @id = -2;
GO



--6
/*
Realizar el procedimiento almacenado actualizarEstatusAlumnos el cual
recibirá como parámetros el id del Alumno al cual se le requiere cambiar el
estatus y el valor del nuevo estatus.
*/
CREATE PROCEDURE actualizarEstatusAlumnos
    @IdAlumno INT,
    @IdEstatus INT
AS
BEGIN
    BEGIN TRY
        BEGIN;
 
            -- actualizar estatus alumno
            UPDATE Alumnos SET idEstatus = @IdEstatus WHERE ID = @IdAlumno;


            PRINT 'Transacción completada exitosamente.';
        END

    END TRY
    BEGIN CATCH
        ROLLBACK;
        PRINT 'Error al actualizar rollback.';
		THROW 51000,'Error al actualizar', 1;
    END CATCH;
END;

----------
EXECUTE actualizarEstatusAlumnos @IdAlumno=1,@IdEstatus=2

--7
/*
Realizar el procedimiento almacenado agregarAlumnos el cual recibirá como
parámetros los valores de cada una de las columnas de la tabla de Alumnos
con los cuales se insertará el registro a la tabla Alumnos. El procedimiento
deberá regresar el id con el que se creo el registro en formato de entero.
*/
CREATE PROCEDURE agregarAlumnos
@nombre varchar(10),
@primerApellido varchar(10),
@segundoApellido varchar(10),
@correo varchar(10),
@telefono nchar(10),
@fechaNacimiento date,
@curp nchar(18),
@sueldo decimal(9,2),
@idEstadoOrigen smallint,
@idEstatus smallint,
@IdAlumnoCreado int OUTPUT

AS
BEGIN
    BEGIN TRY
        BEGIN;
 
            -- actualizar estatus alumno
            INSERT INTO Alumnos (nombre, primerApellido, segundoApellido, correo, telefono, fechaNacimiento, curp, sueldo, idEstadoOrigen,
						idEstatus) 
			values (@nombre,@primerApellido,@segundoApellido,@correo,@telefono,@fechaNacimiento,@curp,@sueldo,@idEstadoOrigen,@idEstatus)
			SET @IdAlumnoCreado =IDENT_CURRENT( 'Alumnos' ) 

            PRINT @IdAlumnoCreado;
        END

    END TRY
    BEGIN CATCH
        ROLLBACK;
        PRINT 'Error al actualizar rollback.';
		THROW 51000,'Error al actualizar', 1;
    END CATCH;
END;

----------
DECLARE @Resultadoid INT;

EXEC agregarAlumnos  @nombre ='Victor',
					 @primerApellido ='Hugo',
					 @segundoApellido ='Aguilar',
					 @correo ='victorh@gmail.com',
					 @telefono = 4422831646,
					 @fechaNacimiento ='2000/12/15',
					 @curp ='AUAV001215HQTGGCA9',
	                 @sueldo =700,
                     @idEstadoOrigen =21,
                     @idEstatus  =  1,
					 @IdAlumnoCreado =@Resultadoid OUTPUT;  

SELECT @Resultadoid AS IDdAlumnoCreado;


--8
/*
Realizar el procedimiento almacenado actualizarAlumnos el cual recibirá
como parámetros los valores de cada una de las columnas de la tabla de
i d nombre primerApellidosegundoApellido correo fechaNacimiento telefono curp Estado Estatus
3 Carlos Martínez Mirón marce_guitarr_1996@outlook.com01/01/1995 2711372600 CURP00000000000003 Veracruz Prospecto
i d nombre primerApellidosegundoApellido correo fechaNacimiento telefono curp Estado Estatus
3 Carlos Martínez Mirón marce_guitarr_1996@outlook.com01/01/1995 2711372600 CURP00000000000003 Veracruz Prospecto
4 Dafne Martínez Estudillo aleestudillomq@gmail.com 01/01/1995 4493877417 CURP00000000000004 Oaxaca Laborando
5 Yered Mendoza García omendozag@outlook.es 01/01/1995 2711189568 CURP00000000000005 Veracruz En capacitación
6 Pedro Rodríguez Flores alo.756@hotmail.com 01/01/1995 2224108674 CURP00000000000006 Puebla En capacitación
i d nombre primerApellidosegundoApellido fechaNacimiento correo telefono curp idEstadoOrigen idEstatus
3 Carlos Martínez Mirón 01/01/1995 marce_guitarr_1996@outlook.com 2711372600 CURP00000000000003 29 1
i d nombre primerApellidosegundoApellido fechaNacimiento correo telefono curp idEstadoOrigen idEstatus
3 Carlos Martínez Mirón 01/01/1995 marce_guitarr_1996@outlook.com 2711372600 CURP00000000000003 29 1
4 Dafne Martínez Estudillo 01/01/1995 aleestudillomq@gmail.com 4493877417 CURP00000000000004 19 5
5 Yered Mendoza García 01/01/1995 omendozag@outlook.es 2711189568 CURP00000000000005 29 3
6 Pedro Rodríguez Flores 01/01/1995 alo.756@hotmail.com 2224108674 CURP00000000000006 20 3
Alumnos con los cuales se actualizarán los valores que existen en la tabla
Alumnos del registro que corresponda al id enviado como parámetro. El
procedimiento deberá regresar la cantidad de registros actualizados.
*/

ALTER PROCEDURE actualizarAlumnos
@idAlumno int,
@nombre varchar(10),
@primerApellido varchar(10),
@segundoApellido varchar(10),
@correo varchar(10),
@telefono nchar(10),
@fechaNacimiento date,
@curp nchar(18),
@sueldo decimal(9,2),
@idEstadoOrigen smallint,
@idEstatus smallint

AS
BEGIN
    BEGIN TRY
        BEGIN;
 
            -- actualizar estatus alumno
			UPDATE Alumnos SET  
							--[id] = @idAlumno,
							[Nombre] = @nombre,
						    [primerApellido] = @primerApellido,
							[segundoApellido] = @segundoApellido,
							[correo] = @correo,
							[telefono] = @telefono,
							[fechaNacimiento] = @fechaNacimiento,
							[curp] = @curp,
							[sueldo] = @sueldo,
							[idEstadoOrigen] = @idEstadoOrigen,
							[idEstatus] = @idEstatus

            WHERE id= @idAlumno
            	   print CONCAT('Sel actualizo el registro con el id ', @idAlumno, 'del alumno ',@nombre, ' ', @primerApellido, ' ',@segundoApellido)
        END

    END TRY
    BEGIN CATCH
        ROLLBACK;
        PRINT 'Error al actualizar rollback.';
		THROW 51000,'Error al actualizar', 1;
    END CATCH;
END;

----------
EXEC actualizarAlumnos  @idAlumno = 20,
						@nombre ='Victor',
						@primerApellido ='Hugo',
						@segundoApellido ='Aguilar',
						@correo ='victorh@gmail.com',
						@telefono = 4422831646,
						@fechaNacimiento ='2000/12/15',
					    @curp ='AUAV001215HQTGGCA9',
						@sueldo =700,
						@idEstadoOrigen =21,
						@idEstatus  =  2;  



--9
/*
Realizar el procedimiento almacenado eliminarAlumnos el cual recibirá como
parámetros el valor del id del registro del alumno del que se requiere eliminar.
Primeramente se deberán eliminar todos los registros de la Tabla de
CursosAlumnos los cuales tengan el id del alumno a eliminar y posteriormente
el eliminar al alumno de la Tabla de Alumnos.
Esto deberá considerarse como una transacción ya que se trate de actualizar
dos tablas relacionadas.
En caso de que no se haya eliminado el registro de la tabla de Alumnos
deberá levantar una excepción.

*/

CREATE PROCEDURE eliminarAlumnos
    @idAlumno int
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Eliminar Alumno de cursos
        DECLARE @SaldoOrigen DECIMAL(18, 2);
        DELETE FROM CursosAlumnos WHERE idAlumno = @idAlumno;


        --Eliminar alumno
        DELETE FROM Alumnos WHERE id = @idAlumno;
       

    END TRY
    BEGIN CATCH
        ROLLBACK;
        PRINT 'Error en la transacción. Se ha realizado un rollback.';
		THROW 51000,'Error al realizar la transferencia', 1;
    END CATCH;
END;

----------
EXECUTE eliminarAlumnos @idAlumno=20

-----------------------------------TROGERS---------------------------------------

--10
/*
Crear el trigger Trigger_EliminarAlumnos el cual se debe ejecutar cuando se
elimina un registro de la tabla de Alumnos. Este trigger deberá insertar un
registro en la Tabla AlumnosBaja del alumno eliminado.
*/
	ALTER TRIGGER Trigger_EliminarAlumnos
	ON Alumnos
	AFTER DELETE
	AS
	SET NOCOUNT ON --impide que se muestre en los mensajes la fila afectada 
	BEGIN
		
		INSERT INTO AlumnosBaja (id,
								nombre,
								 primerApellido,
								 segundoApellido
								 )
		SELECT d.id,
			   d.nombre,
			   d.primerApellido,
			   d.segundoApellido

		FROM deleted d;
	END
	GO
	DELETE from Alumnos WHERE id = 19


	select * from AlumnosBaja
--11
/*
*/
create database PruebasTich


--------13
/*
Sobre la base de datos PruebasTich crear el store Procedure
spEliminaAlumnosCurso el cual deberá eliminar los alumnos que se
encuentren en un determinado curso por lo que recibirá como parámetro el
nombre del curso.

*/
use PruebasTich
GO

ALTER PROCEDURE spEliminaAlumnosCurso
    @NombreCurso VARCHAR(30)
AS
BEGIN

    BEGIN TRY    
	BEGIN TRANSACTION
        -- id curso
        DECLARE @IdCurso int
		SET @IdCurso = (select TOP 1 CursosAlumnos.idCurso
						 from CatCursos INNER JOIN  CursosAlumnos ON CatCursos.id = CursosAlumnos.idCurso
						 Where CatCursos.nombre = @NombreCurso)	       

        --Eliminar alumnos del curso
		DELETE FROM CursosAlumnos WHERE idCurso = @IdCurso;

       
	   COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK;
        PRINT 'Error al eliminar loa alumnos del curso. Se ha realizado un rollback.';
		THROW 51000,'Error al eliminar los alumnos dle curso', 1;
    END CATCH;
END;

----------
EXECUTE spEliminaAlumnosCurso @NombreCurso='matematicas'
select * from cursosAlumnos
select * from CatCursos