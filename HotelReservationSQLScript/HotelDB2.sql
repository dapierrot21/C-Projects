USE [HotelReservation]
GO
ALTER TABLE [dbo].[RoomType] DROP CONSTRAINT [FK__RoomType__RoomTy__3C69FB99]
GO
ALTER TABLE [dbo].[RoomReserved] DROP CONSTRAINT [FK_Room_RoomReserved]
GO
ALTER TABLE [dbo].[RoomReserved] DROP CONSTRAINT [FK_Reservation_RoomReserved]
GO
ALTER TABLE [dbo].[RoomAmenities] DROP CONSTRAINT [FK_Room_RoomAmenities]
GO
ALTER TABLE [dbo].[RoomAmenities] DROP CONSTRAINT [FK_Amentities_RoomAmenities]
GO
ALTER TABLE [dbo].[Room] DROP CONSTRAINT [FK__Room__RoomType__3F466844]
GO
ALTER TABLE [dbo].[ReservationAddOns] DROP CONSTRAINT [FK_Reservation_ReservationAddOns]
GO
ALTER TABLE [dbo].[ReservationAddOns] DROP CONSTRAINT [FK_AddOn_ReservationAddOns]
GO
ALTER TABLE [dbo].[Reservation] DROP CONSTRAINT [FK__Reservati__Promo__4E88ABD4]
GO
ALTER TABLE [dbo].[Guest] DROP CONSTRAINT [FK__Guest__Reservati__5441852A]
GO
ALTER TABLE [dbo].[Billing] DROP CONSTRAINT [FK__Billing__Reserva__5165187F]
GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 9/3/2020 9:41:27 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoomType]') AND type in (N'U'))
DROP TABLE [dbo].[RoomType]
GO
/****** Object:  Table [dbo].[RoomReserved]    Script Date: 9/3/2020 9:41:27 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoomReserved]') AND type in (N'U'))
DROP TABLE [dbo].[RoomReserved]
GO
/****** Object:  Table [dbo].[RoomRate]    Script Date: 9/3/2020 9:41:27 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoomRate]') AND type in (N'U'))
DROP TABLE [dbo].[RoomRate]
GO
/****** Object:  Table [dbo].[RoomAmenities]    Script Date: 9/3/2020 9:41:27 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoomAmenities]') AND type in (N'U'))
DROP TABLE [dbo].[RoomAmenities]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 9/3/2020 9:41:27 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Room]') AND type in (N'U'))
DROP TABLE [dbo].[Room]
GO
/****** Object:  Table [dbo].[ReservationAddOns]    Script Date: 9/3/2020 9:41:27 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReservationAddOns]') AND type in (N'U'))
DROP TABLE [dbo].[ReservationAddOns]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 9/3/2020 9:41:27 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reservation]') AND type in (N'U'))
DROP TABLE [dbo].[Reservation]
GO
/****** Object:  Table [dbo].[PromotionCode]    Script Date: 9/3/2020 9:41:27 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PromotionCode]') AND type in (N'U'))
DROP TABLE [dbo].[PromotionCode]
GO
/****** Object:  Table [dbo].[Guest]    Script Date: 9/3/2020 9:41:27 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Guest]') AND type in (N'U'))
DROP TABLE [dbo].[Guest]
GO
/****** Object:  Table [dbo].[Billing]    Script Date: 9/3/2020 9:41:27 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Billing]') AND type in (N'U'))
DROP TABLE [dbo].[Billing]
GO
/****** Object:  Table [dbo].[Amenities]    Script Date: 9/3/2020 9:41:27 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Amenities]') AND type in (N'U'))
DROP TABLE [dbo].[Amenities]
GO
/****** Object:  Table [dbo].[AddOn]    Script Date: 9/3/2020 9:41:27 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddOn]') AND type in (N'U'))
DROP TABLE [dbo].[AddOn]
GO
/****** Object:  Table [dbo].[AddOn]    Script Date: 9/3/2020 9:41:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddOn](
	[AddOnID] [int] IDENTITY(1,1) NOT NULL,
	[AddOnItem] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AddOnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Amenities]    Script Date: 9/3/2020 9:41:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amenities](
	[AmenitiesID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AmenitiesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Billing]    Script Date: 9/3/2020 9:41:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Billing](
	[BillingID] [int] IDENTITY(1,1) NOT NULL,
	[ReservationID] [int] NULL,
	[RoomTotal] [decimal](18, 0) NOT NULL,
	[AddOnTotal] [decimal](18, 0) NOT NULL,
	[TaxTotal] [decimal](18, 0) NOT NULL,
	[Discount] [decimal](18, 0) NOT NULL,
	[GrandTotal] [decimal](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BillingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guest]    Script Date: 9/3/2020 9:41:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[GuestID] [int] IDENTITY(1,1) NOT NULL,
	[ReservationID] [int] NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[Phone] [varchar](30) NOT NULL,
	[Email] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GuestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PromotionCode]    Script Date: 9/3/2020 9:41:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PromotionCode](
	[PromotionCodeID] [int] IDENTITY(1,1) NOT NULL,
	[CodeType] [varchar](30) NOT NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[CodeDiscount] [decimal](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PromotionCodeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 9/3/2020 9:41:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[Adults] [int] NOT NULL,
	[Children] [int] NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[PromotionCodeID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationAddOns]    Script Date: 9/3/2020 9:41:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationAddOns](
	[ReservationID] [int] NOT NULL,
	[AddOnID] [int] NOT NULL,
 CONSTRAINT [PK_ReservationAddOns] PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC,
	[AddOnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 9/3/2020 9:41:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[FloorNumber] [int] NOT NULL,
	[Description] [varchar](30) NOT NULL,
	[RoomType] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomAmenities]    Script Date: 9/3/2020 9:41:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomAmenities](
	[RoomID] [int] NOT NULL,
	[AmenitiesID] [int] NOT NULL,
 CONSTRAINT [PK_RoomAmenities] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC,
	[AmenitiesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomRate]    Script Date: 9/3/2020 9:41:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomRate](
	[RoomTypeRateID] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[CostPerNight] [decimal](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomTypeRateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomReserved]    Script Date: 9/3/2020 9:41:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomReserved](
	[RoomID] [int] NOT NULL,
	[ReservationID] [int] NOT NULL,
 CONSTRAINT [PK_RoomReserved] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC,
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 9/3/2020 9:41:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomType](
	[RoomTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](30) NOT NULL,
	[RoomTypeRateID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Billing]  WITH CHECK ADD FOREIGN KEY([ReservationID])
REFERENCES [dbo].[Reservation] ([ReservationID])
GO
ALTER TABLE [dbo].[Guest]  WITH CHECK ADD FOREIGN KEY([ReservationID])
REFERENCES [dbo].[Reservation] ([ReservationID])
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD FOREIGN KEY([PromotionCodeID])
REFERENCES [dbo].[PromotionCode] ([PromotionCodeID])
GO
ALTER TABLE [dbo].[ReservationAddOns]  WITH CHECK ADD  CONSTRAINT [FK_AddOn_ReservationAddOns] FOREIGN KEY([AddOnID])
REFERENCES [dbo].[AddOn] ([AddOnID])
GO
ALTER TABLE [dbo].[ReservationAddOns] CHECK CONSTRAINT [FK_AddOn_ReservationAddOns]
GO
ALTER TABLE [dbo].[ReservationAddOns]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_ReservationAddOns] FOREIGN KEY([ReservationID])
REFERENCES [dbo].[Reservation] ([ReservationID])
GO
ALTER TABLE [dbo].[ReservationAddOns] CHECK CONSTRAINT [FK_Reservation_ReservationAddOns]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD FOREIGN KEY([RoomType])
REFERENCES [dbo].[RoomType] ([RoomTypeID])
GO
ALTER TABLE [dbo].[RoomAmenities]  WITH CHECK ADD  CONSTRAINT [FK_Amentities_RoomAmenities] FOREIGN KEY([AmenitiesID])
REFERENCES [dbo].[Amenities] ([AmenitiesID])
GO
ALTER TABLE [dbo].[RoomAmenities] CHECK CONSTRAINT [FK_Amentities_RoomAmenities]
GO
ALTER TABLE [dbo].[RoomAmenities]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomAmenities] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[RoomAmenities] CHECK CONSTRAINT [FK_Room_RoomAmenities]
GO
ALTER TABLE [dbo].[RoomReserved]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_RoomReserved] FOREIGN KEY([ReservationID])
REFERENCES [dbo].[Reservation] ([ReservationID])
GO
ALTER TABLE [dbo].[RoomReserved] CHECK CONSTRAINT [FK_Reservation_RoomReserved]
GO
ALTER TABLE [dbo].[RoomReserved]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomReserved] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[RoomReserved] CHECK CONSTRAINT [FK_Room_RoomReserved]
GO
ALTER TABLE [dbo].[RoomType]  WITH CHECK ADD FOREIGN KEY([RoomTypeRateID])
REFERENCES [dbo].[RoomRate] ([RoomTypeRateID])
GO
