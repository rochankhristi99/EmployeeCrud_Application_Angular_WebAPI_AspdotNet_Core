using EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.DataAccess.Repository
{
    // Interface defining methods for managing Employee data
    public interface IEmployee
    {
        // Method to retrieve all employees
        List<Employee> GetEmployees();

        // Method to add a new employee
        string AddEmp(Employee objEmp);

        // Method to retrieve an employee by ID
        Employee GetEmpById(int id);

        // Method to update employee details
        string UpdateEmp(Employee objEmp);

        // Method to delete an employee
        void DeleteEmp(int id);

        // Method to get all employee information
        List<Employee> GetAllEmpInfo();

        // Method to add an employee to backup table
        string AddEmp_Bck(Employee_Bck objBck_Emp);
    }
}
