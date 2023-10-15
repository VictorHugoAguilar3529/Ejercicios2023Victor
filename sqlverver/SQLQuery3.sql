USE [InstitutoTich3]
GO
SET IDENTITY_INSERT [dbo].Instructores ON 

INSERT [dbo].[Instructores] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento],[rfc], [curp],[cuotaHora], [activo])  VALUES (1, N'Marcelo Isai a', N'García', N'Mirón', N'marcelo@outlook.com', N'9911362600', CAST(N'1997-12-12' AS Date),N'AUAGRDNOwhu12', N'MADA971212HVZRMN04', CAST(22000.00 AS Decimal(9, 2)), 6)
INSERT [dbo].[Instructores] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento],[rfc], [curp],[cuotaHora], [activo])  VALUES (2, N'Oliver Alexis', N'Martínez', N'Estudillo', N'alexis@gmail.com', N'8897877417', CAST(N'1996-04-18' AS Date),N'AUAGRDNOwhu18', N'DIAE960418HOCSVL07', CAST(20000.00 AS Decimal(9, 2)), 6)
INSERT [dbo].[Instructores] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento],[rfc], [curp],[cuotaHora], [activo])  VALUES (3, N'Oscar', N'Mendoza', N'García', N'omscar@outlook.es', N'7711589568', CAST(N'1994-04-07' AS Date),N'AUAGRDNOwhue2', N'RUVJ940407HOCSSN03', CAST(20000.00 AS Decimal(9, 2)), 4)
INSERT [dbo].[Instructores] ([id], [nombre], [primerApellido], [segundoApellido], [correo], [telefono], [fechaNacimiento],[rfc], [curp],[cuotaHora], [activo])  VALUES (4, N'Edgar', N'Martínez', N'Espinoza', N'edgargmail.com', N'5528356144', CAST(N'1996-05-23' AS Date),N'AUAGRDNOwhue2', N'DOML960323HMNMTS00', CAST(25000.00 AS Decimal(9, 2)), 5)
SET IDENTITY_INSERT [dbo].[Instructores] OFF
GO


USE [InstitutoTich3]
GO
SET IDENTITY_INSERT [dbo].CursosInstructores ON 

INSERT [dbo].[CursosInstructores] ([id], [idCurso], [idInstructor], [fechaContratacion])  VALUES (1, 1, 1, CAST(N'1997-12-12' AS Date))
INSERT [dbo].[CursosInstructores] ([id], [idCurso], [idInstructor], [fechaContratacion])  VALUES (2, 2, 1, CAST(N'1997-12-12' AS Date))
INSERT [dbo].[CursosInstructores] ([id], [idCurso], [idInstructor], [fechaContratacion])  VALUES (3, 3, 2, CAST(N'1997-12-12' AS Date))
INSERT [dbo].[CursosInstructores] ([id], [idCurso], [idInstructor], [fechaContratacion])  VALUES (4, 4, 2, CAST(N'1997-12-12' AS Date))
INSERT [dbo].[CursosInstructores] ([id], [idCurso], [idInstructor], [fechaContratacion])  VALUES (5, 1, 3, CAST(N'1997-12-12' AS Date))
INSERT [dbo].[CursosInstructores] ([id], [idCurso], [idInstructor], [fechaContratacion])  VALUES (6, 2, 3, CAST(N'1997-12-12' AS Date))
INSERT [dbo].[CursosInstructores] ([id], [idCurso], [idInstructor], [fechaContratacion])  VALUES (7, 3, 4, CAST(N'1997-12-12' AS Date))
INSERT [dbo].[CursosInstructores] ([id], [idCurso], [idInstructor], [fechaContratacion])  VALUES (8, 4, 4, CAST(N'1997-12-12' AS Date))
SET IDENTITY_INSERT [dbo].[CursosInstructores] OFF
GO