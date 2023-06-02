CREATE TABLE [dbo].[Days] (
    [DayNumber] TINYINT      NOT NULL,
    [DayString] VARCHAR (50) NOT NULL,
    [IsWorkDay] BIT          NOT NULL,
    CONSTRAINT [PK_Days] PRIMARY KEY CLUSTERED ([DayNumber] ASC)
);

