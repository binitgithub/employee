using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee.Models;
using Microsoft.EntityFrameworkCore;

namespace employee.Data
{
    public class EmpDbContext : DbContext
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> options) : base (options){}
        public DbSet<Employee> Employees { get; set; }
    }
}