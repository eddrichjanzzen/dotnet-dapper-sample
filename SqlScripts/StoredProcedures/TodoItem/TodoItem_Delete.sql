CREATE PROCEDURE TodoItem_Delete
	@Id INT
AS
BEGIN TRY
	BEGIN TRANSACTION

		DELETE 
		FROM 
			[TodoItem]
		WHERE 
			Id = @Id;

	COMMIT TRAN;
END TRY

BEGIN CATCH
	IF(@@TRANCOUNT > 0) 
		ROLLBACK TRAN;

	THROW
END CATCH
RETURN 0