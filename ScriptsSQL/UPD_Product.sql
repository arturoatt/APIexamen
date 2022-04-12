USE [Examen]
GO

/****** Object:  StoredProcedure [dbo].[UPD_Product]    Script Date: 11/04/2022 10:01:26 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Actualiza un Producto
-- Retorna el número de registros afectados
-- =============================================
CREATE PROCEDURE [dbo].[UPD_Product] 
			@Id INT,
			@Name nvarchar(50),
			@Price money = 0
AS
BEGIN
   UPDATE Product SET Name =  @Name, Price = @Price, Modification = GETDATE() 
   WHERE Id = @Id;

   SELECT @@ROWCOUNT;
END
GO

