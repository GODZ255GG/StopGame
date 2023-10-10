CREATE TABLE [dbo].[User](
	[idUser] [int] NOT NULL IDENTITY,
	[userName] [varchar](65),
	[email] [varchar](65),
	[password] [varchar](20),
	CONSTRAINT [PK_dbo.User] PRIMARY KEY ([idUser])
)

CREATE TABLE [dbo].[Player](
	[idPlayer] [int] NOT NULL IDENTITY,
	[playingTime] datetime,
	[coins] [int],
	[propilePicture] [varchar](max),
	[idUser] [int] NOT NULL,
	CONSTRAINT [PK_dbo.Player] PRIMARY KEY ([idPlayer])
)

CREATE INDEX [IX_idUser] ON [dbo].[Player]([idUser])

ALTER TABLE [dbo].[Player] ADD CONSTRAINT [FK_dbo.Player_dbo.User_idUser] FOREIGN KEY ([idUser]) REFERENCES [dbo].[User] ([idUser]) ON DELETE CASCADE