CREATE TABLE [dbo].[Genre]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [action] VARCHAR(50) NOT NULL, 
    [scienceFiction] VARCHAR(50) NOT NULL, 
    [horreur] VARCHAR(50) NULL, 
    [drame] VARCHAR(50) NULL, 
    [comedie_romatique] VARCHAR(50) NULL

)
