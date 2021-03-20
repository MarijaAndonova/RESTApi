using aspdotnetCORETest.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspdotnetCORETest.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;  }
        public int Salary { get; set; }
        public DateTime DateofBirth { get; set; }

        public Worker(Employee employee)
        {
            var nameSplited = employee.employee_name.Split(' ');

            this.Id = employee.id;
            this.FirstName = nameSplited[0];
            this.LastName = nameSplited[1];
            this.Salary = employee.employee_salary;
            this.DateofBirth = DateTime.Now.AddYears(-employee.employee_age);
        }
    }

}
