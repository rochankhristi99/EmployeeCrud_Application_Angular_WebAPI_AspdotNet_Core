using EmployeeModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TableReservation.api.DataAccess
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> EmployeeTable { get; set; }
        public DbSet<Employee_Bck> BackUp_EmployeeTable { get; set; }

    }
}
