CREATE PROCEDURE TodoItem_GetById
	@Id INT
AS
BEGIN
	SELECT 
		[TodoItem].Id, 
		[TodoItem].Title, 
		[TodoItem].Completed,
		[TodoItem].Description
	FROM [TodoItem]
	WHERE Id = @Id;
END
