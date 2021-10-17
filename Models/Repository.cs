using NLog;
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
        private string _connectionString;
        private ILogger _logger;
        public Repository(string connectionString, ILogger logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }
        public bool IsConnection
        {
            get
            {
                try
                {
                    using (var context = new TestDb(_connectionString))
                    {
                        return context.Database.Exists();
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error($"Не удалось проверить подключение к базе по причине{Environment.NewLine}{ex}");
                    return false;
                }
            }
        }

        private IEnumerable<ModifiedEmployee> _employees;
        public IEnumerable<ModifiedEmployee> AllEmployees
        {
            get
            {
                try
                {
                    using (var context = new TestDb(_connectionString))
                    {
                        _employees = context.GetAllEmployees().Select(x => new ModifiedEmployee(x)).ToList();
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error($"Не удалось получить список всех сотрудников из базы по причине{Environment.NewLine}{ex}");
                    _employees = Array.Empty<ModifiedEmployee>();
                }                
                return _employees;
            }
        }
        private IEnumerable<Status> _statuses;
        public IEnumerable<Status> Statuses
        {
            get
            {
                try
                {
                    using (var context = new TestDb(_connectionString))
                    {
                        _statuses = context.GetAllStatuses().ToArray();
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error($"Не удалось получить список всех статусов из базы по причине{Environment.NewLine}{ex}");
                    _statuses = Array.Empty<Status>();
                }
                return _statuses;
            }
        }
        private IEnumerable<Department> _departments;
        public IEnumerable<Department> Departments
        {
            get
            {
                try
                {
                    using (var context = new TestDb(_connectionString))
                    {
                        _departments = context.GetAllDepartments().ToArray();
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error($"Не удалось получить список всех отделов из базы по причине{Environment.NewLine}{ex}");
                    _departments = Array.Empty<Department>();
                }
                return _departments;
            }
        }
        private IEnumerable<Position> _positions;
        public IEnumerable<Position> Positions
        {
            get
            {
                try
                {
                    using (var context = new TestDb(_connectionString))
                    {
                        _positions = context.GetAllPositions().ToArray();
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error($"Не удалось получить список всех должностей из базы по причине{Environment.NewLine}{ex}");
                    _positions = Array.Empty<Position>();
                }
                return _positions;
            }
        }
        public IEnumerable<ModifiedEmployee> GetEmployeesByPartOfLastName(string partOfLastName)
        {
            try
            {
                using (var context = new TestDb(_connectionString))
                {
                    _employees = context.GetEmployeesByPartOfLastName(partOfLastName).Select(x => new ModifiedEmployee(x)).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Не удалось получить список сотрудников по части фамилии из базы по причине{Environment.NewLine}{ex}");
                _employees = Array.Empty<ModifiedEmployee>();
            }
            return _employees;
        }
        public IEnumerable<ModifiedEmployee> GetEmployeesBy(Type type, int id)
        {
            using (var context = new TestDb(_connectionString))
            {
                if (type == typeof(Department))
                {
                    try
                    {
                        _employees = context.GetEmployeesByDepartmentId(id).Select(x => new ModifiedEmployee(x)).ToList();
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"Не удалось получить список сотрудников по id отдела из базы по причине{Environment.NewLine}{ex}");
                        _employees = Array.Empty<ModifiedEmployee>();
                    }
                }
                else if (type == typeof(Position))
                {
                    try
                    {
                        _employees = context.GetEmployeesByPositionId(id).Select(x => new ModifiedEmployee(x)).ToList();
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"Не удалось получить список сотрудников по id должности из базы по причине{Environment.NewLine}{ex}");
                        _employees = Array.Empty<ModifiedEmployee>();
                    }
                }
                else if (type == typeof(Status))
                {
                    try
                    {
                        _employees = context.GetEmployeesByStatusId(id).Select(x => new ModifiedEmployee(x)).ToList();
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"Не удалось получить список сотрудников по id статуса из базы по причине{Environment.NewLine}{ex}");
                        _employees = Array.Empty<ModifiedEmployee>();
                    }                    
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
