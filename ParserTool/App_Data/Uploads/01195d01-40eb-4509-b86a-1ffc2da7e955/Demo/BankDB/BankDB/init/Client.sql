USE [BankDB]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Id], [Name], [Money]) VALUES (1, N'Lora', 19500)
INSERT [dbo].[Client] ([Id], [Name], [Money]) VALUES (2, N'John', 20350)
INSERT [dbo].[Client] ([Id], [Name], [Money]) VALUES (3, N'Ben', -20000)
INSERT [dbo].[Client] ([Id], [Name], [Money]) VALUES (4, N'Carlita', 15000)
SET IDENTITY_INSERT [dbo].[Client] OFF
