USE MASTER
GO

DROP DATABASE IF EXISTS HotelReservation;

IF NOT EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'HotelReservation'
)
CREATE DATABASE [HotelReservation]
GO

USE HotelReservation
GO


CREATE TABLE PromotionCode(
 PromotionCodeID INT IDENTITY(1,1) PRIMARY KEY,
 CodeType VARCHAR(30) NOT NULL,
 StartTime datetime2 NOT NULL,
 EndDate datetime2 NOT NULL,
 CodeDiscount decimal NOT NULL
)
GO


CREATE TABLE Reservation(
 ReservationID INT IDENTITY(1,1) PRIMARY KEY,
 Adults INT NOT NULL,
 Children INT NULL,
 StartDate datetime2 NOT NULL,
 EndDate datetime2 NOT NULL,
 PromotionCodeID INT FOREIGN KEY REFERENCES PromotionCode(PromotionCodeID) NULL
 )
GO

CREATE TABLE Billing(
 BillingID INT IDENTITY(1,1) PRIMARY KEY,
 ReservationID INT FOREIGN KEY REFERENCES Reservation(ReservationID),
 RoomTotal decimal NOT NULL,
 AddOnTotal decimal NOT NULL,
 TaxTotal decimal NOT NULL,
 Discount decimal NOT NULL,
 GrandTotal decimal NOT NULL
 )
GO

CREATE TABLE Guest(
 GuestID INT IDENTITY(1,1) PRIMARY KEY,
 ReservationID INT FOREIGN KEY REFERENCES Reservation(ReservationID),
 FirstName VARCHAR(30) NOT NULL,
 LastName VARCHAR(30) NOT NULL,
 Phone VARCHAR(30) NOT NULL,
 Email VARCHAR(30) NOT NULL
 )
GO

CREATE TABLE AddOn(
 AddOnID INT IDENTITY(1,1) PRIMARY KEY,
 AddOnItem VARCHAR(30) NOT NULL
)
GO

CREATE TABLE ReservationAddOns(
 ReservationID INT NOT NULL,
 AddOnID INT NOT NULL,
 CONSTRAINT PK_ReservationAddOns
	PRIMARY KEY(ReservationID, AddOnID),
 CONSTRAINT FK_Reservation_ReservationAddOns
	FOREIGN KEY(ReservationID)
	REFERENCES Reservation(ReservationID),
 CONSTRAINT FK_AddOn_ReservationAddOns
	FOREIGN KEY(AddOnID)
	REFERENCES AddOn (AddOnID),
)
GO

CREATE TABLE RoomRate(
 RoomTypeRateID INT IDENTITY(1,1) PRIMARY KEY,
 StartDate datetime2 NOT NULL,
 EndDate datetime2 NOT NULL,
 CostPerNight decimal NOT NULL
)
GO

CREATE TABLE RoomType(
 RoomTypeID INT IDENTITY(1,1) PRIMARY KEY,
 [Type] VARCHAR(30) NOT NULL,
 RoomTypeRateID INT FOREIGN KEY REFERENCES RoomRate(RoomTypeRateID)
)
GO

CREATE TABLE Room(
 RoomID INT IDENTITY(1,1) PRIMARY KEY,
 FloorNumber INT NOT NULL,
 [Description] VARCHAR(30) NOT NULL,
 RoomType INT FOREIGN KEY REFERENCES RoomType(RoomTypeID) NOT NULL
)
GO

CREATE TABLE RoomReserved(
 RoomID INT NOT NULL,
 ReservationID INT NOT NULL,
 CONSTRAINT PK_RoomReserved
	PRIMARY KEY(RoomID, ReservationID),
 CONSTRAINT FK_Room_RoomReserved
	FOREIGN KEY(RoomID)
	REFERENCES Room(RoomID),
 CONSTRAINT FK_Reservation_RoomReserved
	FOREIGN KEY(ReservationID)
	REFERENCES Reservation(ReservationID),
)
GO

CREATE TABLE Amenities(
 AmenitiesID INT IDENTITY(1,1) PRIMARY KEY,
 [Type] VARCHAR(30) NOT NULL
)
GO

CREATE TABLE RoomAmenities(
 RoomID INT NOT NULL,
 AmenitiesID INT NOT NULL,
 CONSTRAINT PK_RoomAmenities
	PRIMARY KEY(RoomID, AmenitiesID),
 CONSTRAINT FK_Room_RoomAmenities
	FOREIGN KEY(RoomID)
	REFERENCES Room(RoomID),
 CONSTRAINT FK_Amentities_RoomAmenities
	FOREIGN KEY(AmenitiesID)
	REFERENCES Amenities(AmenitiesID),
)
GO
