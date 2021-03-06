USE [Sociobase]
GO
/****** Object:  Table [dbo].[Keywords]    Script Date: 07.11.2015 17:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Keywords](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Keywords_ID]  DEFAULT (newid()),
	[ArticleID] [uniqueidentifier] NULL,
	[Word] [nvarchar](100) NULL,
 CONSTRAINT [PK_Keywords] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'c6d11a18-c495-4faa-a7df-0d5493ad1e7a', N'4194b3f8-c058-4478-bfe3-f1147ff186a2', N'система')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'3546ec35-f161-408d-a9cc-0dedb476059b', N'6d631377-b0d6-4006-954a-c04f02303cf7', N'соціологія знання')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'f2e9727d-1526-4fcf-807f-10b3bae46418', N'4194b3f8-c058-4478-bfe3-f1147ff186a2', N'повсякдення')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'a31a3fbd-ada7-404e-976c-159bdcf105bc', N'6d631377-b0d6-4006-954a-c04f02303cf7', N'знання')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'5aa08508-80bd-4bc8-b044-1cdbbfeeadc2', N'4194b3f8-c058-4478-bfe3-f1147ff186a2', N'життєвий світ')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'7d5d2847-a9e4-4173-86a7-1f9eea6cbcc5', N'c647b4f2-4579-4b11-b971-8dbc7c2c7ab1', N'hjhj')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'592cb9a0-9473-4bc8-a0af-21eab8417305', N'4194b3f8-c058-4478-bfe3-f1147ff186a2', N'структура життєвого світу')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'5aa8bcf6-12e2-4a60-8867-267d19889885', N'af3a134b-3c41-432b-a2da-192e7df968e5', N'концепт')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'8fe838cb-42f2-47a8-8a36-4103a74c5823', N'4194b3f8-c058-4478-bfe3-f1147ff186a2', N'концепт')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'b134d6e1-0b68-4e7c-aec5-5996a46a76f3', N'4194b3f8-c058-4478-bfe3-f1147ff186a2', N'феноменологія')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'edc14a48-0fcc-44bf-979b-6c402365d37c', N'47ff019b-9c3a-48b9-be5e-93599d9891f8', N'радянська соціологія')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'56871e64-9729-4669-aecc-83d2b0d447d4', N'4194b3f8-c058-4478-bfe3-f1147ff186a2', N'розуміюча соціологія')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'993f5d2f-d385-44db-96f0-874b6bec1090', N'47ff019b-9c3a-48b9-be5e-93599d9891f8', N'місто')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'47b5e4ea-2fa9-4a19-a89d-a12db8886a6f', N'47ff019b-9c3a-48b9-be5e-93599d9891f8', N'М. Вебер')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'7a82128d-9da8-433c-9b2b-acc1807897f1', N'47ff019b-9c3a-48b9-be5e-93599d9891f8', N'Г. Зіммель')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'b99c4870-eab3-462e-a6ff-dc0ccaa3762e', N'47ff019b-9c3a-48b9-be5e-93599d9891f8', N'міська ідентичність')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'b64012f5-bc95-4fe5-a973-df8ce11b25df', N'4194b3f8-c058-4478-bfe3-f1147ff186a2', N'Інший')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'1640be2e-d824-44e7-a20e-e289cfac6270', N'47ff019b-9c3a-48b9-be5e-93599d9891f8', N'міська спільнота')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'e0af7e0d-6c85-4426-8a52-e5fe5fdc91cf', N'47ff019b-9c3a-48b9-be5e-93599d9891f8', N'міський спосіб життя')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'f4ba85ed-12cd-4467-88e1-e7ea14ab9274', N'6d631377-b0d6-4006-954a-c04f02303cf7', N'соціальне')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'd5e58b9c-3055-419c-8ad8-f5f484337907', N'6d631377-b0d6-4006-954a-c04f02303cf7', N'ідентичність')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'4cd4b1db-7544-4c63-a7a0-f6ca2aec1731', N'4194b3f8-c058-4478-bfe3-f1147ff186a2', N'драматургічний підхід')
INSERT [dbo].[Keywords] ([ID], [ArticleID], [Word]) VALUES (N'029bdcf1-5a09-47b2-bd91-fbcfa6094d58', N'6d631377-b0d6-4006-954a-c04f02303cf7', N'Р. Брубейкер')
ALTER TABLE [dbo].[Keywords]  WITH CHECK ADD  CONSTRAINT [FK_Keywords_Articles] FOREIGN KEY([ArticleID])
REFERENCES [dbo].[Articles] ([ID])
GO
ALTER TABLE [dbo].[Keywords] CHECK CONSTRAINT [FK_Keywords_Articles]
GO
