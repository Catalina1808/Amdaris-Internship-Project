USE BookLoversProject;

INSERT INTO dbo.Authors (Name, Description) 
VALUES 
('Colleen Hoover', 'International and #1 New York Times bestselling author of romance, YA, thriller, women''s fiction and paranormal romance.'),
('Catherine Steadman', 'Catherine Steadman is an actress and writer based in North London, UK. She is best known for her role as Mabel Lane Fox in Downton Abbey and is currently filming on the new Starz television series ''The Rook''.'),
('J.P. Delaney', 'J. P. Delaney is the pseudonym of a writer who has previously published best-selling fiction under another name.'),
('Rupi Kaur', 'A breakout literary phenomenon and #1 New York Times Bestselling Author, Rupi Kaur wrote, illustrated, and self-published her first poetry collection, ''milk and honey'' in 2014.'),
('J.K. Rowling', 'Although she writes under the pen name J.K. Rowling, pronounced like rolling, her name when her first Harry Potter book was published was simply Joanne Rowling.'),
('Stephenie Meyer', 'Stephenie Meyer is the author of the bestselling Twilight series, The Host, and The Chemist. '),
('George R.R. Martin', 'George Raymond Richard "R.R." Martin was born September 20, 1948, in Bayonne, New Jersey. His father was Raymond Collins Martin, a longshoreman, and his mother was Margaret Brady Martin.'),
('Suzanne Collins', 'Since 1991, Suzanne Collins has been busy writing for children’s television. She has worked on the staffs of several Nickelodeon shows, including the Emmy-nominated hit Clarissa Explains it All and The Mystery Files of Shelby Woo.'),
('Veronica Roth', 'Veronica Roth is the New York Times best-selling author of Poster Girl, Chosen Ones, the short story collection The End and Other Beginnings, the Divergent series, and the Carve the Mark duology.'),
('Cassandra Clare', 'Cassandra Clare was born overseas and spent her early years traveling around the world with her family and several trunks of fantasy books. ')

INSERT INTO dbo.Books (Title, Description)
VALUES
('Ugly Love', 'When Tate Collins meets airline pilot Miles Archer, she knows it isn’t love at first sight. They wouldn’t even go so far as to consider themselves friends. The only thing Tate and Miles have in common is an undeniable mutual attraction.'),
('Verity', 'Lowen Ashleigh is a struggling writer on the brink of financial ruin when she accepts the job offer of a lifetime. Jeremy Crawford, husband of bestselling author Verity Crawford, has hired Lowen to complete the remaining books in a successful series his injured wife is unable to finish.'),
('Maybe Someday', 'At twenty-two years old, Sydney has a great life: She''s in college, working a steady job, in love with her wonderful boyfriend, Hunter, and rooming with her best friend, Tori. But everything changes when she discovers Hunter''s cheating on her and she is left trying to decide what to do next.'),
('November 9', 'Fallon meets Ben, an aspiring novelist, the day before her scheduled cross-country move. Their untimely attraction leads them to spend Fallon’s last day in L.A. together, and her eventful life becomes the creative inspiration Ben has always sought for his novel.'),
('The Girl Before', 'An enthralling psychological thriller that spins one woman''s seemingly good fortune and another woman''s mysterious fate through a kaleidoscope of duplicity, death, and deception.'),
('Believe Me', 'In this twisty psychological thriller from the New York Times bestselling author of The Girl Before, an actress plays both sides of a murder investigation.'),
('Something in the Water', 'Erin is a documentary filmmaker on the brink of a professional breakthrough, Mark a handsome investment banker with big plans. Passionately in love, they embark on a dream honeymoon to the tropical island of Bora Bora, where they enjoy the sun, the sand, and each other.'),
('Milk and Honey', 'Milk and honey is a collection of poetry and prose about survival. About the experience of violence, abuse, love, loss, and femininity. It is split into four chapters, and each chapter serves a different purpose. Deals with a different pain. Heals a different heartache.'),
('The Sun and Her Flowers', 'From Rupi Kaur, the #1 New York Times bestselling author of milk and honey, comes her long-awaited second collection of poetry. A vibrant and transcendent journey about growth and healing. Ancestry and honoring one’s roots.'),
('Twilight', 'When Bella Swan moves to a small town in the Pacific Northwest, she falls in love with Edward Cullen, a mysterious classmate who reveals himself to be a 108-year-old vampire.'),
('New Moon', 'Bella falls into a deep depression after her true love, Edward Cullen, leaves her. Her friendship with Jacob Black is expanded as she realizes that he can mend the hole left open by Edward.'),
('Eclipse', 'Eclipse is the third novel in the Twilight Saga by Stephenie Meyer. It continues the story of Bella Swan and her vampire love, Edward Cullen. The novel explores Bella''s compromise between her love for Edward and her friendship with shape-shifter Jacob Black.'),
('The Hunger Games', 'In the ruins of a place once known as North America lies the nation of Panem, a shining Capitol surrounded by twelve outlying districts. The Capitol is harsh and cruel and keeps the districts in line by forcing them all to send one boy and one girl to participate in the annual Hunger Games, a fight to the death on live TV.'),
('Catching Fire', 'Against all odds, Katniss Everdeen has won the Hunger Games. She and fellow District 12 tribute Peeta Mellark are miraculously still alive. Katniss should be relieved, happy even.'),
('Mockingjay', 'Katniss Everdeen, girl on fire, has survived, even though her home has been destroyed. Gale has escaped. Katniss''s family is safe. Peeta has been captured by the Capitol. District 13 really does exist.'),
('Divergent', 'In Beatrice Prior''s dystopian Chicago world, society is divided into five factions, each dedicated to the cultivation of a particular virtue—Candor (the honest), Abnegation (the selfless), Dauntless (the brave), Amity (the peaceful), and Erudite (the intelligent). ')

INSERT INTO dbo.BookAuthors (BookId, AuthorID)
VALUES
(1, 1),
(2, 1),
(3, 1),
(4, 1),
(5, 3),
(6, 3),
(7, 2),
(8, 4),
(9, 4),
(10, 6),
(11, 6),
(12, 6),
(13, 8),
(14, 8),
(15, 8),
(16, 9)

INSERT INTO dbo.Genres (Name)
VALUES
('Fiction'),
('Fantasy'),
('Romance'),
('Contemporary'),
('Adventure'),
('Young Adult'),
('New Adult'),
('Poetry'),
('Feminism'),
('Adult'),
('Paranormal'),
('Thriller'),
('Mystery'),
('Nonfiction')

INSERT INTO dbo.BookGenres (BookID, GenreID)
VALUES
(1, 3),
(1, 4),
(1, 7),
(2, 3),
(2, 4),
(2, 7),
(3, 3),
(3, 4),
(3, 10),
(4, 3),
(4, 4),
(4, 7),
(5, 12),
(5, 13),
(5, 10),
(6, 12),
(6, 13),
(6, 10),
(7, 10),
(7, 12),
(7, 13),
(8, 8),
(8, 9),
(8, 4),
(8, 14),
(9, 8),
(9, 9),
(9, 4),
(9, 10),
(10, 2),
(10, 3),
(10, 6),
(10, 11),
(11, 2),
(11, 3),
(11, 6),
(11, 11),
(12, 2),
(12, 3),
(12, 6),
(12, 11),
(13, 1),
(13, 2),
(13, 6),
(14, 1),
(14, 2),
(14, 6),
(15, 1),
(15, 2),
(15, 6),
(16, 1),
(16, 2),
(16, 6)

INSERT INTO dbo.Readers (FirstName, LastName, Email, Password)
VALUES
('Catalina', 'Gramada', 'catalina.g1808@gmail.com', '123456'),
('Barbie', 'Roberts', 'barbie@example.com', '123456'),
('Stacie', 'Roberts', 'stacie@example.com', '123456'),
('Skipper', 'Roberts', 'skipper@example.com', '123456'),
('Chelsea', 'Roberts', 'chelsea@example.com', '123456'),
('Ken', 'Carson', 'ken@example.com', '123456'),
('Raquelle', 'Kim', 'raquelle@example.com', '123456'),
('Ryan', 'Kim', 'ryan@example.com', '123456'),
('Nikki', 'O''Neil', 'nikki@example.com', '123456'),
('Teresa', 'Rivera', 'teresa@example.com', '123456')

INSERT INTO dbo.ReaderAuthors (ReaderID, AuthorID)
VALUES
(1, 1),
(1, 3),
(1, 4),
(1, 5),
(2, 2),
(3, 5),
(4, 5),
(5, 8),
(5, 10),
(6, 3),
(6, 7)

INSERT INTO dbo.Reviews (Comment, Date, ReaderID, BookID)
VALUES
('Great book!', '2022-11-29', 1, 1),
('Amazing book!', '2022-11-27', 1, 3),
('I loved the book!', '2022-11-28', 2, 1),
('Great book!', '2022-11-29', 3, 5),
('Great book!', '2022-11-28', 3, 4),
('Amazing book!', '2022-11-29', 5, 8),
('Great book!', '2022-11-29', 6, 7),
('I loved the book!', '2022-11-28', 4, 4),
('My favourite book!', '2022-11-29', 4, 8),
('Great book!', '2022-11-27', 8, 9)

