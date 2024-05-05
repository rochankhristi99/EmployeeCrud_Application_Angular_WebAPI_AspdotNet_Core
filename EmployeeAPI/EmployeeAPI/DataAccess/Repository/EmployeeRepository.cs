using EmployeeAPI.DataAccess.Repository;
using EmployeeModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EmployeeAPI.DataAccess.Repository;

namespace TableReservation.api.DataAccess.Repository
{
    // Repository class for managing employee data
    public class EmployeeRepository : IEmployee
    {
        // Environment for hosting
        private readonly IWebHostEnvironment _hostEnvirionment;

        // Database context for employee data
        private readonly EmployeeDbContext _db;

        // Constructor for EmployeeRepository
        public EmployeeRepository(EmployeeDbContext db, IWebHostEnvironment hostEnvirionment)
        {
            _db = db;
            _hostEnvirionment = hostEnvirionment;
        }

        // Method to retrieve all employees
        public List<Employee> GetEmployees()
        {
            try
            {
                var empList = _db.EmployeeTable.ToList();
                return empList;
            }
            catch
            {
                throw;
            }
        }

        // Method to add a new employee
        public string AddEmp(Employee objEmp)
        {
            try
            {
                _db.EmployeeTable.Add(objEmp);
                _db.SaveChanges();
                return "Record Inserted";

            }
            catch (Exception ex)
            {
                return Convert.ToString(ex);
            }
        }

        // Method to retrieve an employee by ID
        public Employee GetEmpById(int id)
        {
            try
            {
                Employee emp = _db.EmployeeTable.FirstOrDefault(s => s.EmpId.Equals(id));
                return emp;
            }
            catch
            {
                throw;
            }
        }

        // Method to update employee details
        public string UpdateEmp(Employee objEmp)
        {
            try
            {
                _db.EmployeeTable.Update(objEmp);
                _db.SaveChanges();
                return "Record Updated";
            }
            catch
            {
                throw;
            }
        }

        // Method to delete an employee
        public void DeleteEmp(int id)
        {
            try
            {
                Employee emp = _db.EmployeeTable.Find(id);
                _db.EmployeeTable.Remove(emp);
                _db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        // Method to get all employee information
        public List<Employee> GetAllEmpInfo()
        {
            try
            {
                var empList = _db.EmployeeTable.ToList();
                return empList;
            }
            catch
            {
                throw;
            }
        }

        // Method to add an employee to backup table
        public string AddEmp_Bck(Employee_Bck objBck_Emp)
        {
            try
            {
                _db.BackUp_EmployeeTable.Add(objBck_Emp);
                _db.SaveChanges();
                return "Record Deleted";
            }
            catch (Exception ex)
            {
                return Convert.ToString(ex);
            }
        }
    }
}
