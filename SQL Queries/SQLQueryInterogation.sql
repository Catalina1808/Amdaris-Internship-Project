USE BookLoversProject;

SELECT a.Name, b.Title
FROM dbo.Authors as a
INNER JOIN dbo.BookAuthors as ba
ON a.ID = ba.AuthorID
INNER JOIN dbo.Books as b
ON b.ID = ba.BookID
ORDER BY a.Name

SELECT a.Name, COUNT(b.Title)
FROM dbo.Authors as a
INNER JOIN dbo.BookAuthors as ba
ON a.ID = ba.AuthorID
INNER JOIN dbo.Books as b
ON b.ID = ba.BookID
GROUP BY a.Name
ORDER BY a.Name


SELECT r.FirstName as Follower, a.Name as Author
FROM dbo.Readers as r
LEFT JOIN dbo.ReaderAuthors as ra
ON r.ID = ra.ReaderID
LEFT JOIN dbo.Authors as a
ON ra.AuthorID = a.ID

SELECT r.FirstName as Follower, COUNT(a.Name) as NrOfAuthors
FROM dbo.Readers as r
LEFT JOIN dbo.ReaderAuthors as ra
ON r.ID = ra.ReaderID
LEFT JOIN dbo.Authors as a
ON ra.AuthorID = a.ID
GROUP BY r.FirstName
ORDER BY NrOfAuthors DESC

SELECT b.Title, r.Comment
FROM dbo.Books as b
INNER JOIN dbo.BookAuthors as ba
ON b.ID = ba.BookId
INNER JOIN dbo.Reviews as r
ON r.BookID = b.ID
WHERE ba.AuthorID = 1
ORDER BY b.Title

SELECT b.Title, review.Comment, reader.FirstName as Reader
FROM dbo.Books as b
INNER JOIN dbo.BookAuthors as ba
ON b.ID = ba.BookId
INNER JOIN dbo.Reviews as review
ON review.BookID = b.ID
INNER JOIN dbo.Readers as reader
ON review.ReaderID = reader.ID
WHERE ba.AuthorID = 4
ORDER BY b.Title

SELECT b.Title, COUNT(r.Comment) as NrOfComments
FROM dbo.Books as b
LEFT JOIN dbo.BookAuthors as ba
ON b.ID = ba.BookId
LEFT JOIN dbo.Reviews as r
ON r.BookID = b.ID
WHERE ba.AuthorID = 1
GROUP BY b.Title
ORDER BY NrOfComments DESC

SELECT a.Name, b.Title, g.Name
FROM dbo.Authors as a
INNER JOIN dbo.BookAuthors as ba
ON a.ID = ba.AuthorID
INNER JOIN dbo.Books as b
ON ba.BookID = b.ID
INNER JOIN dbo.BookGenres as bg
ON b.ID = bg.BookID
INNER JOIN dbo.Genres as g
ON bg.GenreID = g.ID

SELECT a.Name, b.Title, COUNT(g.Name) as NrOfGenres
FROM dbo.Authors as a
INNER JOIN dbo.BookAuthors as ba
ON a.ID = ba.AuthorID
INNER JOIN dbo.Books as b
ON ba.BookID = b.ID
INNER JOIN dbo.BookGenres as bg
ON b.ID = bg.BookID
INNER JOIN dbo.Genres as g
ON bg.GenreID = g.ID
GROUP BY a.Name, b.Title
HAVING a.Name LIKE 'C%'

SELECT a.Name, COUNT(g.Name) as NrOfGenres
FROM dbo.Authors as a
INNER JOIN dbo.BookAuthors as ba
ON a.ID = ba.AuthorID
INNER JOIN dbo.Books as b
ON ba.BookID = b.ID
INNER JOIN dbo.BookGenres as bg
ON b.ID = bg.BookID
INNER JOIN dbo.Genres as g
ON bg.GenreID = g.ID
GROUP BY a.Name
HAVING a.Name LIKE '[CJ]%'
