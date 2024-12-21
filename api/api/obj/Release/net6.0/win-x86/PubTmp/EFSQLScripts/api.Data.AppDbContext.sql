IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240922171855_addUser')
BEGIN
    CREATE TABLE [users] (
        [Id] int NOT NULL IDENTITY,
        [Email] nvarchar(max) NULL,
        [Password] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [Role] nvarchar(max) NULL,
        CONSTRAINT [PK_users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240922171855_addUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240922171855_addUser', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240925140555_update')
BEGIN
    CREATE TABLE [categoryTypes] (
        [CategoryTypeId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Image] nvarchar(max) NULL,
        CONSTRAINT [PK_categoryTypes] PRIMARY KEY ([CategoryTypeId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240925140555_update')
BEGIN
    CREATE TABLE [categories] (
        [CategoryId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Image] nvarchar(max) NULL,
        [CategoryTypeId] int NOT NULL,
        CONSTRAINT [PK_categories] PRIMARY KEY ([CategoryId]),
        CONSTRAINT [FK_categories_categoryTypes_CategoryTypeId] FOREIGN KEY ([CategoryTypeId]) REFERENCES [categoryTypes] ([CategoryTypeId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240925140555_update')
BEGIN
    CREATE INDEX [IX_categories_CategoryTypeId] ON [categories] ([CategoryTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240925140555_update')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240925140555_update', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240930044423_update2')
BEGIN
    CREATE TABLE [products] (
        [ProductId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        [Price] decimal(18,2) NOT NULL,
        [Discounted] decimal(18,2) NULL,
        [DiscountedPrice] decimal(18,2) NULL,
        [CategoryId] int NOT NULL,
        CONSTRAINT [PK_products] PRIMARY KEY ([ProductId]),
        CONSTRAINT [FK_products_categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [categories] ([CategoryId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240930044423_update2')
BEGIN
    CREATE TABLE [promotion] (
        [PromotionId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [DiscountRate] decimal(18,2) NOT NULL,
        [Quantity] int NULL,
        [StartDate] datetime2 NULL,
        [EndDate] datetime2 NULL,
        CONSTRAINT [PK_promotion] PRIMARY KEY ([PromotionId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240930044423_update2')
BEGIN
    CREATE TABLE [userPromotion] (
        [UserPromotionId] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [PromotionId] int NOT NULL,
        [UsedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_userPromotion] PRIMARY KEY ([UserPromotionId]),
        CONSTRAINT [FK_userPromotion_users_UserId] FOREIGN KEY ([UserId]) REFERENCES [users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240930044423_update2')
BEGIN
    CREATE TABLE [productImages] (
        [ProductImageId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [ProductId] int NOT NULL,
        CONSTRAINT [PK_productImages] PRIMARY KEY ([ProductImageId]),
        CONSTRAINT [FK_productImages_products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [products] ([ProductId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240930044423_update2')
BEGIN
    CREATE TABLE [productSizes] (
        [ProductSizeId] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_productSizes] PRIMARY KEY ([ProductSizeId]),
        CONSTRAINT [FK_productSizes_products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [products] ([ProductId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240930044423_update2')
BEGIN
    CREATE INDEX [IX_productImages_ProductId] ON [productImages] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240930044423_update2')
BEGIN
    CREATE INDEX [IX_products_CategoryId] ON [products] ([CategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240930044423_update2')
BEGIN
    CREATE INDEX [IX_productSizes_ProductId] ON [productSizes] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240930044423_update2')
BEGIN
    CREATE INDEX [IX_userPromotion_UserId] ON [userPromotion] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240930044423_update2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240930044423_update2', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240930075933_update3')
BEGIN
    ALTER TABLE [products] ADD [Image] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240930075933_update3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240930075933_update3', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240930121750_update4')
BEGIN
    ALTER TABLE [products] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240930121750_update4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240930121750_update4', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240930154503_update5')
BEGIN
    ALTER TABLE [products] ADD [Sell] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240930154503_update5')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240930154503_update5', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241002120527_update-6')
BEGIN
    CREATE TABLE [ProductColor] (
        [ProductColorId] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Code] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ProductColor] PRIMARY KEY ([ProductColorId]),
        CONSTRAINT [FK_ProductColor_products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [products] ([ProductId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241002120527_update-6')
BEGIN
    CREATE INDEX [IX_ProductColor_ProductId] ON [ProductColor] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241002120527_update-6')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241002120527_update-6', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241002175045_update-7')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[productSizes]') AND [c].[name] = N'Name');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [productSizes] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [productSizes] DROP COLUMN [Name];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241002175045_update-7')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductColor]') AND [c].[name] = N'Code');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ProductColor] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [ProductColor] DROP COLUMN [Code];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241002175045_update-7')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductColor]') AND [c].[name] = N'Name');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [ProductColor] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [ProductColor] DROP COLUMN [Name];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241002175045_update-7')
BEGIN
    ALTER TABLE [productSizes] ADD [SizeId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241002175045_update-7')
BEGIN
    ALTER TABLE [ProductColor] ADD [ColorId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241002175045_update-7')
BEGIN
    CREATE TABLE [colors] (
        [ColorId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Code] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_colors] PRIMARY KEY ([ColorId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241002175045_update-7')
BEGIN
    CREATE TABLE [sizes] (
        [SizeId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_sizes] PRIMARY KEY ([SizeId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241002175045_update-7')
BEGIN
    CREATE INDEX [IX_productSizes_SizeId] ON [productSizes] ([SizeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241002175045_update-7')
BEGIN
    CREATE INDEX [IX_ProductColor_ColorId] ON [ProductColor] ([ColorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241002175045_update-7')
BEGIN
    ALTER TABLE [ProductColor] ADD CONSTRAINT [FK_ProductColor_colors_ColorId] FOREIGN KEY ([ColorId]) REFERENCES [colors] ([ColorId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241002175045_update-7')
BEGIN
    ALTER TABLE [productSizes] ADD CONSTRAINT [FK_productSizes_sizes_SizeId] FOREIGN KEY ([SizeId]) REFERENCES [sizes] ([SizeId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241002175045_update-7')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241002175045_update-7', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241003123317_update-8')
BEGIN
    ALTER TABLE [productSizes] ADD [Discounted] decimal(18,2) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241003123317_update-8')
BEGIN
    ALTER TABLE [productSizes] ADD [DiscountedPrice] decimal(18,2) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241003123317_update-8')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241003123317_update-8', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241003155746_update-9')
BEGIN
    CREATE TABLE [carts] (
        [CartId] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [ProductId] int NOT NULL,
        [Quantity] int NOT NULL,
        [Color] nvarchar(max) NULL,
        [Size] nvarchar(max) NULL,
        [TotalAmount] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_carts] PRIMARY KEY ([CartId]),
        CONSTRAINT [FK_carts_products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [products] ([ProductId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241003155746_update-9')
BEGIN
    CREATE INDEX [IX_carts_ProductId] ON [carts] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241003155746_update-9')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241003155746_update-9', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241005084444_update10')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[promotion]') AND [c].[name] = N'Quantity');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [promotion] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [promotion] DROP COLUMN [Quantity];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241005084444_update10')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241005084444_update10', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241005084548_update11')
BEGIN
    ALTER TABLE [promotion] ADD [Code] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241005084548_update11')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241005084548_update11', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241005155741_update12')
BEGIN
    EXEC sp_rename N'[productImages].[Name]', N'ImageUrl', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241005155741_update12')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241005155741_update12', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241006042126_update13')
BEGIN
    CREATE TABLE [Comment] (
        [CommentId] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [ProductId] int NOT NULL,
        [CommentText] nvarchar(max) NULL,
        [ImageUrl] nvarchar(max) NULL,
        [CreatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Comment] PRIMARY KEY ([CommentId]),
        CONSTRAINT [FK_Comment_products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [products] ([ProductId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Comment_users_UserId] FOREIGN KEY ([UserId]) REFERENCES [users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241006042126_update13')
BEGIN
    CREATE INDEX [IX_Comment_ProductId] ON [Comment] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241006042126_update13')
BEGIN
    CREATE INDEX [IX_Comment_UserId] ON [Comment] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241006042126_update13')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241006042126_update13', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241006043507_update14')
BEGIN
    ALTER TABLE [Comment] DROP CONSTRAINT [FK_Comment_products_ProductId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241006043507_update14')
BEGIN
    ALTER TABLE [Comment] DROP CONSTRAINT [FK_Comment_users_UserId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241006043507_update14')
BEGIN
    ALTER TABLE [Comment] DROP CONSTRAINT [PK_Comment];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241006043507_update14')
BEGIN
    EXEC sp_rename N'[Comment]', N'comments';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241006043507_update14')
BEGIN
    EXEC sp_rename N'[comments].[IX_Comment_UserId]', N'IX_comments_UserId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241006043507_update14')
BEGIN
    EXEC sp_rename N'[comments].[IX_Comment_ProductId]', N'IX_comments_ProductId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241006043507_update14')
BEGIN
    ALTER TABLE [comments] ADD [Rate] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241006043507_update14')
BEGIN
    ALTER TABLE [comments] ADD CONSTRAINT [PK_comments] PRIMARY KEY ([CommentId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241006043507_update14')
BEGIN
    ALTER TABLE [comments] ADD CONSTRAINT [FK_comments_products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [products] ([ProductId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241006043507_update14')
BEGIN
    ALTER TABLE [comments] ADD CONSTRAINT [FK_comments_users_UserId] FOREIGN KEY ([UserId]) REFERENCES [users] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241006043507_update14')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241006043507_update14', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241007021143_update15')
BEGIN
    ALTER TABLE [ProductColor] DROP CONSTRAINT [FK_ProductColor_colors_ColorId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241007021143_update15')
BEGIN
    ALTER TABLE [ProductColor] DROP CONSTRAINT [FK_ProductColor_products_ProductId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241007021143_update15')
BEGIN
    ALTER TABLE [ProductColor] DROP CONSTRAINT [PK_ProductColor];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241007021143_update15')
BEGIN
    EXEC sp_rename N'[ProductColor]', N'productColors';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241007021143_update15')
BEGIN
    EXEC sp_rename N'[productColors].[IX_ProductColor_ProductId]', N'IX_productColors_ProductId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241007021143_update15')
BEGIN
    EXEC sp_rename N'[productColors].[IX_ProductColor_ColorId]', N'IX_productColors_ColorId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241007021143_update15')
BEGIN
    ALTER TABLE [productColors] ADD CONSTRAINT [PK_productColors] PRIMARY KEY ([ProductColorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241007021143_update15')
BEGIN
    ALTER TABLE [productColors] ADD CONSTRAINT [FK_productColors_colors_ColorId] FOREIGN KEY ([ColorId]) REFERENCES [colors] ([ColorId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241007021143_update15')
BEGIN
    ALTER TABLE [productColors] ADD CONSTRAINT [FK_productColors_products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [products] ([ProductId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241007021143_update15')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241007021143_update15', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241007162709_update16')
BEGIN
    ALTER TABLE [users] ADD [ImageUrl] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241007162709_update16')
BEGIN
    ALTER TABLE [users] ADD [Username] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241007162709_update16')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241007162709_update16', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008100941_update-17')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241008100941_update-17', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008102319_update-18')
BEGIN
    CREATE TABLE [orders] (
        [OrderId] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [ProductId] int NOT NULL,
        [Quantity] int NOT NULL,
        [Status] nvarchar(max) NULL,
        [PaymentStatus] nvarchar(max) NULL,
        [CreateDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000',
        CONSTRAINT [PK_orders] PRIMARY KEY ([OrderId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008102319_update-18')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241008102319_update-18', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008103232_update-19')
BEGIN
    CREATE TABLE [ordersItem] (
        [OrderItemId] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [Color] nvarchar(max) NULL,
        [OrderId] int NOT NULL,
        [Quantity] int NOT NULL,
        [Size] nvarchar(max) NULL,
        [TotalAmount] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_ordersItem] PRIMARY KEY ([OrderItemId]),
        CONSTRAINT [FK_ordersItem_orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [orders] ([OrderId]) ON DELETE CASCADE,
        CONSTRAINT [FK_ordersItem_products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [products] ([ProductId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008103232_update-19')
BEGIN
    CREATE INDEX [IX_ordersItem_OrderId] ON [ordersItem] ([OrderId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008103232_update-19')
BEGIN
    CREATE INDEX [IX_ordersItem_ProductId] ON [ordersItem] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008103232_update-19')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241008103232_update-19', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008133954_update-20')
BEGIN
    ALTER TABLE [orders] ADD [Address] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008133954_update-20')
BEGIN
    ALTER TABLE [orders] ADD [City] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008133954_update-20')
BEGIN
    ALTER TABLE [orders] ADD [Description] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008133954_update-20')
BEGIN
    ALTER TABLE [orders] ADD [District] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008133954_update-20')
BEGIN
    ALTER TABLE [orders] ADD [Name] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008133954_update-20')
BEGIN
    ALTER TABLE [orders] ADD [Phone] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008133954_update-20')
BEGIN
    ALTER TABLE [orders] ADD [Ward] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008133954_update-20')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241008133954_update-20', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008140538_update-21')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[orders]') AND [c].[name] = N'Status');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [orders] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [orders] ADD DEFAULT N'Chưa xác nhận' FOR [Status];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008140538_update-21')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[orders]') AND [c].[name] = N'Description');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [orders] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [orders] ALTER COLUMN [Description] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008140538_update-21')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241008140538_update-21', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008150816_update-22')
BEGIN
    ALTER TABLE [orders] ADD [TotalAmount] decimal(18,2) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008150816_update-22')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241008150816_update-22', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008152143_update-23')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[orders]') AND [c].[name] = N'ProductId');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [orders] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [orders] DROP COLUMN [ProductId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008152143_update-23')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241008152143_update-23', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008152714_update-24')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[orders]') AND [c].[name] = N'Quantity');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [orders] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [orders] DROP COLUMN [Quantity];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241008152714_update-24')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241008152714_update-24', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241009030605_update-25')
BEGIN
    ALTER TABLE [orders] ADD [Discount] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241009030605_update-25')
BEGIN
    ALTER TABLE [orders] ADD [Payment] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241009030605_update-25')
BEGIN
    ALTER TABLE [orders] ADD [ShippingStatus] nvarchar(max) NOT NULL DEFAULT N'Chưa chuyển';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241009030605_update-25')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241009030605_update-25', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241009031725_update-26')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[orders]') AND [c].[name] = N'Discount');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [orders] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [orders] ALTER COLUMN [Discount] decimal(18,2) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241009031725_update-26')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241009031725_update-26', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241009033345_update-27')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[users]') AND [c].[name] = N'Role');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [users] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [users] ALTER COLUMN [Role] nvarchar(max) NOT NULL;
    ALTER TABLE [users] ADD DEFAULT N'User' FOR [Role];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241009033345_update-27')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[orders]') AND [c].[name] = N'Discount');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [orders] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [orders] ALTER COLUMN [Discount] decimal(18,2) NOT NULL;
    ALTER TABLE [orders] ADD DEFAULT 0.0 FOR [Discount];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241009033345_update-27')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241009033345_update-27', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241009110843_update-28')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[products]') AND [c].[name] = N'Sell');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [products] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [products] ALTER COLUMN [Sell] int NOT NULL;
    ALTER TABLE [products] ADD DEFAULT 0 FOR [Sell];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241009110843_update-28')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241009110843_update-28', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241009140424_update-29')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[orders]') AND [c].[name] = N'Status');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [orders] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [orders] DROP COLUMN [Status];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241009140424_update-29')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241009140424_update-29', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241010143418_update-30')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[orders]') AND [c].[name] = N'PaymentStatus');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [orders] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [orders] ADD DEFAULT N'Chưa thanh toán' FOR [PaymentStatus];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241010143418_update-30')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241010143418_update-30', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241010164534_update-31')
BEGIN
    ALTER TABLE [promotion] ADD [Status] bit NOT NULL DEFAULT CAST(1 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241010164534_update-31')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241010164534_update-31', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241012142619_update-32')
BEGIN
    CREATE INDEX [IX_userPromotion_PromotionId] ON [userPromotion] ([PromotionId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241012142619_update-32')
BEGIN
    ALTER TABLE [userPromotion] ADD CONSTRAINT [FK_userPromotion_promotion_PromotionId] FOREIGN KEY ([PromotionId]) REFERENCES [promotion] ([PromotionId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20241012142619_update-32')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241012142619_update-32', N'6.0.0');
END;
GO

COMMIT;
GO

