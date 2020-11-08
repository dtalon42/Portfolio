use GuildCars
go

drop table if exists VehicleSpecial
go

drop table if exists VehicleUser
go

drop table if exists VehicleContact
go

drop table if exists UserRole
go

drop table if exists Vehicle
go

drop table if exists CarType
go

drop table if exists BodyStyle
go

drop table if exists Transmission
go

drop table if exists CarColor
go

drop table if exists Interior
go

drop table if exists SalesData
go

drop table if exists [State]
go

drop table if exists PurchaseType
go

drop table if exists Model
go

drop table if exists Make
go



drop table if exists Specials
go

drop table if exists [User]
go

drop table if exists [Role]
go

drop table if exists Contact
go

create table [State]
(
	state_ID int identity(1,1) primary key not null,
	[state] nvarchar(2) not null
)
go

create table PurchaseType
(
	purchaseType_ID int identity(1,1) primary key not null,
	purchaseType nvarchar(20) not null
)
go


create table SalesData
(
	sale_ID int identity(1,1) primary key not null,
	[name] nvarchar(50) not null,
	phone nvarchar(12) not null,
	email nvarchar(254) not null,
	street_1 nvarchar(95) not null,
	street_2 nvarchar(10) null,
	city nvarchar(17) not null,
	state_ID int references [State](state_ID) not null,
	zipCode nvarchar(5) not null,
	purchasePrice decimal not null,
	purchaseType_ID int foreign key references PurchaseType(purchaseType_ID) not null,
	purchaseDate datetime2 not null,
	userAdded nvarchar(254) not null -- added email for salesperson
)
go

create table Make
(
	make_ID int identity(1,1) primary key not null,
	make nvarchar(17) not null,
	dateAdded datetime2 not null,
	addedBy nvarchar(254) not null
)
go

create table Model
(
	model_ID int identity(1,1) primary key not null,
	model nvarchar(25) not null,
	dateAdded datetime2 not null,
	addedBy nvarchar(254) not null,
	make_ID int foreign key references Make(make_ID) not null

)
go

create table Specials
(
	special_ID int identity(1,1) primary key not null,
	[name] nvarchar(25) not null,
	[description] nvarchar(250) not null
)
go

create table [User]
(
	[user_ID] int identity(1,1) primary key not null,
	firstName nvarchar(30) not null,
	lastName nvarchar(40) not null,
	email nvarchar(254) not null,
	salt nvarchar(100) not null,
	[password] nvarchar(100) not null
)
go

create table [Role]
(
	role_ID int identity(1,1) primary key not null,
	roleName nvarchar(15) not null,
	dateAdded datetime2 not null,
	addedBy nvarchar(254) not null
)
go

create table Contact
(
	contact_ID int identity(1,1) primary key not null,
	[name] nvarchar(50) not null,
	email nvarchar(254) null,
	phoneNumber nvarchar(12) null,
	[description] nvarchar(250) not null
)
go


create table CarType
(
	[type_ID] int identity(1,1) primary key not null,
	carType nvarchar(20) not null
)
go

create table BodyStyle
(
	body_ID int identity(1,1) primary key not null,
	bodyStyle nvarchar(10) not null
)
go

create table Transmission
(
	transmission_ID int identity(1,1) primary key not null,
	transmission nvarchar(25) not null
)
go

create table CarColor
(
	color_ID int identity(1,1) primary key not null,
	color nvarchar(15) not null
)
go

create table Interior
(
	interior_ID int identity(1,1) primary key not null,
	interior nvarchar(15) not null
)
go

create table Vehicle
(
	vehicle_ID int identity(1,1) primary key not null,
	make_ID int foreign key references Make(make_ID) not null,
	model_ID int foreign key references Model(model_ID) not null,
	[type_ID] int foreign key references CarType([type_ID]) not null,
	body_ID int foreign key references BodyStyle(body_ID) not null,
	transmission_ID int foreign key references Transmission(transmission_ID) not null,
	color_ID int foreign key references CarColor(color_ID) not null,
	interior_ID int foreign key references Interior(interior_ID) not null,
	[year] int not null,
	mileage int not null,
	vinNumber nvarchar(17) not null,
	msrp decimal not null,
	salePrice decimal null,
	[description] nvarchar(500) null,
	picture nvarchar(260) null,
	featured bit not null,
	sale_ID int foreign key references SalesData(sale_ID)

)
go

create table VehicleSpecial
(
	vehicle_ID int not null,
	special_ID int not null,
	constraint PK_VehicleSpecial primary key(vehicle_ID, special_ID),
	constraint FK_Vehicle_VehicleSpecial foreign key (vehicle_ID) references Vehicle(vehicle_ID),
	constraint FK_Specials_VehicleSpecial foreign key(special_ID) references Specials(special_ID)
)
go

create table VehicleUser
(
	vehicle_ID int not null,
	[user_ID] int not null,
	constraint PK_VehicleUser primary key(vehicle_ID, [user_ID]),
	constraint FK_Vehicle_VehicleUser foreign key (vehicle_ID) references Vehicle(vehicle_ID),
	constraint FK_User_VehicleUser foreign key ([user_ID]) references [User]([user_ID])
)
go

create table UserRole
(
	[user_ID] int not null,
	role_ID int not null,
	constraint PK_UserRole primary key([user_ID], role_ID),
	constraint FK_User_UserRole foreign key ([user_ID]) references [User]([user_ID]),
	constraint FK_Role_UserRole foreign key (role_ID) references [Role](role_ID)
)
go

create table VehicleContact
(
	vehicle_ID int not null,
	contact_ID int not null,
	constraint PK_VehicleContact primary key(vehicle_ID, contact_ID),
	constraint FK_Vehicle_VehicleContact foreign key (vehicle_ID) references Vehicle(vehicle_ID),
	constraint FK_Contact_VehicleContact foreign key (contact_ID) references Contact(contact_ID)
)
go

