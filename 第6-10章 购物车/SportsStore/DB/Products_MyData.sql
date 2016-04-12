use SportsStore3

SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price],Store) VALUES (1, N'苹果', N'Apple Apple：我爱你，就像老鼠爱大米...', N'水果', CAST(4.00 AS Decimal(16, 2)),10)
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price],Store) VALUES (2, N'香蕉', N'Banana：在平面上，两人要么平行，要么香蕉...', N'水果', CAST(2 AS Decimal(16, 2)),10)
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price],Store) VALUES (3, N'荔枝', N'Leechee：岭南夏天佳果,这里只卖妃子笑品种...', N'水果', CAST(8 AS Decimal(16, 2)),10)
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price],Store) VALUES (4, N'芒果', N'Mango：香香甜甜的大芒果,我看着如饥似渴...', N'水果', CAST(5 AS Decimal(16, 2)),10)
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price],Store) VALUES (5, N'萝卜', N'Radish：也叫菜头，大大滴白萝卜...', N'蔬菜', CAST(1.00 AS Decimal(16, 2)),10)
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price],Store) VALUES (6, N'黄瓜', N'Cucumber：小心捅死你...', N'蔬菜', CAST(1.00 AS Decimal(16, 2)),10)
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price],Store) VALUES (7, N'茄子', N'Eggplant：也叫辣酥...', N'蔬菜', CAST(3 AS Decimal(16, 2)),10)
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price],Store) VALUES (8, N'薯片', N'Potato Piece：薯片，程序员的最爱...', N'零食', CAST(3.00 AS Decimal(16, 2)),10)
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price],Store) VALUES (9, N'雪糕', N'Ice cream：甜筒,广州五羊甜筒...', N'零食', CAST(2.50 AS Decimal(16, 2)),10)
SET IDENTITY_INSERT [dbo].[Products] OFF
