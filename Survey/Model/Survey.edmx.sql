
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/28/2019 09:28:08
-- Generated from EDMX file: C:\Users\Alex\source\repos\Survey\Survey\Model\Survey.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [survey];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Question_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answers] DROP CONSTRAINT [FK_Question_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_Category_Survey]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Surveys] DROP CONSTRAINT [FK_Category_Survey];
GO
IF OBJECT_ID(N'[dbo].[FK_Survey_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Questions] DROP CONSTRAINT [FK_Survey_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_User_UserSurvey]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSurveys] DROP CONSTRAINT [FK_User_UserSurvey];
GO
IF OBJECT_ID(N'[dbo].[FK_Survey_UserSurvey]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSurveys] DROP CONSTRAINT [FK_Survey_UserSurvey];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Questions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Questions];
GO
IF OBJECT_ID(N'[dbo].[Answers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answers];
GO
IF OBJECT_ID(N'[dbo].[Surveys]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Surveys];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[UserSurveys]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSurveys];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Questions'
CREATE TABLE [dbo].[Questions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NULL,
    [Foto] varbinary(max)  NULL,
    [SurveyId] int  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'Answers'
CREATE TABLE [dbo].[Answers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NULL,
    [Foto] varbinary(max)  NULL,
    [QuestionId] int  NOT NULL,
    [IsTrue] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'Surveys'
CREATE TABLE [dbo].[Surveys] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Time] int  NOT NULL,
    [CategoryId] int  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [IsAdmin] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'UserSurveys'
CREATE TABLE [dbo].[UserSurveys] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [SurveyId] int  NOT NULL,
    [IsPass] bit  NOT NULL,
    [Result] float  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [PK_Questions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Answers'
ALTER TABLE [dbo].[Answers]
ADD CONSTRAINT [PK_Answers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Surveys'
ALTER TABLE [dbo].[Surveys]
ADD CONSTRAINT [PK_Surveys]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSurveys'
ALTER TABLE [dbo].[UserSurveys]
ADD CONSTRAINT [PK_UserSurveys]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [QuestionId] in table 'Answers'
ALTER TABLE [dbo].[Answers]
ADD CONSTRAINT [FK_Question_Answer]
    FOREIGN KEY ([QuestionId])
    REFERENCES [dbo].[Questions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Question_Answer'
CREATE INDEX [IX_FK_Question_Answer]
ON [dbo].[Answers]
    ([QuestionId]);
GO

-- Creating foreign key on [SurveyId] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [FK_Survey_Question]
    FOREIGN KEY ([SurveyId])
    REFERENCES [dbo].[Surveys]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Survey_Question'
CREATE INDEX [IX_FK_Survey_Question]
ON [dbo].[Questions]
    ([SurveyId]);
GO

-- Creating foreign key on [UserId] in table 'UserSurveys'
ALTER TABLE [dbo].[UserSurveys]
ADD CONSTRAINT [FK_User_UserSurvey]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_UserSurvey'
CREATE INDEX [IX_FK_User_UserSurvey]
ON [dbo].[UserSurveys]
    ([UserId]);
GO

-- Creating foreign key on [SurveyId] in table 'UserSurveys'
ALTER TABLE [dbo].[UserSurveys]
ADD CONSTRAINT [FK_Survey_UserSurvey]
    FOREIGN KEY ([SurveyId])
    REFERENCES [dbo].[Surveys]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Survey_UserSurvey'
CREATE INDEX [IX_FK_Survey_UserSurvey]
ON [dbo].[UserSurveys]
    ([SurveyId]);
GO

-- Creating foreign key on [CategoryId] in table 'Surveys'
ALTER TABLE [dbo].[Surveys]
ADD CONSTRAINT [FK_Category_Survey]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Category_Survey'
CREATE INDEX [IX_FK_Category_Survey]
ON [dbo].[Surveys]
    ([CategoryId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------