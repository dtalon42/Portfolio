use master;
go

if exists (select * from sysdatabases where name='DvdLibrary')
	drop database DvdLibrary
go

create database DvdLibrary
go

use DvdLibrary
go

create table Dvd (
	dvdId int identity(1,1) primary key not null,
	title nvarchar(20) not null,
	releaseYear nvarchar(4) not null,
	director nvarchar(30) not null,
	rating nvarchar(5) not null,
	notes nvarchar(30)
)
go