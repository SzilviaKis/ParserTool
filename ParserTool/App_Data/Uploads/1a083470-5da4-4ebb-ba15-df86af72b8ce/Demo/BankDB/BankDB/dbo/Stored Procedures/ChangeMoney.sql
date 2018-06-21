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
--Hozz létre egy ChangeMoney nevû tárolt eljárást! Bemenõ paraméterek: Name VARCHAR(50) és Value SMALLINT. 
--Az eljárás meghívásakor a Name nevû személy pénze változzon a bejött értéknek megfelelõen! 
--Schema compareld át a tárolt eljárásodat a dbprojectedre, hogy publisholáskor az is létrejöjjön!

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
		/*VISSZAÁLLÍTJA AZ ÖSSZES BEÁLLÍTÁST*/
		PRINT('DATABASE ROLLED BACK')
	END CATCH

END
GO
