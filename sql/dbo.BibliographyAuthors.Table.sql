USE [Sociobase]
GO
/****** Object:  Table [dbo].[BibliographyAuthors]    Script Date: 07.11.2015 17:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BibliographyAuthors](
	[ID] [uniqueidentifier] NOT NULL,
	[AuthorID] [uniqueidentifier] NOT NULL,
	[BibliographyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_BibliographyAuthors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[BibliographyAuthors] ADD  CONSTRAINT [DF_BibliographyAuthors_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[BibliographyAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BibliographyAuthors_Authors] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([ID])
GO
ALTER TABLE [dbo].[BibliographyAuthors] CHECK CONSTRAINT [FK_BibliographyAuthors_Authors]
GO
ALTER TABLE [dbo].[BibliographyAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BibliographyAuthors_Bibliography] FOREIGN KEY([BibliographyID])
REFERENCES [dbo].[Bibliography] ([ID])
GO
ALTER TABLE [dbo].[BibliographyAuthors] CHECK CONSTRAINT [FK_BibliographyAuthors_Bibliography]
GO
