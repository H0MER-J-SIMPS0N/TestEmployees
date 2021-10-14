USE [TestDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllPositions]
AS
    SELECT Id, Name FROM posts
    order by name
GO

