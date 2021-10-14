using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEmployees.Models
{
    class Repository
    {
        private IEnumerable<ModifiedEmployee> _employees;
        public IEnumerable<ModifiedEmployee> AllEmployees
        {
            get
            {
                using (var context = new TestDb())
                {
                    _employees = context.GetAllEmployees().Select(x => new ModifiedEmployee(x)).ToList();
                }
                return _employees;
            }
        }
        private IEnumerable<Status> _statuses;
        public IEnumerable<Status> Statuses
        {
            get
            {
                using (var context = new TestDb())
                {
                    _statuses = context.GetAllStatuses().ToArray();
                }
                return _statuses;
            }
        }
        private IEnumerable<Department> _departments;
        public IEnumerable<Department> Departments
        {
            get
            {
                using (var context = new TestDb())
                {
                    _departments = context.GetAllDepartments().ToArray();
                }
                return _departments;
            }
        }
        private IEnumerable<Position> _positions;
        public IEnumerable<Position> Positions
        {
            get
            {
                using (var context = new TestDb())
                {
                    _positions = context.GetAllPositions().ToArray();
                }
                return _positions;
            }
        }
        public IEnumerable<ModifiedEmployee> GetEmployeesByPartOfLastName(string partOfLastName)
        {
            using (var context = new TestDb())
            {
                _employees = context.GetEmployeesByPartOfLastName(partOfLastName).Select(x => new ModifiedEmployee(x)).ToList();
            }
            return _employees;
        }
        public IEnumerable<ModifiedEmployee> GetEmployeesBy(Type type, int id)
        {
            using (var context = new TestDb())
            {
                if (type == typeof(Department))
                {
                    _employees = context.GetEmployeesByDepartmentId(id).Select(x => new ModifiedEmployee(x)).ToList();
                }
                else if (type == typeof(Position))
                {
                    _employees = context.GetEmployeesByPositionId(id).Select(x => new ModifiedEmployee(x)).ToList();
                }
                else if (type == typeof(Status))
                {
                    _employees = context.GetEmployeesByStatusId(id).Select(x => new ModifiedEmployee(x)).ToList();
                }
                else
                {
                    return Array.Empty<ModifiedEmployee>();
                }
            }
            return _employees;
        }
    }
}
