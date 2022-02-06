CREATE DATABASE Mc2Db_Query;
GO
USE [Mc2Db_Query]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [varchar](150) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[EmailAddress] [varchar](50) NOT NULL,
	[BankAccountNumber] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](15) NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[HasConfilict] [bit] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE DATABASE Mc2Db_Write;
GO
USE [Mc2Db_Write]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventStore](
	[Id] [uniqueidentifier] NOT NULL,
	[AggregateId] [nvarchar](255) NOT NULL,
	[AggregateTypeName] [nvarchar](255) NOT NULL,
	[Data] [nvarchar](max) NOT NULL,
	[Metadata] [nvarchar](max) NULL,
	[Version] [int] NOT NULL,
	[IsSynced] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_EventStore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO




