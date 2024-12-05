using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee.Data;
using employee.Models;
using Microsoft.EntityFrameworkCore;

namespace employee.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmpDbContext empDbContext;

        public EmployeeRepository(EmpDbContext empDbContext)
        {
            this.empDbContext = empDbContext;
        }

        public async Task<Employee> CreateEmpAsync(Employee employee)
        {
            await empDbContext.Employees.AddAsync(employee);
            await empDbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteEmpAsync(int id)
        {
            var deleteEmp = await empDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (deleteEmp == null)
            {
                return null;
            }
            empDbContext.Employees.Remove(deleteEmp);
            await empDbContext.SaveChangesAsync();
            return deleteEmp;
        }

        public async Task<List<Employee>> GetAllEmpAsync()
        {
            return await empDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await empDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Employee> UpdateEmpAsync(int id, Employee employee)
        {
            var updateEmp = await empDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (updateEmp == null)
            {
                return null;
            }

            updateEmp.FirstName = employee.FirstName;
            updateEmp.LastName = employee.LastName;
            updateEmp.Email = employee.Email;
            updateEmp.PhoneNumber = employee.PhoneNumber;
            updateEmp.DateOfBirth = employee.DateOfBirth;
            updateEmp.DateOfJoining = employee.DateOfJoining;
            updateEmp.Department = employee.Department;
            updateEmp.Position = employee.Position;
            updateEmp.Salary = employee.Salary;
            updateEmp.IsActive = employee.IsActive;

            await empDbContext.SaveChangesAsync();
            return employee;
        }
    }
}