USE [Sociobase]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 07.11.2015 17:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Authors_ID]  DEFAULT (newid()),
	[FirstName] [nvarchar](50) NULL,
	[FirstNameRu] [nvarchar](50) NULL,
	[FirstNameEn] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[MiddleNameRu] [nvarchar](50) NULL,
	[MiddleNameEn] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[LastNameRu] [nvarchar](50) NULL,
	[LastNameEn] [nvarchar](50) NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Authors] ([ID], [FirstName], [FirstNameRu], [FirstNameEn], [MiddleName], [MiddleNameRu], [MiddleNameEn], [LastName], [LastNameRu], [LastNameEn]) VALUES (N'b518cf8b-739a-47ad-a169-178b3bd1bd20', N'Геннадій', N'Геннадий', N'Gennadij', N'', N'', N'', N'Чоппер', N'Чоппер', N'Chopper')
INSERT [dbo].[Authors] ([ID], [FirstName], [FirstNameRu], [FirstNameEn], [MiddleName], [MiddleNameRu], [MiddleNameEn], [LastName], [LastNameRu], [LastNameEn]) VALUES (N'a3dcdffd-de6d-473f-b74f-a60da2f8ccfa', N'Олександр', N'Александр', N'Alexander', NULL, NULL, NULL, N'Зубарєв', N'Зубарев', N'Zubarev')
INSERT [dbo].[Authors] ([ID], [FirstName], [FirstNameRu], [FirstNameEn], [MiddleName], [MiddleNameRu], [MiddleNameEn], [LastName], [LastNameRu], [LastNameEn]) VALUES (N'38f25be5-cc61-4bfd-845e-ad955c610906', N'Олександр', N'Александр', N'Alexander', NULL, NULL, NULL, N'Голіков', N'Голиков', N'Golikov')
INSERT [dbo].[Authors] ([ID], [FirstName], [FirstNameRu], [FirstNameEn], [MiddleName], [MiddleNameRu], [MiddleNameEn], [LastName], [LastNameRu], [LastNameEn]) VALUES (N'bdb6760e-25c9-424b-8533-efbfa29673b7', N'Олексій', N'Алексей', N'Olexiy', NULL, NULL, NULL, N'Мусієздов', N'Мусиездов', N'Musiezdov')
