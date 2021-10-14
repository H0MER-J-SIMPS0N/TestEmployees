USE [TestDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetEmployeesByDepartmentId]
    @departmentId int 
AS
    SELECT p.last_name as 'LastName'
		 , p.first_name as 'FirstName'
		 , p.second_name as 'SecondName'
		 , s.name as 'Status'
		 , d.name as 'Department'
		 , ps.name as 'Position' 
		 , p.date_employ as 'DateEmploy'
		 , ISNULL(p.date_uneploy, '19000101') as 'DateUnemploy'
		 from persons as p
	join status as s
	on p.status=s.id
	join deps as d
	on p.id_dep = d.id
	join posts as ps
	on p.id_post=ps.id
	where p.id_dep = @departmentId;
GO

