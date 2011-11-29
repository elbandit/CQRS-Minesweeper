USE [Minesweeper]
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.GameViews
	(
	Game_Id uniqueidentifier NOT NULL,
	Has_Won bit NOT NULL,
	Has_Lost bit NOT NULL
	)  ON [PRIMARY]
GO
COMMIT


/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.MinefieldViews
	(
	Tile_Id uniqueidentifier NOT NULL,
	Game_Id uniqueidentifier NOT NULL,
	Row int NOT NULL,
	Col int NOT NULL,
	Tile_Image nvarchar(50) NOT NULL,
	Has_Been_Revealed bit NOT NULL
	)  ON [PRIMARY]
GO
COMMIT