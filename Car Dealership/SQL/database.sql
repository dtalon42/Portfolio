use master
go

if exists (select * from sysdatabases where name='GuildCars')
	drop database GuildCars
go

create database GuildCars
go
