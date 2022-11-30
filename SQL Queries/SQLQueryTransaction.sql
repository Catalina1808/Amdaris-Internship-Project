BEGIN TRY
	BEGIN TRANSACTION
		UPDATE dbo.Books
		SET Title = 'Insurgent'
		WHERE ID = 16;
		UPDATE dbo.Authors
		SET Name = 'George R. R. Martin'
		WHERE ID = 7
		UPDATE dbo.Readers
		SET FirstName = 'Ryana'
		WHERE ID = 8
		DELETE FROM dbo.Reviews
		WHERE ID = 9
		DELETE FROM dbo.Books
		WHERE ID = 'number'
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	PRINT 'In CATCH Block'
	ROLLBACK TRANSACTION
END CATCH