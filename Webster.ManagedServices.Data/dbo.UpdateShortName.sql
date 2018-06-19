CREATE PROCEDURE [dbo].[UpdateShortName]
	@SongID uniqueidentifier,
	@ShortName nvarchar(MAX)
AS
	Update dbo.Songs
	Set ShortName = @ShortName
	Where SongID = @SongID
RETURN 0
