USE [InstitutoTich3]
GO
SET IDENTITY_INSERT [dbo].CatCursos ON 

INSERT [dbo].[CatCursos] ([id], [clave], [nombre], [descripcion], [horas], [idPreRequisito], [activo])  VALUES (1, N'012345678912345', N'matematicas', N'metematicas ssssssssss', 50, 4, 6)
INSERT [dbo].[CatCursos] ([id], [clave], [nombre], [descripcion], [horas], [idPreRequisito], [activo])  VALUES (2, N'012345678912345', N'programación', N'programasion ssssssssss', 50,3, 6)
INSERT [dbo].[CatCursos] ([id], [clave], [nombre], [descripcion], [horas], [idPreRequisito], [activo])  VALUES (3, N'012345678912345', N'fisica', N'fisica aaaaaaaaa',20, 2, 4)
INSERT [dbo].[CatCursos] ([id], [clave], [nombre], [descripcion], [horas], [idPreRequisito], [activo])  VALUES (4, N'012345678912345', N'Lengua Extranjera', N'extranjero ooooooooooo', 40, 1, 5)
SET IDENTITY_INSERT [dbo].[CatCursos] OFF
GO


USE [InstitutoTich3]
GO
SET IDENTITY_INSERT [dbo].Cursos ON 

INSERT [dbo].[Cursos] ([id], [idCatCurso], [fechaInicio], [fechatermino], [activo])  VALUES (1, 1, CAST(N'1998-06-04' AS Date), CAST(N'1998-06-05' AS Date), 1)
INSERT [dbo].[Cursos] ([id], [idCatCurso], [fechaInicio], [fechatermino], [activo])  VALUES (2, 2, CAST(N'1998-06-04' AS Date), CAST(N'1998-06-07' AS Date), 1)
INSERT [dbo].[Cursos] ([id], [idCatCurso], [fechaInicio], [fechatermino], [activo])  VALUES (3, 3, CAST(N'1998-06-04' AS Date), CAST(N'1998-06-09' AS Date), 2)
INSERT [dbo].[Cursos] ([id], [idCatCurso], [fechaInicio], [fechatermino], [activo])  VALUES (4, 4, CAST(N'1998-06-04' AS Date), CAST(N'1998-06-10' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Cursos] OFF
GO