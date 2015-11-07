IF OBJECT_ID('GetBibliographyForArticle', 'P') IS NOT NULL
	DROP PROCEDURE GetBibliographyForArticle;

GO

CREATE PROCEDURE GetBibliographyForArticle
	@CurrentArticleID NVARCHAR(36)
AS
BEGIN
	DECLARE @RefArticleAuthor TABLE (ID UNIQUEIDENTIFIER, ArticleName NVARCHAR(1000), FullName NVARCHAR(200));

	INSERT INTO @RefArticleAuthor (ID, ArticleName, FullName)
	SELECT b.ID, a.Name AS ArticleName, SUBSTRING(au.FirstName,1,1) + '.' + au.LastName AS FullName
	FROM Bibliography b
	INNER JOIN Articles a ON a.ID = b.ArticleRefID
	INNER JOIN ArticleAuthors aa ON aa.ArticleID = a.ID
	INNER JOIN Authors au ON au.ID = aa.AuthorID
	WHERE b.ArticleID = @CurrentArticleID;

	INSERT INTO @RefArticleAuthor (ID, ArticleName, FullName)
	SELECT  b.ID, b.ArticleRefName AS ArticleName, SUBSTRING(au.FirstName,1,1) + '.' + au.LastName AS FullName
	FROM Bibliography b
	INNER JOIN BibliographyAuthors ba ON ba.BibliographyID = b.ID
	INNER JOIN Authors au ON au.ID = ba.AuthorID
	WHERE ArticleID = @CurrentArticleID
	AND ArticleRefID IS NULL;

	SELECT  ID, STUFF((SELECT ', ' + FullName AS [text()]
			FROM @RefArticleAuthor xt
			WHERE xt.id = t.id
			FOR XML PATH('')), 1, 2, '')
			+ ' «' + ArticleName + '»' AS Bibliography
	FROM @RefArticleAuthor t
	GROUP BY id, ArticleName;
END;

EXEC GetBibliographyForArticle '6D631377-B0D6-4006-954A-C04F02303CF7'