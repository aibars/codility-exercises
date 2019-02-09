CREATE TABLE plays (
	id int NOT NULL,
	title varchar(40) NOT NULL,
	writer varchar(40) NOT NULL
) GO
CREATE UNIQUE INDEX UQ__plays__3213E83E1347223D ON plays (id) GO

CREATE TABLE reservations (
	id int NOT NULL,
	play_id int NOT NULL,
	number_of_tickets int NOT NULL,
	theater varchar(40) NOT NULL
) GO
CREATE UNIQUE INDEX UQ__reservat__3213E83EFB804F2A ON reservations (id) GO

SELECT a.id, 
       a.title, 
       CASE 
         WHEN Sum(b.number_of_tickets) IS NULL THEN 0 
         ELSE Sum(b.number_of_tickets) 
       END AS total_reserved_tickets 
FROM   plays a 
       LEFT JOIN reservations b 
              ON a.id = b.play_id 
GROUP  BY a.id, 
          a.title 
ORDER  BY total_reserved_tickets DESC, 
          a.id ASC 