USE [Sociobase]
GO
/****** Object:  Table [dbo].[ArticleAuthors]    Script Date: 07.11.2015 17:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleAuthors](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ArticleAuthors_ID]  DEFAULT (newid()),
	[ArticleID] [uniqueidentifier] NOT NULL,
	[AuthorID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ArticleAuthors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ArticleAuthors] ([ID], [ArticleID], [AuthorID]) VALUES (N'f90c6096-05f0-4da4-ae1c-0f082bcca5e3', N'6d631377-b0d6-4006-954a-c04f02303cf7', N'38f25be5-cc61-4bfd-845e-ad955c610906')
INSERT [dbo].[ArticleAuthors] ([ID], [ArticleID], [AuthorID]) VALUES (N'29d3d9a8-53bf-4200-bce2-1547a26cb652', N'd2d16c69-48dc-42d0-8a27-b6f9f54c78d7', N'a3dcdffd-de6d-473f-b74f-a60da2f8ccfa')
INSERT [dbo].[ArticleAuthors] ([ID], [ArticleID], [AuthorID]) VALUES (N'e424cbae-c3b2-4784-91ad-1693a487cc04', N'd2d16c69-48dc-42d0-8a27-b6f9f54c78d7', N'b518cf8b-739a-47ad-a169-178b3bd1bd20')
INSERT [dbo].[ArticleAuthors] ([ID], [ArticleID], [AuthorID]) VALUES (N'b0f1b27b-7999-4cb9-991d-240d2b68a956', N'c647b4f2-4579-4b11-b971-8dbc7c2c7ab1', N'a3dcdffd-de6d-473f-b74f-a60da2f8ccfa')
INSERT [dbo].[ArticleAuthors] ([ID], [ArticleID], [AuthorID]) VALUES (N'0c06eec0-29c3-4b42-b48c-462ab87afdbe', N'af3a134b-3c41-432b-a2da-192e7df968e5', N'a3dcdffd-de6d-473f-b74f-a60da2f8ccfa')
INSERT [dbo].[ArticleAuthors] ([ID], [ArticleID], [AuthorID]) VALUES (N'ffb3e3d1-b132-4628-8392-66e63df88040', N'c647b4f2-4579-4b11-b971-8dbc7c2c7ab1', N'38f25be5-cc61-4bfd-845e-ad955c610906')
INSERT [dbo].[ArticleAuthors] ([ID], [ArticleID], [AuthorID]) VALUES (N'14fd57a6-ac92-4ce5-b370-8c6cf8c8df7a', N'af3a134b-3c41-432b-a2da-192e7df968e5', N'b518cf8b-739a-47ad-a169-178b3bd1bd20')
INSERT [dbo].[ArticleAuthors] ([ID], [ArticleID], [AuthorID]) VALUES (N'5484eaf3-ffe3-45cd-89f1-9493ee1326d3', N'4194b3f8-c058-4478-bfe3-f1147ff186a2', N'a3dcdffd-de6d-473f-b74f-a60da2f8ccfa')
INSERT [dbo].[ArticleAuthors] ([ID], [ArticleID], [AuthorID]) VALUES (N'9f6d3505-4634-47bc-b62a-a02c788823d4', N'd2d16c69-48dc-42d0-8a27-b6f9f54c78d7', N'38f25be5-cc61-4bfd-845e-ad955c610906')
INSERT [dbo].[ArticleAuthors] ([ID], [ArticleID], [AuthorID]) VALUES (N'1c33bcdd-5166-46bf-9af9-a566f1a86554', N'7a910a63-38d8-4428-b8f0-1b20eafe3be2', N'bdb6760e-25c9-424b-8533-efbfa29673b7')
INSERT [dbo].[ArticleAuthors] ([ID], [ArticleID], [AuthorID]) VALUES (N'34135d18-59ff-4dc2-822f-d43eb6a6eee1', N'47ff019b-9c3a-48b9-be5e-93599d9891f8', N'bdb6760e-25c9-424b-8533-efbfa29673b7')
INSERT [dbo].[ArticleAuthors] ([ID], [ArticleID], [AuthorID]) VALUES (N'b0e543d2-7019-4934-ad38-da6c2485261a', N'7a910a63-38d8-4428-b8f0-1b20eafe3be2', N'b518cf8b-739a-47ad-a169-178b3bd1bd20')
ALTER TABLE [dbo].[ArticleAuthors]  WITH CHECK ADD  CONSTRAINT [FK_ArticleAuthors_Articles] FOREIGN KEY([ArticleID])
REFERENCES [dbo].[Articles] ([ID])
GO
ALTER TABLE [dbo].[ArticleAuthors] CHECK CONSTRAINT [FK_ArticleAuthors_Articles]
GO
ALTER TABLE [dbo].[ArticleAuthors]  WITH CHECK ADD  CONSTRAINT [FK_ArticleAuthors_Authors] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([ID])
GO
ALTER TABLE [dbo].[ArticleAuthors] CHECK CONSTRAINT [FK_ArticleAuthors_Authors]
GO
