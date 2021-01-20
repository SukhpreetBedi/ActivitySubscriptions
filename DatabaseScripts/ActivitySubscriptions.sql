CREATE DATABASE ActivitySubscriptions
GO

USE [ActivitySubscriptions]  
GO   

SET ANSI_NULLS ON  
GO  
      
SET QUOTED_IDENTIFIER ON  
GO  
      
SET ANSI_PADDING ON  
GO  

CREATE TABLE [dbo].[Activities](
  [Id] [int] IDENTITY(1,1) PRIMARY KEY,
  [ActivityType] [varchar](50) NOT NULL
)
GO

INSERT INTO [dbo].[Activities](ActivityType)
VALUES ('Golf'),('Ping Pong'), ('Yoga Classes'), ('Paint Night'), ('Bingo')
GO

CREATE TABLE [dbo].[Subscribers](  
  [Id] [int] IDENTITY(1,1) NOT NULL,
  [FirstName] [varchar](50) NOT NULL,
  [LastName] [varchar](50) NOT NULL,  
  [EmailAddress] [varchar](50) NOT NULL,
  [ActivityId] [int] FOREIGN KEY REFERENCES [dbo].Activities(Id),
  [Comments] [varchar](300)  NULL
PRIMARY KEY CLUSTERED   
(  
  [Id] ASC  
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]     
GO  
      
SET ANSI_PADDING ON  
GO  
