USE [band_tracker]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 3/3/2017 11:36:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bands_venues]    Script Date: 3/3/2017 11:36:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands_venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bands_id] [int] NULL,
	[venues_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues]    Script Date: 3/3/2017 11:36:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[bands_venues] ON 

INSERT [dbo].[bands_venues] ([id], [bands_id], [venues_id]) VALUES (2, 5, 3)
INSERT [dbo].[bands_venues] ([id], [bands_id], [venues_id]) VALUES (3, 5, 3)
INSERT [dbo].[bands_venues] ([id], [bands_id], [venues_id]) VALUES (4, 7, 3)
SET IDENTITY_INSERT [dbo].[bands_venues] OFF
