using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.DataAccess.Repository;
using EmployeeModel;

namespace EmployeeAPI.Controllers
{
    // Controller for handling employee-related API requests
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly IEmployee _employee;

        // Constructor for EmployeeAPIController
        public EmployeeAPIController(IEmployee i_employee)
        {
            _employee = i_employee;
        }

        // Endpoint to get all employees
        [HttpGet]
        [Route("api/employee/index")]
        public List<Employee> Index()
        {
            try
            {
                return _employee.GetEmployees();
            }
            catch
            {
                throw;
            }
        }

        // Endpoint to add a new employee
        [HttpPost]
        [Route("api/employee/Create")]
        public void Create([FromBody] Employee employee_info)
        {
            try
            {
                if (ModelState.IsValid)
                    _employee.AddEmp(employee_info);
            }
            catch
            {
                // Error handling
            }
        }

        // Endpoint to get employee details by ID
        [HttpGet]
        [Route("api/employee/Details/{id}")]
        public Employee Details(int id)
        {
            return _employee.GetEmpById(id);
        }

        // Endpoint to update employee details
        [HttpPut]
        [Route("api/employee/Edit")]
        public void Edit([FromBody] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                    this._employee.UpdateEmp(employee);
            }
            catch
            {
                // Error handling
            }
        }

        // Endpoint to delete an employee
        [HttpPost]
        [Route("api/employee/delete")]
        public void Delete([FromBody] Employee_Bck employee_info)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employee.AddEmp_Bck(employee_info); // Add to backup table
                    _employee.DeleteEmp(employee_info.EmpId); // Delete from main table
                }
            }
            catch
            {
                // Error handling
            }
        }
    }
}
