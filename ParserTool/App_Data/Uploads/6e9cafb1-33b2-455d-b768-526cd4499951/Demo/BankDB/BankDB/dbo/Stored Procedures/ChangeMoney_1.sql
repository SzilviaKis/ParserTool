-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--SQL_0410
--Hozz létre egy ChangeMoney nevű tárolt eljárást! Bemenő paraméterek: Name VARCHAR(50) és Value SMALLINT. 
--Az eljárás meghívásakor a Name nevű személy pénze változzon a bejött értéknek megfelelően! 
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