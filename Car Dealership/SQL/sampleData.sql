use GuildCars
go

delete from Contact
go

delete from Vehicle
go

dbcc checkident('Vehicle', reseed, 1)
go

delete from Model
go

delete from Make
go

delete from CarType
go

delete from BodyStyle
go

delete from Transmission
go

delete from CarColor
go

delete from Interior
go

delete from SalesData
go

dbcc checkident('SalesData', reseed, 1)
go

delete from PurchaseType
go

delete from [State]
go

delete from Specials
go

set identity_insert [State] on

insert into [State](state_ID, [state])
values (1, 'CA')
go

insert into [State](state_ID, [state])
values (2, 'NV')
go

insert into [State](state_ID, [state])
values (3, 'OR')
go

insert into [State](state_ID, [state])
values (4, 'WA')
go

set identity_insert [State] off


set identity_insert PurchaseType on

insert into PurchaseType(purchaseType_ID, purchaseType)
values (1, 'Bank Finance')
go

insert into PurchaseType(purchaseType_ID, purchaseType)
values (2, 'Cash')
go

insert into PurchaseType(purchaseType_ID, purchaseType)
values (3, 'Dealer Finance')
go

set identity_insert PurchaseType off




set identity_insert CarType on 

insert into CarType([type_ID], carType)
values(1, 'New')
go

insert into CarType([type_ID], carType)
values(2, 'Used')
go

set identity_insert CarType off





set identity_insert BodyStyle on

insert into BodyStyle(body_ID, bodyStyle)
values (1, 'Car')
go

insert into BodyStyle(body_ID, bodyStyle)
values (2, 'SUV')
go

insert into BodyStyle(body_ID, bodyStyle)
values (3, 'Truck')
go

insert into BodyStyle(body_ID, bodyStyle)
values (4, 'Van')
go

set identity_insert BodyStyle off





set identity_insert Transmission on

insert into Transmission(transmission_ID, transmission)
values (1, 'Automatic')
go

insert into Transmission(transmission_ID, transmission)
values(2, 'Manual')
go

set identity_insert Transmission off





set identity_insert CarColor on

insert into CarColor(color_ID, color)
values(1, 'White')
go

insert into CarColor(color_ID, color)
values(2, 'Silver')
go

insert into CarColor(color_ID, color)
values(3, 'Black')
go

insert into CarColor(color_ID, color)
values(4, 'Red')
go

insert into CarColor(color_ID, color)
values(5, 'Yellow')
go

set identity_insert CarColor off



set identity_insert Interior on

insert into Interior(interior_ID, interior)
values(1, 'Black')
go

insert into Interior(interior_ID, interior)
values(2, 'White')
go

insert into Interior(interior_ID, interior)
values(3, 'Cream')
go

insert into Interior(interior_ID, interior)
values(4, 'Grey')
go

insert into Interior(interior_ID, interior)
values(5, 'Tan')
go

set identity_insert Interior off



set identity_insert Specials on 

insert into Specials(special_ID, [name], [description])
values (1, 'Car Special', 'Small discount on cars')
go

insert into Specials(special_ID, [name], [description])
values (2, 'SUV Special', 'Small discount on SUVs')
go

insert into Specials(special_ID, [name], [description])
values (3, 'Truck Special', 'Small discount on trucks')
go

set identity_insert Specials off

set identity_insert Make on 

insert into Make(make_ID, make, dateAdded, addedBy)
values(1, 'Ford', '1950-01-01', 'testadmin')
go

insert into Make(make_ID, make, dateAdded, addedBy)
values(2, 'Nissan', '1965-01-02', 'testadmin')
go

insert into Make(make_ID, make, dateAdded, addedBy)
values(3, 'Audi', '1980-01-01', 'testadmin')

set identity_insert Make off


set identity_insert Model on

insert into Model(model_ID, model, dateAdded, addedBy, make_ID)
values(1, 'Mustang', '1950-01-01', 'testadmin', 1)
go

insert into Model(model_ID, model, dateAdded, addedBy, make_ID)
values(2, '370Z', '1965-01-02', 'testadmin', 2)
go

insert into Model(model_ID, model, dateAdded, addedBy, make_ID)
values(3, 'A4', '1965-01-03', 'testadmin', 3)
go

set identity_insert Model off


set identity_insert Vehicle on

insert into Vehicle(vehicle_ID, make_ID, model_ID, [type_ID], body_ID, transmission_ID, color_ID,
					interior_ID, [year], mileage, vinNumber, msrp, salePrice, [description], picture, featured, sale_ID)
values(1, 1, 1, 1, 1, 1, 4, 1, 2019, 20000, 'JM3TB2DV1C0364982', 50000, 47500, 'American muscle', '/Images/inventory-1.png', 0, null)
go

insert into Vehicle(vehicle_ID, make_ID, model_ID, [type_ID], body_ID, transmission_ID, color_ID,
					interior_ID, [year], mileage, vinNumber, msrp, salePrice, [description], picture, featured, sale_ID)
values(2, 2, 2, 2, 1, 2, 2, 4, 2014, 35000,'JM3TB2DV1C0364982', 30000, 28500, 'Japanese sports car', '/Images/inventory-2.jpg', 1, null)
go

insert into Vehicle(vehicle_ID, make_ID, model_ID, [type_ID], body_ID, transmission_ID, color_ID,
					interior_ID, [year], mileage, vinNumber, msrp, salePrice, [description], picture, featured, sale_ID)
values(3, 3, 3, 1, 1, 1, 2, 5, 2020, 500, 'KNDJE723587479167', 37400, 35530, 'German upmarket daily driver', '/Images/inventory-3.jpg', 1, null)
go

insert into Vehicle(vehicle_ID, make_ID, model_ID, [type_ID], body_ID, transmission_ID, color_ID,
					interior_ID, [year], mileage, vinNumber, msrp, salePrice, [description], picture, featured, sale_ID)
values(4, 1, 1, 2, 1, 1, 4, 1, 2019, 20000, 'JM3TB2DV1C0364982', 30000, 285000, 'American muscle', '/Images/inventory-1.png', 0, null)

set identity_insert Vehicle off


-- Vehicle sample data
