IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[Country] (
        [lcountryid] smallint NOT NULL IDENTITY,
        [lcountry] varchar(250) NOT NULL,
        [addedon] datetime NOT NULL,
        CONSTRAINT [PK__Country__6489F65FA62BE0C8] PRIMARY KEY ([lcountryid])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[PlanType] (
        [PlanID] smallint NOT NULL IDENTITY,
        [PlanName] nvarchar(256) NOT NULL,
        [Status] bit NOT NULL,
        [AddedOn] datetime NOT NULL,
        [UpdatedOn] datetime NULL,
        CONSTRAINT [PK__PlanType__755C22D7C20AC035] PRIMARY KEY ([PlanID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[RoleMaster] (
        [RoleID] smallint NOT NULL IDENTITY,
        [Name] nvarchar(256) NOT NULL,
        [Status] bit NOT NULL,
        [AddedOn] datetime NOT NULL,
        [UpdatedOn] datetime NULL,
        CONSTRAINT [PK__RoleMast__8AFACE3ACDFB82B6] PRIMARY KEY ([RoleID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[UserType] (
        [UserTypeID] smallint NOT NULL IDENTITY,
        [UserType] nvarchar(50) NOT NULL,
        [Status] bit NOT NULL,
        [AddedOn] datetime NOT NULL,
        [UpdatedOn] datetime NULL,
        CONSTRAINT [PK_UserType] PRIMARY KEY ([UserTypeID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[State] (
        [lstateid] smallint NOT NULL IDENTITY,
        [lcountryid] smallint NULL,
        [lstate] varchar(250) NOT NULL,
        [ltype] varchar(20) NOT NULL,
        [ltin] tinyint NOT NULL,
        [lstatecode] varchar(5) NULL,
        [addedon] datetime NOT NULL,
        CONSTRAINT [PK__State__8868BBCC77CE0983] PRIMARY KEY ([lstateid]),
        CONSTRAINT [FK__State__lcountryi__24485945] FOREIGN KEY ([lcountryid]) REFERENCES [dbo].[Country] ([lcountryid]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[UserMaster] (
        [UserID] bigint NOT NULL IDENTITY,
        [EmailID] nvarchar(256) NOT NULL,
        [PasswordHash] varbinary(max) NULL,
        [PasswordSalt] varbinary(max) NULL,
        [MobileNo] bigint NULL,
        [UserTypeID] smallint NOT NULL,
        [PlanID] smallint NOT NULL,
        [OTP] nvarchar(15) NULL,
        [Status] bit NOT NULL,
        [AddedOn] datetime NOT NULL,
        [UpdatedOn] datetime NULL,
        [FirstName] nvarchar(256) NOT NULL DEFAULT ((N'')),
        [LastName] nvarchar(256) NOT NULL DEFAULT ((N'')),
        CONSTRAINT [PK__UserMast__1788CCACAFF82403] PRIMARY KEY ([UserID]),
        CONSTRAINT [FK__UserMaste__PlanI__2A01329B] FOREIGN KEY ([PlanID]) REFERENCES [dbo].[PlanType] ([PlanID]) ON DELETE NO ACTION,
        CONSTRAINT [FK__UserMaste__UserT__2AF556D4] FOREIGN KEY ([UserTypeID]) REFERENCES [dbo].[UserType] ([UserTypeID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[City] (
        [lcityid] int NOT NULL IDENTITY,
        [lstateid] smallint NULL,
        [lcountryid] smallint NULL,
        [lstate] varchar(250) NOT NULL,
        [ltype] varchar(20) NOT NULL,
        [ltin] tinyint NOT NULL,
        [lstatecode] varchar(5) NULL,
        [addedon] datetime NOT NULL,
        CONSTRAINT [PK__City__E0907D6E18F908AB] PRIMARY KEY ([lcityid]),
        CONSTRAINT [FK__City__lcountryid__3572E547] FOREIGN KEY ([lcountryid]) REFERENCES [dbo].[Country] ([lcountryid]) ON DELETE NO ACTION,
        CONSTRAINT [FK__City__lstateid__347EC10E] FOREIGN KEY ([lstateid]) REFERENCES [dbo].[State] ([lstateid]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[User_Bank_Details] (
        [AccountID] bigint NOT NULL IDENTITY,
        [UserID] bigint NOT NULL,
        [Beneficiary_AccountNo] varchar(25) NOT NULL,
        [Beneficiary_AccountType] varchar(50) NOT NULL,
        [IFSC_Code] varchar(11) NOT NULL,
        [Beneficiary_Name] varchar(80) NOT NULL,
        [Cancelled_Cheque] varchar(100) NOT NULL,
        [CreatedDateTime] datetime NOT NULL,
        [UpdatedDateTime] datetime NOT NULL,
        [IsComplete] bit NULL,
        CONSTRAINT [PK__User_Ban__349DA586763060CC] PRIMARY KEY ([AccountID]),
        CONSTRAINT [FK__User_Bank__UserI__253C7D7E] FOREIGN KEY ([UserID]) REFERENCES [dbo].[UserMaster] ([UserID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[User_Company_Details] (
        [CompanyID] bigint NOT NULL IDENTITY,
        [UserID] bigint NOT NULL,
        [Company_Name] varchar(160) NOT NULL,
        [Company_EmailID] varchar(320) NOT NULL,
        [website] bit NULL,
        [website_url] varchar(100) NULL,
        [Company_GSTIN] varchar(30) NULL,
        [BillingAddress_Line1] varchar(100) NOT NULL,
        [BillingAddress_Line2] varchar(100) NULL,
        [BillingAddress_PinCode] int NOT NULL,
        [BillingAddress_City] varchar(100) NOT NULL,
        [BillingAddress_State] varchar(100) NOT NULL,
        [BillingAddress_PhoneCountryCode] varchar(10) NULL,
        [BillingAddress_Phone] varchar(15) NOT NULL,
        [Signature] varchar(100) NULL,
        [Logo] varchar(100) NULL,
        [Signature_Data] varbinary(max) NULL,
        [Logo_Data] varbinary(max) NULL,
        [Invoice_Prefix] varchar(100) NULL,
        [Invoice_Suffix] varchar(100) NULL,
        [CreatedDateTime] datetime NOT NULL,
        [UpdatedDateTime] datetime NOT NULL,
        [IsComplete] bit NULL,
        CONSTRAINT [PK__User_Com__2D971C4C1FB71867] PRIMARY KEY ([CompanyID]),
        CONSTRAINT [FK__User_Comp__UserI__3943762B] FOREIGN KEY ([UserID]) REFERENCES [dbo].[UserMaster] ([UserID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[User_Info] (
        [InfoID] bigint NOT NULL IDENTITY,
        [UserID] bigint NOT NULL,
        [User_Cat] varchar(50) NOT NULL,
        [sale_medium] varchar(5000) NULL,
        [Monthly_Shipments] varchar(500) NOT NULL,
        [ProductCategory] varchar(3000) NOT NULL,
        [OtherCategory] varchar(300) NOT NULL,
        [CreatedDateTime] datetime NULL,
        [UpdatedDateTime] datetime NULL,
        [IsComplete] bit NULL,
        CONSTRAINT [PK__User_Inf__4DEC9D9A4D3F29E0] PRIMARY KEY ([InfoID]),
        CONSTRAINT [FK__User_Info__UserI__3C1FE2D6] FOREIGN KEY ([UserID]) REFERENCES [dbo].[UserMaster] ([UserID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[UserInRoles] (
        [UserRoleID] int NOT NULL IDENTITY,
        [UserID] bigint NOT NULL,
        [RoleID] smallint NOT NULL,
        [Status] bit NOT NULL,
        [AddedOn] datetime NOT NULL,
        [UpdatedOn] datetime NULL,
        CONSTRAINT [PK__UserInRo__3D978A55E50B2BF8] PRIMARY KEY ([UserRoleID]),
        CONSTRAINT [FK__UserInRol__RoleI__2818EA29] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[RoleMaster] ([RoleID]) ON DELETE NO ACTION,
        CONSTRAINT [FK__UserInRol__UserI__290D0E62] FOREIGN KEY ([UserID]) REFERENCES [dbo].[UserMaster] ([UserID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE INDEX [IX_City_lcountryid] ON [dbo].[City] ([lcountryid]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE INDEX [IX_City_lstateid] ON [dbo].[City] ([lstateid]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ__PlanType__46E12F9E9A2E9B47] ON [dbo].[PlanType] ([PlanName]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ__RoleMast__737584F6188F921D] ON [dbo].[RoleMaster] ([Name]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE INDEX [IX_State_lcountryid] ON [dbo].[State] ([lcountryid]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE INDEX [IX_User_Bank_Details_UserID] ON [dbo].[User_Bank_Details] ([UserID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE INDEX [IX_User_Company_Details_UserID] ON [dbo].[User_Company_Details] ([UserID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE INDEX [IX_User_Info_UserID] ON [dbo].[User_Info] ([UserID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE INDEX [IX_UserInRoles_RoleID] ON [dbo].[UserInRoles] ([RoleID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE INDEX [IX_UserInRoles_UserID] ON [dbo].[UserInRoles] ([UserID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ__UserMast__7ED91AEE6DEB1797] ON [dbo].[UserMaster] ([EmailID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE INDEX [IX_UserMaster_PlanID] ON [dbo].[UserMaster] ([PlanID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE INDEX [IX_UserMaster_UserTypeID] ON [dbo].[UserMaster] ([UserTypeID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UQ__UserType__87E7869178F78539] ON [dbo].[UserType] ([UserType]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200822061031_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200822061031_InitialCreate', N'3.1.6');
END;

GO

