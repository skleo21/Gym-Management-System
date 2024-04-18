
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/26/2022 03:11:18
-- Generated from EDMX file: C:\Users\leori\Documents\Istec\Tec Internet\Projeto Final\Myproject\Myproject\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [project];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__reservas__idcli__4222D4EF]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[reservas] DROP CONSTRAINT [FK__reservas__idcli__4222D4EF];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[clientes];
GO
IF OBJECT_ID(N'[dbo].[especialidades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[especialidades];
GO
IF OBJECT_ID(N'[dbo].[reservas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[reservas];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'clientes'
CREATE TABLE [dbo].[clientes] (
    [idcli] int IDENTITY(1,1) NOT NULL,
    [ncliente] nvarchar(50)  NOT NULL,
    [datanasC] datetime  NULL,
    [idade] int  NULL,
    [foto] nvarchar(50)  NULL
);
GO

-- Creating table 'especialidades'
CREATE TABLE [dbo].[especialidades] (
    [especialidade] nchar(20)  NOT NULL
);
GO

-- Creating table 'trainers'
CREATE TABLE [dbo].[trainers] (
    [idpt] int IDENTITY(1,1) NOT NULL,
    [ptrainer] nvarchar(50)  NOT NULL,
    [especialidade] nchar(20)  NULL,
    [xp] int  NULL,
    [idade] datetime  NULL,
    [ptrainerfoto] varbinary(max)  NULL,
    [phora] decimal(10,2)  NULL
);
GO

-- Creating table 'reservas'
CREATE TABLE [dbo].[reservas] (
    [idreserva] int IDENTITY(1,1) NOT NULL,
    [idpt] int  NULL,
    [idcli] int  NULL,
    [datainicio] datetime  NULL,
    [datafinal] datetime  NULL,
    [tempo] int  NULL,
    [custo] decimal(10,2)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idcli] in table 'clientes'
ALTER TABLE [dbo].[clientes]
ADD CONSTRAINT [PK_clientes]
    PRIMARY KEY CLUSTERED ([idcli] ASC);
GO

-- Creating primary key on [especialidade] in table 'especialidades'
ALTER TABLE [dbo].[especialidades]
ADD CONSTRAINT [PK_especialidades]
    PRIMARY KEY CLUSTERED ([especialidade] ASC);
GO

-- Creating primary key on [idpt] in table 'trainers'
ALTER TABLE [dbo].[trainers]
ADD CONSTRAINT [PK_trainers]
    PRIMARY KEY CLUSTERED ([idpt] ASC);
GO

-- Creating primary key on [idreserva] in table 'reservas'
ALTER TABLE [dbo].[reservas]
ADD CONSTRAINT [PK_reservas]
    PRIMARY KEY CLUSTERED ([idreserva] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idcli] in table 'reservas'
ALTER TABLE [dbo].[reservas]
ADD CONSTRAINT [FK__reservas__idcli__4222D4EF]
    FOREIGN KEY ([idcli])
    REFERENCES [dbo].[clientes]
        ([idcli])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__reservas__idcli__4222D4EF'
CREATE INDEX [IX_FK__reservas__idcli__4222D4EF]
ON [dbo].[reservas]
    ([idcli]);
GO

-- Creating foreign key on [especialidade] in table 'trainers'
ALTER TABLE [dbo].[trainers]
ADD CONSTRAINT [FK_fkptraineresp]
    FOREIGN KEY ([especialidade])
    REFERENCES [dbo].[especialidades]
        ([especialidade])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_fkptraineresp'
CREATE INDEX [IX_FK_fkptraineresp]
ON [dbo].[trainers]
    ([especialidade]);
GO

-- Creating foreign key on [idpt] in table 'reservas'
ALTER TABLE [dbo].[reservas]
ADD CONSTRAINT [FK__reservas__idpt__412EB0B6]
    FOREIGN KEY ([idpt])
    REFERENCES [dbo].[trainers]
        ([idpt])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__reservas__idpt__412EB0B6'
CREATE INDEX [IX_FK__reservas__idpt__412EB0B6]
ON [dbo].[reservas]
    ([idpt]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------