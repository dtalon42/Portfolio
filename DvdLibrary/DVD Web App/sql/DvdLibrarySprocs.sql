use DvdLibrary
go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdById'
	)
begin
	drop procedure DvdById
end
go

create procedure DvdById(
	@Id int
	)
as

select *
from Dvd
where Dvd.dvdId = @Id

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AllDvds'
	)
begin
	drop procedure AllDvds
end
go

create procedure AllDvds
as

select *
from Dvd

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdByTitle'
	)
begin
	drop procedure DvdByTitle
end
go

create procedure DvdByTitle(
	@Title nvarchar(20)
	)
as

select *
from Dvd
where title like '%' + @Title + '%' 


go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdByYear'
	)
begin
	drop procedure DvdByYear
end
go

create procedure DvdByYear(
	@Year nvarchar(4)
	)
as

select *
from Dvd
where releaseYear = @Year 


go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdByDirector'
	)
begin
	drop procedure DvdByDirector
end
go

create procedure DvdByDirector(
	@Director nvarchar(30)
	)
as

select *
from Dvd
where director like '%' + @Director + '%' 


go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdByRating'
	)
begin
	drop procedure DvdByRating
end
go

create procedure DvdByRating(
	@Rating nvarchar(5)
	)
as

select *
from Dvd
where rating = @Rating 


go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'CreateDvd'
	)
begin
	drop procedure CreateDvd
end
go

create procedure CreateDvd(
	@Title nvarchar(20),
	@ReleaseYear nvarchar(4),
	@Director nvarchar(30),
	@Rating nvarchar(5),
	@Notes nvarchar(30)
	)
as

insert into Dvd(title, releaseYear, director, rating, notes)
values (@Title, @ReleaseYear, @Director, @Rating, @Notes)

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'UpdateDvd'
	)
begin
	drop procedure UpdateDvd
end
go

create procedure UpdateDvd(
	@Id int,
	@Title nvarchar(20),
	@ReleaseYear nvarchar(4),
	@Director nvarchar(30),
	@Rating nvarchar(5),
	@Notes nvarchar(30)
	)
as

update Dvd
set title = @Title,
	releaseYear = @ReleaseYear,
	director = @Director,
	rating = @Rating,
	notes = @Notes
where dvdId = @Id
go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DeleteDvd'
	)
begin
	drop procedure DeleteDvd
end
go

create procedure DeleteDvd(
	@Id int
	)
as

delete from Dvd
where dvdId = @Id
go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'LastDvd'
	)
begin
	drop procedure LastDvd
end
go

create procedure LastDvd
as

select *
from Dvd
where dvdId = (select max(dvdId) from Dvd)
go