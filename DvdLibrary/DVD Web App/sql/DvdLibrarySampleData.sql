use DvdLibrary
go

delete from Dvd
go

set identity_insert Dvd on

insert into Dvd(dvdId, title, releaseYear, director, rating, notes)
values (1, 'A Great Tale', '2015', 'Sam Jones', 'PG', 'This really is a great tale!')
go

insert into Dvd( dvdId, title, releaseYear, director, rating, notes)
values (2, 'A Good Tale', '2012', 'Joe Smith', 'PG-13', 'This is a good tale!')
go

insert into Dvd(dvdId, title, releaseYear, director, rating, notes)
values (3, 'A Super Tale', '2015', 'Sam Jones', 'PG', 'A great remake!')
go

insert into Dvd(dvdId, title, releaseYear, director, rating, notes)
values (4, 'A Super Tale', '1985', 'Joe Smith', 'PG', 'The original!')
go

insert into Dvd(dvdId, title, releaseYear, director, rating, notes)
values (5, 'A Wonderful Tale', '2015', 'Joe Smith', 'PG-13', 'Wonderful, just wonderful!')
go

insert into Dvd(dvdId, title, releaseYear, director, rating, notes)
values (6, 'Just A Tale', '2015', 'Joe Baker', 'PG', 'It is a tale!')
go

insert into Dvd(dvdId, title, releaseYear, director, rating, notes)
values (7, 'A New Tale', '2016', 'Jack Jameson', 'PG-13', 'Brand spanking new!')
go

set identity_insert Dvd off