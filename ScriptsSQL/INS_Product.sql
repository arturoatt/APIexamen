USE [Examen]
GO

/****** Object:  StoredProcedure [dbo].[INS_Product]    Script Date: 11/04/2022 10:01:02 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Registro de un Product
-- Retorna el Id generado
-- =============================================
CREATE PROCEDURE [dbo].[INS_Product]
			@Name nvarchar(50),
			@Price money = 0
AS
BEGIN

	INSERT INTO Product (Name, Price, Creation)
     VALUES  (@Name,@Price,GETDATE())

    SELECT SCOPE_IDENTITY();
END
GO

