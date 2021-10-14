USE [TestDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllStatuses]
AS
    select Id, Name from status
	order by name
GO

