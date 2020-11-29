use master
go

if exists (select name from master.sys.server_principals
	where name = 'MovieLibraryApp')
	begin
		drop login MovieLibraryApp
	end
go

create login MovieLibraryApp with password='testing123'
go

use MovieLibrary
go

drop user if exists libraryUser
go

create user libraryUser for login MovieLibraryApp
go

drop role if exists db_executor
go

create role db_executor
grant execute to db_executor
alter role db_executor add member libraryUser
go

grant select on Movie to libraryUser
grant insert on Movie to libraryUser
grant update on Movie to libraryUser
grant delete on Movie to libraryUser
go