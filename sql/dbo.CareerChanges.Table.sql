USE [Sociobase]
GO
/****** Object:  Table [dbo].[CareerChanges]    Script Date: 11.09.2015 18:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CareerChanges]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CareerChanges](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_CareerChanges_ID]  DEFAULT (newid()),
	[AuthorID] [uniqueidentifier] NOT NULL,
	[Degree] [nvarchar](30) NULL,
	[Position] [nvarchar](20) NULL,
	[IsCurrent] [int] NULL,
	[ChangeYear] [int] NULL
) ON [PRIMARY]
END
GO
INSERT [dbo].[CareerChanges] ([ID], [AuthorID], [Degree], [Position], [IsCurrent], [ChangeYear]) VALUES (N'9759d5ee-b3ff-4e3a-b787-65018490548c', N'a3dcdffd-de6d-473f-b74f-a60da2f8ccfa', NULL, N'викладач', 1, 2015)
INSERT [dbo].[CareerChanges] ([ID], [AuthorID], [Degree], [Position], [IsCurrent], [ChangeYear]) VALUES (N'8ef66e2a-ec55-4c19-a751-d55104228944', N'38f25be5-cc61-4bfd-845e-ad955c610906', N'кандидат соціологічних наук', N'доцент', 1, 2015)
INSERT [dbo].[CareerChanges] ([ID], [AuthorID], [Degree], [Position], [IsCurrent], [ChangeYear]) VALUES (N'0a5ac720-c24d-4cb5-b30f-8831bfc6de94', N'bdb6760e-25c9-424b-8533-efbfa29673b7', N'кандидат соціологічних наук', N'доцент', 1, 2015)
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CareerChanges_Authors]') AND parent_object_id = OBJECT_ID(N'[dbo].[CareerChanges]'))
ALTER TABLE [dbo].[CareerChanges]  WITH CHECK ADD  CONSTRAINT [FK_CareerChanges_Authors] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CareerChanges_Authors]') AND parent_object_id = OBJECT_ID(N'[dbo].[CareerChanges]'))
ALTER TABLE [dbo].[CareerChanges] CHECK CONSTRAINT [FK_CareerChanges_Authors]
GO
