CREATE PROCEDURE [dbo].[Students_Delete]
	@StudentID int
AS
BEGIN
	SET NOCOUNT ON;

	delete
	from dbo.Attendances
	where StudentID = @StudentID

	delete
	from dbo.Students
	where StudentID = @StudentID

END
