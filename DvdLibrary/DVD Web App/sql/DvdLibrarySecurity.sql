use master
go

if exists (select name from master.sys.server_principals
	where name = 'DvdLibraryApp')
	begin
		drop login DvdLibraryApp
	end
go

create login DvdLibraryApp with password='testing123'
go

use DvdLibrary
go

drop user if exists libraryUser
go

create user libraryUser for login DvdLibraryApp
go

drop role if exists db_executor
go

create role db_executor
grant execute to db_executor
alter role db_executor add member libraryUser
go

grant select on Dvd to libraryUser
grant insert on Dvd to libraryUser
grant update on Dvd to libraryUser
grant delete on Dvd to libraryUser
go