CREATE TABLE [dbo].[FolderFile] (
    [Id]           INT      IDENTITY (1, 1) NOT NULL,
    [FolderPathId] INT      NULL,
    [SqlFile]      INT      NULL,
    [SqlLine]      INT      NULL,
    [CsFile]       INT      NULL,
    [CsLine]       INT      NULL,
    [JsFile]       INT      NULL,
    [JsLine]       INT      NULL,
    [HtmlFile]     INT      NULL,
    [HtmlLine]     INT      NULL,
    [Date]         DATETIME NULL,
    CONSTRAINT [PK_FolderFiles] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FolderFile_FolderPath] FOREIGN KEY ([FolderPathId]) REFERENCES [dbo].[FolderPath] ([Id])
);



