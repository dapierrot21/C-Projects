USE CarDealership
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name='Role')
DROP TABLE [Role]
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Specials')
DROP TABLE Specials
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Contact')
DROP TABLE Contact
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='SalesInfo')
DROP TABLE SalesInfo
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='PurchaseType')
DROP TABLE PurchaseType
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='State')
DROP TABLE [State]
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='CarDetails')
DROP TABLE CarDetails
GO

IF EXISTS(SELECT * FROM sys.table_types WHERE name='Interior')
DROP TABLE Interior
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Car')
DROP TABLE Car
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='CarNewOrUsedType')
DROP TABLE CarNewOrUsedType
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Color')
DROP TABLE Color
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Transmission')
DROP TABLE Transmission
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='BodyStyle')
DROP TABLE BodyStyle
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='MakeModel')
DROP TABLE MakeModel
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Make')
DROP TABLE Make
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Model')
DROP TABLE Model
GO













CREATE TABLE CarNewOrUsedType(
	TypeId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	TypeName nvarchar(10) NOT NULL
)
GO

CREATE TABLE BodyStyle(
	BodyStyleId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Style nvarchar(10) NOT NULL
)
GO

CREATE TABLE Transmission(
	TransmissionId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	TransmissionType nvarchar(10) NOT NULL
)
GO

CREATE TABLE Color(
	ColorId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	ColorName nvarchar(10) NOT NULL
)
GO	

CREATE TABLE Interior(
	InteriorId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	InteriorColor varchar(10) NOT NULL
)
GO

CREATE TABLE Make(
	MakeId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	UserId nvarchar(128) NOT NULL,
	MakeType varchar(10) NOT NULL,
	CreatedDate datetime2 not null default(getdate())
)
GO

CREATE TABLE Model(
	ModelId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	UserId nvarchar(128) NOT NULL,
	ModelType varchar(50) NOT NULL,
	CreatedDate datetime2 not null default(getdate())
)
GO

CREATE TABLE MakeModel(
	MakeId int NOT NULL FOREIGN KEY REFERENCES Make(MakeId),
	ModelId int NOT NULL FOREIGN KEY REFERENCES Model(ModelId)
)
GO


CREATE TABLE Car(
	CarId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	UserID nvarchar(128) NOT NULL,
	MakeId int NOT NULL FOREIGN KEY REFERENCES Make(MakeId),
	ModelId int NOT NULL FOREIGN KEY REFERENCES Model(ModelId),
	TypeId int NOT NULL FOREIGN KEY REFERENCES CarNewOrUsedType(TypeId),
	BodyStyleId int NOT NULL FOREIGN KEY REFERENCES BodyStyle(BodyStyleId),
	TransmissionId int NOT NULL FOREIGN KEY REFERENCES Transmission(TransmissionId),
	ColorId int NOT NULL FOREIGN KEY REFERENCES Color(ColorId),
	InteriorId int NOT NULL FOREIGN KEY REFERENCES Interior(InteriorId),
	[Year] varchar(4) NOT NULL,
	Milage varchar(30) NOT NULL,
	VIN varchar(17) NOT NULL,
	MSRP decimal NOT NULL,
	SalePrice decimal NOT NULL,
	[Description] varchar(180) NOT NULL,
	UploadedPicture varchar(50),
	IsFeatured bit NOT NULL
)
GO

CREATE TABLE CarDetails (
	CarId int NOT NULL FOREIGN KEY REFERENCES Car(CarId),
	[Year] varchar(4) NOT NULL,
	MakeType varchar(10) NOT NULL,
	ModelType varchar(50) NOT NULL,
	Style nvarchar(10) NOT NULL,
	TransmissionType nvarchar(10) NOT NULL,
	ColorName nvarchar(10) NOT NULL,
	InteriorColor varchar(10) NOT NULL,
	Milage varchar(30) NOT NULL,
	VIN varchar(17) NOT NULL,
	SalePrice decimal(18,0) NOT NULL,
	MSRP decimal(18,0) NOT NULL,
	[Description] varchar(180) NOT NULL,
	UploadedPicture varchar(50) NOT NULL
)
GO


CREATE TABLE [State](
	StateId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	StateName varchar(10) NOT NULL
)
GO

CREATE TABLE PurchaseType(
	PurchaseTypeId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	PurchaseTypeInfo varchar(30) NOT NULL
)
GO


CREATE TABLE SalesInfo(
	SalesInfoId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	UserId nvarchar(128) NOT NULL,
	CarId int NOT NULL,
	[Name] varchar(50) NOT NULL,
	Email varchar(320) NOT NULL,
	Street1 varchar(25) NOT NULL,
	Street2 varchar(25) NOT NULL,
	City varchar(15) NOT NULL,
	StateId int  NOT NULL FOREIGN KEY REFERENCES [State](StateId),
	ZipCode int NOT NULL,
	PurchasePrice decimal NOT NULL,
	PurchaseTypeId int NOT NULL FOREIGN KEY REFERENCES PurchaseType(PurchaseTypeId)
)
GO

CREATE TABLE Contact(
	ContactId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] varchar(30) NOT NULL,
	Email varchar(320) NOT NULL,
	Phone varchar(15) NOT NULL,
	[Message] varchar(250) NOT NULL
)
GO

CREATE TABLE Specials(
	SpecialsId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Title varchar(150) NOT NULL,
	[Description] varchar(250) NOT NULL,
	CreatedDate datetime2 not null default(getdate())
)
GO

CREATE TABLE [Role](
	RoleId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	UserId nvarchar(128) NOT NULL,
	RoleTitle varchar(30) NOT NULL
)
GO



