/**



**/

/*Global variables*/
DECLARE @dbname varchar(12)
SET @dbname ='GrabbaRideDB'


/* Kill all connections and drop database */

IF EXISTS (SELECT * FROM sys.databases WHERE NAME = @dbname)
	PRINT ('Attempting to kill all conections to' + @dbname )
	DECLARE @ProcessId varchar(4)
	DECLARE CurrentProcesses SCROLL CURSOR FOR
	select spid from sysprocesses where dbid = (select dbid from sysdatabases where name = @dbname ) order by spid 
	FOR READ ONLY
		OPEN CurrentProcesses
		FETCH NEXT FROM CurrentProcesses INTO @ProcessId
		WHILE @@FETCH_STATUS <> -1
		BEGIN
			--print 'Kill ' + @processid
			PRINT('KILL ' +  @ProcessId)
			--Kill @ProcessId
			FETCH NEXT FROM CurrentProcesses INTO @ProcessId
		END
	CLOSE CurrentProcesses
	DeAllocate CurrentProcesses
	IF EXISTS (SELECT * FROM sys.databases WHERE NAME = @dbname)
		DROP DATABASE GrabbaRideDB /* if any one knows how to convert my declared varchar to work with this statement DOO IT*/
	PRINT('Done closing connections to '+@dbname+ '. The database is DEAD')

/* Create a new database */

CREATE DATABASE GrabbaRideDB
IF EXISTS (SELECT * FROM sys.databases WHERE NAME = @dbname)
	PRINT ('Creation of GrabbaRideDB on localhost was successful')
	
/****** Object:  Table [dbo].[Location]    Script Date: 07/29/2008 23:04:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Location]') AND type in (N'U'))
DROP TABLE [dbo].[Location]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 07/29/2008 23:04:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Location]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Location](
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Long] [float] NOT NULL,
	[Lat] [float] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

/****** Object:  Table [dbo].[Users]    Script Date: 07/29/2008 23:04:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 07/29/2008 23:04:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[UserID] [int] NOT NULL,
	[ScreenName] [nchar](50) NULL,
	[Gender] [bit] NOT NULL,
	[OpenID] [xml] NULL,
	[Notes] [ntext] NULL,
	[DOB] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

/****** Object:  Index [IX_Users]    Script Date: 07/29/2008 23:04:03 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND name = N'IX_Users')
CREATE NONCLUSTERED INDEX [IX_Users] ON [dbo].[Users] 
(
	[UserID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This table contains user information' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Users'

GO
/****** Object:  Table [dbo].[Rides]    Script Date: 07/29/2008 23:04:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rides]') AND type in (N'U'))
DROP TABLE [dbo].[Rides]
GO
/****** Object:  Table [dbo].[Rides]    Script Date: 07/29/2008 23:04:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rides]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Rides](
	[RideID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[FromLocationID] [int] NOT NULL,
	[ToLocationID] [int] NOT NULL,
	[DepatureTime] [datetime] NOT NULL,
	[ArivalTime] [datetime] NOT NULL,
	[ReturnRideID] [int] NULL,
	[Recurrence] [xml] NULL,
	[Complete] [bit] NULL,
	[RideType] [bit] NULL,
 CONSTRAINT [PK_Rides] PRIMARY KEY CLUSTERED 
(
	[RideID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 is wanted RIDE 0 is offered RIDE' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Rides', @level2type=N'COLUMN', @level2name=N'RideType'

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Destination has a location]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rides]'))
ALTER TABLE [dbo].[Rides]  WITH CHECK ADD  CONSTRAINT [Destination has a location] FOREIGN KEY([FromLocationID])
REFERENCES [dbo].[Location] ([LocationID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Return ride has a ride ID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rides]'))
ALTER TABLE [dbo].[Rides]  WITH CHECK ADD  CONSTRAINT [Return ride has a ride ID] FOREIGN KEY([RideID])
REFERENCES [dbo].[Rides] ([RideID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[To location has a location ID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rides]'))
ALTER TABLE [dbo].[Rides]  WITH CHECK ADD  CONSTRAINT [To location has a location ID] FOREIGN KEY([ToLocationID])
REFERENCES [dbo].[Location] ([LocationID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[User can own rides]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rides]'))
ALTER TABLE [dbo].[Rides]  WITH CHECK ADD  CONSTRAINT [User can own rides] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
 