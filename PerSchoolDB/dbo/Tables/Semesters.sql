CREATE TABLE [dbo].[Semesters] (
    [SemesterNumber] TINYINT NOT NULL,
    [StartDate]      DATE    NOT NULL,
    [EndDate]        DATE    NOT NULL,
    CONSTRAINT [PK_Semesters] PRIMARY KEY CLUSTERED ([SemesterNumber] ASC)
);

