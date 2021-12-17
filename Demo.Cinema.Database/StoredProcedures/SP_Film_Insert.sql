CREATE PROCEDURE [dbo].[SP_Film_Insert]
	@titre NVARCHAR(128),
	@date DATE
AS
	INSERT INTO [Film]([Titre],[DateSortie])
	OUTPUT [inserted].[Id]
	VALUES (@titre, @date)
