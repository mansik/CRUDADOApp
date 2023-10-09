CREATE TABLE [dbo].[Student]
(
	[Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50) NOT NULL,
    [Reg]     NVARCHAR (50) NULL,
    [Class]   NVARCHAR (50) NULL,
    [Section] NVARCHAR (50) NULL
)
