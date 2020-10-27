IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DbReset')
		DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
BEGIN
	DELETE FROM [State];
	DELETE FROM Color;
	DELETE FROM BodyStyle;
	DELETE FROM CarNewOrUsedType;
	DELETE FROM Contact;
	DELETE FROM Interior;
	DELETE FROM Make;
	DELETE FROM MakeModel;
	DELETE FROM Model;
	DELETE FROM PurchaseType;
	DELETE FROM Specials;
	DELETE FROM Transmission;
	DELETE FROM Car;
	DELETE FROM CarType;
	DELETE FROM InventoryReport;
	DELETE FROM [Role];
	DELETE FROM AspNetUsers WHERE id = '00000000-0000-0000-0000-000000000000';
	

	-- State --
	SET IDENTITY_INSERT [State] ON;

	INSERT INTO [State](StateId, StateName)
	VALUES(1, 'Ohio'),
	(2, 'Kentucky'),
	(3, 'Minnesota'); 

	SET IDENTITY_INSERT [State] OFF;

	-- Color --
	SET IDENTITY_INSERT Color ON;

	INSERT INTO Color(ColorId, ColorName)
	VALUES(1, 'Red'),
	(2, 'Blue'),
	(3, 'Black'),
	(4, 'White'),
	(5, 'Silver');

	SET IDENTITY_INSERT Color OFF;

	-- BodyStyle --
	SET IDENTITY_INSERT BodyStyle ON;
	
	INSERT INTO BodyStyle(BodyStyleId, Style)
	VALUES(1, 'Car'),
	(2, 'Van'),
	(3, 'Truck');

	SET IDENTITY_INSERT BodyStyle OFF;


	-- CarNewOrUsedType --
	SET IDENTITY_INSERT CarNewOrUsedType ON;

	INSERT INTO CarNewOrUsedType(TypeId, TypeName)
	VALUES(1, 'New'),
	(2, 'Used');

	SET IDENTITY_INSERT CarNewOrUsedType OFF;

	-- Contact --
	SET IDENTITY_INSERT Contact ON;

	INSERT INTO Contact(ContactId, [Name], Email, Phone, [Message])
	VALUES(1, 'Dean Pierrot', 'dapierrot21@gmail.com', '111-111-1111', 'Will like to buy a brand new telsa!'),
	(2, 'Nipsey Hussle', 'tmc@gmail.com', '222-222-2222', 'Let me buy the whole please!!!'),
	(3, 'Tobe Nwigwe', 'tryJesus@gmail.com', '333-333-3333', 'Hey I found the car I want.');

	SET IDENTITY_INSERT Contact OFF;

	-- Interior --
	SET IDENTITY_INSERT Interior ON;

	INSERT INTO Interior(InteriorId, InteriorColor)
	VALUES(1, 'Tan'),
	(2, 'Black');

	SET IDENTITY_INSERT Interior OFF;

	-- Make --
	SET IDENTITY_INSERT Make ON;
	INSERT INTO Make(MakeId, MakeType, CreatedDate)
	VALUES(1, 'Ram', ' '),
	(2, 'F-150', ' '),
	(3, 'Model S', ' ');

	SET IDENTITY_INSERT Make OFF;

	-- MakeModel --
	INSERT INTO MakeModel(MakeId, ModelId)
	VALUES(1, 1),
	(2, 2),
	(3, 3);

	-- Model -- 
	SET IDENTITY_INSERT Model ON;
	INSERT INTO Model(ModelId, ModelType, CreatedDate)
	VALUES(1, 'Dodge', ' '),
	(2, 'Ford', ' '),
	(3, 'Tesla', ' ');

	SET IDENTITY_INSERT Model OFF;


	-- PurchaseType --
	SET IDENTITY_INSERT PurchaseType ON;
	INSERT INTO PurchaseType(PurchaseTypeId, PurchaseTypeInfo)
	VALUES(1, 'Dealer Finance'),
	(2, 'Cash Payment'),
	(3, 'Bank Loan');

	SET IDENTITY_INSERT PurchaseType OFF;

	-- Specials --
	SET IDENTITY_INSERT Specials ON;
	INSERT INTO Specials(SpecialsId, Title, [Description])
	VALUES(1, 'Spring Break Deals', '25% off any car for students'),
	(2, '4th of July Deals', '15% off and SUVs for veterans'),
	(3, 'Going out of Business Sale', '95% off all cars');

	SET IDENTITY_INSERT Specials OFF;

	-- Transmission --
	SET IDENTITY_INSERT Transmission ON;
	INSERT INTO Transmission(TransmissionId, TransmissionType)
	VALUES(1, 'Automatic'),
	(2, 'Manual');

	SET IDENTITY_INSERT Transmission OFF;

	-- Car --
	SET IDENTITY_INSERT Car ON;
	INSERT INTO Car(CarId, UserID, MakeId, ModelId, TypeId, BodyStyleId, TransmissionId, ColorId, InteriorId, [Year],
	Milage, VIN, MSRP, SalePrice, [Description], UploadedPicture, IsFeatured)
	VALUES(1, '00000000-0000-0000-0000-000000000000', 1, 1, 1, 1, 1, 2, 2, '2020', 'New', 1234545466, 150.00, 135.00, 'Brand New Car', 'Image file path', 0),
	(2, '00000000-0000-0000-0000-000000000000', 1, 1, 1, 1, 2, 2, 2, '2020', '15,000', 123454546679, 150.00, 125.00,'Brand New Car', 'Image file path', 1);

	SET IDENTITY_INSERT Car OFF;

	-- CarType --
	INSERT INTO CarType(CarId, TypeId)
	VALUES(1, 1),
	(2, 2);

	-- InventoryReport --
	SET IDENTITY_INSERT InventoryReport ON;
	INSERT INTO InventoryReport(InventoryReportId, [Year], MakeId, ModelId, [Count], StockValue, isSold)
	VALUES(1, '2019', 1, 3, 4, 15000.00, 1),
	(2, '1995', 1, 1, 10, 16000.00, 0);

	SET IDENTITY_INSERT InventoryReport OFF;

	-- SalesInfo --
	SET IDENTITY_INSERT SalesInfo ON;
	INSERT INTO SalesInfo(SalesInfoId, UserId, [Name], Email, Street1, Street2, City, StateId, ZipCode, PurchasePrice,
	PurchaseTypeId)
	VALUES( 1, 'sa', 'Dean Pierrot', 'dapierrot21@gmail.com', 'Main Street Ave', 'N/A', 'Louisville', 2, 40299, 150000.00, 1
	),
	(2, 'dp', 'Kaden', 'SupercoolKid@gmail.com', 'King Street Ln', 'Main Street Ave', 'Louisville', 2, 40299, 200000.00, 2);

	SET IDENTITY_INSERT SalesInfo OFF;

	-- Role --
	SET IDENTITY_INSERT [Role] ON;
	INSERT INTO [Role](RoleId, RoleTitle)
	VALUES(1, 'ADMIN'),
	(2, 'USER');

	SET IDENTITY_INSERT [Role] OFF;



	-- Users --
	INSERT INTO AspNetUsers(Id, RoleId, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled,
	AccessFailedCount, UserName)
	VALUES('00000000-0000-0000-0000-000000000000', 1, 0, 0, 'test@test.com', 0, 0, 0, 'TestUser');

END