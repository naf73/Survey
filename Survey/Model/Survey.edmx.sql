
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/26/2019 08:52:20
-- Generated from EDMX file: C:\Users\Alex\source\repos\Survey\Survey\Model\Survey.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [uzpa];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_QuestionAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answers] DROP CONSTRAINT [FK_QuestionAnswer];
GO
IF OBJECT_ID(N'[dbo].[FK_CategorySurveySurvey]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Surveys] DROP CONSTRAINT [FK_CategorySurveySurvey];
GO
IF OBJECT_ID(N'[dbo].[FK_SurveyQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Questions] DROP CONSTRAINT [FK_SurveyQuestion];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserSurvey]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSurveys] DROP CONSTRAINT [FK_UserUserSurvey];
GO
IF OBJECT_ID(N'[dbo].[FK_SurveyUserSurvey]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSurveys] DROP CONSTRAINT [FK_SurveyUserSurvey];
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
IF OBJECT_ID(N'[dbo].[SurveyCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SurveyCategories];
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
    [Text] nvarchar(max)  NOT NULL,
    [Foto] nvarchar(max)  NOT NULL,
    [SurveyId] int  NOT NULL
);
GO

-- Creating table 'Answers'
CREATE TABLE [dbo].[Answers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Foto] nvarchar(max)  NOT NULL,
    [QuestionId] int  NOT NULL,
    [IsTrue] bit  NOT NULL
);
GO

-- Creating table 'Surveys'
CREATE TABLE [dbo].[Surveys] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Time] datetime  NOT NULL,
    [SurveyCategoryId] int  NOT NULL
);
GO

-- Creating table 'SurveyCategories'
CREATE TABLE [dbo].[SurveyCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Role] int  NOT NULL
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

-- Creating primary key on [Id] in table 'SurveyCategories'
ALTER TABLE [dbo].[SurveyCategories]
ADD CONSTRAINT [PK_SurveyCategories]
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

-- Creating foreign key on [SurveyCategoryId] in table 'Surveys'
ALTER TABLE [dbo].[Surveys]
ADD CONSTRAINT [FK_SurveyCategory_Survey]
    FOREIGN KEY ([SurveyCategoryId])
    REFERENCES [dbo].[SurveyCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SurveyCategory_Survey'
CREATE INDEX [IX_FK_SurveyCategory_Survey]
ON [dbo].[Surveys]
    ([SurveyCategoryId]);
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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------