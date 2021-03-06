USE [Sociobase]
GO
/****** Object:  Table [dbo].[References]    Script Date: 11.09.2015 19:17:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[References]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[References](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_References_ID]  DEFAULT (newid()),
	[ArticleID] [uniqueidentifier] NOT NULL,
	[ArticleRefID] [uniqueidentifier] NULL,
	[ArticleRefName] [nvarchar](200) NULL,
	[ArticleRefAuthorID] [uniqueidentifier] NULL,
	[ArticleRefSource] [nvarchar](200) NULL,
	[ArticleRefYear] [int] NULL,
 CONSTRAINT [PK_References] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
INSERT [dbo].[References] ([ID], [ArticleID], [ArticleRefID], [ArticleRefName], [ArticleRefAuthorID], [ArticleRefSource], [ArticleRefYear]) VALUES (N'01bb1568-4806-4142-a4ef-25a55a82031e', N'6d631377-b0d6-4006-954a-c04f02303cf7', NULL, N'Идентичность в структуре знания о социальном: эвристические возможности и методологические ограничения', N'38f25be5-cc61-4bfd-845e-ad955c610906', N'Молодий вчений', 2015)
INSERT [dbo].[References] ([ID], [ArticleID], [ArticleRefID], [ArticleRefName], [ArticleRefAuthorID], [ArticleRefSource], [ArticleRefYear]) VALUES (N'b666fd34-d824-4468-9ff4-5adad94eb3de', N'6d631377-b0d6-4006-954a-c04f02303cf7', NULL, N'бла', NULL, N'бла', 2008)
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_References_Articles]') AND parent_object_id = OBJECT_ID(N'[dbo].[References]'))
ALTER TABLE [dbo].[References]  WITH CHECK ADD  CONSTRAINT [FK_References_Articles] FOREIGN KEY([ArticleID])
REFERENCES [dbo].[Articles] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_References_Articles]') AND parent_object_id = OBJECT_ID(N'[dbo].[References]'))
ALTER TABLE [dbo].[References] CHECK CONSTRAINT [FK_References_Articles]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_References_ArticlesRef]') AND parent_object_id = OBJECT_ID(N'[dbo].[References]'))
ALTER TABLE [dbo].[References]  WITH CHECK ADD  CONSTRAINT [FK_References_ArticlesRef] FOREIGN KEY([ArticleRefID])
REFERENCES [dbo].[Articles] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_References_ArticlesRef]') AND parent_object_id = OBJECT_ID(N'[dbo].[References]'))
ALTER TABLE [dbo].[References] CHECK CONSTRAINT [FK_References_ArticlesRef]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_References_Authors]') AND parent_object_id = OBJECT_ID(N'[dbo].[References]'))
ALTER TABLE [dbo].[References]  WITH CHECK ADD  CONSTRAINT [FK_References_Authors] FOREIGN KEY([ArticleRefAuthorID])
REFERENCES [dbo].[Authors] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_References_Authors]') AND parent_object_id = OBJECT_ID(N'[dbo].[References]'))
ALTER TABLE [dbo].[References] CHECK CONSTRAINT [FK_References_Authors]
GO





