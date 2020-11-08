use GuildCars
go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetSpecials'
	)
	begin
	drop procedure GetSpecials
	end
go

create procedure GetSpecials
as

select *
from Specials

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AddSpecial'
	)
	begin
	drop procedure AddSpecial
	end
go

create procedure AddSpecial(
	@Name nvarchar(25),
	@Description nvarchar(250)
)
as

insert into Specials([name], [description])
values(@Name, @Description)

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DeleteSpecial'
	)
	begin
	drop procedure DeleteSpecial
	end
go

create procedure DeleteSpecial(
	@Id int
	)
as

delete from Specials
where special_ID = @Id

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetFeaturedVehicles'
	)
	begin
	drop procedure GetFeaturedVehicles
	end
go

create procedure GetFeaturedVehicles

as

select [year], Make.make, Model.model, salePrice, picture
from Vehicle
inner join Make on Vehicle.make_ID = Make.make_ID
inner join Model on Vehicle.model_ID = Model.model_ID
where featured = 1 and sale_ID is null

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetNewVehicles'
	)
	begin
	drop procedure GetNewVehicles
	end
go

create procedure GetNewVehicles(
	@SearchString nvarchar(30),
	@NewOrUsed bit, -- 1 is new, 0 is used
	@minPrice decimal, -- pass default value from application
	@maxPrice decimal,
	@minYear int,
	@maxYear int
	)

as
-- get first 20 vehicles
select top 20 Vehicle.vehicle_ID, [year], Make.make, Model.model, CarType.carType,
		BodyStyle.bodyStyle,
		Transmission.transmission, CarColor.color,
		Interior.interior, mileage, vinNumber, salePrice, msrp, picture
from Vehicle
inner join Make on Vehicle.make_ID = Make.make_ID
inner join Model on Vehicle.model_ID = Model.model_ID
inner join CarType on Vehicle.[type_ID] = CarType.[type_ID] 
inner join BodyStyle on Vehicle.body_ID = BodyStyle.body_ID
inner join Transmission on Vehicle.transmission_ID = Transmission.transmission_ID
inner join CarColor on Vehicle.color_ID = CarColor.color_ID
inner join Interior on Vehicle.interior_ID = Interior.interior_ID
	where Vehicle.[type_ID] = @NewOrUsed
	and Vehicle.sale_ID is null
	and msrp > @minPrice 
				and msrp < @maxPrice 
				and [year] > @minYear 
				and [year] < @maxYear
				and 
				(
					isnull(@SearchString, '') <> @SearchString -- checks that SearchString is not null and is not an empty string
					or CONCAT([year], ' ', Make.make, ' ', Model.model) like '%' + @SearchString + '%'
				)		
order by msrp desc  

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetUsedVehicles'
	)
	begin
	drop procedure GetUsedVehicles
	end
go

create procedure GetUsedVehicles(
	@SearchString nvarchar(30),
	@NewOrUsed bit, -- 1 is new, 0 is used
	@minPrice decimal, -- pass default value from application
	@maxPrice decimal,
	@minYear int,
	@maxYear int
	)

as
-- get first 20 vehicles
select top 20 Vehicle.vehicle_ID, [year], Make.make, Model.model, CarType.carType,
		BodyStyle.bodyStyle,
		Transmission.transmission, CarColor.color,
		Interior.interior, mileage, vinNumber, salePrice, msrp, picture
from Vehicle
inner join Make on Vehicle.make_ID = Make.make_ID
inner join Model on Vehicle.model_ID = Model.model_ID
inner join CarType on Vehicle.[type_ID] = CarType.[type_ID] 
inner join BodyStyle on Vehicle.body_ID = BodyStyle.body_ID
inner join Transmission on Vehicle.transmission_ID = Transmission.transmission_ID
inner join CarColor on Vehicle.color_ID = CarColor.color_ID
inner join Interior on Vehicle.interior_ID = Interior.interior_ID
	where Vehicle.[type_ID] = 2
	and Vehicle.sale_ID is null
	and msrp > @minPrice 
				and msrp < @maxPrice 
				and [year] > @minYear 
				and [year] < @maxYear
				and 
				(
					isnull(@SearchString, '') <> @SearchString -- checks that SearchString is not null and is not an empty string
					or CONCAT([year], ' ', Make.make, ' ', Model.model) like '%' + @SearchString + '%'
				)		
order by msrp desc  

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetAvailableVehicles'
	)
	begin
	drop procedure GetAvailableVehicles
	end
go

create procedure GetAvailableVehicles(
	@SearchString nvarchar(30),
	@minPrice decimal, -- pass default value from application
	@maxPrice decimal,
	@minYear int,
	@maxYear int
	)
as

select Vehicle.vehicle_ID, [year], Make.make, Model.model, CarType.carType,
		BodyStyle.bodyStyle,
		Transmission.transmission, CarColor.color,
		Interior.interior, mileage, vinNumber, salePrice, msrp, picture
from Vehicle
inner join Make on Vehicle.make_ID = Make.make_ID
inner join Model on Vehicle.model_ID = Model.model_ID
inner join CarType on Vehicle.[type_ID] = CarType.[type_ID]
inner join BodyStyle on Vehicle.body_ID = BodyStyle.body_ID
inner join Transmission on Vehicle.transmission_ID = Transmission.transmission_ID
inner join CarColor on Vehicle.color_ID = CarColor.color_ID
inner join Interior on Vehicle.interior_ID = Interior.interior_ID
where Vehicle.sale_ID is null
	and msrp > @minPrice 
				and msrp < @maxPrice 
				and [year] > @minYear 
				and [year] < @maxYear
				and 
				(
					isnull(@SearchString, '') <> @SearchString -- checks that SearchString is not null and is not an empty string
					or CONCAT([year], ' ', Make.make, ' ', Model.model) like '%' + @SearchString + '%'
				)		
order by msrp desc

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetVehicleDetails'
	)
	begin
	drop procedure GetVehicleDetails
	end
go

create procedure GetVehicleDetails(
	@Id int
)
as

select Vehicle.vehicle_ID, [year], Make.make, Model.model, CarType.carType,
		BodyStyle.bodyStyle,
		Transmission.transmission, CarColor.color,
		Interior.interior, mileage, vinNumber, salePrice, msrp, picture, [description], sale_ID
from Vehicle
inner join Make on Vehicle.make_ID = Make.make_ID
inner join Model on Vehicle.model_ID = Model.model_ID
inner join CarType on Vehicle.[type_ID] = CarType.[type_ID] 
inner join BodyStyle on Vehicle.body_ID = BodyStyle.body_ID
inner join Transmission on Vehicle.transmission_ID = Transmission.transmission_ID
inner join CarColor on Vehicle.color_ID = CarColor.color_ID
inner join Interior on Vehicle.interior_ID = Interior.interior_ID
where vehicle_ID = @Id


go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetVehicle'
	)
	begin
	drop procedure GetVehicle
	end
go

create procedure GetVehicle(
	@Id int
)
as

select Vehicle.vehicle_ID, [year], make_ID, model_ID, [type_ID],
		body_ID, transmission_ID, color_ID, interior_ID, mileage, 
		vinNumber, salePrice, msrp, picture, [description], sale_ID
from Vehicle

where vehicle_ID = @Id


go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AddContact'
	)
	begin
	drop procedure AddContact
	end
go

create procedure AddContact(
	@Name nvarchar(50),
	@Email nvarchar(254),
	@Phone nvarchar(12),
	@Description nvarchar(250)
)

as
	insert into Contact([name], email, phoneNumber, [description])
	values(@Name, @Email, @Phone, @Description)


go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AddSalesData'
	)
	begin
	drop procedure AddSalesData
	end
go

create procedure AddSalesData(
	@Id int,
	@Name nvarchar(50), 
	@Phone nvarchar(12), 
	@Email nvarchar(254), 
	@Street1 nvarchar(95), 
	@Street2 nvarchar(10), 
	@City nvarchar(17), 
	@StateID int, 
	@Zipcode nvarchar(5), 
	@PurchasePrice decimal, 
	@PurchaseTypeID int,
	@userAdded nvarchar(254)) -- added this line

	as

	insert into SalesData([name], phone, email, street_1, street_2, city, state_ID, zipCode, purchasePrice, purchaseType_ID, purchaseDate, userAdded)
	values(@Name, @Phone, @Email, @Street1, @Street2, @City, @StateID, @Zipcode, @PurchasePrice, @PurchaseTypeID, GETDATE(), @userAdded)
	
	update Vehicle
	set sale_ID = IDENT_CURRENT('SalesData')
	where Vehicle.vehicle_ID = @Id

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetSalesData'
	)
	begin
	drop procedure GetSalesData
	end
go

create procedure GetSalesData( -- may require revision, not sure if only one row will be returned
	@Id int
	)
as

select SalesData.*, PurchaseType.purchaseType, [State].[state]
from SalesData
inner join PurchaseType on SalesData.purchaseType_ID = PurchaseType.purchaseType_ID
inner join [State] on SalesData.state_ID = [State].state_ID
where SalesData.sale_ID = @Id

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetState'
	)
	begin
	drop procedure GetState
	end
go

create procedure GetState
as

select *
from [State]
go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetPurchaseType'
	)
	begin
	drop procedure GetPurchaseType
	end
go

create procedure GetPurchaseType
as

select *
from PurchaseType

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AddVehicle'
	)
	begin
	drop procedure AddVehicle
	end
go

create procedure AddVehicle (
	@MakeID int, 
	@ModelID int, 
	@TypeID int, 
	@BodyID int,
	@TransmissionID int,
	@ColorID int,
	@InteriorID int,
	@Year int,
	@Mileage int,
	@vinNumber nvarchar(17),
	@Msrp decimal,
	@SalePrice decimal,
	@Description nvarchar(500),
	@Picture nvarchar(260),
	@Featured bit
	)
as

insert into Vehicle(make_ID, model_ID, [type_ID], body_ID, transmission_ID, 
					color_ID, interior_ID, [year], mileage, vinNumber, msrp, 
					salePrice, [description], picture, featured)
values(@MakeID, @ModelID, @TypeID, @BodyID, @TransmissionID, @ColorID, @InteriorID, @Year,
	   @Mileage, @vinNumber, @Msrp, @SalePrice, @Description, @Picture, @Featured)



go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'EditVehicle'
	)
	begin
	drop procedure EditVehicle
	end
go

create procedure EditVehicle (
	@Id int,	
	@MakeID int, 
	@ModelID int, 
	@TypeID int, 
	@BodyID int,
	@TransmissionID int,
	@ColorID int,
	@InteriorID int,
	@Year int,
	@Mileage int,
	@vinNumber nvarchar(17),
	@Msrp decimal,
	@SalePrice decimal,
	@Description nvarchar(500),
	@Picture nvarchar(260),
	@Featured bit)
as

update Vehicle
set make_ID = @MakeID, model_ID = @ModelID, [type_ID] = @TypeID, body_ID = @BodyID,
	transmission_ID = @TransmissionID, color_ID = @ColorID, interior_ID = @InteriorID, 
	[year] = @Year,
    mileage = @Mileage, vinNumber = @vinNumber, msrp = @Msrp, salePrice = @SalePrice,
	[description] = @Description, picture = @Picture, featured = @Featured
where vehicle_ID = @Id

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DeleteVehicle'
	)
	begin
	drop procedure DeleteVehicle
	end
go

create procedure DeleteVehicle (
	@Id int
	)
	as

	delete from Vehicle where vehicle_ID = @Id

go

/*if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AddUser'
	)
	begin
	drop procedure AddUser
	end
go

create procedure AddUser(
	
	@FirstName nvarchar(30),
	@LastName nvarchar(40),
	@email nvarchar(254)
	)

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetUsers'
	)
	begin
	drop procedure GetUsers
	end
go

create procedure GetUsers
as

select *
from [User]
go

create procedure EditUser

go

create procedure DeleteUser

go*/


if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AddMake'
	)
	begin
	drop procedure AddMake
	end
go

create procedure AddMake(
	@Make nvarchar(17),
	@AddedBy nvarchar(254)
	)
as

insert into Make(make, dateAdded, addedBy)
values(@Make, GETDATE(), @AddedBy)


go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AddModel'
	)
	begin
	drop procedure AddModel
	end
go

create procedure AddModel(
	@Model nvarchar(17),
	@AddedBy nvarchar(254),
	@Make int
	)
as

	insert into Model(model, dateAdded, addedBy, make_ID)
	values(@Model, GETDATE(), @AddedBy, @Make)

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetCarType'
	)
	begin
	drop procedure GetCarType
	end
go

create procedure GetCarType
as

select *
from CarType

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetBodyStyle'
	)
	begin
	drop procedure GetBodyStyle
	end
go

create procedure GetBodyStyle
as

select *
from BodyStyle

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetTransmission'
	)
	begin
	drop procedure GetTransmission
	end
go

create procedure GetTransmission
as

select *
from Transmission

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetColor'
	)
	begin
	drop procedure GetColor
	end
go

create procedure GetColor
as

select *
from CarColor
go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetInterior'
	)
	begin
	drop procedure GetInterior
	end
go

create procedure GetInterior
as

select * 
from Interior

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetModel'
	)
	begin
	drop procedure GetModel
	end
go

create procedure GetModel(
	@MakeID int
	)
as 

select * from Model
where make_ID = @MakeID

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetAllMakesModels'
	)
	begin
	drop procedure GetAllMakesModels
	end
go

create procedure GetAllMakesModels
as

select Make.make, model, Model.dateAdded, Model.addedBy
from Model
inner join Make on Model.make_ID = Make.make_ID
order by Make.make, model

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetMake'
	)
	begin
	drop procedure GetMake
	end
go

create procedure GetMake
as

select *
from Make

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetFileNumber'
	)
	begin
	drop procedure GetFileNumber
	end
go

create procedure GetFileNumber
as

select max(vehicle_ID) from Vehicle

go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetInventoryReportNew'
	)
	begin
	drop procedure GetInventoryReportNew
	end
go

create procedure GetInventoryReportNew
as
	select [year], make, model, count(*) as InventoryCount, sum(msrp) as [Stock Value]
	from Vehicle
	inner join Make on Vehicle.make_ID = Make.make_ID
	inner join Model on Vehicle.model_ID = Model.model_ID
	where [type_ID] = 1 and sale_ID is null
	group by [year], make, model
go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetInventoryReportUsed'
	)
	begin
	drop procedure GetInventoryReportUsed
	end
go

create procedure GetInventoryReportUsed
as
	select [year], make, model, count(*) as InventoryCount, sum(msrp) as [Stock Value]
	from Vehicle
	inner join Make on Vehicle.make_ID = Make.make_ID
	inner join Model on Vehicle.model_ID = Model.model_ID
	where [type_ID] = 2 and sale_ID is null
	group by [year], make, model
go

if exists ( select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'SalesReport'
	)
	begin
	drop procedure SalesReport
	end
go

create procedure SalesReport(
	@userEmail nvarchar(254),
	@fromDate datetime2,
	@toDate datetime2
	)
as

select firstName, lastName, count(s.userAdded) as VehiclesSold, sum(s.purchasePrice) as TotalSales 
from AspNetUsers as asp
inner join AspNetUserRoles on asp.Id = AspNetUserRoles.UserId
inner join AspNetRoles on AspNetUserRoles.RoleId = AspNetRoles.Id
left outer join SalesData as s on asp.Email = s.userAdded
where asp.Email like '%' + @userEmail + '%' 
	and AspNetRoles.Name = 'Sales' 
	and s.purchaseDate > @fromDate 
	and s.purchaseDate < @toDate
group by firstName, lastName
	
go
-- reports? 