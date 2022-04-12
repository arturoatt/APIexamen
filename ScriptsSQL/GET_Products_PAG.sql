USE [Examen]
GO

/****** Object:  StoredProcedure [dbo].[GET_Products_PAG]    Script Date: 11/04/2022 10:00:46 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Regresa los Products paginados
-- =============================================
CREATE PROCEDURE [dbo].[GET_Products_PAG]
	@PageNumber INT = 1,
	@RowsOfPage INT = 10
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Product 
	ORDER BY Id 
	OFFSET (@PageNumber-1)*@RowsOfPage ROWS
	FETCH NEXT @RowsOfPage ROWS ONLY
END
GO

