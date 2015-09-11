USE [Sociobase]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 11.09.2015 18:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Authors]') AND type in (N'U'))
BEGIN
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
END
GO
INSERT [dbo].[Authors] ([ID], [FirstName], [FirstNameRu], [FirstNameEn], [MiddleName], [MiddleNameRu], [MiddleNameEn], [LastName], [LastNameRu], [LastNameEn]) VALUES (N'a3dcdffd-de6d-473f-b74f-a60da2f8ccfa', N'Олександр', N'Александр', N'Alexander', NULL, NULL, NULL, N'Зубарєв', N'Зубарев', N'Zubarev')
INSERT [dbo].[Authors] ([ID], [FirstName], [FirstNameRu], [FirstNameEn], [MiddleName], [MiddleNameRu], [MiddleNameEn], [LastName], [LastNameRu], [LastNameEn]) VALUES (N'38f25be5-cc61-4bfd-845e-ad955c610906', N'Олександр', N'Александр', N'Alexander', NULL, NULL, NULL, N'Голіков', N'Голиков', N'Golikov')
INSERT [dbo].[Authors] ([ID], [FirstName], [FirstNameRu], [FirstNameEn], [MiddleName], [MiddleNameRu], [MiddleNameEn], [LastName], [LastNameRu], [LastNameEn]) VALUES (N'bdb6760e-25c9-424b-8533-efbfa29673b7', N'Олексій', N'Алексей', N'Olexiy', NULL, NULL, NULL, N'Мусієздов', N'Мусиездов', N'Musiezdov')
