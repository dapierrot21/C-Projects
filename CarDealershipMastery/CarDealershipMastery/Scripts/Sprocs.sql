USE CarDealership
GO

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
GO


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
	WHERE ROUTINE_NAME = 'ContactSelect')
		DROP PROCEDURE ContactSelect
GO

CREATE PROCEDURE ContactSelect(
	@ContactId int
)AS
BEGIN
	SELECT ContactId, [Name], Email, Phone, [Message]
	FROM Contact
	WHERE ContactId = @ContactId
END

GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ContactInsert')
		DROP PROCEDURE ContactInsert
GO

CREATE PROCEDURE ContactInsert (
	@ContactId int output,
	@Name varchar(50),
	@Email varchar(320),
	@Phone varchar(15),
	@Message varchar(250)
) AS
BEGIN
	INSERT INTO Contact([Name], Email, Phone, [Message])
	VALUES (@Name, @Email, @Phone, @Message);

	-- Returns the last id identity that was created --
	SET @ContactId = SCOPE_IDENTITY();
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ContactUpdate')
		DROP PROCEDURE ContactUpdate
GO

CREATE PROCEDURE ContactUpdate (
	@ContactId int,
	@Name varchar(50),
	@Email varchar(320),
	@Phone varchar(15),
	@Message varchar(250)
) AS
BEGIN
	UPDATE Contact SET
		[Name] = @Name, 
		Email = @Email, 
		Phone = @Phone,
		[Message] = @Message
	
	WHERE ContactId = @ContactId

END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ContactDelete')
		DROP PROCEDURE ContactDelete
GO

CREATE PROCEDURE ContactDelete (
	@ContactId int
) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Contact WHERE @ContactId = ContactId;

	COMMIT TRANSACTION
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
	WHERE ROUTINE_NAME = 'MakeSelect')
		DROP PROCEDURE MakeSelect
GO

CREATE PROCEDURE MakeSelect (
	@MakeId int
)AS
BEGIN
	SELECT MakeId, UserId, MakeType, CreatedDate
	FROM Make
	WHERE MakeId = @MakeId
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakeInsert')
		DROP PROCEDURE MakeInsert
GO

CREATE PROCEDURE MakeInsert (
	@MakeId int output,
	@UserId nvarchar(128),
	@MakeType varchar(10)
) AS
BEGIN
	INSERT INTO Make(UserId, MakeType)
	VALUES (@UserId, @MakeType);

	-- Returns the last id identity that was created --
	SET @MakeId = SCOPE_IDENTITY();
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakeUpdate')
		DROP PROCEDURE MakeUpdate
GO

CREATE PROCEDURE MakeUpdate (
	@MakeId int,
	@UserId nvarchar(128),
	@MakeType varchar(10)
) AS
BEGIN
	UPDATE Make SET
		UserId = @UserId,
		MakeType = @MakeType

	WHERE MakeId = @MakeId

END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakeDelete')
		DROP PROCEDURE MakeDelete
GO

CREATE PROCEDURE MakeDelete (
	@MakeId int
) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Make WHERE @MakeId = MakeId;

	COMMIT TRANSACTION
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
	WHERE ROUTINE_NAME = 'ModelsSelect')
		DROP PROCEDURE ModelsSelect
GO

CREATE PROCEDURE ModelsSelect(
	@ModelId int
)AS
BEGIN
	SELECT ModelId, UserId, ModelType, CreatedDate
	FROM Model
	WHERE ModelId = @ModelId
END

GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelInsert')
		DROP PROCEDURE ModelInsert
GO

CREATE PROCEDURE ModelInsert (
	@ModelId int output,
	@UserId nvarchar(128),
	@ModelType varchar(50)
) AS
BEGIN
	INSERT INTO Model(UserId, ModelType)
	VALUES (@UserId, @ModelType);

	-- Returns the last id identity that was created --
	SET @ModelId = SCOPE_IDENTITY();
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelUpdate')
		DROP PROCEDURE ModelUpdate
GO

CREATE PROCEDURE ModelUpdate (
	@ModelId int,
	@UserId nvarchar(128),
	@ModelType varchar(50)
) AS
BEGIN
	UPDATE Model SET
		UserId = @UserId,
		ModelType = @ModelType

	WHERE ModelId = @ModelId

END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelDelete')
		DROP PROCEDURE ModelDelete
GO

CREATE PROCEDURE ModelDelete (
	@ModelId int
) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Model WHERE @ModelId = ModelId;

	COMMIT TRANSACTION
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
	WHERE ROUTINE_NAME = 'SpecialsSelect')
		DROP PROCEDURE SpecialsSelect
GO

CREATE PROCEDURE SpecialsSelect (
	@SpecialsId int
)AS
BEGIN
	SELECT SpecialsId, Title, [Description]
	FROM Specials
	WHERE SpecialsId = @SpecialsId
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsInsert')
		DROP PROCEDURE SpecialsInsert
GO

CREATE PROCEDURE SpecialsInsert (
	@SpecialsId int output,
	@Title varchar(150),
	@Description varchar(320)
)AS
BEGIN
	INSERT INTO Specials(Title, [Description])
	VALUES (@Title, @Description);

	-- Returns the last id identity that was created --
	SET @SpecialsId = SCOPE_IDENTITY();
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsUpdate')
		DROP PROCEDURE SpecialsUpdate
GO

CREATE PROCEDURE SpecialsUpdate (
	@SpecialsId int,
	@Title varchar(150),
	@Description varchar(320)
) AS
BEGIN
	UPDATE Specials SET
		Title = @Title,
		[Description] = @Description

	
	WHERE SpecialsId = @SpecialsId

END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsDelete')
		DROP PROCEDURE SpecialsDelete
GO

CREATE PROCEDURE SpecialsDelete (
	@SpecialsId int
) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Specials WHERE @SpecialsId = SpecialsId;

	COMMIT TRANSACTION
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

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsSelectRecent')
		DROP PROCEDURE SpecialsSelectRecent
GO

CREATE PROCEDURE SpecialsSelectRecent AS
BEGIN
	SELECT SpecialsId, Title, [Description]
	FROM Specials
	ORDER BY CreatedDate
END
GO

-- Car Procedures --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarSelect')
		DROP PROCEDURE CarSelect
GO

CREATE PROCEDURE CarSelect(
	@CarId int
)AS
BEGIN
	SELECT CarId, UserID, MakeId, ModelId, TypeId, BodyStyleId, TransmissionId, ColorId, InteriorId, [Year], Milage,
	VIN, MSRP, SalePrice, [Description], UploadedPicture, IsFeatured
	FROM Car
	WHERE CarId = @CarId
END

GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarInsert')
		DROP PROCEDURE CarInsert
GO

CREATE PROCEDURE CarInsert (
	@CarId int output,
	@UserId nvarchar(128),
	@MakeId int,
	@ModelId int,
	@TypeId int,
	@BodyStyleId int,
	@TransmissionId int,
	@ColorId int,
	@InteriorId int,
	@Year varchar(4),
	@Milage varchar(30),
	@VIN varchar(17),
	@MSRP int,
	@SalePrice decimal(18,0),
	@Description varchar(80),
	@UploadedPicture varchar(50),
	@IsFeatured bit
) AS
BEGIN
	INSERT INTO Car(UserID, MakeId, ModelId, TypeId, BodyStyleId, TransmissionId, ColorId, InteriorId, [Year],
	Milage, VIN, MSRP, SalePrice, [Description], UploadedPicture, IsFeatured)
	VALUES (@UserId, @MakeId, @ModelId, @TypeId, @BodyStyleId, @TransmissionId, @ColorId, @InteriorId, @Year, @Milage, @VIN,
	@MSRP, @SalePrice, @Description, @UploadedPicture, @IsFeatured);

	-- Returns the last id identity that was created --
	SET @CarId = SCOPE_IDENTITY();
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarUpdate')
		DROP PROCEDURE CarUpdate
GO

CREATE PROCEDURE CarUpdate (
	@CarId int,
	@UserId nvarchar(128),
	@MakeId int,
	@ModelId int,
	@TypeId int,
	@BodyStyleId int,
	@TransmissionId int,
	@ColorId int,
	@InteriorId int,
	@Year varchar(4),
	@Milage varchar(30),
	@VIN varchar(17),
	@MSRP int,
	@SalePrice decimal(18,0),
	@Description varchar(80),
	@UploadedPicture varchar(50),
	@IsFeatured bit
) AS
BEGIN
	UPDATE Car SET
		UserID = @UserId, 
		MakeId = @MakeId, 
		ModelId = @ModelId, 
		TypeId = @TypeId, 
		BodyStyleId = @BodyStyleId, 
		TransmissionId = @TransmissionId, 
		ColorId = @ColorId, 
		InteriorId = @InteriorId, 
		[Year] = @Year,
		Milage = @Milage, 
		VIN = @VIN, 
		MSRP = @MSRP, 
		SalePrice = @SalePrice, 
		[Description] = @Description, 
		UploadedPicture = @UploadedPicture, 
		IsFeatured = @IsFeatured
	
	WHERE CarId = @CarId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarDelete')
		DROP PROCEDURE CarDelete
GO

CREATE PROCEDURE CarDelete (
	@CarId int
) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Car WHERE CarId = @CarId;

	COMMIT TRANSACTION
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarSelectRecent')
		DROP PROCEDURE CarSelectRecent
GO

CREATE PROCEDURE CarSelectRecent AS
BEGIN
	SELECT TOP 8 CarId, UserId, [Year], MakeId, ModelId, SalePrice, UploadedPicture
	FROM Car
	WHERE IsFeatured = 1
	ORDER BY [Year] ASC
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarSelectDetails')
		DROP PROCEDURE CarSelectDetails
GO

CREATE PROCEDURE CarSelectDetails (
	@CarId int
)AS
BEGIN
	SELECT CarId, c.UserId, [Year], c.MakeId, c.ModelId, c.BodyStyleId, c.TransmissionId, c.ColorId, c.InteriorId, Milage, 
	VIN, SalePrice, MSRP, [Description], UploadedPicture
	FROM Car c
		INNER JOIN Make ma ON c.MakeId = ma.MakeId
		INNER JOIN Model mo ON c.ModelId = mo.ModelId
		INNER JOIN BodyStyle bs ON c.BodyStyleId = bs.BodyStyleId
		INNER JOIN Transmission t ON c.TransmissionId = t.TransmissionId
		INNER JOIN Color co ON c.ColorId = co.ColorId
		INNER JOIN Interior i ON c.InteriorId = i.InteriorId
	WHERE CarId = @CarId
END

GO

-- SalesInfo Procedures --
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SalesInfoSelect')
		DROP PROCEDURE SalesInfoSelect
GO

CREATE PROCEDURE SalesInfoSelect(
	@SalesInfoId int
)AS
BEGIN
	SELECT UserId, CarId, SalesInfoId, [Name], Email, Street1, Street2, City, StateId, ZipCode, PurchasePrice, PurchaseTypeId
	FROM SalesInfo
	WHERE SalesInfoId = @SalesInfoId
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SalesInfoInsert')
		DROP PROCEDURE SalesInfoInsert
GO

CREATE PROCEDURE SalesInfoInsert (
	@SalesInfoId int output,
	@CarId int,
	@UserId nvarchar(128),
	@Name varchar(50),
	@Email varchar(320),
	@Street1 varchar(25),
	@Street2 varchar(25),
	@City varchar(15),
	@StateId int,
	@ZipCode int,
	@PurchasePrice decimal(18,0),
	@PurchaseTypeId int
)AS
BEGIN
	INSERT INTO SalesInfo(UserId, CarId, [Name], Email, Street1, Street2, City, StateId, ZipCode, PurchasePrice,
	PurchaseTypeId)
	VALUES (@UserId, @CarId, @Name, @Email, @Street1, @Street2, @City, @StateId, @ZipCode, @PurchasePrice, @PurchaseTypeId);

	-- Returns the last id identity that was created --
	SET @SalesInfoId = SCOPE_IDENTITY();
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SalesInfoUpdate')
		DROP PROCEDURE SalesInfoUpdate
GO

CREATE PROCEDURE SalesInfoUpdate (
	@SalesInfoId int,
	@UserId nvarchar(128),
	@CarId int,
	@Name varchar(50),
	@Email varchar(320),
	@Street1 varchar(25),
	@Street2 varchar(25),
	@City varchar(15),
	@StateId int,
	@ZipCode int,
	@PurchasePrice decimal(18,0),
	@PurchaseTypeId int
) AS
BEGIN
	UPDATE SalesInfo SET
		UserId = @UserId,
		CarId = @CarId,
		[Name] = @Name, 
		Email = @Email, 
		Street1 = @Street1, 
		Street2 = @Street2, 
		City = @City, 
		StateId = @StateId, 
		ZipCode = @ZipCode, 
		PurchasePrice = @PurchasePrice,
		PurchaseTypeId = @PurchaseTypeId
	
	WHERE SalesInfoId = @SalesInfoId

END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SalesInfoDelete')
		DROP PROCEDURE SalesInfoDelete
GO

CREATE PROCEDURE SalesInfoDelete (
	@SalesInfoId int
) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM SalesInfo WHERE @SalesInfoId = SalesInfoId;

	COMMIT TRANSACTION
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