 

-- State Procedures --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectAllStates')
		DROP PROCEDURE SelectAllStates
GO

CREATE PROCEDURE SelectAllStates AS
BEGIN
	SELECT StateId, StateName
	FROM [State]
END


-- Color Procedures --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectAllColors')
		DROP PROCEDURE SelectAllColors
GO

CREATE PROCEDURE SelectAllColors AS
BEGIN
	SELECT ColorId, ColorName
	FROM Color
END

GO


-- New Or Used Procedures --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectAllNewOrUsed')
		DROP PROCEDURE SelectAllNewOrUsed
GO

CREATE PROCEDURE SelectAllNewOrUsed AS
BEGIN
	SELECT TypeId, TypeName
	FROM CarNewOrUsedType
END

GO


-- Body Style Procedures --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectAllBodyStyle')
		DROP PROCEDURE SelectAllBodyStyle
GO

CREATE PROCEDURE SelectAllBodyStyle AS
BEGIN
	SELECT BodyStyleId, Style
	FROM BodyStyle
END

GO

-- Contact Procedures --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectAllContacts')
		DROP PROCEDURE SelectAllContacts
GO

CREATE PROCEDURE SelectAllContacts AS
BEGIN
	SELECT ContactId, [Name], Email, Phone, [Message]
	FROM Contact
END

GO

-- Interior Procedures --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectAllInteriors')
		DROP PROCEDURE SelectAllInteriors
GO

CREATE PROCEDURE SelectAllInteriors AS
BEGIN
	SELECT InteriorId, InteriorColor
	FROM Interior
END

GO


-- Make Procedures --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectAllMakes')
		DROP PROCEDURE SelectAllMakes
GO

CREATE PROCEDURE SelectAllMakes AS
BEGIN
	SELECT MakeId, MakeType, CreatedDate
	FROM Make
END

GO

-- MakeModel Prodcedures --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectAllMakeModels')
		DROP PROCEDURE SelectAllMakeModels
GO

CREATE PROCEDURE SelectAllMakeModels AS
BEGIN
	SELECT MakeId, ModelId
	FROM MakeModel
END

GO

-- Model Procedures --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectAllModels')
		DROP PROCEDURE SelectAllModels
GO

CREATE PROCEDURE SelectAllModels AS
BEGIN
	SELECT ModelId, ModelType, CreatedDate
	FROM Model
END

GO

-- PurchaseType Procedures --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectAllPurchaseTypes')
		DROP PROCEDURE SelectAllPurchaseTypes
GO

CREATE PROCEDURE SelectAllPurchaseTypes AS
BEGIN
	SELECT PurchaseTypeId, PurchaseTypeInfo
	FROM PurchaseType
END

GO

-- Specials Procedures --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectAllSpecials')
		DROP PROCEDURE SelectAllSpecials
GO

CREATE PROCEDURE SelectAllSpecials AS
BEGIN
	SELECT SpecialsId, Title, [Description]
	FROM Specials
END

GO

-- Transmission Procedures --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectAllTransmission')
		DROP PROCEDURE SelectAllTransmission
GO

CREATE PROCEDURE SelectAllTransmission AS
BEGIN
	SELECT TransmissionId, TransmissionType
	FROM Transmission
END

GO

-- Car Procedures --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectAllCars')
		DROP PROCEDURE SelectAllCars
GO

CREATE PROCEDURE SelectAllCars AS
BEGIN
	SELECT CarId, UserID, MakeId, ModelId, TypeId, BodyStyleId, TransmissionId, ColorId, InteriorId, [Year], Milage,
	VIN, MSRP, SalePrice, [Description], UploadedPicture, IsFeatured
	FROM Car
END

GO

-- CarType Procedures --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectAllCarTypes')
		DROP PROCEDURE SelectAllCarTypes
GO


CREATE PROCEDURE SelectAllCarTypes AS
BEGIN
	SELECT CarId, TypeId
	FROM CarType
END

GO

-- InventoryReport Procedures --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectAllInventoryReports')
		DROP PROCEDURE SelectAllInventoryReports
GO


CREATE PROCEDURE SelectAllInventoryReports AS
BEGIN
	SELECT InventoryReportId, [Year], MakeId, ModelId, [Count], StockValue, isSold
	FROM InventoryReport
END

GO

-- SalesInfo Procedures --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectAllSalesInfo')
		DROP PROCEDURE SelectAllSalesInfo
GO


CREATE PROCEDURE SelectAllSalesInfo AS
BEGIN
	SELECT UserId, SalesInfoId, [Name], Email, Street1, Street2, City, StateId, ZipCode, PurchasePrice, PurchaseTypeId
	FROM SalesInfo
END

GO

-- Role Procedure --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectAllRoles')
		DROP PROCEDURE SelectAllRoles
GO


CREATE PROCEDURE SelectAllRoles AS
BEGIN
	SELECT RoleId, RoleTitle
	FROM [Role]
END

GO




