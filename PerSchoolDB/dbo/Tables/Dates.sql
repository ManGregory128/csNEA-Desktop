CREATE TABLE [dbo].[Dates] (
    [Date]           DATE         NOT NULL,
    [SemesterNumber] TINYINT      NOT NULL,
    [DayNumber]      TINYINT      NOT NULL,
    [IsHoliday]      BIT          NOT NULL,
    [HolidayName]    VARCHAR (50) NULL,
    CONSTRAINT [PK_Dates] PRIMARY KEY CLUSTERED ([Date] ASC),
    CONSTRAINT [DatesDayLink] FOREIGN KEY ([DayNumber]) REFERENCES [dbo].[Days] ([DayNumber]),
    CONSTRAINT [DatesSemLink] FOREIGN KEY ([SemesterNumber]) REFERENCES [dbo].[Semesters] ([SemesterNumber])
);

