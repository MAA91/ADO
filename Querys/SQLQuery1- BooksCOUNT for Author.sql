USE Library;
GO

SELECT COUNT(book_id) AS 'Books count', first_name+' '+last_name AS 'Author'
FROM	Books, Authors
WHERE	author=author_id
GROUP BY last_name, first_name