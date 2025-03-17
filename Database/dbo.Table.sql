CREATE TABLE [dbo].[Event]
(
	[eId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [title] NVARCHAR(50) NULL, 
    [category] NVARCHAR(50) NULL, 
    [capacity] NVARCHAR(50) NULL, 
    [regesterd_seats] INT NULL DEFAULT 0, 
    [price] INT NULL, 
    [venue] NVARCHAR(50) NULL, 
    [date] DATETIME NULL, 
    [start_time] NVARCHAR(50) NULL, 
    [duration] NVARCHAR(50) NULL, 
    [image1] NVARCHAR(50) NULL
)
