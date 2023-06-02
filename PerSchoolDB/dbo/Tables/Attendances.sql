CREATE TABLE [dbo].[Attendances] (
    [Date]      DATE        NOT NULL,
    [Period]    TINYINT     NOT NULL,
    [StudentID] INT         NOT NULL,
    [MemberOf]  VARCHAR (3) NOT NULL,
    [IsPresent] BIT         NOT NULL,
    CONSTRAINT [PK_Attendances] PRIMARY KEY CLUSTERED ([Date] ASC, [Period] ASC, [StudentID] ASC),
    CONSTRAINT [AttendanceDateLink] FOREIGN KEY ([Date]) REFERENCES [dbo].[Dates] ([Date]),
    CONSTRAINT [AttendanceGroupLink] FOREIGN KEY ([MemberOf]) REFERENCES [dbo].[Groups] ([GroupID]),
    CONSTRAINT [AttendancePeriodLink] FOREIGN KEY ([Period]) REFERENCES [dbo].[Periods] ([PeriodID]),
    CONSTRAINT [AttendanceStudentLink] FOREIGN KEY ([StudentID]) REFERENCES [dbo].[Students] ([StudentID])
);

