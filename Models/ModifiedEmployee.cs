using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEmployees.Models
{
    class ModifiedEmployee
    {
        public string Fio { get; private set; }
        public string Status { get; private set; }
        public string Department { get; private set; }
        public string Position { get; private set; }
        public string DateEmploy { get; private set; }
        public string DateUnemploy { get; private set; }
        public ModifiedEmployee(Employee employee)
        {
            string fName = string.IsNullOrEmpty(employee.FirstName) ? string.Empty : $" {employee.FirstName.First()}.";
            string lName = string.IsNullOrEmpty(employee.SecondName) ? string.Empty : $" {employee.SecondName.First()}.";
            Fio = $"{employee.LastName}{fName}{lName}";
            Status = employee.Status;
            Department = employee.Department;
            Position = employee.Position;
            DateEmploy = employee.DateEmploy.ToString("yyyy-MM-dd");
            DateUnemploy = employee.DateUnemploy == new DateTime(1900, 01, 01) ? string.Empty : employee.DateUnemploy.ToString("yyyy-MM-dd");
        }
    }
}
