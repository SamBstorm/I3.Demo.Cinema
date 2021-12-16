CREATE PROCEDURE [dbo].[SP_Film_Insert]
	@titre NVARCHAR(128),
	@date DATE
AS
	INSERT INTO [Film]([Titre],[DateSortie])
	VALUES (@titre, @date)
RETURN 0
