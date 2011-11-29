USE [Minesweeper]
GO

/****** Object:  Table [dbo].[Minefields]    Script Date: 10/08/2011 19:35:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Minefields](
	[Tile_Id] [uniqueidentifier] NOT NULL,
	[Is_Revealed] [bit] NOT NULL,
	[Contains_Mine] [bit] NOT NULL,
	[Number_Of_Mines_Surrounding] [int] NULL,
	[Game_Id] [uniqueidentifier] NOT NULL,
	[Row] [int] NOT NULL,
	[Col] [int] NOT NULL,
 CONSTRAINT [PK_Minefields] PRIMARY KEY CLUSTERED 
(
	[Tile_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO