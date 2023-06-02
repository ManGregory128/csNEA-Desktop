CREATE TABLE [dbo].[Periods] (
    [PeriodID]    TINYINT NOT NULL,
    [CanBeDouble] BIT     NOT NULL,
    CONSTRAINT [PK_Periods] PRIMARY KEY CLUSTERED ([PeriodID] ASC)
);

