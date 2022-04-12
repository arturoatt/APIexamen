USE [Examen]
GO

/****** Object:  StoredProcedure [dbo].[SEL_Product]    Script Date: 11/04/2022 10:01:14 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Regresa el Product solicitado
-- =============================================
CREATE PROCEDURE [dbo].[SEL_Product]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Product WHERE Id = @Id;

END
GO

