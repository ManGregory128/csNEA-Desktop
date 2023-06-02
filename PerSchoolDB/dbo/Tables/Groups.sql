CREATE TABLE [dbo].[Groups] (
    [GroupID]    VARCHAR (3)  NOT NULL,
    [TeacherRep] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED ([GroupID] ASC),
    CONSTRAINT [GroupsRepLink] FOREIGN KEY ([TeacherRep]) REFERENCES [dbo].[Users] ([UserName])
);

