CREATE PROCEDURE TodoItem_Update
	@Id INT,
	@Title NVARCHAR(50),
	@Completed BIT,
	@Description NVARCHAR(MAX)
AS
BEGIN TRY
	BEGIN TRANSACTION

	  UPDATE [TodoItem] 
	  SET
			Title = @Title,
			Completed = @Completed,
			Description = @Description
		WHERE 
			Id = @Id

	COMMIT TRAN;
END TRY

BEGIN CATCH
	IF(@@TRANCOUNT > 0) 
		ROLLBACK TRAN;

	THROW
END CATCH
RETURN 0