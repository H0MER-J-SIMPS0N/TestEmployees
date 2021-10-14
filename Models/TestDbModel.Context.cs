﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestEmployees.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TestDb : DbContext
    {
        public TestDb()
            : base("name=TestDb")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<Department> GetAllDepartments()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Department>("GetAllDepartments");
        }
    
        public virtual ObjectResult<Employee> GetAllEmployees()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Employee>("GetAllEmployees");
        }
    
        public virtual ObjectResult<Position> GetAllPositions()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Position>("GetAllPositions");
        }
    
        public virtual ObjectResult<Status> GetAllStatuses()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Status>("GetAllStatuses");
        }
    
        public virtual ObjectResult<Employee> GetEmployeesByDepartmentId(Nullable<int> departmentId)
        {
            var departmentIdParameter = departmentId.HasValue ?
                new ObjectParameter("departmentId", departmentId) :
                new ObjectParameter("departmentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Employee>("GetEmployeesByDepartmentId", departmentIdParameter);
        }
    
        public virtual ObjectResult<Employee> GetEmployeesByPartOfLastName(string lastname)
        {
            var lastnameParameter = lastname != null ?
                new ObjectParameter("lastname", lastname) :
                new ObjectParameter("lastname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Employee>("GetEmployeesByPartOfLastName", lastnameParameter);
        }
    
        public virtual ObjectResult<Employee> GetEmployeesByPositionId(Nullable<int> positionId)
        {
            var positionIdParameter = positionId.HasValue ?
                new ObjectParameter("positionId", positionId) :
                new ObjectParameter("positionId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Employee>("GetEmployeesByPositionId", positionIdParameter);
        }
    
        public virtual ObjectResult<Employee> GetEmployeesByStatusId(Nullable<int> statusId)
        {
            var statusIdParameter = statusId.HasValue ?
                new ObjectParameter("statusId", statusId) :
                new ObjectParameter("statusId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Employee>("GetEmployeesByStatusId", statusIdParameter);
        }
    }
}
