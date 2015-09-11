USE [Sociobase]
GO
/****** Object:  Table [dbo].[ArticleAuthors]    Script Date: 11.09.2015 18:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ArticleAuthors]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ArticleAuthors](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ArticleAuthors_ID]  DEFAULT (newid()),
	[ArticleID] [uniqueidentifier] NOT NULL,
	[AuthorID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ArticleAuthors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
INSERT [dbo].[ArticleAuthors] ([ID], [ArticleID], [AuthorID]) VALUES (N'f90c6096-05f0-4da4-ae1c-0f082bcca5e3', N'6d631377-b0d6-4006-954a-c04f02303cf7', N'38f25be5-cc61-4bfd-845e-ad955c610906')
INSERT [dbo].[ArticleAuthors] ([ID], [ArticleID], [AuthorID]) VALUES (N'18893675-bb52-46ae-8782-475c611bb1f4', N'47ff019b-9c3a-48b9-be5e-93599d9891f8', N'bdb6760e-25c9-424b-8533-efbfa29673b7')
INSERT [dbo].[ArticleAuthors] ([ID], [ArticleID], [AuthorID]) VALUES (N'5484eaf3-ffe3-45cd-89f1-9493ee1326d3', N'4194b3f8-c058-4478-bfe3-f1147ff186a2', N'a3dcdffd-de6d-473f-b74f-a60da2f8ccfa')
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ArticleAuthors_Articles]') AND parent_object_id = OBJECT_ID(N'[dbo].[ArticleAuthors]'))
ALTER TABLE [dbo].[ArticleAuthors]  WITH CHECK ADD  CONSTRAINT [FK_ArticleAuthors_Articles] FOREIGN KEY([ArticleID])
REFERENCES [dbo].[Articles] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ArticleAuthors_Articles]') AND parent_object_id = OBJECT_ID(N'[dbo].[ArticleAuthors]'))
ALTER TABLE [dbo].[ArticleAuthors] CHECK CONSTRAINT [FK_ArticleAuthors_Articles]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ArticleAuthors_Authors]') AND parent_object_id = OBJECT_ID(N'[dbo].[ArticleAuthors]'))
ALTER TABLE [dbo].[ArticleAuthors]  WITH CHECK ADD  CONSTRAINT [FK_ArticleAuthors_Authors] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ArticleAuthors_Authors]') AND parent_object_id = OBJECT_ID(N'[dbo].[ArticleAuthors]'))
ALTER TABLE [dbo].[ArticleAuthors] CHECK CONSTRAINT [FK_ArticleAuthors_Authors]
GO
