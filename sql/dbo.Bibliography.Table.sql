USE [Sociobase]
GO
/****** Object:  Table [dbo].[Bibliography]    Script Date: 07.11.2015 17:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bibliography](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_References_ID]  DEFAULT (newid()),
	[ArticleID] [uniqueidentifier] NULL,
	[ArticleRefID] [uniqueidentifier] NULL,
	[ArticleRefName] [nvarchar](200) NULL,
	[ArticleRefSource] [nvarchar](200) NULL,
	[ArticleRefYear] [int] NULL,
 CONSTRAINT [PK_References] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Bibliography] ([ID], [ArticleID], [ArticleRefID], [ArticleRefName], [ArticleRefSource], [ArticleRefYear]) VALUES (N'01bb1568-4806-4142-a4ef-25a55a82031e', N'6d631377-b0d6-4006-954a-c04f02303cf7', NULL, N'Идентичность в структуре знания о социальном: эвристические возможности и методологические ограничения', N'Молодий вчений', 2015)
INSERT [dbo].[Bibliography] ([ID], [ArticleID], [ArticleRefID], [ArticleRefName], [ArticleRefSource], [ArticleRefYear]) VALUES (N'b666fd34-d824-4468-9ff4-5adad94eb3de', N'6d631377-b0d6-4006-954a-c04f02303cf7', N'c647b4f2-4579-4b11-b971-8dbc7c2c7ab1', NULL, NULL, NULL)
ALTER TABLE [dbo].[Bibliography]  WITH CHECK ADD  CONSTRAINT [FK_Bibliography_Articles] FOREIGN KEY([ArticleID])
REFERENCES [dbo].[Articles] ([ID])
GO
ALTER TABLE [dbo].[Bibliography] CHECK CONSTRAINT [FK_Bibliography_Articles]
GO
ALTER TABLE [dbo].[Bibliography]  WITH CHECK ADD  CONSTRAINT [FK_Bibliography_ArticlesRef] FOREIGN KEY([ArticleRefID])
REFERENCES [dbo].[Articles] ([ID])
GO
ALTER TABLE [dbo].[Bibliography] CHECK CONSTRAINT [FK_Bibliography_ArticlesRef]
GO
