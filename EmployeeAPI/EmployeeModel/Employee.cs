using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModel
{
    // Model class representing an Employee
    public class Employee
    {
        // Primary key for Employee
        [Key]
        public int EmpId { get; set; }

        // First name of the Employee
        public string Firstname { get; set; }

        // Last name of the Employee
        public string Lastname { get; set; }

        // Email address of the Employee
        public string Email { get; set; }

        // Mobile number of the Employee
        public string MobileNo { get; set; }
    }
}
