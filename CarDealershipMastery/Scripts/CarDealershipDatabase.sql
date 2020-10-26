USE CarDealership
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='InventoryReport')
DROP TABLE InventoryReport
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Specials')
DROP TABLE Specials
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='SalesInfo')
DROP TABLE SalesInfo
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Contact')
DROP TABLE Contact
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='CarType')
DROP TABLE CarType
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Car')
DROP TABLE Car
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='CarNewOrUsedType')
DROP TABLE CarNewOrUsedType
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='BodyStyle')
DROP TABLE BodyStyle
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Color')
DROP TABLE Color
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Transmission')
DROP TABLE Transmission
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Model')
DROP TABLE Model
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Make')
DROP TABLE Make
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Interior')
DROP TABLE Interior
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='PurchaseType')
DROP TABLE PurchaseType
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='State')
DROP TABLE [State]
GO



CREATE TABLE [State](
	StateId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	StateName varchar(10) NOT NULL
)
GO

CREATE TABLE PurchaseType(
	PurchaseTypeId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	PurchaseType varchar(30) NOT NULL
)
GO

CREATE TABLE Interior(
	InteriorId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	InteriorColor varchar(10) NOT NULL
)
GO

CREATE TABLE Make(
	MakeId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	MakeType varchar(10) NOT NULL,
	CreatedDate datetime2 not null default(getdate())
)
GO

CREATE TABLE Model(
	ModelId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	ModelType varchar(10) NOT NULL,
	MakedId int NOT NULL FOREIGN KEY REFERENCES Make(MakeId),
	CreatedDate datetime2 not null default(getdate())
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

CREATE TABLE BodyStyle(
	BodyStyleId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Style nvarchar(10) NOT NULL
)
GO

CREATE TABLE CarNewOrUsedType(
	TypeId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	TypeName nvarchar(10) NOT NULL
)
GO

CREATE TABLE Car(
	CarId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	UserID nvarchar(128) NOT NULL,
	MakedId int NOT NULL FOREIGN KEY REFERENCES Make(MakeId),
	ModelId int NOT NULL FOREIGN KEY REFERENCES Model(ModelId),
	TypeId int NOT NULL FOREIGN KEY REFERENCES CarNewOrUsedType(TypeId),
	BodyStyleId int NOT NULL FOREIGN KEY REFERENCES BodyStyle(BodyStyleId),
	TransmissionId int NOT NULL FOREIGN KEY REFERENCES Transmission(TransmissionId),
	ColorId int NOT NULL FOREIGN KEY REFERENCES Color(ColorId),
	InteriorId int NOT NULL FOREIGN KEY REFERENCES Interior(InteriorId),
	[Year] varchar(4) NOT NULL,
	Milage varchar(30) NOT NULL,
	VIN int NOT NULL,
	MSRP int NOT NULL,
	SalePrice decimal NOT NULL,
	[Description] varchar(80) NOT NULL,
	UploadedPicture varchar(50),
	IsFeatured bit NOT NULL
)
GO

CREATE TABLE CarType(
	CarId int NOT NULL FOREIGN KEY REFERENCES Car(CarId),
	TypeId int NOT NULL FOREIGN KEY REFERENCES CarNewOrUsedType(TypeId),
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

CREATE TABLE SalesInfo(
	UserId nvarchar(128) NOT NULL,
	SalesInfoId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
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

CREATE TABLE Specials(
	SpecialsId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Title varchar(15) NOT NULL,
	[Description] varchar(250) NOT NULL
)
GO


CREATE TABLE InventoryReport(
	InventoryReportId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Year] int NOT NULL,
	MakedId int NOT NULL FOREIGN KEY REFERENCES Make(MakeId),
	ModelId int NOT NULL FOREIGN KEY REFERENCES Model(ModelId),
	[Count] int NOT NULL,
	StockValue int NOT NULL,
	isSold bit NOT NULL
)
GO

