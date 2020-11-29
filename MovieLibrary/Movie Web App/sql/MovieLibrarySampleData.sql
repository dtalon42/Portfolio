use MovieLibrary
go

delete from Movie
go

set identity_insert Movie on

insert into Movie(movieId, title, releaseYear, director, rating, [description], thumbsUp, thumbsDown)
values (1, 'A Great Tale', '2015', 'Sam Jones', 'PG', 'This really is a great tale!', 10, 2)
go

insert into Movie(movieId, title, releaseYear, director, rating, [description], thumbsUp, thumbsDown)
values (2, 'A Good Tale', '2012', 'Joe Smith', 'PG-13', 'This is a good tale!', 15, 1)
go

insert into Movie(movieId, title, releaseYear, director, rating, [description], thumbsUp, thumbsDown)
values (3, 'A Super Tale', '2015', 'Sam Jones', 'PG', 'A great remake!', 17, 3)
go

insert into Movie(movieId, title, releaseYear, director, rating, [description], thumbsUp, thumbsDown)
values (4, 'A Super Tale', '1985', 'Joe Smith', 'PG', 'The original!',  100, 7)
go

insert into Movie(movieId, title, releaseYear, director, rating, [description], thumbsUp, thumbsDown)
values (5, 'A Wonderful Tale', '2015', 'Joe Smith', 'PG-13', 'Wonderful, just wonderful!', 50, 2)
go

insert into Movie(movieId, title, releaseYear, director, rating, [description], thumbsUp, thumbsDown)
values (6, 'Just A Tale', '2015', 'Joe Baker', 'PG', 'It is a tale!', 25, 25)
go

insert into Movie(movieId, title, releaseYear, director, rating, [description], thumbsUp, thumbsDown)
values (7, 'A New Tale', '2016', 'Jack Jameson', 'PG-13', 'Brand spanking new!', 20, 9)
go

insert into Movie(movieId, title, releaseYear, director, rating, [description], thumbsUp, thumbsDown)
values (8, 'Spider-Man: Homecoming', '2017', 'Jon Watts', 'PG-13', 'Spider-Man after The Avengers', 25, 4)
go

insert into Movie(movieId, title, releaseYear, director, rating, [description], thumbsUp, thumbsDown)
values (9, 'Spider-Man: Far From Home', '2019', 'Jon Watts', 'PG-13', 'Spider-Man saves the world', 30, 11)
go

insert into Movie(movieId, title, releaseYear, director, rating, [description], thumbsUp, thumbsDown)
values (10, 'Thor', '2011', 'Kenneth Branagh', 'PG-13', 'Origin of the god of thunder', 27, 6)
go

insert into Movie(movieId, title, releaseYear, director, rating, [description], thumbsUp, thumbsDown)
values (11, 'Iron Man', '2008', 'Jon Favreau', 'PG-13', 'RDJ becomes playboy Tony Stark', 50, 9)
go

insert into Movie(movieId, title, releaseYear, director, rating, [description], thumbsUp, thumbsDown)
values (12, 'The Incredible Hulk', '2008', 'Louis Leterrier', 'PG-13', 'Scientist turns into green man', 37, 8)
go

insert into Movie(movieId, title, releaseYear, director, rating, [description], thumbsUp, thumbsDown)
values (13, 'The Avengers', '2011', 'Joss Whedon', 'PG-13', 'Superheroes team up, save city', 50, 11)
go

insert into Movie(movieId, title, releaseYear, director, rating, [description], thumbsUp, thumbsDown)
values (14, 'Doctor Strange', '2016', 'Scott Derrickson', 'PG-13', 'Man uses magic, defies physics', 47, 12)
go

insert into Movie(movieId, title, releaseYear, director, rating, [description], thumbsUp, thumbsDown)
values (15, 'Captain America', '2011', 'Joe Johnston', 'PG-13', 'Origins of the Captain', 20, 9)
go

insert into Movie(movieId, title, releaseYear, director, rating, [description], thumbsUp, thumbsDown)
values (16, 'Guardians of the Galaxy', '2014', 'James Gunn', 'PG-13', 'Misfits defend the galaxy', 40, 5)
go

set identity_insert Movie off