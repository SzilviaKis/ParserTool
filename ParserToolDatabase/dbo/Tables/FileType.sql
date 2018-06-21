CREATE TABLE [dbo].[FileType] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Type] VARCHAR (20) NULL,
    CONSTRAINT [PK_FileType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

