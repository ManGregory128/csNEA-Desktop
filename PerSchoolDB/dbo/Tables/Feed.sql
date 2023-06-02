CREATE TABLE [dbo].[Feed] (
    [Author]         VARCHAR (50) NOT NULL,
    [DateTimePosted] DATETIME     NOT NULL,
    [Post]           TEXT         NOT NULL,
    CONSTRAINT [PK_Feed] PRIMARY KEY CLUSTERED ([Author] ASC, [DateTimePosted] ASC),
    CONSTRAINT [FeedAuthorLink] FOREIGN KEY ([Author]) REFERENCES [dbo].[Users] ([UserName])
);

