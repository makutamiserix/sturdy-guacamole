CREATE PROCEDURE [dbo].[SelectSong]
	@SongID uniqueidentifier
AS
	Select s.SongID, s.SongFileName, h.ShortName, s.SongData, s.OrderingIndex
	From dbo.Songs As s
	Join dbo.SongShortNames As h
	On h.SongID = s.SongID
	Where s.SongID = @SongID
RETURN 0