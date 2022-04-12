USE [Examen]
GO

/****** Object:  StoredProcedure [dbo].[DEL_Product]    Script Date: 11/04/2022 10:00:26 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Borra un Producto
-- Retorna el número de registros afectados
-- =============================================
CREATE PROCEDURE [dbo].[DEL_Product]
	@Id INT
AS
BEGIN
	DELETE FROM Product WHERE Id = @Id;

	SELECT @@ROWCOUNT;
END
GO

