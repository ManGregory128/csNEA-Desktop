CREATE TABLE [dbo].[Users] (
    [UserName]     VARCHAR (50) NOT NULL,
    [UserPassword] VARCHAR (50) NOT NULL,
    [UserRole]     CHAR (1)     NOT NULL,
    [FirstName]    VARCHAR (50) NOT NULL,
    [LastName]     VARCHAR (50) NULL,
    [IsLoggedIn]   BIT          NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserName] ASC)
);

