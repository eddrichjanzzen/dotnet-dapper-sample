CREATE PROCEDURE TodoItem_Create
	@Title NVARCHAR(50),
	@Completed BIT,
	@Description NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO [TodoItem] (Title, Completed, Description)
	OUTPUT inserted.Id
	VALUES (@Title, @Completed, @Description)
END


AS
	BEGIN TRY
		BEGIN TRANSACTION

			INSERT INTO [TodoItem] (Title, Completed, Description)
			OUTPUT inserted.Id
			VALUES (@Title, @Completed, @Description)

			SELECT SCOPE_IDENTITY();

		COMMIT TRAN;
	END TRY

	BEGIN CATCH
		IF(@@TRANCOUNT > 0) 
			ROLLBACK TRAN;

		THROW
	END CATCH