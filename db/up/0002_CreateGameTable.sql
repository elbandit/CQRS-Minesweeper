USE [Minesweeper]
GO

/****** Object:  Table [dbo].[Games]    Script Date: 10/08/2011 19:33:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Games](
	[Game_Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[Game_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Minefields]  WITH CHECK ADD  CONSTRAINT [FK_Minefields_Games] FOREIGN KEY([Game_Id])
REFERENCES [dbo].[Games] ([Game_Id])
GO

ALTER TABLE [dbo].[Minefields] CHECK CONSTRAINT [FK_Minefields_Games]
GO
