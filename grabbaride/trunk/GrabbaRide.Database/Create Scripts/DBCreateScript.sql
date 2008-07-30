/**

Amy's sweet create script

**/

/*Global variables*/
DECLARE @dbname char(12)
SET @dbname ='GrabbaRideDB'

/* Kill all connections and drop database */
/*

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
		DROP DATABASE GrabbaRideDB /* if any one knows how to convert my declared varchar to work with this statement DOO IT
	PRINT('Done closing connections to '+@dbname+ '. The database is DEAD')
*/
/* Create a new database */

/*
PRINT 'Attempting to create database ' + @dbname
CREATE DATABASE GrabbaRideDB
IF EXISTS (SELECT * FROM sys.databases WHERE NAME = @dbname)
	PRINT ('Creation of GrabbaRideDB on localhost was successful')
*/

/* Clean the existing database */


/* Create the Location table */
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

/* Create the Users table */
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

/* Create the Rides table */
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

/* Create the foreign key constraints */
ALTER TABLE [dbo].[Rides]  WITH CHECK ADD  CONSTRAINT [Destination has a location] FOREIGN KEY([FromLocationID])
REFERENCES [dbo].[Location] ([LocationID])

ALTER TABLE [dbo].[Rides]  WITH CHECK ADD  CONSTRAINT [Return ride has a ride ID] FOREIGN KEY([RideID])
REFERENCES [dbo].[Rides] ([RideID])

ALTER TABLE [dbo].[Rides]  WITH CHECK ADD  CONSTRAINT [To location has a location ID] FOREIGN KEY([ToLocationID])
REFERENCES [dbo].[Location] ([LocationID])

ALTER TABLE [dbo].[Rides]  WITH CHECK ADD  CONSTRAINT [User can own rides] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
