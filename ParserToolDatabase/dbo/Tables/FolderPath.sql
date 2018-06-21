CREATE TABLE [dbo].[FolderPath] (
    [UserId]        INT            NOT NULL,
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Date]          DATETIME       NULL,
    [FolderPathway] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_FolderPath_1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FolderPath_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);



