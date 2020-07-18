CREATE PROCEDURE TodoItem_GetAll
	@filter nvarchar(500) = NULL,
	@page int = 1,
	@pageSize int = 10
AS

	IF NULLIF(ISNULL(@filter, ''), '') IS NOT NULL
	BEGIN

		SELECT COUNT(*)
		FROM [TodoItem]
		WHERE	Title LIKE '%' + @filter + '%' OR	Description LIKE '%' + @filter + '%';

		SELECT 
			[TodoItem].Id, 
			[TodoItem].Title, 
			[TodoItem].Completed,
			[TodoItem].Description
		FROM [TodoItem]
		WHERE	Title LIKE '%' + @filter + '%' OR	Description LIKE '%' + @filter + '%'
		ORDER BY Id ASC
		OFFSET (@pageSize * (@page - 1)) ROWS
		FETCH NEXT @pageSize ROWS ONLY;
	END
	ELSE
	BEGIN

		SELECT COUNT(*)
		FROM [TodoItem]
		
		SELECT 
			[TodoItem].Id, 
			[TodoItem].Title, 
			[TodoItem].Completed,
			[TodoItem].Description
		FROM [TodoItem]
		ORDER BY Id ASC
		OFFSET (@pageSize * (@page - 1)) ROWS
		FETCH NEXT @pageSize ROWS ONLY;
	END

RETURN 0