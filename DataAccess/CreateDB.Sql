﻿USE [master]
GO

CREATE DATABASE [People] ON  PRIMARY 
( NAME = N'People', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\People.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'People_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\People_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [People] SET COMPATIBILITY_LEVEL = 100
GO


ALTER DATABASE [People] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [People] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [People] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [People] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [People] SET ARITHABORT OFF 
GO

ALTER DATABASE [People] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [People] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [People] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [People] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [People] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [People] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [People] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [People] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [People] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [People] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [People] SET  DISABLE_BROKER 
GO

ALTER DATABASE [People] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [People] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [People] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [People] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [People] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [People] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [People] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [People] SET  READ_WRITE 
GO

ALTER DATABASE [People] SET RECOVERY FULL 
GO

ALTER DATABASE [People] SET  MULTI_USER 
GO

ALTER DATABASE [People] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [People] SET DB_CHAINING OFF 
GO


USE [People]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE SCHEMA LoanTracking  AUTHORIZATION dbo;
GO
CREATE TABLE LoanTracking.LoanApplicant
(
	Id INT NOT NULL IDENTITY(1,1),
	Title VARCHAR(30) NULL,
	FirstName VARCHAR(200) NULL,
	LastName VARCHAR(200) NULL,		
	Created DATETIMEOFFSET NOT NULL,
	LastModified DATETIMEOFFSET NOT NULL,	
	FullName as CONCAT(FirstName, ' ', LastName),	
    CONSTRAINT PK_Applicant PRIMARY KEY (Id),	
)

SET ANSI_PADDING OFF
GO


USE [People]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
CREATE TABLE LoanTracking.Money (
	Id INT NOT NULL IDENTITY(1,1),
	ApplicantId INT NOT NULL ,		
	Amount MONEY NOT NULL,
	IsPrimaryLoan BIT NOT NULL,
	IsLoDocLoan BIT NOT NULL,
	IsFirstHomeBuyer BIT NOT NULL,
	IsSelfEmployed BIT NOT NULL,
	ProductName VARCHAR(150) NULL,
	ApprovalNumber VARCHAR(50) NULL,
	Balance MONEY NOT NULL CONSTRAINT DF_Money_BALANCE DEFAULT(0),
	ApplicationDate DATE NULL,
	SubmissionDate DATE NULL,			
	CONSTRAINT PK_Money PRIMARY KEY (Id),
	CONSTRAINT FK_Money_Applicant FOREIGN KEY (ApplicantId) REFERENCES LoanTracking.LoanApplicant (Id),
)
GO

SET ANSI_PADDING OFF
GO

USE [People]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
CREATE TABLE LoanTracking.Expense (
	Id INT NOT NULL IDENTITY(1,1),
	ApplicantId INT NOT NULL ,		
	Amount MONEY NOT NULL,
	ExpenseType INT NOT NULL,
	Frequency INT NOT NULL,	
	CONSTRAINT PK_Expense PRIMARY KEY (Id),
	CONSTRAINT FK_Expense_Applicant FOREIGN KEY (ApplicantId) REFERENCES LoanTracking.LoanApplicant (Id),
)
GO
SET ANSI_PADDING OFF
GO

Use [master]
GO

IF EXISTS (SELECT * FROM sys.server_principals WHERE name = N'TestUser')
	DROP LOGIN TestUser
GO
	CREATE LOGIN TestUser WITH PASSWORD='password', CHECK_POLICY = OFF
GO


Use [People]  
GO


IF EXISTS (SELECT * FROM sys.database_principals WHERE name = N'TestUser')
	DROP USER TestUser
GO
	CREATE USER TestUser FOR LOGIN TestUser WITH DEFAULT_SCHEMA=[LoanTracking]
GO

EXEC sp_addrolemember N'db_datareader', N'TestUser'
EXEC sp_addrolemember N'db_datawriter', N'TestUser'


GO
INSERT INTO [LoanTracking].[LoanApplicant]([Title],[FirstName],[LastName],[Created],[LastModified])  VALUES('Mr','Bob','Smith',GETDATE(),GETDATE())
GO
INSERT INTO [LoanTracking].[LoanApplicant]([Title],[FirstName],[LastName],[Created],[LastModified])  VALUES('Mrs','Mary','Smith',GETDATE(),GETDATE())
GO
INSERT INTO [LoanTracking].[LoanApplicant]([Title],[FirstName],[LastName],[Created],[LastModified])  VALUES('Mr','Mick','Brown',GETDATE(),GETDATE())
GO
INSERT INTO [LoanTracking].[LoanApplicant]([Title],[FirstName],[LastName],[Created],[LastModified])  VALUES('Mrs','Alice','Smith',GETDATE(),GETDATE())
GO
INSERT INTO [LoanTracking].[Money]([ApplicantId],[Amount],[IsPrimaryLoan],[IsLoDocLoan],[IsFirstHomeBuyer],[IsSelfEmployed],[ProductName],[ApprovalNumber],[Balance],[ApplicationDate],[SubmissionDate])
     VALUES(1,100.00,1,0,1,1,'Sample Prod','AB121212',500000,GETDATE(),GETDATE())
GO
INSERT INTO [LoanTracking].[Money]([ApplicantId],[Amount],[IsPrimaryLoan],[IsLoDocLoan],[IsFirstHomeBuyer],[IsSelfEmployed],[ProductName],[ApprovalNumber],[Balance],[ApplicationDate],[SubmissionDate]) 
     VALUES (1,200.00,1,1,0,0,'Sample Prod2','AB22222',8000000,GETDATE(),GETDATE())








