CREATE TABLE [dbo].[Students] (
    [StudentID]    INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (255) NOT NULL,
    [LastName]     VARCHAR (255) NOT NULL,
    [StudentGroup] VARCHAR (3)   NOT NULL,
    [MotherName]   VARCHAR (50)  NOT NULL,
    [MotherPhone]  INT           NOT NULL,
    [FatherName]   VARCHAR (50)  NOT NULL,
    [FatherPhone]  INT           NOT NULL,
    [ThirdName]    VARCHAR (50)  NOT NULL,
    [ThirdRole]    VARCHAR (50)  NOT NULL,
    [ThirdPhone]   INT           NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED ([StudentID] ASC),
    CONSTRAINT [StudentsGroupLink] FOREIGN KEY ([StudentGroup]) REFERENCES [dbo].[Groups] ([GroupID])
);

