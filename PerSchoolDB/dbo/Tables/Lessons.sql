CREATE TABLE [dbo].[Lessons] (
    [LessonID]   TINYINT      NOT NULL,
    [LessonName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED ([LessonID] ASC)
);

