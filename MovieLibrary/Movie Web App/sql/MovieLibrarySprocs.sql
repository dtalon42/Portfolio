use MovieLibrary
go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'MovieById'
	)
begin
	drop procedure MovieById
end
go

create procedure MovieById(
	@Id int
	)
as

select *
from Movie
where Movie.movieId = @Id

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AllMovies'
	)
begin
	drop procedure AllMovies
end
go

create procedure AllMovies
as

select *
from Movie

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'MovieByTitle'
	)
begin
	drop procedure MovieByTitle
end
go

create procedure MovieByTitle(
	@Title nvarchar(20)
	)
as

select *
from Movie
where title like '%' + @Title + '%' 


go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'MovieByYear'
	)
begin
	drop procedure MovieByYear
end
go

create procedure MovieByYear(
	@Year nvarchar(4)
	)
as

select *
from Movie
where releaseYear = @Year 


go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'MovieByDirector'
	)
begin
	drop procedure MovieByDirector
end
go

create procedure MovieByDirector(
	@Director nvarchar(30)
	)
as

select *
from Movie
where director like '%' + @Director + '%' 


go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'MovieByRating'
	)
begin
	drop procedure MovieByRating
end
go

create procedure MovieByRating(
	@Rating nvarchar(5)
	)
as

select *
from Movie
where rating = @Rating 


go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'CreateMovie'
	)
begin
	drop procedure CreateMovie
end
go

create procedure CreateMovie(
	@Title nvarchar(20),
	@ReleaseYear nvarchar(4),
	@Director nvarchar(30),
	@Rating nvarchar(5),
	@Description nvarchar(30),
	@ThumbsUp int,
	@ThumbsDown int
	)
as

insert into Movie(title, releaseYear, director, rating, [description], thumbsUp, thumbsDown)
values (@Title, @ReleaseYear, @Director, @Rating, @Description, @ThumbsUp, @ThumbsDown)

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'UpdateMovie'
	)
begin
	drop procedure UpdateMovie
end
go

create procedure UpdateMovie(
	@Id int,
	@Title nvarchar(20),
	@ReleaseYear nvarchar(4),
	@Director nvarchar(30),
	@Rating nvarchar(5),
	@Description nvarchar(30),
	@ThumbsUp int,
	@ThumbsDown int
	)
as

update Movie
set title = @Title,
	releaseYear = @ReleaseYear,
	director = @Director,
	rating = @Rating,
	[description] = @Description,
	thumbsUp = @ThumbsUp,
	thumbsDown = @ThumbsDown
where movieId = @Id
go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DeleteMovie'
	)
begin
	drop procedure DeleteMovie
end
go

create procedure DeleteMovie(
	@Id int
	)
as

delete from Movie
where movieId = @Id
go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'LastMovie'
	)
begin
	drop procedure LastMovie
end
go

create procedure LastMovie
as

select *
from Movie
where movieId = (select max(movieId) from Movie)
go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'ThumbsUp'
	)
begin
	drop procedure ThumbsUp
end
go

create procedure ThumbsUp(
	@Id int)
as

update Movie
set thumbsUp = thumbsUp + 1
where movieId = @Id
go


if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'ThumbsDown'
	)
begin
	drop procedure ThumbsDown
end
go

create procedure ThumbsDown(
	@Id int)
as

update Movie
set thumbsDown = thumbsDown + 1
where movieId = @Id
go