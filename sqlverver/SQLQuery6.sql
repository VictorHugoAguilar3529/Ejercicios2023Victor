use InstitutoTich3;
GO
use EJercicios

--ejercicio 1
 use InstitutoTich3;
 GO
select  primerApellido as [Apellido Paterno],segundoApellido as [Apellido Materno], nombre, telefono, correo
 INTO Ejercicios.dbo.Alumnos_CopA 
from Alumnos

GO


--Ejercicio 2
 use InstitutoTich3
select  nombre, primerApellido as [Apellido Paterno],segundoApellido as [Apellido Materno], rfc, primerApellido as [Cuota por hora]
INTO Ejercicios.dbo.Instructores_CopA from Instructores


GO


--Ejercicio 3
 use InstitutoTich3
select  clave, nombre,descripcion, horas
INTO Ejercicios.dbo.CatCursos_CopA 
from CatCursos

GO

--Ejercicio 4
 use InstitutoTich3
select  top(5) *
INTO Ejercicios.dbo.Alumnosjovenes_CopA 
from Alumnos
ORDER BY fechaNacimiento desc

GO

create database EJercicios;
GO


--join

 use InstitutoTich3
select  nombre, primerApellido as [Apellido Paterno],segundoApellido as [Apellido Materno], rfc, cuotaHora as [Cuota por hora], activo as status
INTO Ejercicios.dbo.ins_CopA from Instructores


GO

--2

SELECT Catcur.nombre as Curso, Horas as hora, Cur.fechaInicio,fechaTermino
	FROM Cursos Cur INNER JOIN  CatCursos Catcur
	ON Cur.idCatCurso = Catcur.id 
	WHERE Horas = 50

GO


--3
SELECT nombre,primerApellido,segundoApellido, curp 
	
	 from Alumnos
	

	GO


--4
SELECT inst.nombre as nombre, inst.cuotaHora as cuotaHora, cur.fechaInicio as fechaInicio, cur.fechatermino as fechatermino
	FROM Instructores inst INNER JOIN  Cursos cur 
	ON inst.id = cur.idCatCurso 
	GO

--5

SELECT Allum.nombre as nombre, Allum.primerApellido as primerApellido, Allum.segundoApellido as segundoApellido, cat.nombre  as nombre, curr.fechaInicio as fechaInicio, curr.fechatermino as fechatermino, cura.calificacion as calificacion
	FROM Alumnos Allum INNER JOIN  CursosAlumnos cura 
	ON Allum.id = cura.idCurso
	  INNER JOIN Cursos curr
	ON curr.id = cura.idCurso
	INNER JOIN CatCursos cat
	ON cat.id = curr.idCatCurso
	GO


--6
SELECT Allum.nombre as nombre, Allum.primerApellido as primerApellido, Allum.segundoApellido as segundoApellido, cat.nombre  as nombre, curr.fechaInicio as fechaInicio, curr.fechatermino as fechatermino, cura.calificacion as calificacion
	FROM Alumnos Allum INNER JOIN  CursosAlumnos cura 
	ON Allum.id = cura.idAlumno
	INNER JOIN CatCursos cat
	ON cat.id = cura.id 
	INNER JOIN Cursos curr
	ON curr.id = cura.id 
	ORDER BY calificacion desc

	GO


--7
 use InstitutoTich3
select  cur.clave as clave, cur.nombre as nombre, cur.horas as horas ,  IIF(cur.idPreRequisito  is NULL, 'Sin prerequisito', cat.nombre) as Perrequisito
FROM CatCursos Cat RIGHT JOIN  CatCursos cur 
ON cat.id = cur.idPreRequisito 

GO

-- Consulta alumnos curso
use InstitutoTich3;
GO
SELECT Alumnos.id, Alumnos.nombre, primerApellido, segundoApellido,  est.nombre, curr.fechaInicio, curr.fechaTermino, calificacion,
CASE
	WHEN calificacion>8 THEN 'Excelente'
	WHEN calificacion>6 THEN 'Bien'
	WHEN calificacion=6 THEN 'Suficiente'
	WHEN calificacion<6 THEN 'N/A'
END AS 'Nivel'
FROM Alumnos
	INNER JOIN Estados est
ON est.id = Alumnos.idEstadoOrigen
    INNER JOIN CursosAlumnos cura
ON cura.idAlumno = Alumnos.idEstadoOrigen
    INNER JOIN Cursos curr
ON curr.id = Alumnos.idEstadoOrigen
	



--fuunciones del sistema
--1 SELECT DATEDIFF(year,'2010/05/12','2022/05/12') AS DateDif;
SELECT id,nombre, primerApellido, segundoApellido,  fechaNacimiento, GETDATE() as Hoy, DATEDIFF(year,fechaNacimiento, GETDATE()) AS Edad, DATEDIFF(year, DATEADD(month, -5, fechaNacimiento), GETDATE()) AS Edad5Meses
from Alumnos
 GO


 --2
SELECT id,nombre, UPPER(primerApellido) as primerApellido, UPPER(segundoApellido) as segundoApellido ,  fechaNacimiento, GETDATE() as Hoy, DATEDIFF(year,fechaNacimiento, GETDATE())  AS Edad, DATEDIFF(year, DATEADD(month, -5, fechaNacimiento), GETDATE()) AS Edad5Meses
from Alumnos
GO

--3 
SELECT id,nombre, primerApellido, segundoApellido,  fechaNacimiento, curp, SUBSTRING(curp, 5, 6) as [FEchaCurp]
from Alumnos
 GO


--4
SELECT id,nombre, primerApellido, segundoApellido,  fechaNacimiento, curp, SUBSTRING(curp, 11, 1) as [Sexo]
from Alumnos
 GO


 --5
 SELECT id,nombre, primerApellido, segundoApellido,  fechaNacimiento, correo, REPLACE(correo, '@gmail', '@hotmail') as CorreoHot
from Alumnos
 GO

 -----------------------

 ---1
use InstitutoTich3;
GO

  SELECT Est.nombre as Estado, count(CurAlu.calificacion) as Totalalumnos
  FROM Alumnos Alu INNER JOIN 
				Estados Est ON Alu.idEstadoOrigen = Est.id INNER JOIN
				CursosAlumnos CurAlu ON Alu.id = CurAlu.idAlumno 
  WHERE Alu.id >1
GROUP BY Est.nombre
ORDER BY Estado

GO

---2
use InstitutoTich3;
GO

  SELECT esta.nombre as Estatus, count(esta.Nombre) as Total
  FROM Alumnos Alu INNER JOIN 
				Estados Est ON Alu.idEstadoOrigen = Est.id INNER JOIN
				EstatusAlumnos esta ON Alu.id = esta.id 
  WHERE Alu.id >1
GROUP BY esta.nombre
ORDER BY esta.nombre

GO

----3
use InstitutoTich3;
GO

 SELECT  'calificaciones' as 'calificacines alumnos', count(CurAlu.calificacion) as Total, max(CurAlu.calificacion) as Maxima, min(CurAlu.calificacion) as Minima, AVG(CurAlu.calificacion) as Promedio
  FROM Alumnos Alu INNER JOIN 
				CursosAlumnos CurAlu ON Alu.id = CurAlu.idAlumno 
  WHERE Alu.id >0



---4
   SELECT  cat.nombre as nombre, count(CurAlu.calificacion) as Total, max(CurAlu.calificacion) as Maxima, min(CurAlu.calificacion) as Minima, AVG(CurAlu.calificacion) as Promedio
  FROM Alumnos Alu INNER JOIN 
				CursosAlumnos CurAlu ON Alu.id = CurAlu.idAlumno INNER JOIN
				CatCursos cat ON CurAlu.idCurso = cat.id
				 
  WHERE Alu.id >0
GROUP BY cat.nombre
ORDER BY nombre

GO


--5
 SELECT  est.nombre as nombre, count(CurAlu.calificacion) as Total, max(CurAlu.calificacion) as Maxima, min(CurAlu.calificacion) as Minima, AVG(CurAlu.calificacion) as Promedio
 FROM Alumnos Alu INNER JOIN 
				CursosAlumnos CurAlu ON Alu.id = CurAlu.idAlumno INNER JOIN
				CatCursos cat ON CurAlu.idCurso = cat.id INNER JOIN
				Estados est On alu.idEstadoOrigen = est.id

				 
WHERE Alu.id >1
GROUP BY est.nombre
HAVING AVG (CurAlu.calificacion) > 2
ORDER BY nombre



----------------Filtros-------------------------

---1
SELECT *
FROM Alumnos
WHERE segundoApellido LIKE 'Mendoza';

GO

--2
SELECT *
	FROM Alumnos Allu INNER JOIN EstatusAlumnos est
	ON Allu.id = est.id 
	WHERE est.Nombre LIKE 'En Capacitación';
	GO

--3 ISNUMERIC(25648.5)
 SELECT id,nombre, primerApellido, segundoApellido,  fechaNacimiento, GETDATE() as Hoy, DATEDIFF(year,fechaNacimiento, GETDATE()) AS Edad
from Instructores
WHERE DATEDIFF(year,fechaNacimiento, GETDATE()) > 30;
 GO

 --4
 SELECT id,nombre, primerApellido, segundoApellido,  fechaNacimiento, GETDATE() as Hoy, DATEDIFF(year,fechaNacimiento, GETDATE()) AS Edad
from Alumnos
--ERE DATEDIFF(year,fechaNacimiento, GETDATE()) >= 25 AND DATEDIFF(year,fechaNacimiento, GETDATE()) <=30
WHERE  DATEDIFF(year,fechaNacimiento, GETDATE()) BETWEEN 20 AND 25
 GO

--5
 SELECT  Alu.nombre as nombre, est.nombre as origen, esta.Nombre
 FROM Alumnos Alu INNER JOIN 
				EstatusAlumnos esta ON Alu.id = esta.id INNER JOIN
				Estados est On alu.idEstadoOrigen = est.id

				 
WHERE est.nombre LIKE 'Oaxaca'
AND esta.Nombre Like 'En Capacitación'
OR est.nombre LIKE 'Campeche'
AND esta.Nombre Like 'Prospecto'

--6
SELECT *
from Alumnos
where correo LIKE '%gmail%';

--7
select *
FROM Alumnos 
where fechaNacimiento LIKE '%2000-03%';


--8
SELECT id, nombre, primerApellido, segundoApellido, DATEDIFF(year,fechaNacimiento, GETDATE()) AS Edad
FROM Alumnos
WHERE(DATEDIFF(year,fechaNacimiento, GETDATE())+5) >= 30
GO

--9
select *
FROM Alumnos
where nombre LIKE '__________';

--10

select *
FROM Alumnos 
where curp  LIKE '[N]%';

GO
--11
 SELECT  Alu.nombre as nombre, Alu.primerApellido, Alu.segundoApellido, cur.calificacion
 FROM Alumnos Alu INNER JOIN 
				Cursos curs ON Alu.id = curs.idCatCurso INNER JOIN
				CursosAlumnos cur On alu.id = cur.calificacion 


				 
WHERE cur.calificacion > 4
GO

--12
 SELECT ALu.id as id, Alu.nombre as nombre, esta.Nombre as estatus, Alu.sueldo
 FROM Alumnos Alu INNER JOIN 
				EstatusAlumnos esta ON Alu.id = esta.id 
				 
WHERE esta.Nombre LIKE 'Laborando' OR esta.Nombre LIKE 'Prospecto'
AND Alu.sueldo > 15000
GO


--13
SELECT *
FROM Alumnos
WHERE fechaNacimiento LIKE '%[1990-1995]';
GO
--14
SELECT nombre, convert(date,(SUBSTRING(curp, 5,6))) as fechacurp, fechaNacimiento
FROM Alumnos

WHERE fechaNacimiento = convert(date,(SUBSTRING(curp, 5,6)));

--15


SELECT nombre, primerApellido, segundoApellido, SUBSTRING(curp, 7,2) as mes,DATEDIFF(year,fechaNacimiento, GETDATE()) AS Edad
FROM Alumnos
WHERE primerApellido LIKE  '[A]%' AND SUBSTRING(curp, 7,2) = 04 
AND DATEDIFF(year,fechaNacimiento, GETDATE()) > 21 AND DATEDIFF(year,fechaNacimiento, GETDATE()) <30

--16
SELECT *
FROM Alumnos
where nombre LIKE '%Luis%';

--17


use InstitutoTich3;
GO

 SELECT  cat.nombre as nombre, cur.fechaInicio as inicio, cur.fechatermino as termino, COUNT(CurAlu.idAlumno) as TOTAlALum, AVG(CurAlu.calificacion) as Promedio
  FROM Alumnos Alu INNER JOIN 
				CursosAlumnos CurAlu ON Alu.id = CurAlu.idAlumno INNER JOIN
				CatCursos cat ON CurAlu.idCurso = cat.id INNER JOIN
				Cursos cur On cat.id = cur.idCatCurso
				 
WHERE cur.fechaInicio LIKE '2021-%' OR cur.fechatermino LIKE '2021-%'
GROUP BY cat.nombre, cur.fechaInicio, cur.fechatermino
ORDER BY nombre
GO

--18
 SELECT  est.nombre as nombre, count(CurAlu.calificacion) as Total, AVG(CurAlu.calificacion) as Promedio, AVG(Alu.sueldo) as SUeldoPromedio
 FROM Alumnos Alu INNER JOIN 
				CursosAlumnos CurAlu ON Alu.id = CurAlu.idAlumno INNER JOIN
				CatCursos cat ON CurAlu.idCurso = cat.id INNER JOIN
				Estados est On alu.idEstadoOrigen = est.id

				 
WHERE Alu.id >1
GROUP BY est.nombre
HAVING AVG (CurAlu.calificacion) > 6
ORDER BY nombre
GO


------subconsultas-----------
use InstitutoTich3;
GO
---1
/*
Obtener el nombre del alumno cuya longitud es la más grande

*/
SELECT id, nombre, LEN(nombre) as numerocaracteres
FROM Alumnos
WHERE LEN(nombre) >= All (SELECT LEN(nombre) as numerocaracteres FROM Alumnos);

--2
/*
. Mostrar el o los alumnos menos jóvenes

*/
SELECT nombre, DATEDIFF(year,fechaNacimiento, GETDATE()) AS Edad
FROM Alumnos
WHERE DATEDIFF(year,fechaNacimiento, GETDATE()) >= ALL (SELECT DATEDIFF(year,fechaNacimiento, GETDATE()) AS Edad FROM Alumnos);
SELECT * FROM Alumnos

GO

--3
/*
. Obtener una lista de los alumnos que tuvieron la máxima calificación

*/
 SELECT  cat.nombre as curso, cur.fechainicio, cur.fechatermino, CurAlu.calificacion
  FROM Alumnos Alu INNER JOIN 
				CursosAlumnos CurAlu ON Alu.id = CurAlu.idAlumno INNER JOIN 
				CatCursos cat ON CurAlu.idCurso = cat.id INNER JOIN 
				Cursos cur ON cat.id = cur.idCatCurso
  WHERE CurAlu.calificacion  IN (SELECT MAX(calificacion) as calidicacion FROM CursosAlumnos  );



  ---4
 /*
. Obtener la siguiente consulta con los datos de cada uno de los cursos

*/
select   prom.idc ,prom.nombre, prom.fechaInicio, prom.fechatermino,prom.minimo, prom.maximo, prom.promedio
FROM CursosAlumnos
				INNER JOIN (SELECT DISTINCT CursosAlumnos.idCurso as idc, CatCursos.nombre, AVG(CursosAlumnos.calificacion) as promedio, min(CursosAlumnos.calificacion) as minimo, max(CursosAlumnos.calificacion) as maximo, Cursos.id,Cursos.fechaInicio, Cursos.fechatermino 
				FROM CursosAlumnos
				INNER JOIN 
				Cursos  ON Cursos.id = CursosAlumnos.idCurso
                INNER JOIN 
				CatCursos ON CatCursos.id = CursosAlumnos.idCurso  
				GROUP BY CursosAlumnos.idCurso, CatCursos.nombre, Cursos.id, Cursos.fechaInicio, Cursos.fechatermino) as prom
ON prom.id = CursosAlumnos.idCurso


WHERE CursosAlumnos.idCurso IN (SELECT DISTINCT idCurso FROM CursosAlumnos) 
--AND CursosAlumnos.calificacion = prom.promedio

--5
 /*
Obtener una consulta de los alumnos que tienen una calificación igual o menor
que el promedio de calificaciones.os

*/
 SELECT  Alu.nombre as nombre, Alu.primerApellido as apellido1, Alu.segundoApellido as apellido2, cat.nombre as curso, cur.fechainicio, cur.fechatermino, CurAlu.calificacion
  FROM Alumnos Alu INNER JOIN 
				CursosAlumnos CurAlu ON Alu.id = CurAlu.idAlumno INNER JOIN 
				CatCursos cat ON CurAlu.idCurso = cat.id INNER JOIN 
				Cursos cur ON cat.id = cur.idCatCurso
  
  WHERE CurAlu.calificacion  <= ALL (SELECT AVG(calificacion) as promedio FROM CursosAlumnos  );
 

 --6
 /*
. Obtener una lista de los alumnos que tuvieron la máxima calificación en cada uno
de los cursos.

*/

select Alumnos.nombre, Alumnos.primerApellido, segundoApellido, fechaNacimiento, Calmax.nombre, Calmax.fechatermino, Calmax.calificacion
FROM CursosAlumnos  
                INNER JOIN 
				Alumnos  ON Alumnos.id = CursosAlumnos.idAlumno 
				INNER JOIN (SELECT CatCursos.nombre, MAX(CursosAlumnos.calificacion) as calificacion, Cursos.id,Cursos.fechaInicio, Cursos.fechatermino 
				FROM CursosAlumnos
				INNER JOIN 
				Cursos  ON Cursos.id = CursosAlumnos.idCurso
                INNER JOIN 
				CatCursos ON CatCursos.id = CursosAlumnos.idCurso  
				GROUP BY CatCursos.nombre, Cursos.id, Cursos.fechaInicio, Cursos.fechatermino) as Calmax
ON Calmax.id = CursosAlumnos.idCurso


WHERE  CursosAlumnos.idCurso = Calmax.id AND CursosAlumnos.calificacion = Calmax.calificacion




-----------------------OpERADORES DE CONJUNTO-----------------------
-------1
/*
. Obtener una consulta que contenga el Nombre y apellidos, mes y día
de nacimiento de todos los alumnos y profesores, ordenado por tipo
mes y día de nacimiento
*/
use InstitutoTich3;
GO

	SELECT 'Alumno' as TipoPersona,nombre, primerApellido, segundoApellido, substring(curp, 7,2) as MesNacimiento, substring(curp, 9,2) as DiaNacimiento
	FROM Alumnos
	UNION 
	SELECT 'Profesor' as TipoPersona, nombre, primerApellido, segundoApellido, substring(curp, 7,2) as MesNacimiento, substring(curp, 9,2) as DiaNacimiento
	FROM Instructores
	ORDER BY TipoPersona

	SELECT * FROM Alumnos
	SELECT * FROM Instructores

-----------------Actualizaciones-----------
--1
/*
Actualizar el estatus del Alumnos de los que están en propedéutico a capacitación
*/

UPDATE Alumnos SET idEstatus = 2
WHERE idEstatus = 1
select * from Alumnos
--2

/*
. Actualizar el segundo apellido del Alumno a Mayúsculas


*/


	UPDATE Alu SET Alu.segundoApellido = upper(Alu.segundoApellido)
	FROM Alumnos Alu 
	WHERE id= 2

	
	select UPPER(Alu.segundoApellido)
	FROM Alumnos Alu 
	WHERE id= 1

	SELECT * FROM Alumnos
--3
/*
Actualizar el segundo Apellido para que la primera letra sea mayúsculas y el resto
minúsculas
STUFF(LOWER(segundoApellido), 1,1 ,
*/ 


select * from Alumnos
UPDATE Alumnos SET segundoApellido = STUFF(LOWER(segundoApellido), 1,1 , UPPER(LEFT(segundoApellido,1)))
	WHERE id=2

--4
/*
 Actualizar el número telefónico de los instructores para que los dos primeros
dígitos sean 55, en caso de que de acuerdo al curp sean del DF
 STUFF('Practicando SQL server', 2, 10, 'en TICH')
*/



UPDATE Instructores SET telefono = '55'+SUBSTRING(telefono,3, LEN(telefono))
WHERE substring(curp,12,2) = 'DF'
Select * from Instructores
--5
/*
Subirles un punto en la calificación a los alumnos de Hidalgo y Oaxaca, y del
Curso impartido en junio de 2021. Se deberá considerar que al incrementar el
punto no exceda del máximo de la calificación permitida.
*/
use InstitutoTich3;
GO
UPDATE CursosAlumnos SET CursosAlumnos.calificacion = CursosAlumnos.calificacion +1
from CursosAlumnos  INNER JOIN
Cursos   ON CursosAlumnos.id = Cursos.id INNER JOIN
Alumnos ON Alumnos.id = CursosAlumnos.idAlumno
WHERE  CursosAlumnos.calificacion <= 9 
AND Cursos.fechaInicio LIKE '%2021-04%' 
AND ( Alumnos.idEstadoOrigen = 12 
OR Alumnos.idEstadoOrigen = 19 );

select * from  CursosAlumnos
--6
/*
Subirle el 10% de la cuota por hora a los profesores que han impartido el curso de
Desarrollador .Net

*/

UPDATE Instructores SET cuotaHora = (ins.cuotaHora / 100) * 110
FROM Instructores ins INNER JOIN
CursosInstructores curi ON ins.id = curi.idInstructor 
WHERE   curi.idCurso = 1

select *
FROM Instructores, CursosInstructores
--7
/*
En la Base de Datos Ejercicios realice lo siguiente:
a. Copiar la Tabla de Alumnos de la Base de Datos InstitutoTich a la Tabla
AlumnosTodos
b. Copiar a los alumnos de Hidalgo de la Tabla de Alumnos de la Base de
Datos InstitutoTich a la Tabla AlumnosHgo
c. En la Tabla AlumnosHgo cambiarles el número telefónico inicie con 77,
mediante la instrucción update
d. Actualizar el teléfono de la tabla AlumnosTodos obtenidos desde la taba
AlumnosHgo
*/


--a
 use InstitutoTich3;
 GO
select *
 INTO Ejercicios.dbo.AlumnosTodos 
from Alumnos
GO


--b
 use InstitutoTich3;
 GO
use EJercicios
GO
select *
INTO Ejercicios.dbo.AlumnosHIdalgo 
from Alumnos
WHERE idEstadoOrigen = 12
GO

--c
--REPLACE(telefono,'','(831)')
use EJercicios
GO
UPDATE AlumnosHIdalgo SET telefono = '77'+SUBSTRING(telefono,3, LEN(telefono))
GO

--d
UPDATE AlumnosTodos SET AlumnosTodos.telefono = AlumnosHIdalgo.telefono
from AlumnosTodos  INNER JOIN
AlumnosHIdalgo   ON AlumnosTodos.id = AlumnosHIdalgo.id
where AlumnosHIdalgo.id = AlumnosTodos.id
GO

select *
from AlumnosTodos


-------------Funciones definiadas por el ususario----------------------------------
--1
/*
Crear una función Suma que reciba dos números enteros y regrese la suma de
ambos números

*/
use InstitutoTich3;
GO

CREATE FUNCTION Sumar
(
@num1 int,
@num2 int
)
RETURNS int
AS
BEGIN
 RETURN @num1 + @num2
END

--Ejecutar
print dbo.Sumar(1,4)

--2
/*
Crear la función GetGenero la cual reciba como parámetros el curp y regrese el
género al que pertenece
*/
ALTER FUNCTION Genero
(
@Curp Varchar(50)
)
RETURNS Varchar(50)
AS
BEGIN

 RETURN iif(SUBSTRING(@Curp,11,1) = 'M', 'Mujer', 'Hombre'  )  
		
END

--Ejecutar
Print dbo.Genero('AUAV001215MQTGGCA9')





--3
/*
Crear la función GetFechaNacimiento la cual reciba como parámetros la curp y
regrese la fecha de nacimiento. La fecha de nacimiento deberá completarse a 4
dígitos, debiéndose determinar si es año dos mil o año mil novecientos
*/
Create FUNCTION GetFechaNacimiento
(
@Curp Varchar(50)
)
RETURNS DATE
AS
BEGIN
declare @Año DATE

SET @Año = CONVERT(DATE,SUBSTRING(@Curp,5,6))

RETURN @Año
END;

--Ejecutar
Print dbo.GetFechaNacimiento('AUAV001215HQTGGCA9')



--4
/*
. Crear la función GetidEstado la cual reciba como parámetros la curp y regrese el
Id Estado con base en la siguiente tabla

*/

select SUBSTRING('AUAV001215HQTGGCA9',12,2)

Create FUNCTION GetIdEstado
(
@Curp Varchar(50)
)
RETURNS INT
AS
BEGIN
DECLARE @Estado varchar(100)
DECLARE @idEstado int


set @Estado = SUBSTRING(@Curp,12,2)

set   @idEstado = CASE @Estado  
      WHEN 'AS' THEN 1  
      WHEN 'BC' THEN 2
      WHEN 'BS' THEN 3
	  WHEN 'CC' THEN 4
	  WHEN 'CH' THEN 5
      WHEN 'CS' THEN 6
	  WHEN 'CL' THEN 7
      WHEN 'CM' THEN 8 
      WHEN 'DG' THEN 9
      WHEN 'GT' THEN 10
      WHEN 'GR' THEN 11
	  WHEN 'HG' THEN 12
      WHEN 'JC' THEN 13
      WHEN 'MC' THEN 14
      WHEN 'MN' THEN 15
      WHEN 'MS' THEN 16
      WHEN 'NT' THEN 17
      WHEN 'NL' THEN 18
      WHEN 'OC' THEN 19
      WHEN 'PL' THEN 20
      WHEN 'QT' THEN 21
      WHEN 'QR' THEN 22
      WHEN 'SP' THEN 23
      WHEN 'SL' THEN 24
      WHEN 'SR' THEN 25
      WHEN 'TC' THEN 26
      WHEN 'TS' THEN 27
      WHEN 'TL' THEN 28
      WHEN 'VZ' THEN 29
      WHEN 'YN' THEN 30
      WHEN 'ZS' THEN 31
end    
return @idEstado
END;

--Ejecutar
Print dbo.GetIdEstado('AUAV001215HQTGGCA9')


--5 CALCULADORA
ALTER FUNCTION Calculadora
(
@num1 int,
@operador varchar(2),
@num2 int
)
RETURNS FLOAT
AS
BEGIN
DECLARE @Resultado float
set   @Resultado = CASE @operador  
      WHEN '+' THEN (@num1 + @num2)
	  WHEN '-' THEN (@num1 - @num2)
	  WHEN '*' THEN (@num1 * @num2)
	  WHEN '%' THEN (@num1 % nullif(@num2,0))
--iif( @num2 <=0,0,@num2)BREAK
      --iif( @num2 =0,0,@num2)
	  WHEN '/' THEN (@num1 /nullif(@num2,0))
	  --raiserror('Oh no a fatal error', 20, -1) with log
	  
	   
      END

RETURN @Resultado
END;

--Ejecutar
print dbo.Calculadora(1,'%',0)



--6
/*
Realizar una función llamada GetHonorarios que calcule el importe a pagar a un
determinado instructor y curso, por lo que la función recibirá como parámetro el id
del instructor y el id del curso.
*/
select	inst.id as intructorid, inst.cuotaHora as cuota, cat.horas as horas 
FROM Instructores inst INNER JOIN  CatCursos cat 
ON inst.id = cat.id

ALTER FUNCTION GetHorarios
(
@idInstructor smallint,
@idCurso smallint
)
RETURNS DECIMAL(9,2)
AS
BEGIN

RETURN (
select inst.cuotaHora * cat.horas 
FROM Instructores inst INNER JOIN  CatCursos cat ON inst.id = cat.id
WHERE inst.id =@idInstructor AND cat.id = @idCurso
) 
END;

--Ejecutar
print dbo.GetHorarios(1,1)
select * from CatCursos
select * from Instructores


--7
/*
Crear la función GetEdad la cual reciba como parámetros la fecha de nacimiento y
la fecha a la que se requiere realizar el cálculo de la edad. Los años deberán se
cumplidos, considerando mes y día
*/

Alter FUNCTION GetEdad
(
@Fecha1 DATE,
@Fecha2 DATE
)
RETURNS INT
AS
BEGIN
declare @Edad INT
--DATEDIFF(month,@Fecha1,@Fecha2)
SET @Edad = 
floor(
(cast(convert(varchar(8),@Fecha2,112) as int)-
cast(convert(varchar(8),@Fecha1,112) as int) ) / 10000
) 
RETURN @Edad
END;

--Ejecutar

Print dbo.GetEdad('2000/12/15', '2023/12/15')
Select DATEDIFF(month,'2000/05/12','2022/08/12')



--8
/*
Crear la función Factorial la cual reciba como parámetros un número entero y
regrese como resultado el factorial.

*/
CREATE FUNCTION factorial ( 
@numero int 
)
RETURNS INT
AS
BEGIN
DECLARE @i  int

    IF @numero <= 1
        SET @i = 1
    ELSE
        SET @i = @numero * dbo.factorial( @numero - 1 )
RETURN (@i)
END;


--Ejecutar
print dbo.factorial(5)

--9
/*
Crear la función ReembolsoQuincenal la cual reciba como parámetros un
SueldoMensual y regrese como resultado el Importe de Reembolso quincenal,
considerando que el importe total a reembolsar es igual a dos meses y medio de
sueldo, y el periodo de reembolso es de 6 meses
*/
CREATE FUNCTION RembolsoQuincena
(
@Sueldo FLOAT
)
RETURNS FLOAT
AS
BEGIN
DECLARE @Rembolso FLOAT
DECLARE @Importe FLOAT

SET @Importe = @Sueldo *2.5
SET @Rembolso = @Importe /12
RETURN @Rembolso
END;

--Ejecutar
print dbo.RembolsoQuincena(20000)

--10
/*
Realizar una función que calcule el impuesto que debe pagar un instructor para un
determinado curso. De tal manera que la función recibirá id de un instructor y el id
del curso correspondiente.

El cálculo del impuesto se realiza de la siguiente forma:

Determinar el porcentaje que aplicará dependiendo del estado de nacimiento
	Chiapas = 5 %
	Sonora = 10 %
	Veracruz = 7 %
	El resto del país 8 %

*/
ALTER FUNCTION ImpuestoIns
(
@idInstructor smallint,
@idCurso smallint
)
RETURNS FLOAT
AS
BEGIN
DECLARE @Estado varchar(10)
DECLARE @Rembolso FLOAT
DECLARE @Impuesto FLOAT
DECLARE @Curp Varchar(50)
SET @Curp =( select curp from Instructores where id = @idInstructor)
set @Estado = SUBSTRING(@Curp,12,2)

set   @Impuesto = CASE @Estado 
      WHEN 'CH' THEN 5
	  WHEN 'SR' THEN 10
      WHEN 'VZ' THEN 7
      ELSE 8
	  END    
RETURN (
select ((inst.cuotaHora * cat.horas)/100)* @Impuesto
FROM Instructores inst INNER JOIN  CatCursos cat ON inst.id = cat.id
WHERE inst.id =@idInstructor AND cat.id = @idCurso
)


END;

--Ejecutar
print dbo.ImpuestoIns(1,1)

--11
/*
Haciendo uso de la función GetEdad, obtener una relación de alumnos con la edad
a la fecha de inscripción, y la edad actual. De aquellos alumnos que actualmente
tengan más de 25 años.

*/


SELECT Alumnos.nombre, Alumnos.primerApellido, Alumnos.segundoApellido, CursosAlumnos.fechaInscripcion, 
       [dbo].getEdad(Alumnos.fechaNacimiento, CursosAlumnos.fechaInscripcion) as EdadINcripcion,
	   [dbo].getEdad(Alumnos.fechaNacimiento, getDate()) as EdadActual
FROM Alumnos INNER JOIN
CursosAlumnos ON CursosAlumnos.idAlumno = Alumnos.id
WHERE [dbo].getEdad(fechaNacimiento, getDate()) > 25

--12
/*
*/

ALTER FUNCTION RembolsoTich
(
@Sueldo FLOAT,
@Meses INT
)
RETURNS FLOAT
AS
BEGIN
DECLARE @Importe FLOAT
DECLARE @Porcentaje FLOAT


SET @Porcentaje = @Sueldo / 1000

set   @Importe = CASE @Meses  
      WHEN 1 THEN  @Porcentaje 
      WHEN 2 THEN @Porcentaje * .75 
	  WHEN 3 THEN @Porcentaje * .50
	  WHEN 4 THEN @Porcentaje * .20 
	  WHEN 5 THEN  0 
	  WHEN 6 THEN  0 
	  END
RETURN @Importe
END;

--Ejecutar
print dbo.RembolsoTich(20000,3)
select (20000)- ((20000/100)*(20 * .75))
select ((20000/100)*15)

--13
/*
Hacer una función que convierta a mayúsculas la primera letra de cada palabra de
un cadena de caracteres recibida.
*/

ALTER FUNCTION PromeraMayu
(
@Palabra varchar(50)
)
RETURNS varchar(50)
AS
BEGIN
 declare @Reset bit;
  declare @Ret varchar(8000);
  declare @i int;
  declare @c char(1);

 select @Reset = 1, @i = 1, @Ret = '';

  while (@i <= len(@Palabra))
    select @c = substring(@Palabra, @i, 1),
      @Ret = @Ret + case when @Reset = 1 then UPPER(@c) else LOWER(@c) end,
      @Reset = case when @c like '[a-zA-Z]' then 0 else 1 end,
      @i = @i + 1
  return @Ret
END;

--Ejecutar
print dbo.PromeraMayu('h m m')



-------------------FUNCIONES DE TABLA--------------------------------
--1
/*
 Hacer una función valuada en tabla que obtenga la tabla de amortización de los
Reembolsos quincenales que un participante tiene que realizar en 6 meses

*/
GO

ALTER  FUNCTION  ListaAmortizacion 
(
@idAlumno int
)
RETURNS @tablaAmortizacion TABLE
(
       
       Quincena int ,
       saldoAnterior decimal(9,2),
	   Pago decimal(9,2),
	   SAldonuevo decimal(9,2)
)
AS
BEGIN
Declare @quin int
Declare @Denuda decimal(9,2) 
Declare @Pago decimal(9,2)
Declare @Sueldo decimal(9,2) = (select sueldo from alumnos WHERE id=@idAlumno )
Declare @SaldoAnterior decimal(9,2)
Declare @SaldoNuevo decimal(9,2)

SET @quin = 1
SET @Denuda = @Sueldo * 2.5
SET @SaldoAnterior = @Sueldo
SET @SaldoNuevo = @Sueldo
SET @Pago = @Sueldo/12



      
	   while (@quin <= 12)
	   
	   BEGIN

	   SET @SaldoAnterior =@SaldoNuevo
	   SET @SaldoNuevo = @SaldoNuevo -@Pago
	
	   

		INSERT INTO @tablaAmortizacion
		
		select @quin, @SaldoAnterior,@Pago,@SaldoNuevo
		SET @quin = @quin +1 
	   END
		
		
	   
       RETURN 
END;
GO

---------
SELECT * FROM ListaAmortizacion(1)

Drop FUNCTION ListaAmortizacion;



--2
/*
Hacer una función valuada en tabla que obtenga la tabla de amortización de los
préstamos posibles que se le pueden hacer a un instructor.
La función recibirá como parámetro el id del instructor
El importe del préstamo será 200 veces la cuota por hora
El porcentaje de interés será el 24% anual cuando la cuota por hora sea superior a
200
Para el resto será de 18%
El pago mensual será el equivalente a 25 horas
*/
GO
ALTER  FUNCTION  TablaDeAmortizacion 
(
@idInstructor int
)
RETURNS @ListaPrestamoAmortizacion TABLE
(
       
       mes int,
       saldoAnterior decimal (19,3),
	   Intereses decimal (19,3),
	   Pago decimal (19,3),
	   SaldoNuevo decimal (19,3)
)
AS
BEGIN
Declare @Interes decimal (9,2)
Declare @InteresMensual decimal (9,2)
Declare @Pago decimal (9,2)
Declare @PagoMes decimal (9,2)
Declare @SaldoAnterior decimal (9,2)
Declare @SaldoNuevo decimal (9,2)
Declare @CuotaHora decimal (9,2) = (SELECT cuotaHora FROM Instructores WHERE id=@idInstructor) 
DECLARE @i int

Set @InteresMensual = iif((@CuotaHora) >= 200,24,18 ) /12
SET @Pago = (200)*(@CuotaHora )
SET @PagoMes = (25)*(@CuotaHora )
set @i = 1
SET @SaldoAnterior = @Pago
SET @SaldoNuevo = @Pago


	   while (@i <= 12)
	   BEGIN
			
			SET @Interes=(( @SaldoAnterior *@InteresMensual)/100)	
			--SET @SaldoNuevo = iif(@SaldoNuevo > 0,((@SaldoNuevo -@PagoMes)+@Interes),0) 
			--SET @PagoMes = iif(@PagoMes >= @SaldoNuevo,@SaldoNuevo,@PagoMes) 
			
			
		INSERT INTO  @ListaPrestamoAmortizacion
			select  @i, @SaldoAnterior,@Interes ,@PagoMes,@SaldoNuevo
        SET @i = @i +1 	
		SET @SaldoAnterior =@SaldoNuevo

		--if(@PagoMes>@SaldoNuevo)
		--SET @i=11
	   END
	   
       RETURN 
	   
END;
GO

---------
SELECT * FROM TablaDeAmortizacion(1)
select * from TablaDeAmortizacion(1)


GO
ALTER  FUNCTION  TablaDeAmortizacion 
(
@idInstructor int
)
RETURNS @ListaPrestamoAmortizacion TABLE
(
       
       mes int,
       saldoAnterior decimal (19,3),
	   Intereses decimal (19,3),
	   Pago decimal (19,3),
	   SaldoNuevo decimal (19,3)
)
AS
BEGIN
Declare @Interes decimal (9,2)
Declare @InteresMensual decimal (9,2)
Declare @Pago decimal (9,2)
Declare @PagoMes decimal (9,2)
Declare @SaldoAnterior decimal (9,2)
Declare @SaldoNuevo decimal (9,2)
Declare @CuotaHora decimal (9,2) = (SELECT cuotaHora FROM Instructores WHERE id=@idInstructor) 
DECLARE @i int

Set @InteresMensual = iif((@CuotaHora) >= 200,24,18 ) /12
SET @Pago = (200)*(@CuotaHora )
SET @PagoMes = (25)*(@CuotaHora )
set @i = 1
SET @SaldoAnterior = @Pago
SET @SaldoNuevo = @Pago


	   while (@i < 12)
	   BEGIN
			
			SET @Interes=((@SaldoAnterior *@InteresMensual)/100)
			SET @PagoMes =iif(@PagoMes>@SaldoNuevo,(@SaldoNuevo+@Interes),@PagoMes)
			SET @SaldoNuevo = (@SaldoNuevo -@PagoMes)+@Interes
			
		INSERT INTO  @ListaPrestamoAmortizacion
			select  @i, @SaldoAnterior,@Interes ,@PagoMes,@SaldoNuevo
        SET @i = @i +1 	
		SET @SaldoAnterior =@SaldoNuevo
		SET @i = iif(@SaldoNuevo = 0,12,@i)

	   END
	   
       RETURN 
	   
END;
GO









































