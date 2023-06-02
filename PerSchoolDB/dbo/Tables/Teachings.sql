CREATE TABLE [dbo].[Teachings] (
    [PeriodID]        TINYINT      NOT NULL,
    [LessonID]        TINYINT      NOT NULL,
    [TeacherUsername] VARCHAR (50) NOT NULL,
    [Day]             TINYINT      NOT NULL,
    [GroupID]         VARCHAR (3)  NULL,
    CONSTRAINT [PK_Teachings] PRIMARY KEY CLUSTERED ([PeriodID] ASC, [LessonID] ASC, [TeacherUsername] ASC, [Day] ASC),
    CONSTRAINT [TeachingsDayLink] FOREIGN KEY ([Day]) REFERENCES [dbo].[Days] ([DayNumber]),
    CONSTRAINT [TeachingsGroupLink] FOREIGN KEY ([GroupID]) REFERENCES [dbo].[Groups] ([GroupID]),
    CONSTRAINT [TeachingsLessonLink] FOREIGN KEY ([LessonID]) REFERENCES [dbo].[Lessons] ([LessonID]),
    CONSTRAINT [TeachingsPeriodLink] FOREIGN KEY ([PeriodID]) REFERENCES [dbo].[Periods] ([PeriodID]),
    CONSTRAINT [TeachingsTeacherLink] FOREIGN KEY ([TeacherUsername]) REFERENCES [dbo].[Users] ([UserName])
);

