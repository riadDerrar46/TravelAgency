CREATE TABLE [dbo].[TravelPlans]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	-- Add columns based on TravelPlan entity when its structure is known

	NumberOfPeople INT NOT NULL DEFAULT(1),
	Destination NVARCHAR(255) NOT NULL DEFAULT '',
	Description NVARCHAR(400) NOT NULL DEFAULT '',
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	Budget DECIMAL(18,2) NOT NULL,
	IsActive BIT NOT NULL DEFAULT(1),
	CreationDate DATETIME NOT NULL DEFAULT GETDATE(),
	DeleteDate DATETIME NULL,
)
