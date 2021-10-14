USE [TestDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllDepartments]
AS
    SELECT Id, Name FROM deps
    order by name
GO