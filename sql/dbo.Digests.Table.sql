USE [Sociobase]
GO
/****** Object:  Table [dbo].[Digests]    Script Date: 07.11.2015 17:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Digests](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Digests_ID]  DEFAULT (newid()),
	[Name] [nvarchar](200) NULL,
	[Type] [nvarchar](50) NULL,
	[Number] [int] NULL,
	[Year] [int] NULL,
	[City] [nvarchar](50) NULL,
	[Publisher] [nvarchar](50) NULL,
	[TotalPages] [int] NULL,
 CONSTRAINT [PK_Digests] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Digests] ([ID], [Name], [Type], [Number], [Year], [City], [Publisher], [TotalPages]) VALUES (N'0820804e-d048-4489-9601-49a51724da0d', N'Вісник Харківського національного університету імені В.Н Каразіна', N'збірник наукових праць', 1148, 2015, N'Харків', N'Видавництво ХНУ', 160)
INSERT [dbo].[Digests] ([ID], [Name], [Type], [Number], [Year], [City], [Publisher], [TotalPages]) VALUES (N'29fc6cea-03ee-437b-bd1c-8de530bab9f4', N'asasasasasasa', N'fj', 123, 1232, N'pjpi', N'huh', 56)
