-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--SQL_0410
--Hozz l�tre egy ChangeMoney nev� t�rolt elj�r�st! Bemen� param�terek: Name VARCHAR(50) �s Value SMALLINT. 
--Az elj�r�s megh�v�sakor a Name nev� szem�ly p�nze v�ltozzon a bej�tt �rt�knek megfelel�en! 
--Schema compareld �t a t�rolt elj�r�sodat a dbprojectedre, hogy publishol�skor az is l�trej�jj�n!

CREATE PROCEDURE ChangeMoney 
@Name VARCHAR(50), 
@Value SMALLINT,
@Money INT

AS 
BEGIN
	BEGIN TRY
		BEGIN TRAN

			PRINT('TRYING TO SUBSTRACT FROM @Name.Money')
			UPDATE Client
			SET Money  = Money - @Value
			WHERE Name = @Name

			PRINT('TRYING TO ADD MONEY TI @IdTo')
			UPDATE Client
			SET Money = Money + @Value
			WHERE Name = @Name

		COMMIT TRAN
	END TRY
	BEGIN CATCH 
		PRINT('TRANSACTION FAILED! ROLLING BACK DATABASE')
		ROLLBACK TRAN
		/*VISSZA�LL�TJA AZ �SSZES BE�LL�T�ST*/
		PRINT('DATABASE ROLLED BACK')
	END CATCH

END
GO
