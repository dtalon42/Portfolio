use master
go

if exists (select * from sysdatabases where name='MovieLibrary')
	drop database MovieLibrary
go

create database MovieLibrary
go

use MovieLibrary
go

drop table if exists Movie
go

create table Movie (
	movieId int identity(1,1) primary key not null,
	title nvarchar(30) not null,
	releaseYear nvarchar(4) not null,
	director nvarchar(30) not null,
	rating nvarchar(5) not null,
	[description] nvarchar(30),
	thumbsUp int not null,
	thumbsDown int not null
)
go