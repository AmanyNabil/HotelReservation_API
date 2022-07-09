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

CREATE TABLE [rooms] (
    [id] int NOT NULL IDENTITY,
    [floor_no] int NOT NULL,
    [finger_no] int NOT NULL,
    [is_vip] bit NOT NULL,
    CONSTRAINT [PK_rooms] PRIMARY KEY ([id])
);
GO

CREATE TABLE [users] (
    [id] int NOT NULL IDENTITY,
    [name] nvarchar(100) NOT NULL,
    [Email] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_users] PRIMARY KEY ([id])
);
GO

CREATE TABLE [reservations] (
    [id] int NOT NULL IDENTITY,
    [user_id] int NOT NULL,
    [room_id] int NOT NULL,
    [ReservationDate_from] datetime2 NOT NULL,
    [ReservationDate_to] datetime2 NOT NULL,
    CONSTRAINT [PK_reservations] PRIMARY KEY ([id]),
    CONSTRAINT [FK_reservations_rooms_room_id] FOREIGN KEY ([room_id]) REFERENCES [rooms] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_reservations_users_user_id] FOREIGN KEY ([user_id]) REFERENCES [users] ([id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_reservations_room_id] ON [reservations] ([room_id]);
GO

CREATE INDEX [IX_reservations_user_id] ON [reservations] ([user_id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220704023235_Create_Hotel_DB', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'finger_no', N'floor_no', N'is_vip') AND [object_id] = OBJECT_ID(N'[rooms]'))
    SET IDENTITY_INSERT [rooms] ON;
INSERT INTO [rooms] ([id], [finger_no], [floor_no], [is_vip])
VALUES (1, 1, 1, CAST(0 AS bit)),
(2, 2, 1, CAST(0 AS bit)),
(3, 3, 2, CAST(0 AS bit)),
(4, 5, 2, CAST(1 AS bit));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'finger_no', N'floor_no', N'is_vip') AND [object_id] = OBJECT_ID(N'[rooms]'))
    SET IDENTITY_INSERT [rooms] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'Email', N'name') AND [object_id] = OBJECT_ID(N'[users]'))
    SET IDENTITY_INSERT [users] ON;
INSERT INTO [users] ([id], [Email], [name])
VALUES (1, N'Amani.nabil@hotmail.com', N'Amany Nabil'),
(2, N'Ahmed.M@hotmail.com', N'Ahmed Mohamed'),
(3, N'Ali.Said@hotmail.com', N'Ali Said'),
(4, N'Tamer.M@hotmail.com', N'Tamed Mohamed');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'Email', N'name') AND [object_id] = OBJECT_ID(N'[users]'))
    SET IDENTITY_INSERT [users] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'ReservationDate_from', N'ReservationDate_to', N'room_id', N'user_id') AND [object_id] = OBJECT_ID(N'[reservations]'))
    SET IDENTITY_INSERT [reservations] ON;
INSERT INTO [reservations] ([id], [ReservationDate_from], [ReservationDate_to], [room_id], [user_id])
VALUES (1, '2022-06-01T00:00:00.0000000', '2022-06-05T00:00:00.0000000', 1, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'ReservationDate_from', N'ReservationDate_to', N'room_id', N'user_id') AND [object_id] = OBJECT_ID(N'[reservations]'))
    SET IDENTITY_INSERT [reservations] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'ReservationDate_from', N'ReservationDate_to', N'room_id', N'user_id') AND [object_id] = OBJECT_ID(N'[reservations]'))
    SET IDENTITY_INSERT [reservations] ON;
INSERT INTO [reservations] ([id], [ReservationDate_from], [ReservationDate_to], [room_id], [user_id])
VALUES (2, '2022-07-04T00:00:00.0000000', '2022-07-30T00:00:00.0000000', 3, 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'ReservationDate_from', N'ReservationDate_to', N'room_id', N'user_id') AND [object_id] = OBJECT_ID(N'[reservations]'))
    SET IDENTITY_INSERT [reservations] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220704024308_Create_SeedData', N'5.0.17');
GO

COMMIT;
GO

