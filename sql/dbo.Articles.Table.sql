USE [Sociobase]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 11.09.2015 18:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Articles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Articles](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Articles_ID]  DEFAULT (newid()),
	[Language] [nchar](10) NULL,
	[Name] [nvarchar](200) NULL,
	[Annotation] [nvarchar](1500) NULL,
	[DigestID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
INSERT [dbo].[Articles] ([ID], [Language], [Name], [Annotation], [DigestID]) VALUES (N'47ff019b-9c3a-48b9-be5e-93599d9891f8', N'ua        ', N'Місто та міський спосіб життя: радянська соціологія як втілення веберівського підходу до аналізу міської ідентичнсті', N'Статтю присвячено розгляду радянського досвіду інтерпретації міста та міського способу життя з точки зору концептуалізації міської ідентичності. Висхідним пунктом аналізу є виокремлення в соціологічній класиці веберівського та зіммелівського підходів до розгляду міста та міської ідентичності. ', N'0820804e-d048-4489-9601-49a51724da0d')
INSERT [dbo].[Articles] ([ID], [Language], [Name], [Annotation], [DigestID]) VALUES (N'6d631377-b0d6-4006-954a-c04f02303cf7', N'ru        ', N'Идентичности (без?) знаниевых оснований: беседуя с Роджерсом Брубейкером', N'В статье осуществляется анализ знаниевых оснований идентичностей в дискуссии с концепцией "этничности без групп" Роджерса Брубейкера. Основные положения этой концепции анализируются в дискурсе социологии знания, осуществляется ее сравнение с концепциями, выступающими в качестве ключевых для анализа знаниевой конституции идентичности концепциями.', N'0820804e-d048-4489-9601-49a51724da0d')
INSERT [dbo].[Articles] ([ID], [Language], [Name], [Annotation], [DigestID]) VALUES (N'4194b3f8-c058-4478-bfe3-f1147ff186a2', N'ua        ', N'Концепт "життєвого світу" в історико-соціологічній ретроспективі (теоретико-методологічні підходи другої половини ХХ століття)', N'У статті аналізуються соціологічні інтерпретації концепту життєвого світу в історико-соціологічній ретроспективі (теоретико-методологічні підходи другої половини ХХ століття). Констатується, що будь-який концепт виникає як відповідь на проблеми теорії та життя й має свою історію, яка може бути досліджена.', N'0820804e-d048-4489-9601-49a51724da0d')
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Articles_Digests]') AND parent_object_id = OBJECT_ID(N'[dbo].[Articles]'))
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Digests] FOREIGN KEY([DigestID])
REFERENCES [dbo].[Digests] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Articles_Digests]') AND parent_object_id = OBJECT_ID(N'[dbo].[Articles]'))
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Digests]
GO
