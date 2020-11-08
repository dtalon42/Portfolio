use GuildCars
go 

delete from SalesData
go

set identity_insert SalesData on 

insert into SalesData(sale_ID, [name], phone, email, street_1, street_2, city, state_ID, zipCode, purchasePrice, purchaseType_ID, purchaseDate, userAdded)
values(1, 'keith', '1234567890', '123@test.com', '123 Main st', null, 'City', 1, '12345', 10000, 1, '01-01-2010', 'test@sales.com')
go

insert into SalesData(sale_ID, [name], phone, email, street_1, street_2, city, state_ID, zipCode, purchasePrice, purchaseType_ID, purchaseDate, userAdded)
values(2, 'keith', '1234567890', '123@test.com', '123 Main st', null, 'City', 1, '12345', 12500, 1, '01-01-2011', 'testsales@admin.com')
go

set identity_insert SalesData off
